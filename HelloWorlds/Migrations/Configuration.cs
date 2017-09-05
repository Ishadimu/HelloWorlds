using HelloWorlds.Extensions;
using HelloWorlds.Models;
using HelloWorlds.Models.Enums;
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

            context.SaveChanges();
        }

        private void SeedEnums(ApplicationDbContext context)
        {
            context.CityTypes.SeedEnumValues<CityType, CityEnum>(@enum => @enum);
            context.StateTypes.SeedEnumValues<StateType, StateEnum>(@enum => @enum);
            context.CountryTypes.SeedEnumValues<CountryType, CountryEnum>(@enum => @enum);
            context.WorldTypes.SeedEnumValues<WorldType, WorldEnum>(@enum => @enum);
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
                    EmailConfirmed = true
                });
        }
    }
}
