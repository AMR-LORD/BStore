﻿using System.ComponentModel.DataAnnotations;

namespace BStore.Models
{
    public class Country
    {
        public int ID { get; set; }
        [StringLength(30, ErrorMessage = " name cannot exceed 30 characters.")]
        public string? Name { get; set; }
        public ICollection<Governorate> Governorate { get; set; }
        public ICollection<Author> author { get; set; }
    }
}
