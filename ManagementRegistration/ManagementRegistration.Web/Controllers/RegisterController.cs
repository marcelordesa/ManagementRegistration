using System.Threading.Tasks;
using ManagementRegistration.Domain.Contracts.Services;
using ManagementRegistration.Domain.Models;
using ManagementRegistration.ServicesFactory.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ManagementRegistration.Web.Controllers
{
    [Produces("application/json")]
    public class RegisterController : Controller
    {
        IRegisterService service = ServicesFactory.ServicesFactory.GetServiceInstance(EnumServices.Register) as IRegisterService;

        [Route("api/Register/GetAllRegister")]
        [HttpGet]
        public async Task<RegistersModel> GetAllRegister()
        {
            return await service.GetAllRegister();
        }

        [Route("api/Register/InsertRegister")]
        [HttpPost]
        public async Task<RegisterModel> InsertRegister([FromBody]RegisterModel register)
        {
            return await service.InsertRegister(register);
        }
    }
}