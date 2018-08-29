using ManagementRegistration.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Linq;

namespace ManagementRegistration.Infrastructure
{
    public class ManagementRegistrationDbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase Database { get; }

        public ManagementRegistrationDbContext()
        {
            try
            {
                ConnectionString = "mongodb://localhost:27017";
                DatabaseName = "ManagementRegistration";
                IsSSL = true;

                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

                var mongoClient = new MongoClient(settings);
                Database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar ao banco de dados.", ex);
            }
        }

        public IMongoCollection<Register> Register
        {
            get { return Database.GetCollection<Register>("Register"); }
        }

        public IMongoCollection<Profession> Profession
        {
            get
            {
                return Database.GetCollection<Profession>("Profession");
            }
        }

        public void SeedingRegistration()
        {
            var professionsList = Profession.Find(c => c.Description != null).ToList();

            if (!professionsList.Any())
            {
                Profession profession1 = new Profession();
                profession1.ProfessionId = 1;
                profession1.Description = "Analista de Sistemas";
                Profession.InsertOneAsync(profession1);

                Profession profession2 = new Profession();
                profession2.ProfessionId = 2;
                profession2.Description = "Engenheiro Civil";
                Profession.InsertOneAsync(profession2);

                Profession profession3 = new Profession();
                profession3.ProfessionId = 3;
                profession3.Description = "Arquiteto de Software";
                Profession.InsertOneAsync(profession3);
            }
        }
    }
}