using CGen.Core.Repository.Context;

namespace CGen.Core.Repository.Repositories
{
    public class BaseRepository
    {
        protected CGenContext Context { get; set; }

        public BaseRepository(CGenContext context)
        {
            Context = context;
        }
    }
}