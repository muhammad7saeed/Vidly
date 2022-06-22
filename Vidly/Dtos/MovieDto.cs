using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)] //Maximum number of character
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DataAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStocks { get; set; }


         public GenreDto Genre { get; set; }



        [Required]
        public int GenreId { get; set; }
    }
}