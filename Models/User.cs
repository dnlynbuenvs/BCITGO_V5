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



    }
}
