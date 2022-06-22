using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  DurationInMonth { get; set; }
        public int Discount { get; set; }
        public int RentAmount { get; set; }

    }
}