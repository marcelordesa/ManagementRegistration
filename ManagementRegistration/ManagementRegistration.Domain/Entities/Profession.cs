using MongoDB.Bson;

namespace ManagementRegistration.Domain.Entities
{
    public class Profession
    {
        public ObjectId Id { get; set; }
        public int ProfessionId { get; set; }
        public string Description { get; set; }
    }
}