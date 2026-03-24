using Infrastructure.DBConfiguration.EFCore;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Interfaces.Repositories.Standard;
using Infrastructure.Repositories.Domain.EFCore;
using Infrastructure.Repositories.Standard.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC.ORMs.EFCore
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string connectionString = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped<IPlanoPagamentoRepository, PlanoPagamentoRepository>();
            services.AddScoped<ICentroDeCustoRepository, CentroDeCustoRepository>();
            services.AddScoped<ICobrancaRepository, CobrancaRepository>();
            services.AddScoped<IResponsavelFinanceiroRepository, ResponsavelFinanceiroRepository>();

            return services;
        }
    }
}
