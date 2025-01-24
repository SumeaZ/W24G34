﻿using Eventify.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Eventify.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;



    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        
        public DbSet<RefreshToken> RefreshTokens { get; set; }
         public DbSet<Events> Events { get; set; } 
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Role> Roles { get; set; }
         public DbSet<Schedule> Schedules { get; set; }
       

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        List<IdentityRole> roles = new List<IdentityRole>()
            
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }

public class Schedule
{
}