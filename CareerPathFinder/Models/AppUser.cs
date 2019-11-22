namespace CareerPathFinder.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.Collections.Generic;

    public class AppUser : IdentityUser
    {
        public ICollection<Profile> Profiles { get; set; }
    }
}