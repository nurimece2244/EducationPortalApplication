using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;
using InternProject.Persistence.Repositories;
using InternProject.Persistence.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace InternProject.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistanceLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped< IUserRepository, UserRepository>();
        serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        serviceCollection.AddScoped< IAuthenticationService, AuthenticationService>();
        serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        serviceCollection.AddScoped<IEducationCategory, EducationCategoryRepository>();
        serviceCollection.AddScoped<IEducationService, EducationRepository>();
        serviceCollection.AddScoped<ITrackingEducation, TrackingEducationRepository>();
        serviceCollection.AddScoped<IRoleService, RoleServiceRepository>();
       
    }
}