using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CGen.Core.Domain.Common;

namespace CGen.Core.Domain.DomainObjects
{
    public class Client : GuidId
    {
        public Client()
        {
            Invoices = new List<Invoice>();
            Payments = new List<Payment>();
        }
        
        [Required]
        public string UniqueCode { get; set; }
        [Required]
        public string ClientEmail { get; set; }
        
        public DateTimeOffset LastLoginDate { get; set; }

        public virtual IList<Invoice> Invoices { get; set; }
        public virtual IList<Payment> Payments { get; set; }
    }
}