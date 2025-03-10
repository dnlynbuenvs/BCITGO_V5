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
        public int UserID { get; set; }
        public string DrivingLicense { get; set; }

    }
}
