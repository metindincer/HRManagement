using Core.Models;
using Core.Repositories_Abstract;
using Core.Services_Abstract;
using Data.Context;
using Data.Repositories_Concrete;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using Services.Services_Concrete;
using Services.Services_Concrete.EmailService;
using Services.Services_Concrete.TokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.EmailService;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(a =>
                {
                    a.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userMachine = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
                            var user = userMachine.GetUserAsync(context.HttpContext.User);
                            if (user == null) context.Fail("UnAuthorized");
                            return Task.CompletedTask;
                        }
                    };
                    a.RequireHttpsMetadata = false;
                    a.SaveToken = true;
                    a.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

            //Identity entegre
            services.AddDbContext<HRDbContext>(options =>
            options.UseSqlServer(Configuration.
            GetConnectionString("SqlServerConnectionString"),
            x => x.MigrationsAssembly("Data")));
            
            services.AddIdentity<User, Role>(a=> 
            {
                a.User.RequireUniqueEmail = true;
                a.SignIn.RequireConfirmedEmail = true;
                a.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
            }).AddEntityFrameworkStores<HRDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation");

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
               opt.TokenLifespan = TimeSpan.FromHours(2));

            services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromDays(3));

            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddTransient<TokenManagerMiddleware>();
            services.AddTransient<ITokenManager, TokenManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedRedisCache(r =>
            {
                r.Configuration = Configuration["redis:connectionString"];
            });

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
            services.AddScoped<IPermissionTypeService, PermissionTypeService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();


            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options => options.AddPolicy("myPolicy", builder =>
            {
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.WithOrigins("https://hr57.azurewebsites.net");
            }));
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = Configuration["CacheConnection"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
                    c.RoutePrefix = string.Empty;
                });
             
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
                });

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("myPolicy");
            app.UseRouting();
            

            //Identity entegre
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseMiddleware<TokenManagerMiddleware>();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
