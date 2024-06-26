using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Common.Interfaces.Services;
using Cine.Infrastructure.Authentication;
using Cine.Infrastructure.Persistence;
using Cine.Infrastructure.Persistence.Repositories;
using Cine.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Infraestructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<CineDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IPartnerRepository, PartnerRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IHallRepository, HallRepository>();
        services.AddScoped<IScheduleRepository, ScheduleRepository>();
        services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IChairRepository, ChairRepository>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();
        services.AddScoped<ITicketRepository, TicketsRepository>();
        services.AddScoped<IPointsPurchaseRepository, PointsPurchaseRepository>();
        services.AddScoped<IMonetaryPurchaseRepository, MonetaryPurchaseRepository>();
        return services;
    }
}