using CGen.Core.Domain.DomainObjects;
using CGen.Core.Domain.Models;

namespace CGen.Core.Repository.Contracts
{
    public interface IUsersRepository
    {
        User AddUser(NewUserModel user);
        User ValidateUser(AuthenticationModel user);
    }
}