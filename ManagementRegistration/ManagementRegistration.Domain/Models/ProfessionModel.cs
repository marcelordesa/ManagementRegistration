using MongoDB.Bson;

namespace ManagementRegistration.Domain.Models
{
    public class ProfessionModel : BaseModel
    {
        public ObjectId Id { get; set; }
        public int ProfessionId { get; set; }
        public string Description { get; set; }
    }
}