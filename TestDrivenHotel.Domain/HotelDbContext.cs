﻿using Microsoft.EntityFrameworkCore;
using TestDrivenHotel.DAL.Models;

namespace TestDrivenHotel.DAL
{
    public class HotelDbContext : DbContext
    {
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between RoomModel and BookingModel
            modelBuilder.Entity<RoomModel>()
                .HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            // Populate Rooms
            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 1,
                Description = "Luxury Suite with Ocean View",
                Price = 500,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 2,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 3,
                Description = "Family Room with Garden View",
                Price = 350,
                MaxNumberOfGuests = 4,
                Seaview = false,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 4,
                Description = "Deluxe Room with Pool Access",
                Price = 400,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 5,
                Description = "Executive Suite with Panoramic View",
                Price = 600,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 6,
                Description = "Penthouse with Private Terrace",
                Price = 800,
                MaxNumberOfGuests = 4,
                Seaview = true,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 7,
                Description = "Economy Room with Courtyard View",
                Price = 150,
                MaxNumberOfGuests = 1,
                Seaview = false,
                Balcony = false
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 8,
                Description = "Business Suite with Workstation",
                Price = 450,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = false
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 9,
                Description = "Honeymoon Villa with Jacuzzi",
                Price = 700,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 10,
                Description = "Budget Room with Shared Bathroom",
                Price = 100,
                MaxNumberOfGuests = 1,
                Seaview = false,
                Balcony = false
            });

            // Populate Bookings
            modelBuilder.Entity<BookingModel>().HasData(new BookingModel
            {
                Id = 1,
                RoomId = 1,
                StartDate = new DateTime(2024, 2, 5),
                EndDate = new DateTime(2024, 2, 10),
                Created = DateTime.Now,
                Comment = "Honeymoon getaway"
            });

            modelBuilder.Entity<BookingModel>().HasData(new BookingModel
            {
                Id = 2,
                RoomId = 2,
                StartDate = new DateTime(2024, 3, 15),
                EndDate = new DateTime(2024, 3, 20),
                Created = DateTime.Now,
                Comment = "Business conference"
            });

            modelBuilder.Entity<BookingModel>().HasData(new BookingModel
            {
                Id = 3,
                RoomId = 3,
                StartDate = new DateTime(2024, 4, 10),
                EndDate = new DateTime(2024, 4, 15),
                Created = DateTime.Now,
                Comment = "Family vacation"
            });

            modelBuilder.Entity<BookingModel>().HasData(new BookingModel
            {
                Id = 4,
                RoomId = 4,
                StartDate = new DateTime(2024, 5, 20),
                EndDate = new DateTime(2024, 5, 25),
                Created = DateTime.Now,
                Comment = "Anniversary celebration"
            });
        }
    }
}

