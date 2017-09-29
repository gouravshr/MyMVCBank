using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace ATM.Entity.Models
{
    public class CheckingAccount
    {
        [Required]
        public int CheckingAccountId { get; set; }

        [Required]
        [RegularExpression(@"/d{2, 50}", ErrorMessage = "First name should be at least 2 characters long!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"/d{2, 50}", ErrorMessage = "Last name should be at least 2 characters long!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactNumber { get; set; }

        [Required]
        [RegularExpression(@"/d{6, 10}", ErrorMessage ="Account number should be 6 to 10 charaters long!")]
        public string AccountNumber { get; set; }
        [Required]
        public string RountingNumber { get; set; }
    }
}
