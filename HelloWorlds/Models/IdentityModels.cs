using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using HelloWorlds.Models.Enums;
using HelloWorlds.Models.Locations;
using HelloWorlds.Models.Travels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HelloWorlds.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    { 
        public ApplicationDbContext()
            : base("HelloWorldsConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // base models
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<World> Worlds { get; set; }

        // relations
        public DbSet<FutureVisit> FutureVisits { get; set; }
        public DbSet<PastVisit> PastVisits { get; set; }

        // enums
        public DbSet<CityType> CityTypes { get; set; }
        public DbSet<CountryType> CountryTypes { get; set; }
        public DbSet<StateType> StateTypes { get; set; }
        public DbSet<WorldType> WorldTypes { get; set; }
    }
}