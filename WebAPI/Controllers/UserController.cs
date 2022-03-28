using AutoMapper;
using Core.Models;
using Core.Services_Abstract;
using Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.Services_Concrete.EmailService;
using Services.Services_Concrete.TokenService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Validators;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IEmailSender emailSender;
        private readonly ITokenManager tokenManager;

        public UserController(IUserService us, UserManager<User> um, SignInManager<User> sm, IMapper m, IConfiguration c, IEmailSender es, ITokenManager tm)
        {
            userManager = um;
            signInManager = sm;
            mapper = m;
            configuration = c;
            emailSender = es;
            userService = us;
            tokenManager = tm;
        }

        //Test için
        [HttpGet("getFruits")]
        [AllowAnonymous]
        public ActionResult GetFruits()
        {
            List<string> myList = new List<string>() { "apple", "banana" };
            return Ok(myList);
        }

        //Test için
        [HttpGet("getFruitsAuthenticated")]
        [Authorize(Roles = "director")]
        public async Task<ActionResult> GetFruitsAuthenticatedAsync()
        {

            var email = User.Claims.FirstOrDefault().Value;
            var role = User.Claims.ToList()[1].Value;
            User user = await userService.GetUserByEmail(email);
            var ID = user.Id;
            var userName = user.UserName;

            List<string> myList = new List<string>() { "user id: " + ID, "user name: " + userName, "email: " + email, "user role: " + role };
            return Ok(myList);
        }

        //try-catch eklenecek get token ve register için
        [AllowAnonymous]
        [HttpPost("getToken")]
        public async Task<ActionResult> GetToken([FromBody] UserLogInDTO userLogInDTO)
        {
            User user = await userService.GetUserByEmail(userLogInDTO.Email);
            if (user != null)
            {
                var userRole = await userManager.GetRolesAsync(user);
                var signInResult = await signInManager.CheckPasswordSignInAsync(user, userLogInDTO.Password, false);
                if (signInResult.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, userLogInDTO.Email),
                            new Claim(ClaimTypes.Role, userRole[0])
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])), SecurityAlgorithms.HmacSha256)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized("Wrong credentials or unconfirmed email!");
                }
            }
            return Unauthorized("Wrong credentials!");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] CreateUserDTO createUserDTO)
        {
            var user = mapper.Map<CreateUserDTO, User>(createUserDTO);

            var createResult = await userManager.CreateAsync(user, createUserDTO.Password);
            if (createResult.Succeeded)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "User", new { token, email = user.Email }, Request.Scheme);

                var message = new Message(new string[] { user.Email }, "HRManagement confirmation email link", confirmationLink, null);
                await emailSender.SendEmailAsync(message);

                await userManager.AddToRoleAsync(user, "director");

                return Ok(new { Result = "Successfully registered. Please verify your email address." });
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in createResult.Errors)
                {
                    stringBuilder.Append(error.Description);
                }
                return BadRequest(new { Result = $"Register Fail: {stringBuilder.ToString()}" });
            }
        }

        [Authorize(Roles = "director")]
        [HttpPost("createPersonnel")]
        public async Task<ActionResult> CreatePersonnel([FromBody] CreateUserDTO createUserDTO)
        {
            var user = mapper.Map<CreateUserDTO, User>(createUserDTO);
            user.EmailConfirmed = true;

            var createResult = await userManager.CreateAsync(user, createUserDTO.Password);
            if (createResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "personnel");


                return Ok(new { Result = "Personel successfuly created." });
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in createResult.Errors)
                {
                    stringBuilder.Append(error.Description);
                }
                return BadRequest(new { Result = $"Creation Fail: {stringBuilder.ToString()}" });
            }
        }

        [HttpGet("confirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return NotFound("User not found");

            var result = await userManager.ConfirmEmailAsync(user, token);
            return Ok(result.Succeeded ? "Confirmation successful!" : "Error");
        }

        [HttpGet("successRegistration")]
        public IActionResult SuccessRegistration()
        {
            return Ok("Registration successful");
        }

        [HttpPut("updateUser/{id}")]
        
        public async Task<ActionResult<UpdateUserDTO>> UpdateUser(string id, [FromBody] UpdateUserDTO saveUptadeUserResource)
        {
            var validator = new UpdateUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUptadeUserResource);
            var requestIsInvalid = id == null || !validationResult.IsValid;
            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);
            var updateToBeUser = await userService.GetUserById(id);
            if(updateToBeUser == null)
            {
                return NotFound();
            }
            var user = mapper.Map<UpdateUserDTO, User>(saveUptadeUserResource);
            await userService.UpdateUser(id, user);
            var updateUser = await userService.GetUserById(id);
            var updateUserPermissionResource = mapper.Map<User, UpdateUserDTO>(updateUser);
            return Ok(updateUserPermissionResource);
        }

        //Şirket Yöneticisi onay/ret
        [Authorize(Roles = "admin")]
        [HttpPut("directorActivation/{id}")]
        public async Task<ActionResult<UserActivationDTO>> DirectorActivation(string id,[FromBody] UserActivationDTO userActivationDTO)
        {
            
            var userToUpdate = await userService.GetUserById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            var user = mapper.Map<UserActivationDTO, User>(userActivationDTO);
            await userService.UpdateUser(id, user);
            var updateUser = await userService.GetUserById(id);
            
            if(userActivationDTO.IsActive==false)
            {
              var messageFalse = new Message(new string[] { updateUser.Email }, "HRManagement account deactivation info ","Your account is canceled.", null);
                await emailSender.SendEmailAsync(messageFalse);

            }
            else if(userActivationDTO.IsActive == true)
            {
               var messageTrue = new Message(new string[] { updateUser.Email }, "HRManagement account activation info", "Your account is confirmed.", null);
                await emailSender.SendEmailAsync(messageTrue);
            }
            
            return Ok(updateUser);
        }
        //Bütün üyeler
        [HttpGet("getUsers")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllMembers()
        {
            var users = await userService.GetAllAsync();
            var usersDTO = mapper.Map<IEnumerable<User>, IEnumerable<UpdateUserDTO>>(users);
            return Ok(usersDTO);
        }

        [HttpPost("tokens/cancel")]
        public async Task<IActionResult> CancelAccessToken()
        {
            await tokenManager.DeactivateCurrentAsync();

            return NoContent();
        }

    }
}
