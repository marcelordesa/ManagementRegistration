using ManagementRegistration.Domain.Contracts.Repositories;

namespace ManagementRegistration.RepositoriesFactory
{
    public class RepositoryFactory
    {
        public static IRepository GetRepositoryInstance<T>() where T : IRepository, new()
        {
            return new T();
        }
    }
}