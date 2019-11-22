namespace CareerPathFinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public string Name { get; set; }

        public Career Career { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}