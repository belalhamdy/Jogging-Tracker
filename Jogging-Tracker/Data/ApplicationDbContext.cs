using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogging_Tracker.DTOs.JoggingRecord;
using Jogging_Tracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jogging_Tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedDatabase(builder);
        }

        public DbSet<JoggingRecord> JoggingRecords { get; set; }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var roles = GetRolesTable();
            var users = GetUsersTable();
            var usersRoles = users.Select((t, i) => new IdentityUserRole<string>()
                {RoleId = roles[Math.Min(i, roles.Count - 1)].Id, UserId = t.Id}).ToList();
            var joggingRecords = GetJoggingRecords();
            for (var i = 0; i < joggingRecords.Count; i++)
            {
                joggingRecords[i].UserId = users[i % 3 + 2].Id;
            }

            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<ApplicationUser>().HasData(users);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(usersRoles);
            modelBuilder.Entity<JoggingRecord>().HasData(joggingRecords);
        }

        private List<IdentityRole> GetRolesTable()
        {
            var roles = new List<string>()
            {
                Utilities.UserRoles.UserManager, Utilities.UserRoles.Admin, Utilities.UserRoles.User
            };
            return roles.Select(role => new IdentityRole()
                {Id = Guid.NewGuid().ToString(), Name = role, NormalizedName = role.ToUpper()}).ToList();
        }

        private List<ApplicationUser> GetUsersTable()
        {
            var usernames = new List<string>()
            {
                "manager", "admin", "user1", "user2", "user3"
            };
            var hasher = new PasswordHasher<ApplicationUser>();
            return usernames.Select(t => new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(), UserName = t, NormalizedUserName = t.ToUpper(),
                PasswordHash = hasher.HashPassword(null, "string")
            }).ToList();
        }

        private List<JoggingRecord> GetJoggingRecords()
        {
            //TODO
            return new List<JoggingRecord>()
            {
                new JoggingRecord()
                {
                    Date = DateTime.Now,DistanceInMeters = 10,DurationInSeconds = 10,RecordId = 1
                },
                new JoggingRecord()
                {
                    Date = DateTime.Now,DistanceInMeters = 20,DurationInSeconds = 20,RecordId = 2
                },
                new JoggingRecord()
                {
                    Date = DateTime.Now,DistanceInMeters = 30,DurationInSeconds = 30,RecordId = 3
                }
            };
        }
    }
}