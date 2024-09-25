﻿using BStore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BStore.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string? UserID { get; set; }
        [Range(0,5)]
        public decimal Rating { get; set; }
        [StringLength(15, ErrorMessage = " Review cannot exceed 300 characters.")]
        public string? ReviewText { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;
        public Book Book { get; set; }
        public ApplicationUser User { get; set; }

    }
}
