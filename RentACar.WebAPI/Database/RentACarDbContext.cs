using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Models;

namespace RentACar.WebAPI.Database
{
    public class RentACarDbContext : DbContext
    {
        public RentACarDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<PickupLocation> PickupLocation { get; set; }
        public DbSet<DropoffLocation> DropoffLocations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

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

            modelBuilder.Entity<DropoffLocation>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.Name).IsRequired().HasMaxLength(100);
                x.HasMany(x => x.Reservations).WithOne(i => i.DropoffLocation).IsRequired(false);
                x.HasData(new DropoffLocation { Id = 1, Name = "Palma Airpot" },
                    new DropoffLocation { Id = 2, Name = "Palma City Center" },
                    new DropoffLocation { Id = 3, Name = "Acludia" },
                    new DropoffLocation { Id = 4, Name = "Manacor" });
            });

            modelBuilder.Entity<PickupLocation>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.Name).IsRequired().HasMaxLength(100);
                x.HasMany(x => x.Reservations).WithOne(i => i.PickupLocation).IsRequired(false);
                x.HasData(new PickupLocation { Id = 1, Name = "Palma Airpot" },
               new PickupLocation { Id = 2, Name = "Palma City Center" },
               new PickupLocation { Id = 3, Name = "Acludia" },
               new PickupLocation { Id = 4, Name = "Manacor" });
            });

            modelBuilder.Entity<Reservation>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.StartDate).IsRequired();
                x.Property(x => x.EndDate).IsRequired();
                x.Property(x => x.TotalCost).IsRequired();
            });

            modelBuilder.Entity<Car>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).IsRequired();
                x.Property(x => x.Make).IsRequired().HasMaxLength(100);
                x.Property(x => x.Model).IsRequired().HasMaxLength(20);
                x.Property(x => x.DailyRate).IsRequired();
                x.Property(x => x.Kind).IsRequired().HasMaxLength(100);
                x.Property(x => x.IsAvailable).IsRequired();
                x.HasMany(x => x.Reservations).WithOne(i => i.Car).IsRequired(false);
                x.HasData(new Car { Id = 1, Make = "Tesla", Model = "Super", DailyRate = 402, Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 2, Make = "Tesla", Model = "Super X", DailyRate = 432, PlateNumber = "X412", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 3, Make = "Tesla", Model = "Super Y", DailyRate = 213, PlateNumber = "D212", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 4, Make = "Tesla", Model = "Huge", DailyRate = 531, PlateNumber = "DL212", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 5, Make = "Tesla", Model = "Huge", DailyRate = 402, PlateNumber = "D242", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 6, Make = "Tesla", Model = "Great", DailyRate = 421, PlateNumber = "DR212", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 7, Make = "Tesla", Model = "Super", DailyRate = 402, PlateNumber = "D211", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 8, Make = "Tesla", Model = "Super X", DailyRate = 421, PlateNumber = "D210", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 9, Make = "Tesla", Model = "Super Huge", DailyRate = 342, PlateNumber = "D212", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 10, Make = "Tesla", Model = "Super", DailyRate = 533, PlateNumber = "D212", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 11, Make = "Tesla", Model = "Super Huge", DailyRate = 533, PlateNumber = "DF212", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 12, Make = "Tesla", Model = "Great Huge", DailyRate = 531, PlateNumber = "DR212", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 13, Make = "Tesla", Model = "Super", DailyRate = 123, PlateNumber = "D2312", Kind = "Passenger", IsAvailable = true },
                    new Car { Id = 14, Make = "Tesla", Model = "Super", DailyRate = 402, PlateNumber = "D212", Kind = "Passenger", IsAvailable = true });
            });
        }
    }
}