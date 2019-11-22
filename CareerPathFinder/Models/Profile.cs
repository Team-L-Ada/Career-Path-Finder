namespace CareerPathFinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    public class Profile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public DateTime SubmittedAt { get; set; }

        public ICollection<Answer> Answers { get; set; }

        // [ForeignKey(nameof(User))]
        // public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}