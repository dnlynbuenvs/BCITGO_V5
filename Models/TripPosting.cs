using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BCITGO_FINAL.Models
{
    public class TripPosting
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TripPostingID { get; set; }



        [ForeignKey("DriverID")]
        [Display(Name = "Driver ID")] // Added Display Name
        public int DriverID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] // 🚀 Prevents cascade delete issues for Driver
        public required Driver Driver { get; set; } // Navigation property to Driver - 3ADDED


        [ForeignKey("VehicleID")]
        [Display(Name = "Vehicle ID")] // Added Display Name
        public int VehicleID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] // 🚀 Prevents cascade delete issues for Vehicle
        public required Vehicle Vehicle { get; set; } // Navigation property to Vehicle - 3ADDED


        [Required]
        [Display(Name = "Start Location")] // Added Display Name
        public required string StartLocation { get; set; }

        [Required]
        [Display(Name = "End Location")] // Added Display Name
        public required string EndLocation { get; set; }

        [Display(Name = "Trip Date")] // Added Display Name

        public DateTime Date { get; set; }

        [Display(Name = "Seats Available")] // Added Display Name

        public int SeatAvailable { get; set; }

        [Display(Name = "Status")] // Added Display Name

        public required string Status { get; set; }
        public ICollection<TripBooking> TripBookings { get; set; } = new List<TripBooking>(); // Navigation property for related bookings - 3ADDED







    }
}
