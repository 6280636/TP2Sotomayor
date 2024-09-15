using JuliePro.Models;
using Microsoft.EntityFrameworkCore;

namespace JuliePro.Data
{
    public static class ModelBuilderDataGenerator
    {
        public static void GenerateData(this ModelBuilder builder)
        {
            #region Données pour Speciality
            builder.Entity<Speciality>().HasData(new Speciality() { Id = 1, Name = "Perte de poids" });
            builder.Entity<Speciality>().HasData(new Speciality() { Id = 2, Name = "Course" });
            builder.Entity<Speciality>().HasData(new Speciality() { Id = 3, Name = "Halthérophilie" });
            builder.Entity<Speciality>().HasData(new Speciality() { Id = 4, Name = "Réhabilitation" });
            #endregion

            #region Données pour Trainer
            builder.Entity<Trainer>().HasData(new Trainer() { Id = 1, FirstName = "Chrystal", LastName = "Lapierre", Email = "Chrystal.lapierre@juliepro.ca", SpecialityId = 1, Photo = "Chrystal.png" });
            builder.Entity<Trainer>().HasData(new Trainer() { Id = 2, FirstName = "Félix", LastName = "Trudeau", Email = "Felix.trudeau@juliePro.ca", SpecialityId = 2, Photo = "Felix.png" });
            builder.Entity<Trainer>().HasData(new Trainer() { Id = 3, FirstName = "François", LastName = "Saint-John", Email = "Frank.StJohn@juliepro.ca", SpecialityId = 1, Photo = "Francois.png" });
            builder.Entity<Trainer>().HasData(new Trainer() { Id = 4, FirstName = "Jean-Claude", LastName = "Bastien", Email = "JC.Bastien@juliepro.ca", SpecialityId = 4, Photo = "JeanClaude.png" });
            builder.Entity<Trainer>().HasData(new Trainer() { Id = 5, FirstName = "Jin Lee", LastName = "Godette", Email = "JinLee.godette@juliepro.ca", SpecialityId = 3, Photo = "Jin Lee.png" });
            builder.Entity<Trainer>().HasData(new Trainer() { Id = 6, FirstName = "Karine", LastName = "Lachance", Email = "Karine.Lachance@juliepro.ca", SpecialityId = 2, Photo = "Karine.png" });
            builder.Entity<Trainer>().HasData(new Trainer() { Id = 7, FirstName = "Ramone", LastName = "Esteban", Email = "Ramone.Esteban@juliepro.ca", SpecialityId = 3, Photo = "Ramone.png" });
            #endregion

            #region Données pour Customer
            builder.Entity<Customer>().HasData(new Customer() { Id = 1, TrainerId = 1, FirstName = "Premier", LastName = "Perdant", Email = "lost@test.com", BirthDate = new DateTime(1984, 10, 04, 13, 12, 00) });
            builder.Entity<Customer>().HasData(new Customer() { Id = 2, TrainerId = 1, FirstName = "Super", LastName = "Champion", Email = "win@test.com", BirthDate = new DateTime(1980, 6, 3, 13, 12, 00) });
            builder.Entity<Customer>().HasData(new Customer() { Id = 3, TrainerId = 1, FirstName = "Master", LastName = "Zen", Email = "zen@test.com", BirthDate = new DateTime(1972, 3, 2, 13, 12, 00) });
            #endregion

            #region Données pour Objective
            builder.Entity<Objective>().HasData(new Objective() { Id = 1, CustomerId = 1, Name = "Course", DistanceKm = 8, AchievedDate = new DateTime(2022, 10, 04, 13, 12, 00) });
            builder.Entity<Objective>().HasData(new Objective() { Id = 2, CustomerId = 1, Name = "Perte de poids", LostWeightKg = 5 });

            builder.Entity<Objective>().HasData(new Objective() { Id = 3, CustomerId = 2, Name = "Course", DistanceKm = 8, AchievedDate = new DateTime(2022, 10, 04, 13, 12, 00) });
            builder.Entity<Objective>().HasData(new Objective() { Id = 4, CustomerId = 2, Name = "Course", DistanceKm = 5, AchievedDate = new DateTime(2022, 10, 04, 13, 12, 00) });

            builder.Entity<Objective>().HasData(new Objective() { Id = 5, CustomerId = 3, Name = "Perte de poids", LostWeightKg = 8 });
            builder.Entity<Objective>().HasData(new Objective() { Id = 6, CustomerId = 3, Name = "Perte de poids", LostWeightKg = 5 });
            #endregion
        }
    }
}
