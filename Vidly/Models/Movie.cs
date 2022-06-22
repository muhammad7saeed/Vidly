using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to Entered Your Name")]
        [StringLength(255)] //Maximum number of character
        public string Name { get; set; }

        [Required(ErrorMessage = "You have to Entered Your Release Date")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Data Added")]
        public DateTime? DataAdded { get; set; }

        [Required(ErrorMessage = "You have to Entered Your Number in Stocks")]
        [Range(1,20,ErrorMessage = "The Field Number in Stock should be select from 1 to 20")]
        [Display(Name = "Number In Stocks")]
        public int NumberInStocks { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }


    }
}