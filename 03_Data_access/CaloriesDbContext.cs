using _03_Data_access.Entities;
using _03_Data_access.Helpers;
using Microsoft.EntityFrameworkCore;
using System;

namespace _03_Data_access
{
    public class CaloriesDbContext : DbContext
    {
        public DbSet<Sex> Sex { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodDiary>  FoodDiary { get; set; }
        public DbSet<WaterDiary> WaterDiary { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-03NT1MK\SQLEXPRESS;
                                            Initial Catalog = Calories_Db;
                                            Integrated Security=True;
                                            Connect Timeout=30;
                                            Encrypt=False;
                                            Trust Server Certificate=False;
                                            Application Intent=ReadWrite;
                                            Multi Subnet Failover=False"
            );

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seeders
            modelBuilder.SeedSex();
            modelBuilder.SeedActivity();
            modelBuilder.SeedGoal();
            modelBuilder.SeedFood();
            modelBuilder.SeedAccount();
            //Fluent API configurations
            modelBuilder.Entity<Food>().HasIndex(f => f.Name).IsUnique();
            modelBuilder.Entity<Activity>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<Sex>().HasIndex(s => s.Name).IsUnique();
            //Relationship configurations
            modelBuilder.Entity<Accounts>().HasMany(a => a.FoodDiaries).WithOne(d => d.Account).HasForeignKey(d => d.AccountId);
            modelBuilder.Entity<Activity>().HasMany(a => a.Accounts).WithOne(a => a.Activity).HasForeignKey(a => a.ActivityId);
            modelBuilder.Entity<Sex>().HasMany(s => s.Accounts).WithOne(a => a.Sex).HasForeignKey(a => a.SexId);
            modelBuilder.Entity<Food>().HasMany(f => f.FoodDiaries).WithOne(d => d.Food).HasForeignKey(d => d.FoodId);
            modelBuilder.Entity<Accounts>().HasMany(a => a.WaterDiaries).WithOne(w => w.Account).HasForeignKey(w => w.AccountId);
            modelBuilder.Entity<Goal>().HasMany(g => g.Accounts).WithOne(a => a.Goal).HasForeignKey(a => a.GoalId);
        }
    }

}
