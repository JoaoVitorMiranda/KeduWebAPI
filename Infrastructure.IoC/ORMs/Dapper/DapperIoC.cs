using Infrastructure.DBConfiguration.Dapper;
using Infrastructure.Interfaces.DBConfiguration;
using Infrastructure.Interfaces.Repositories.Standard;
using Infrastructure.Repositories.Standard.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC.ORMs.Dapper
{
    public class DapperIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfigurationSection dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration)
                                                                             .GetSection("ConnectionStrings");

            services.Configure<DataSettings>(dbConnectionSettings);
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            return services;
        }
    }
}
