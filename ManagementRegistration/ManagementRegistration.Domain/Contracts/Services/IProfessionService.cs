using ManagementRegistration.Domain.Models;
using System.Threading.Tasks;

namespace ManagementRegistration.Domain.Contracts.Services
{
    public interface IProfessionService
    {
        Task<ProfessionsModel> GetAllProfession();
    }
}