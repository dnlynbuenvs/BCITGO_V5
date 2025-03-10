using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class Vehicle
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int VehicleID { get; set; }

        [ForeignKey("DriverID")]
        [Display(Name = "Driver ID")]  // Added Display Name

        public int DriverID { get; set; }

        [Display(Name = "License Plate")]  // Added Display Name

        public string LicensePlate { get; set; }

        [Display(Name = "Brand")]  // Added Display Name

        public string Brand { get; set; }

        [Display(Name = "Model")]  // Added Display Name

        public string Model { get; set; }

        [Display(Name = "Capacity")]  // Added Display Name

        public int Capacity { get; set; }

    }
}
