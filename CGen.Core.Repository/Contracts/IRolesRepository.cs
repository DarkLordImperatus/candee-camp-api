using System;
using CGen.Core.Domain.DomainObjects;

namespace CGen.Core.Repository.Contracts
{
    public interface IRolesRepository
    {
        Role GetRole(Guid roleId);
    }
}