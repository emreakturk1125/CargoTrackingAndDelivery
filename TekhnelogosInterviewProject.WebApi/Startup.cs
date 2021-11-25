using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Core.UnitOfWorks;
using TekhnelogosInterviewProject.Data;
using TekhnelogosInterviewProject.Data.Repositories;
using TekhnelogosInterviewProject.Data.UnitOfWorks;
using TekhnelogosInterviewProject.Service.Services;
using TekhnelogosInterviewProject.WebApi.Configuration;  
using TekhnelogosInterviewProject.Entity.DTOs;
using TekhnelogosInterviewProject.Service.Security.Token;

namespace TekhnelogosInterviewProject.WebApi
{
    // ÖNEMLİ migartion işlemi farklı bir class library de oalcağı için API projesine Microsoft.EntityFrameWork.Design kütüphanesi eklenmelidir
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

            //// Jwt Token ayarları - 1
            ///
            #region ilk yaptığım token ayarları
            //services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x =>
            //{
            //    var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:SecretKey"]);

            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ValidateLifetime = true,
            //        RequireExpirationTime = false
            //    };
            //}); 
            #endregion

            //// Jwt Token ayarları - 2
            ///
            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtbeareroptions =>
            {
                jwtbeareroptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey),
                    ClockSkew = TimeSpan.Zero
                };
            });
             
            //Tüm nesnelerin dönüşterme işlemi için gerekli (Dto)
            services.AddAutoMapper(typeof(Startup));
             
            // Db bağlantısı
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:SqlConnectionString"].ToString(), o => o.MigrationsAssembly("TekhnelogosInterviewProject.Data")));

            // Bir class'ın constructor ında IUnitOfWork ile karşılaşırsa, UnitOfWork den bir nesne örneği alacak ve request içinde birden fazla IUnitOfWork ile karşılaşırsa aynı nesneyi alacak
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPersonalService, PersonalService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITokenHandler, TekhnelogosInterviewProject.Service.Security.Token.TokenHandler>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;  // Api nin davranışını değiştirioyoruz, Filterları kontrol etme ben edeceğim demektir.
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TekhnelogosInterviewProject.WebApi", Version = "v1.1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                {
                   new OpenApiSecurityScheme{
                         Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              }
                         },
                        new List<string>()
                     }
                 });
            });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TekhnelogosInterviewProject.WebApi v1.1"));
            }

            // (Global hata yakalama)  
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });
              
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
