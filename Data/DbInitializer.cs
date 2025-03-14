﻿using BCITGO_FINAL.Models;

namespace BCITGO_FINAL.Data
{
    public class DbInitializer
    {

        public static void Initialize(ApplicationDbContext context)
        {
            // Ensure database is created - REMOVED
            //context.Database.EnsureCreated(); - REMOVED


            // Check if any data exists to avoid duplication
            if (context.User.Any() || context.Donation.Any() || context.Driver.Any() ||
                context.Vehicle.Any() || context.TripPosting.Any() || context.TripBooking.Any() ||
                context.Review.Any())
            {
                return; // Database has been seeded
            }

            // Seed Users
            var user1 = new User { Name = "Dannie", PhoneNumber = "10", Description = "any description", BCIT_Email = "dbuenviaje@my.bcit.ca" };
            context.User.Add(user1);
            context.SaveChanges(); // Save to get UserID

            // Seed Donations
            var donation1 = new Donation { Name = "Dannie", Amount = 10, UserID = user1.UserID };
            context.Donation.Add(donation1);
            context.SaveChanges();

            // Seed Driver
            var driver1 = new Driver { UserID = user1.UserID, User = user1, DrivingLicense = "1234" };
            context.Driver.Add(driver1);
            context.SaveChanges();

            // Seed Vehicle
            var vehicle1 = new Vehicle { DriverID = driver1.DriverID, Driver = driver1, LicensePlate = "V26B34", Brand = "Mitsubishi", Model = "2024", Capacity = 4 };
            context.Vehicle.Add(vehicle1);
            context.SaveChanges();

            // Seed Trip Postings
            var trip1 = new TripPosting { DriverID = driver1.DriverID, Driver = driver1, VehicleID = vehicle1.VehicleID, Vehicle = vehicle1, StartLocation = "Patterson", EndLocation = "Richmond", SeatAvailable = 5, Status = "available", Date = new DateTime(2025, 3, 10) };
            var trip2 = new TripPosting { DriverID = driver1.DriverID, Driver = driver1, VehicleID = vehicle1.VehicleID, Vehicle = vehicle1, StartLocation = "Metrotown", EndLocation = "Surrey", SeatAvailable = 3, Status = "available", Date = new DateTime(2025, 3, 10) };
            var trip3 = new TripPosting { DriverID = driver1.DriverID, Driver = driver1, VehicleID = vehicle1.VehicleID, Vehicle = vehicle1, StartLocation = "loc1", EndLocation = "loc2", SeatAvailable = 3, Status = "available", Date = new DateTime(2025, 3, 10) };
            context.TripPosting.Add(trip1);
            context.TripPosting.Add(trip2);
            context.TripPosting.Add(trip3);
            context.SaveChanges(); // Save to get TripPostingID
            Console.WriteLine($"trip1 ID: {trip1.TripPostingID}, trip2 ID: {trip2.TripPostingID}, trip3 ID: {trip3.TripPostingID}");

            // Seed Trip Booking
            var tripBooking1 = new TripBooking { TripPostingID = trip1.TripPostingID, TripPosting = trip1, UserID = user1.UserID, User = user1, SeatsBook = 2, BookingStatus = "available" };
            context.TripBooking.Add(tripBooking1);
            context.SaveChanges();

            // Seed Reviews
            var review1 = new Review { TripPostingID = trip1.TripPostingID, Rating = 5, ReviewDescription = "Great experience!" };
            var review2 = new Review { TripPostingID = trip2.TripPostingID, Rating = 4, ReviewDescription = "Very comfortable ride!" };
            var review3 = new Review { TripPostingID = trip3.TripPostingID, Rating = 4, ReviewDescription = "Test 3!" };

            Console.WriteLine("Adding reviews...");
            context.Review.AddRange(review1, review2, review3);
            context.SaveChanges();
            Console.WriteLine("Reviews added successfully.");

        }
    }
}
