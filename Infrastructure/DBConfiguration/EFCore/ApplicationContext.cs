using Infrastructure.Domain.Entities;
using Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DBConfiguration.EFCore
{
    public class ApplicationContext : DbContext
    {
        /* Creating DatabaseContext without Dependency Injection */
        public ApplicationContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                string connectionString = DatabaseConnection.ConnectionConfiguration.GetConnectionString("DefaultConnection");
                dbContextOptionsBuilder.UseNpgsql(connectionString);
            }
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
        }

        /* Creating DatabaseContext configured outside with Dependency Injection */
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        // Specify DbSet properties etc
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own configuration here
            modelBuilder.ApplyConfiguration(new PlanoPagamentoMapping());
            modelBuilder.ApplyConfiguration(new ResponsavelFinanceiroMapping());
            modelBuilder.ApplyConfiguration(new CentroDeCustoMapping());
            modelBuilder.ApplyConfiguration(new CobrancaMapping());
        }
        public DbSet<PlanoPagamento> PlanoPagamento { get; set; }
        public DbSet<CentroDeCusto> CentroDeCusto { get; set; }
        public DbSet<Cobranca> Cobranca { get; set; }
        public DbSet<ResponsavelFinanceiro> ResponsavelFinanceiro { get; set; }
    }
}
