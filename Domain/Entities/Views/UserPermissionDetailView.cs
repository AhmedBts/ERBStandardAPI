using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class UserPermissionDetailView
    {
        public int UserId { get; set; }

        public decimal ProgId { get; set; }
        public decimal ParentId { get; set; }


        public string ArabicName { get; set; }
        public string LatinName { get; set; }
        public int GroupCode { get; set; }
        public Nullable<bool> Insert { get; set; }
        public Nullable<bool> Edit { get; set; }
        public Nullable<bool> Read { get; set; }
        public Nullable<bool> Delete { get; set; }
        public Nullable<bool> Print { get; set; }
    }
}
