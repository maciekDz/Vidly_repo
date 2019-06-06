﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int MovieId { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public int GenreId { get; set; }
        public GenreDto Genre { get; set; }

        [Required]
        [DataType(DataType.Date)] //format set globaly in Global.asax
        public DateTime RelaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)] //format set globaly in Global.asax
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Range(0, 20)]
        [Required]
        public int Availability { get; set; }
    }
}