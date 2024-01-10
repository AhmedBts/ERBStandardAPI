using Domain.Entities.Common;
using Domain.Entities.Enum;
using Domain.Entities.ReservationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.SecurityModule.Master
{
    public class User : AuditableEntity
    {
        public int Id { get; set; }
     
        public string UserName { get; set; } =  default!;

        public string Name { get; set; } = default!;
        public string? Mobile { get; set; } = default!;
        public string? Email { get; set; } = default!;
        public DateTime? BirthDay { get; set; } 

        public string? Mobile1 { get; set; }  = default!;
        public string? address { get; set; } = default!;
        public int? CountryCode { get; set; } = default!;
        public Boolean? NotActive { get; set; }
        public Genders? Gender { get; set; }
        [JsonIgnore]
        public byte[]? PasswordHash { get; set; } = default!;
        [JsonIgnore]
        public byte[]? PasswordSolt { get; set; } = default!;
        public int? GroupId { get; set; }
        public int? UserType { get; set; }
        public string? PhotoUserPath { get; set; } = default!;
        public Boolean? Approval { get; set; } = null;

        [JsonIgnore]
        public virtual Group? Groups { get; set; }
        [JsonIgnore]
        public virtual ICollection<VerificationCode>? VerificationCodes { get; set; } = default!;
       
    }
}
