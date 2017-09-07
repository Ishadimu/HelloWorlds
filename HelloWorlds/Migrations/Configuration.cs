using System;
using System.Collections.Generic;
using HelloWorlds.Extensions;
using HelloWorlds.Models;
using HelloWorlds.Models.Enums;
using HelloWorlds.Models.Locations;
using Microsoft.AspNet.Identity;

namespace HelloWorlds.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<HelloWorlds.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HelloWorlds.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            SeedUsers(context);
            SeedEnums(context);
            SeedLocations(context);

            context.SaveChanges();
        }

        private void SeedLocations(ApplicationDbContext context)
        {
            var earth = new World("Earth");
            var aiur = new World("Aiur");
            var worlds = new List<World> {earth, aiur};
            worlds.ForEach(w => context.Worlds.AddOrUpdate(u => u.Name, w));
            context.SaveChanges();

            var unitedStates = new Country("United States", earth);
            var japan = new Country("Japan", earth);
            var countries = new List<Country> {unitedStates, japan};
            countries.ForEach(c => context.Countries.AddOrUpdate(u => u.Name, c));
            context.SaveChanges();

            var georgia = new State("Georgia", unitedStates);
            var florida = new State("Florida", unitedStates);
            var states = new List<State> {georgia, florida};
            states.ForEach(s => context.States.AddOrUpdate(u => u.Name, s));
            context.SaveChanges();

            var atlanta = new City("Atlanta", georgia);
            var jacksonville = new City("Jacksonville", florida);
            var cities = new List<City> {atlanta, jacksonville};
            cities.ForEach(c => context.Cities.AddOrUpdate(u => u.Name, c));
            context.SaveChanges();
        }

        private void SeedEnums(ApplicationDbContext context)
        {
            foreach (var @enum in Enum.GetValues(typeof(WorldEnum)))
                context.WorldTypes.AddOrUpdate(u => u.Id,
                    new WorldType { Id = (int)@enum, Name = @enum.ToString() });

            foreach (var @enum in Enum.GetValues(typeof(CountryEnum)))
                context.CountryTypes.AddOrUpdate(u => u.Id,
                    new CountryType { Id = (int)@enum, Name = @enum.ToString() });

            foreach (var @enum in Enum.GetValues(typeof(StateEnum)))
                context.StateTypes.AddOrUpdate(u => u.Id,
                    new StateType { Id = (int)@enum, Name = @enum.ToString() });

            foreach (var @enum in Enum.GetValues(typeof(CityEnum)))
                context.CityTypes.AddOrUpdate(u => u.Id,
                    new CityType { Id = (int)@enum, Name = @enum.ToString() });

            context.SaveChanges();
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var passwordHash = new PasswordHasher();
            var password = passwordHash.HashPassword("Password123!");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "george.ishadimu@gmail.com",
                    Email = "george.ishadimu@gmail.com",
                    PasswordHash = password,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                });
        }
    }
}
