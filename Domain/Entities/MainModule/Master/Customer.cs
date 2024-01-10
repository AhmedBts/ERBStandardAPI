using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.MainModule.Master
{
    public class Customer:AuditableEntity
    {
        public int CustCode { get; set; }
        public string CustName { get; set; }=string.Empty;
        public string CustLatName { get; set; } = string.Empty; 
        public string CountryCode { get; set; } = string.Empty;

        public string CustAddress { get; set; } = string.Empty;
        public string CustLatAddress { get; set; } = string.Empty;
        public int? BasicCurrencyCode { get; set; }
        public string Telephone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;
        public string ContactPersonEmail { get; set; } = string.Empty;
        public bool? NotActive { get; set; }
        public string TaxId { get; set; } = string.Empty;
        public string TaxType { get; set; } = string.Empty; 
        public string CountryISO { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
   
   
    }   
}
