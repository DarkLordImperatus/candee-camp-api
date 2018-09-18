using System;
using System.Collections.Generic;
using CGen.Core.Domain.Common;

namespace CGen.Core.Domain.DomainObjects
{
    public class Invoice : GuidId
    {
        public Invoice()
        {
            Payments = new List<Payment>();
        }
        
        public string InvoiceNumber { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public virtual Client Client { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual IList<Payment> Payments { get; set; }
    }
}