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
        public int DriverID { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

    }
}
