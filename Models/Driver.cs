using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class Driver
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DriverID { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User ID")] // Added display name for UserID

        public int UserID { get; set; }

        [Display(Name = "Driving License")] // Added display name for DrivingLicense

        public string DrivingLicense { get; set; }

    }
}
