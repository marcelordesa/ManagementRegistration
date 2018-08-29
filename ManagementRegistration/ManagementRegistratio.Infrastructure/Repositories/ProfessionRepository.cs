using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementRegistration.Domain.Contracts.Repositories;
using ManagementRegistration.Domain.Entities;
using MongoDB.Driver;

namespace ManagementRegistration.Infrastructure.Repositories
{
    public class ProfessionRepository : IRepository
    {
        ManagementRegistrationDbContext Context;

        public ProfessionRepository()
        {
            Context = new ManagementRegistrationDbContext();
        }

        public async Task<IEnumerable<object>> GetAll()
        {
            return await Context.Profession.Find(c => c.Description != null).ToListAsync();
        }

        public async Task<object> Insert(object item)
        {
            Profession _profession = item as Profession;
            await Context.Profession.InsertOneAsync(_profession);
            var profession = Context.Profession.Find(c => c.Id == _profession.Id).FirstOrDefault();
            return profession;
        }
    }
}