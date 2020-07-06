using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BID_DLC.Models
{
    public class Shift
    {
        public int Shift_ID { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public DateTime ShiftName { get; set; }
    }
}