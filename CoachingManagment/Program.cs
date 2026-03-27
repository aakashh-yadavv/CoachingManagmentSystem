
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MngBussinessLogicLayer.Mapper;
using MngBussinessLogicLayer.Repository.Implementation;
using MngBussinessLogicLayer.Repository.Interface;
using MngDataAccessLayer.Data;
using System.Text;

namespace CoachingManagment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))

                    };
                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(m =>
            {
                m.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                });
                m.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                }); 

            });
            builder.Services.AddDbContext<CoachingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CoachingDb"));
            });
            builder.Services.AddAutoMapper(typeof(ApplicationMapp));
            builder.Services.AddScoped<ICourse, CourseServiceClass>();
            builder.Services.AddScoped<ITeacher, TeacherServiceClass>();
            builder.Services.AddScoped<IStudents, StudentServcieClass>();
            builder.Services.AddScoped<IBatch, BatchServiceClass>();
            builder.Services.AddScoped<IFees, FeesServiceClass>();
            builder.Services.AddScoped<IAttendance, AttendanceServiceClass>();
            builder.Services.AddScoped<IAuth, AuthService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }   
            
    }
}