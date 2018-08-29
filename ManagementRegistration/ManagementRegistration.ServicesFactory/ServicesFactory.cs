using ManagementRegistration.Domain.Contracts.Repositories;
using ManagementRegistration.Domain.Contracts.Services;
using ManagementRegistration.Infrastructure.Repositories;
using ManagementRegistration.RepositoriesFactory;
using ManagementRegistration.Services;
using ManagementRegistration.ServicesFactory.Enums;

namespace ManagementRegistration.ServicesFactory
{
    public class ServicesFactory
    {
        public ServicesFactory(){}

        public static object GetServiceInstance(EnumServices option)
        {
            switch (option)
            {
                case EnumServices.Register:
                    return InstanceRegisterService();
                case EnumServices.Profession:
                    return InstanceProfessionService();
            }

            return null;
        }

        private static object InstanceRegisterService()
        {
            IRepository repository = RepositoryFactory.GetRepositoryInstance<RegisterRepository>();
            IRegisterService service = new RegisterService(repository);

            return service;
        }

        private static object InstanceProfessionService()
        {
            IRepository repository = RepositoryFactory.GetRepositoryInstance<ProfessionRepository>();
            IProfessionService service = new ProfessionService(repository);

            return service;
        }
    }
}