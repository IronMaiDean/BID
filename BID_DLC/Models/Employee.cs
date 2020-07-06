using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BID_DLC.Models
{
    public class Employee
    {

        public int Employee_ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string DisplayName
        {
            get
            {
                return FirstName + ' ' + Surname;
            }
        }

        public int TotalHoursApril { get; set; }
        public int TotalHoursMay { get; set; }

    }
}