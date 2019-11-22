namespace CareerPathFinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        // [Required]
        // [ForeignKey(nameof(Category))]
        // public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}