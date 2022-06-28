using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {

        public int Id { get; set; }

        [Display(Name = "Are you want to Subscribe a News letter ?!")]
        public bool IsSubscribedToNewsLetter { get; set; }

        [StringLength(255)] //Maximum number of character
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "You have to Entered Your Name")]
        public string Name { get; set ; }



        [Display(Name = "Are you Male?!")]

        public bool IsMale { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Required(ErrorMessage = "You have to Entered Your MemberShipType")]
        [Display(Name = "Customer MemberShip")]
        public int?  MemberShipTypeID { get; set; }


        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }


    }
}