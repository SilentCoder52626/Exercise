using Exercise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise.ViewModel
{
    public class MoviesFormViewModel
    {
        public List<MoviesGenre> MoviesGenres { get; set; }

        public int? Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Released Date")]
        [Required]
        public DateTime? DateCreated { get; set; }
        

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public MoviesGenre MoviesGenre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte? MoviesGenreId { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        public MoviesFormViewModel()
        {
            Id = 0;
        }

        public MoviesFormViewModel(Movies movies)
        {
            Id = movies.Id;
            Name = movies.Name;
            DateCreated = movies.DateCreated;
            MoviesGenreId = movies.MoviesGenreId;
            NumberInStock = movies.NumberInStock;

        }
    }
}