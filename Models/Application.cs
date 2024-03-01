﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Group3_11.Models
{
    public class Application

    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int Task { get; set; }
        public int DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool Completed { get; set; }
        
    }
}