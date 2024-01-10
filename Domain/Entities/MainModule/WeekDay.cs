using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ReservationModule
{
    public class WeekDay
    {
        [Key]
        public int DayCode { get; set; }
        public string DayName { get; set; }
        public string DayLatName { get; set; }
    }
}
