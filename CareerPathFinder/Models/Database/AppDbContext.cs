namespace CareerPathFinder.Models.Database
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; protected set; }

        public virtual DbSet<Career> Careers { get; protected set; }

        public virtual DbSet<Category> Categories { get; protected set; }

        public virtual DbSet<Profile> Profiles { get; protected set; }

        public virtual DbSet<Question> Questions { get; protected set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("uuid-ossp")
                   .Entity<Answer>()
                   .Property(e => e.Id)
                   .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.HasPostgresExtension("uuid-ossp")
                   .Entity<Career>()
                   .Property(e => e.Id)
                   .HasDefaultValueSql("uuid_generate_v4()"); 

            modelBuilder.HasPostgresExtension("uuid-ossp")
                   .Entity<Category>()
                   .Property(e => e.Id)
                   .HasDefaultValueSql("uuid_generate_v4()"); 

            modelBuilder.HasPostgresExtension("uuid-ossp")
                   .Entity<Profile>()
                   .Property(e => e.Id)
                   .HasDefaultValueSql("uuid_generate_v4()"); 

            modelBuilder.HasPostgresExtension("uuid-ossp")
                   .Entity<Question>()
                   .Property(e => e.Id)
                   .HasDefaultValueSql("uuid_generate_v4()"); 
        }
    }
}