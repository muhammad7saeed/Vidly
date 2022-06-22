using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [StringLength(255)] //Maximum number of character
        [Required(ErrorMessage = "You have to Entered Your Name")]
        public string Name { get; set; }

        public bool IsMale { get; set; }

        public int? MemberShipTypeID { get; set; }

        public MembershipTypeDto MemberShipType { get; set; }

       // [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

    }
}