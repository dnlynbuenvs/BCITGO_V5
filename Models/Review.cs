using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class Review
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ReviewID { get; set; }

        [ForeignKey("TripPosting")]
        [Display(Name = "Trip Posting ID")] // Added display name

        public int TripPostingID { get; set; }

        [Display(Name = "Rating")] // Added display name

        public int Rating { get; set; }

        [Display(Name = "Review Description")] // Added display name

        public string ReviewDescription { get; set; }

        [Display(Name = "Review Date")] // Added display name

        public DateTime ReviewDate { get; set; } = DateTime.Now;

    }
}
