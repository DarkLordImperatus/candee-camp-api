using System;
using System.Linq;
using CGen.Core.Domain.DomainObjects;
using CGen.Core.Repository.Context;
using CGen.Core.Repository.Contracts;

namespace CGen.Core.Repository.Repositories
{
    public class RolesRepository : BaseRepository, IRolesRepository
    {
        public RolesRepository(CGenContext context) : base(context)
        {
        }

        public Role GetRole(Guid roleId)
        {
            var role = Context.Roles.FirstOrDefault(x => x.Id == roleId);

            return role;
        }
    }
}