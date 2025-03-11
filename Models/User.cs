using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCITGO_FINAL.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }


        [Display(Name = "Full Name")] // Added Display Name
        public string Name { get; set; }

        [Display(Name = "Phone Number")] // Added Display Name

        public string PhoneNumber { get; set; }

        [Display(Name = "Description")] // Added Display Name

        public string Description { get; set; }

        [Display(Name = "BCIT Email")] // Added Display Name

        public string BCIT_Email { get; set; }

        // Navigation property for related donations - ADDED new
        // ICollection<Donation> is just a fancy way of saying "a collection of donations."
        // new List<Donation>();, we make sure that when you create a new user, they automatically have an empty list to store all the donations they will have in the future. So, even if no donations are added yet, the user is ready to hold them.
        public ICollection<Donation> Donations { get; set; } = new List<Donation>(); // Initialize the property
                // ICollection<Donation> is just a fancy way of saying "a collection of donations."

        // Constructor to initialize properties to avoid non-nullable issues - ADDED BELOW
        public User()
        {
            Name = string.Empty; // It makes sure that when you create a user, their name is empty, not missing.
            PhoneNumber = string.Empty;
            Description = string.Empty;
            BCIT_Email = string.Empty;
        }
    }
}
