using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class Driver
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DriverID { get; set; }


        [Display(Name = "User ID")] // Added display name for UserID
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public required User User { get; set; } // Add this line to include the related User - 3ADDED

        public ICollection<TripPosting> TripPostings { get; set; } = new List<TripPosting>(); // ✅ Add this


        [Display(Name = "Driving License")] // Added display name for DrivingLicense
        [Required] //3added
        [StringLength(100, ErrorMessage = "License plate must be between 5 and 100 characters.", MinimumLength = 5)] //3added
        public required string DrivingLicense { get; set; }



    }
}
