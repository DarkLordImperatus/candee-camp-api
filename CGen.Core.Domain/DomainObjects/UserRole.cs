﻿using CGen.Core.Domain.Common;

namespace CGen.Core.Domain.DomainObjects
{
    public class UserRole : GuidId
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}