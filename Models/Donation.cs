using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class Donation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DonationID { get; set; }

        [Display(Name = "Donor Name")] // Added Display Name

        public string Name { get; set; }

        [Display(Name = "Donation Amount")] // Added Display Name

        public int Amount { get; set; }

        [Display(Name = "Donation Date")] // Added Display Name

        public DateTime DateTime { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        [Display(Name = "User ID")] // Added Display Name


        public int UserID { get; set; }

    }
}
