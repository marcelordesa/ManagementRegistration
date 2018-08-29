using System.Collections.Generic;

namespace ManagementRegistration.Domain.Models
{
    public class ProfessionsModel : BaseModel
    {
        public IEnumerable<ProfessionModel> Professions {get; set;}
    }
}