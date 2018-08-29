using System.Threading.Tasks;
using ManagementRegistration.Domain.Contracts.Services;
using ManagementRegistration.Domain.Models;
using ManagementRegistration.ServicesFactory.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ManagementRegistration.Web.Controllers
{
    [Produces("application/json")]
    public class ProfessionController : Controller
    {
        IProfessionService service = ServicesFactory.ServicesFactory.GetServiceInstance(EnumServices.Profession) as IProfessionService;

        [Route("api/Profession/GetAllProfession")]
        [HttpGet]
        public async Task<ProfessionsModel> GetAllProfession()
        {
            var professions = await service.GetAllProfession();
            return professions;
        }
    }
}