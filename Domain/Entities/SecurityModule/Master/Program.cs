using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SecurityModule.Master
{
    public class Program
    {
        public decimal ProgId { get; set; }
        public decimal? ParentId { get; set; }
        public string ArabicName { get; set; } = default!;
        public string LatinName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string FormName { get; set; } = default!;
        public string Parameters { get; set; } = default!;
        public string Url { get; set; } = default!;
        public bool? HaveInsert { get; set; }
        public bool? HaveEdit { get; set; }
        public bool? HaveRead { get; set; }
        public bool? HaveDelete { get; set; }
        public bool? HavePrint { get; set; }
    }
}
