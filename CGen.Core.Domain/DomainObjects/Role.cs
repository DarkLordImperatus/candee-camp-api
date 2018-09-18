using System.Collections.Generic;
using CGen.Core.Domain.Common;

namespace CGen.Core.Domain.DomainObjects
{
    public class Role : GuidId
    {
        public Role()
        {
            UserRoles = new List<UserRole>();
        }

        public string Name { get; set; }
        public virtual IList<UserRole> UserRoles { get; set; }
    }
}