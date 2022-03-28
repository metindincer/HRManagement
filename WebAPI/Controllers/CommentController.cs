using AutoMapper;
using Core.Models;
using Core.Services_Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Validators;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CommentController : ControllerBase
    {
        private readonly ICommentSerivce commentService;
        private readonly IMapper mapper;
        public CommentController(ICommentSerivce _commentService,IMapper _mapper)
        {
            commentService = _commentService;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateComentDTO>>> GetAllComment()
        {
            var comments = await commentService.GetAllComments();
            var commentsDTO = mapper.Map<IEnumerable<Comment>, IEnumerable<CreateComentDTO>>(comments);
            return Ok(commentsDTO);
        }
        [HttpPost]
        [Authorize(Roles = "director")]
        public async Task<ActionResult<CreateComentDTO>> CreateComment([FromBody] CreateComentDTO saveCommentResource)
        {
            var validator = new CreateCommentResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCommentResource);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var commentToCreate = mapper.Map<CreateComentDTO, Comment>(saveCommentResource);
            var newComment = await commentService.CreateComment(commentToCreate);
            var comment = await commentService.GetCommentById(newComment.CommentId);
            var commentResource = mapper.Map<Comment, CreateComentDTO>(comment);
            return Ok(commentResource);
        }
        [HttpPut]
        [Authorize(Roles = "director")]
        public async Task<ActionResult<CreateComentDTO>> UpdateComment(int id, [FromBody] CreateComentDTO saveCommentResource)
        {
            var validator = new UpdateCommentResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCommentResource);
            var requestIsInvalid = id == 0 || !validationResult.IsValid;
            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);
            var commentToUpdate = await commentService.GetCommentById(id);
            if(commentToUpdate == null)
            {
                return NotFound();
            }
            var comment = mapper.Map<CreateComentDTO, Comment>(saveCommentResource);
            await commentService.UpdateComment(id, comment);
            var updateComment = await commentService.GetCommentById(id);
            var updateCommentResource = mapper.Map<Comment, CreateComentDTO>(updateComment);
            return Ok(updateCommentResource);
        }
        [HttpDelete("Delete")]
        [Authorize(Roles = "director")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var comment = await commentService.GetCommentById(id);
            if(comment == null)
            {
                return NotFound();
            }
            await commentService.DeleteComment(comment);
            return NoContent();
        }
    }
}
