using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class Review
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ReviewID { get; set; }

        [ForeignKey("TripPostingID")]
        [Display(Name = "Trip Posting ID")] // Added display name
        public int TripPostingID { get; set; } // Navigation property to TripPosting - 3ADDED



        [Display(Name = "Rating")] // Added display name

        public int Rating { get; set; }

        [Required] //3added
        [StringLength(500, ErrorMessage = "Review description must be between 10 and 500 characters.", MinimumLength = 10)] //  3added
        [Display(Name = "Review Description")] // Added display name

        public required string ReviewDescription { get; set; }


        [Display(Name = "Review Date")] // Added display name
        [DataType(DataType.Date)] // makes sure only the date is stored/displayed instead of including the time. -3ADDED

        public DateTime ReviewDate { get; set; } = DateTime.Now;

    }
}
