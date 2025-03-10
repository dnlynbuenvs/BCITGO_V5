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
        public int TripPostingID { get; set; }
        public int Rating { get; set; }
        public string ReviewDescription { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;

    }
}
