using System.Collections.Generic;

namespace ManagementRegistration.Domain.Models
{
    public class RegistersModel : BaseModel
    {
        public IEnumerable<RegisterModel> Registers { get; set; }
    }
}