using _03_Data_access.Entities;
using Microsoft.EntityFrameworkCore;

namespace _03_Data_access.Helpers
{
    static public class DbInitializer
    {
        public static void SeedSex(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sex>().HasData(new Sex[]
            {
                new  Sex() {Id = 1,Name="Male"},
                new Sex() {Id = 2,Name="Female"}
            });
        }
        public static void SeedActivity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasData(new Activity[]
            {
                new  Activity() {Id = 1,Name="Sedentary",Coefficient=1.2},
                new Activity() {Id = 2,Name="Light",Coefficient=1.375},
                new Activity() {Id = 3,Name="Moderate",Coefficient=1.55},
                new Activity() {Id = 4,Name="High",Coefficient=1.725},
                new Activity() {Id = 5,Name="Very High",Coefficient= 1.9}
            });
        }
        public static void SeedGoal(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goal>().HasData(new Goal[]
            {
                new  Goal() {Id = 1,Name="Lose weight",Coefficient=0.85,Share_proteins=0.28,Share_fats=0.29,Share_carbs=0.43},
                new Goal() {Id = 2,Name="Maintain weight",Coefficient=1,Share_proteins=0.25,Share_fats=0.26,Share_carbs=0.49},
                new Goal() {Id = 3,Name="Increase weight",Coefficient=1.1,Share_proteins=0.25,Share_fats=0.28,Share_carbs=0.47}
            });
        }
        public static void SeedFood(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(new Food[]
            {
                new  Food() {Id = 1,Name="Cherry",Proteins=0.9,Fats=0,Carbs=11.1,Calories=46},
                new  Food() {Id = 2,Name="Kiwi",Proteins=1,Fats=0.7,Carbs=9.7,Calories=46},
                new  Food() {Id = 3,Name="Strawberry",Proteins=0.6,Fats= 0.4,Carbs=7,Calories=30},
                new  Food() {Id = 4,Name="Lemon",Proteins=0.9,Fats=0,Carbs=3.3,Calories=30},
                new  Food() {Id = 5,Name="Apple",Proteins=0.5,Fats=0,Carbs=11.4,Calories=48},
                new  Food() {Id = 6,Name="Bilberry",Proteins=1.2,Fats=0,Carbs=8.8,Calories=41},
                new  Food() {Id = 7,Name="Peach",Proteins=0.9,Fats=0,Carbs=10.1,Calories=42},
                new  Food() {Id = 8,Name="Raspberry",Proteins=0.7,Fats=0,Carbs=9.2,Calories=43},
                new  Food() {Id = 9,Name="Mango",Proteins=0.6,Fats=0.4,Carbs=11.8,Calories=69},
                new  Food() {Id = 10,Name="Pear",Proteins=0.5,Fats=0,Carbs=10.6,Calories=41}
            });
        }
        public static void SeedAccount(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>().HasData(new Accounts[]
            {
                new  Accounts() {Login = "Wukas",Password="QWERTY1234",Age=19,SexId=2,Height=165,Weight =60,ActivityId=2,GoalId=1}
            }) ;
        }
    }
}
