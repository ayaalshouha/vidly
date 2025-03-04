﻿using System;
using System.ComponentModel.DataAnnotations;


namespace vidly.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
    }
}