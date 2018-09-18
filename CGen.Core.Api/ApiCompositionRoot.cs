using CGen.Core.Repository;
using LightInject;

namespace CGen.Core.Api
{
    public class ApiCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterFrom<CoreCompositionRoot>();
        }
    }
}