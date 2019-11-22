namespace CareerPathFinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public bool Value { get; set; }
        
        // [ForeignKey(nameof(Question))]
        // public Guid QuestionId { get; set; }
        
        public Question Question { get; set; }

        // [ForeignKey(nameof(Profile))]
        // public Guid ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}