using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementRegistration.Domain.Contracts.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<object>> GetAll();
        Task<object> Insert(object item);
    }
}