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
        [Display(Name = "Driver ID")] // Added Display Name


        public int DriverID { get; set; }

        [ForeignKey("Vehicle")]
        [Display(Name = "Vehicle ID")] // Added Display Name


        public int VehicleID { get; set; }

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

        public string Status { get; set; }






    }
}
