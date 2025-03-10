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
        public int TripPostingID { get; set; }

        [ForeignKey("UserID")]

        public int UserID { get; set; }
        public int SeatsBook { get; set; }
        public string BookingStatus { get; set; }


    }
}
