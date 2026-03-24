using Infrastructure.Domain.Entities.Interfaces.Standard;
using Infrastructure.Interfaces.Repositories.Standard;

namespace Infrastructure.Interfaces.Repositories.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
    }
}
