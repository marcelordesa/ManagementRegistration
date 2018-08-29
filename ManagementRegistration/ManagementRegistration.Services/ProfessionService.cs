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
    public class ProfessionService : IProfessionService
    {
        IRepository Repository;

        public ProfessionService(IRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<ProfessionsModel> GetAllProfession()
        {
            ProfessionsModel model = new ProfessionsModel();
            try
            {
                var professions = await this.Repository.GetAll() as IEnumerable<Profession>;
                model.Professions = professions.Select(p => new ProfessionModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    ProfessionId = p.ProfessionId
                });
            }
            catch(Exception ex)
            {
                model.Error = true;
                model.Message = $"Erro ao retornar lista de profissões:\n\n {ex.Message}";
            }

            return model;
        }
    }
}