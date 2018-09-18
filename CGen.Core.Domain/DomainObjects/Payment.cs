using System;
using System.ComponentModel.DataAnnotations;
using CGen.Core.Domain.Common;

namespace CGen.Core.Domain.DomainObjects
{
    public class Payment : GuidId
    {
        [Required]
        public decimal Amount { get; set; }

        public DateTimeOffset DatePaid { get; set; }

        public virtual Client Client { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}