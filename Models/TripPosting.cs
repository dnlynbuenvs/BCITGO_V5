using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class TripPosting
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TripPostingID { get; set; }

        [ForeignKey("Driver")]

        public int DriverID { get; set; }

        [ForeignKey("Vehicle")]

        public int VehicleID { get; set; }
        public required string StartLocation { get; set; }
        public required string EndLocation { get; set; }
        public DateTime Date { get; set; }
        public int SeatAvailable { get; set; }
        public string Status { get; set; }






    }
}
