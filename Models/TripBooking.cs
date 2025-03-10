using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class TripBooking
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        [ForeignKey("TripPosting")]
        [Display(Name = "Trip Posting ID")] // Added Display Name
        public int TripPostingID { get; set; }

        [ForeignKey("UserID")]
        [Display(Name = "User ID")] // Added Display Name


        public int UserID { get; set; }

        [Display(Name = "Seats Booked")] // Added Display Name

        public int SeatsBook { get; set; }

        [Display(Name = "Booking Status")] // Added Display Name

        public string BookingStatus { get; set; }


    }
}
