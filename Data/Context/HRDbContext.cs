using Core.Models;
using Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    //Identity entegre
    public class HRDbContext : IdentityDbContext<User, Role, string>
    {
        public HRDbContext(DbContextOptions<HRDbContext> dbContext) : base(dbContext) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Break> Breaks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Documentation> Documentations { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<BreakAndShift> BreakAndShifts { get; set; }
        public DbSet<MembershipApplication> MembershipApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.ApplyConfiguration(new BreakAndShiftConfiguration());
            modelBuilder.ApplyConfiguration(new BreakConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new DebitConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentationConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new MembershipApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<Role>().HasData(new Role { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = "2c5e174e-3b0e-446f-86af-483d56fd7211", Name = "personnel", NormalizedName = "PERSONNEL" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = "2c5e174e-3b0e-446f-86af-483d56fd7212", Name = "director", NormalizedName = "DIRECTOR" });
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<User>().HasData(
           new User
           {
               Id = "8atillae445865-a24d-4543-a6c6-944db9",
               Email = "atillamumcular@hotmail.com",
               NormalizedEmail = "ATILLAMUMCULAR@HOTMAIL.COM",
               UserName = "atilla",
               NormalizedUserName = "ATILLA",
               PasswordHash = hasher.HashPassword(null, "123.Admin"),
               EmailConfirmed = true,
               LockoutEnabled = false,         
               SecurityStamp = Guid.NewGuid().ToString()
           }
       );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
           new IdentityUserRole<string>
           {
               RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
               UserId = "8atillae445865-a24d-4543-a6c6-944db9"
           }
       );


        }
    }
}
