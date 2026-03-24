using Infrastructure.Domain.Entities.Interfaces.Standard;
using Infrastructure.Interfaces.Repositories.Domain.Standard;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Standard.EFCore
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                           IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        public string connectionString = "";

        protected DomainRepository(DbContext dbContext) : base(dbContext)
        {
            connectionString = dbContext.Database.GetDbConnection().ConnectionString;
        }
    }
}
