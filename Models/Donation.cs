using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class Donation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DonationID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        [ForeignKey("User")]

        public int UserID { get; set; }

    }
}
