using CGen.Core.Repository.Contracts;
using CGen.Core.Repository.Repositories;
using LightInject;

namespace CGen.Core.Repository
{
    public class CoreCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IUsersRepository, UsersRespository>();
        }
    }
}