using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Released Date")]
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1,20)]
        public int NumberInStock { get; set; }
        
        public MoviesGenre MoviesGenre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte MoviesGenreId { get; set; }
    }
}