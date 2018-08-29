using ManagementRegistration.Domain.Contracts.Repositories;
using ManagementRegistration.Domain.Contracts.Services;
using ManagementRegistration.Domain.Entities;
using ManagementRegistration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementRegistration.Services
{
    public class RegisterService : IRegisterService
    {
        IRepository Repository;

        public RegisterService(IRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<RegistersModel> GetAllRegister()
        {
            RegistersModel model = new RegistersModel();
            model.Registers = new List<RegisterModel>();

            try
            {
                var registers = await this.Repository.GetAll() as IEnumerable<Register>;

                if (registers.Any())
                    model.Registers = registers.Select(r => new RegisterModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Email = r.Email,
                        ProfessionId = r.ProfessionId,
                        ProfessionDescription = r.ProfessionDescription,
                        Unemployed = r.Unemployed,
                        DateBirth = r.DateBirth
                    });
            }
            catch (Exception ex)
            {
                model.Error = true;
                model.Message = $"Erro ao lista cadastros:\n\n {ex.Message}";
            }

            return model;
        }

        public async Task<RegisterModel> InsertRegister(RegisterModel register)
        {
            try
            {
                if (register.Error)
                    return register;

                var _register = new Register
                {
                    Name = register.Name,
                    Email = register.Email,
                    ProfessionId = register.ProfessionId,
                    ProfessionDescription = register.ProfessionDescription,
                    Unemployed = register.Unemployed,
                    DateBirth = register.DateBirth
                };

                var registerNew = await this.Repository.Insert(_register) as Register;

                return new RegisterModel
                {
                    Id = registerNew.Id,
                    Name = registerNew.Name,
                    Email = registerNew.Email,
                    ProfessionId = registerNew.ProfessionId,
                    ProfessionDescription = registerNew.ProfessionDescription,
                    Unemployed = registerNew.Unemployed,
                    DateBirth = registerNew.DateBirth
                };
            }
            catch (Exception ex)
            {
                return new RegisterModel
                {
                    Error = true,
                    Message = $"Erro ao inserir um cadastro:\n\n {ex.Message}"
                };
            }
        }
    }
}