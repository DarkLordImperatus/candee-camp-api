using System;
using System.Linq;
using CGen.Core.Domain.DomainObjects;
using CGen.Core.Domain.Models;
using CGen.Core.Repository.Common;
using CGen.Core.Repository.Context;
using CGen.Core.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CGen.Core.Repository.Repositories
{
    public class UsersRespository : BaseRepository, IUsersRepository
    {
        public UsersRespository(CGenContext context) : base(context)
        {
        }

        public User AddUser(NewUserModel user)
        {
            var salt = Helper.CreateUniqueString(64);
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.Password.Encrypt(salt),
                Salt = salt,
                DateCreated = DateTimeOffset.Now
            };

            Context.Users.Add(newUser);
            Context.SaveChanges();

            return newUser;
        }

        public User ValidateUser(AuthenticationModel user)
        {
            var dbUser = Context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .FirstOrDefault(x => x.Username == user.Username);

            if (dbUser == null) return null;

            var passwordHash = user.Password.Encrypt(dbUser.Salt);

            if (passwordHash != dbUser.PasswordHash) return null;
            
            dbUser.LastLoggedInDate = DateTimeOffset.Now;

            Context.SaveChanges();
                
            return dbUser;

        }
    }
}