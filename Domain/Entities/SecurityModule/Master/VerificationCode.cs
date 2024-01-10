using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.SecurityModule.Master
{
    public class VerificationCode
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public int UserId { get; set; }
        public bool IsUsed { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
