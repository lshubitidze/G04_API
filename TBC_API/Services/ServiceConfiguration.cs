using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using Mediator.Commands.PersonCommands;
using Mediator.Commands.RelatedPersonCommands;
using Mediator.Commands.UserCommands;
using Mediator.Handlers.CityHandlers;
using Mediator.Handlers.PersonHandlers;
using Mediator.Handlers.RelatedPersonHandlers;
using Mediator.Handlers.UserHandlers;
using Mediator.Queries.CityQueryes;
using Mediator.Queries.PersonQueryes;
using Mediator.Queries.RelatedPersonQueryes;
using Mediator.Queries.UserQueryes;
using Repository;
using Repository.Database;
using Service;
using TBC_API.JwtToken;
using TBC_API.Mapper;
using Fasade.Interfaces.JwtToken;
using Fasade.Interfaces.Repository;
using Fasade.Interfaces.Service;
using Fasade.Models;

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
            builder.Services.AddTransient<IRequestHandler<GetUserByIdQuery, UserModel>, GetUserByIdHandler>();

            builder.Services.AddTransient<IRequestHandler<InsertPersonCommand, PersonModel>, InsertPersonHandler>();
            builder.Services.AddTransient<IRequestHandler<UpdatePersonCommand>, UpdatePersonHandler>();
            builder.Services.AddTransient<IRequestHandler<DeletePersonCommand>, DeletePersonHandler>();
            builder.Services.AddTransient<IRequestHandler<DeletePersonByIdCommand>, DeletePersonByIdHandler>();
            builder.Services.AddTransient<IRequestHandler<GetPersonByIdQuery, PersonModel>, GetPersonByIdHandler>();

            builder.Services.AddTransient<IRequestHandler<InsertRelatedPersonCommand, RelatedPersonModel>, InsertRelatedPersonHandle>();
            builder.Services.AddTransient<IRequestHandler<UpdateRelatedPersonCommand>, UpdateRelatedPersonHandler>();
            builder.Services.AddTransient<IRequestHandler<DeleteRelatedPersonCommand>, DeleteRelatedPersonHandler>();
            builder.Services.AddTransient<IRequestHandler<DeleteRelatedPersonByIdCommand>, DeleteRelatedPersonByIdHandler>();
            builder.Services.AddTransient<IRequestHandler<GetRelatedPersonByIdQuery, RelatedPersonModel>, GetRelatedPersonByIdHandler>();

            //builder.Services.AddTransient<IRequestHandler<InsertCityCommand, CityModel>, InsertCityHandler>();
            //builder.Services.AddTransient<IRequestHandler<UpdateCityCommand>, UpdateCityHandler>();
            //builder.Services.AddTransient<IRequestHandler<DeleteCityCommand>, DeleteCityHandler>();
            //builder.Services.AddTransient<IRequestHandler<DeleteCityByIdCommand>, DeleteCityByIdHandler>();
            builder.Services.AddTransient<IRequestHandler<GetCityByIdQuery, CityModel>, GetCityByIdHandler>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
            // Add automapper
            builder.Services.AddAutoMapper(typeof(MapperConfiguration).Assembly);
            // Add JWT Token
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = JwtConfiguration.SetOptions());
        }
    }
}
