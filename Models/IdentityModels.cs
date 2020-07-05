using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Airport_IS.Models.Entities;
using Airport_IS.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airport_IS.Models
{
    
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
           
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
         
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }
        public DbSet<Baggage> Baggages { get; set; }
        public DbSet<TicketSale> TicketSales { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<AirportTax> AirportTaxes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}