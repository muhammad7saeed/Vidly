using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerMemberShipViewModel
    {

        public Customer Customer { get; set; }
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }




    }
}