using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Common
{
    public class GeneralSetup
    {
        [Key]
       public int Code { get; set; }
        public string Name { get; set; }
        public string MailHost { get; set; }
        public string MailApi { get; set; }
        public int? MailPort { get; set; }
        public string Email { get; set; }
        public string AppPassword { get; set; }

    }
}
