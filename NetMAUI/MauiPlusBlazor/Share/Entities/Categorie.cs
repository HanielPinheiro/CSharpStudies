﻿using System.ComponentModel.DataAnnotations;

namespace Share.Entities
{
    public class Categorie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [MaxLength(100, ErrorMessage = "The field {0} can't have more than {1} characters")]
        [Display(Name = "Categorie")]
        public string Name { get; set; } = null!;
    }
}
