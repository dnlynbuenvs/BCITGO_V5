using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BCITGO_FINAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

    }    

        public DbSet<Donation> Donation { get; set; }
        public DbSet<TripBooking> TripBooking { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TripPosting> TripPosting { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Donation>().ToTable("Donation");
            modelBuilder.Entity<TripBooking>().ToTable("TripBooking");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<TripPosting>().ToTable("TripPosting");
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
        }
    }
}


