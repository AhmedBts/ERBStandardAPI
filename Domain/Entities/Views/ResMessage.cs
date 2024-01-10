using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class ResMessage
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}
