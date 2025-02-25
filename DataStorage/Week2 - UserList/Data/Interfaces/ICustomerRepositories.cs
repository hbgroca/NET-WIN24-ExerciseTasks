using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface ICustomerRepositories
    {
        Task<CustomersEntity> CreateAsync(CustomersEntity entity);
        Task<bool> DeleteAsync(CustomersEntity entity);
        IEnumerable<CustomersEntity> GetAll();
        Task<IEnumerable<CustomersEntity>> GetAllAsync();
        Task<CustomersEntity> GetAsync(Expression<Func<CustomersEntity, bool>> expression);
        Task<CustomersEntity> UpdateAsync(CustomersEntity updatedEntity);
    }
}