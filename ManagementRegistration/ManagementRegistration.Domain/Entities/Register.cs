using MongoDB.Bson;
using System;

namespace ManagementRegistration.Domain.Entities
{
    public class Register
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int ProfessionId { get; set; }
        public string ProfessionDescription { get; set; }
        public DateTime DateBirth { get; set; }
        public bool Unemployed { get; set; }
    }
}