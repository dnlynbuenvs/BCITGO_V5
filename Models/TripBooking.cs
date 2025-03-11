using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class TripBooking
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        [ForeignKey("TripPostingID")]
        [Display(Name = "Trip Posting ID")] // Added Display Name
        public int TripPostingID { get; set; }
        public required TripPosting TripPosting { get; set; } // Navigation property to TripPosting - 3added


        [ForeignKey("UserID")] //modified from UserID - 3added
        [Display(Name = "User ID")] // Added Display Name

        public int UserID { get; set; }
        public required User User { get; set; } // Navigation property to User - 3ADDED


        [Display(Name = "Seats Booked")] // Added Display Name

        public int SeatsBook { get; set; }

        [Display(Name = "Booking Status")] // Added Display Name
        [Required] //3added
        public required string BookingStatus { get; set; }
        //public object? Name { get; internal set; }
    }
}
