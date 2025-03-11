using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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
        [Display(Name = "User ID")]
        public int UserID { get; set; }



        // Navigation property to the related User - ADDED
        // User? is a reference to the User class. It’s a link between this donation and a user. The ? means that the user can either be there (if the donation has a user) or be null (if no user is assigned to the donation yet).
        // get; set; allows getting or setting the value of this User property, which could be a specific user who made this donation.
        [Required]
        [DeleteBehavior(DeleteBehavior.Cascade)] // Ensures related Donations are deleted when a User is deleted
        public User? User { get; set; }


        // Constructor to initialize the properties to avoid non-nullable issues - ADDED
        public Donation()
        {
            Name = string.Empty; // Ensures that when a new donation is created, the Name (which represents the donor’s name) starts as an empty string (not null or missing).

        }
    }
}
