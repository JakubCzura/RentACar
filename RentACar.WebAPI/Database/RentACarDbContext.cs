using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RentACar.WebAPI.Database
{
    public class RentACarDbContext : DbContext
    {
        public RentACarDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<PickupLocation> PickupLocations { get; set; }
        public DbSet<DropoffLocation> DropoffLocations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.Name).IsRequired().HasMaxLength(100);
                x.Property(x => x.Surname).IsRequired().HasMaxLength(100);
                x.Property(x => x.Email).IsRequired().HasMaxLength(100);
                x.Property(x => x.Password).IsRequired();
                x.HasMany(x => x.Reservations).WithOne(i => i.User).IsRequired(false);
            });

            modelBuilder.Entity<City>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.Name).IsRequired().HasMaxLength(100);
                x.HasMany(x => x.Locations).WithOne(i => i.City);
            });

            modelBuilder.Entity<DropoffLocation>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.Name).IsRequired().HasMaxLength(100);
                x.Property(x => x.PostalCode).IsRequired().HasMaxLength(20);
                x.Property(x => x.ParkingSpaces).IsRequired().HasMaxLength(100000);
                x.Property(x => x.ParkedCars).IsRequired();
                x.HasMany(x => x.Reservations).WithOne(i => i.DropoffLocation).IsRequired(false);
            });

            modelBuilder.Entity<PickupLocation>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.Name).IsRequired().HasMaxLength(100);
                x.Property(x => x.PostalCode).IsRequired().HasMaxLength(20);
                x.Property(x => x.ParkingSpaces).IsRequired().HasMaxLength(100000);
                x.Property(x => x.ParkedCars).IsRequired();
                x.HasMany(x => x.Reservations).WithOne(i => i.PickupLocation).IsRequired(false);
            });

            modelBuilder.Entity<Reservation>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.StartDate).IsRequired();
                x.Property(x => x.EndDate).IsRequired();
                //x.Property(x => x.User).IsRequired();
                //x.Property(x => x.Car).IsRequired();
                //x.Property(x => x.PickupLocation).IsRequired();
                //x.Property(x => x.DropoffLocation).IsRequired();
                //x.Property(x => x.Payment).IsRequired();
                x.HasOne(x => x.Payment).WithOne(i => i.Reservation).HasForeignKey<Reservation>(x => x.PaymentId).IsRequired();
            });

            modelBuilder.Entity<Payment>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.Amount).IsRequired();
                x.Property(x => x.Date).IsRequired();
                //x.HasOne(x => x.Reservation).WithOne(i => i.Payment).IsRequired();
            });

            modelBuilder.Entity<Car>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.Make).IsRequired().HasMaxLength(100);
                x.Property(x => x.Model).IsRequired().HasMaxLength(20);
                x.Property(x => x.Description).IsRequired().HasMaxLength(100);
                x.Property(x => x.Color).IsRequired().HasMaxLength(20);
                x.Property(x => x.Capacity).IsRequired().HasMaxLength(100);
                x.Property(x => x.ManufactureYear).IsRequired();
                x.Property(x => x.DailyRate).IsRequired();
                x.Property(x => x.Kind).IsRequired().HasMaxLength(100);
                x.Property(x => x.IsAvailable).IsRequired();
                x.HasMany(x => x.Reservations).WithOne(i => i.Car).IsRequired(false);
            });
        }
    }
}
