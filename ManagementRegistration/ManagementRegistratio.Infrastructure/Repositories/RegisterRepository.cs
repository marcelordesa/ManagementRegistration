using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementRegistration.Domain.Contracts.Repositories;
using ManagementRegistration.Domain.Entities;
using MongoDB.Driver;

namespace ManagementRegistration.Infrastructure.Repositories
{
    public class RegisterRepository : IRepository
    {
        ManagementRegistrationDbContext Context;

        public RegisterRepository()
        {
            Context = new ManagementRegistrationDbContext();
        }

        public async Task<IEnumerable<object>> GetAll()
        {
            return await Context.Register.Find(c => c.Name != null).ToListAsync();
        }

        public async Task<object> Insert(object item)
        {
            Register _register = item as Register;
            await Context.Register.InsertOneAsync(_register);
            var register = Context.Register.Find(c => c.Id == _register.Id).FirstOrDefault();
            return register;
        }
    }
}