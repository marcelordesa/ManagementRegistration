using ManagementRegistration.Domain.Models;
using System.Threading.Tasks;

namespace ManagementRegistration.Domain.Contracts.Services
{
    public interface IRegisterService
    {
        Task<RegistersModel> GetAllRegister();
        Task<RegisterModel> InsertRegister(RegisterModel register);
    }
}