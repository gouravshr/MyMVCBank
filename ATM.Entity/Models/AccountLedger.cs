using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Entity.Models
{
    public class AccountLedger
    {
        [Required]
        public int AccountLedgerId { get; set; }
        public DateTime TransactionDT { get; set; }
        public Decimal Deposit { get; set; }
        public Decimal Withdraw { get; set; }

        public virtual CheckingAccount AccountNumber { get; set; }
    }
}
