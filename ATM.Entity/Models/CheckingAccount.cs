using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM.Entity.Models
{
    public class CheckingAccount
    {
        [Required]
        public int CheckingAccountId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "First name should be at least 2 characters long!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last name should be at least 2 characters long!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }
      
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 6)]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"[0-9]{6,10}", ErrorMessage ="Account number should be 6 to 10 charaters long!")]
        public string AccountNumber { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 6)]
        [Column(TypeName = "varchar")]
        public string RountingNumber { get; set; }

        public virtual ICollection<AccountLedger> AccLedger { get; set; }

        public string userId { get; set; }
    }
}
