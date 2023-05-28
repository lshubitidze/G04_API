using Fasade.Interfaces.JwtToken;
using Fasade.Interfaces.Repository;
using Fasade.Interfaces.Service;
using Fasade.Models;
using Mediator.Commands.UserCommands;
using Mediator.Handlers.UserHandlers;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Repository.Database;
using Repository;
using Service;
using System.Net.NetworkInformation;
using TBC_API.JwtToken;
using TBC_API.Mapper;

namespace TBC_API.Services
{
    public static class ServiceConfiguration
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            string? connectionstring = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build().GetConnectionString("Default");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add dbcontext
            builder.Services.AddDbContext<TBCDbContext>(option => option.UseSqlServer(connectionstring));
            // Add repositories
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<IRelatedPersonRepository, RelatedPersonRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            // Add services
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IRelatedPersonService, RelatedPersonService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
            builder.Services.AddScoped<ITokenParameters, TokenParameters>();
            // Add unitofwork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Add mediator
            builder.Services.AddTransient<IRequestHandler<InsertUserCommand, UserModel>, InsertUserHandler>();
            builder.Services.AddTransient<IRequestHandler<LoginUserCommand, string>, LoginUserHandler>();
            builder.Services.AddTransient<IRequestHandler<DeleteUserCommand>, DeleteUserHandler>();
            builder.Services.AddTransient<IRequestHandler<DeleteUserByIdCommand>, DeleteUserByIdHandler>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
            // Add automapper
            builder.Services.AddAutoMapper(typeof(MapperConfiguration).Assembly);
            // Add JWT Token
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters =  JwtConfiguration.SetOptions());
        }
    }
}
