using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Users.Infrastructure.Persistance;
using Users.Application.Contracts;
using Users.Infrastructure.Repositories;

namespace Users.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UsersContext>(o => o.UseSqlServer(configuration.GetConnectionString("UserConnectionString")));

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();

        return services;
    }
}