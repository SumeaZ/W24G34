using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Eventify.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;
using Eventify.Controllers;

public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Events> Events { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Explicitly define keys for Identity entities if necessary
        builder.Entity<IdentityUserLogin<string>>()
            .HasKey(login => new { login.LoginProvider, login.ProviderKey });

        builder.Entity<Role>().HasData(new Role
        {
            Id = Guid.NewGuid().ToString(),
            Name = "USER",
            NormalizedName = "USER"
            
        },
        new Role
         {
             Id = Guid.NewGuid().ToString(),
             Name = "ADMIN",
             NormalizedName = "USER"
     
         });





        builder.Entity<FeedBack>()
       .HasOne(fb => fb.Event)
       .WithMany(e => e.FeedBacks)
       .HasForeignKey(fb => fb.EventId)
       .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<Registration>()
        .HasOne<User>() 
        .WithMany() 
        .HasForeignKey(r => r.UserId)
        .HasPrincipalKey(u => u.Id);





    }



}









