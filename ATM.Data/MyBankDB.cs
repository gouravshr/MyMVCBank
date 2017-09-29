namespace ATM.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entity.Models;
    public partial class MyBankDB : DbContext
    {
        public MyBankDB()
            : base("name=MyBankDB")
        {
            
        }

        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<AccountLedger> AccountLedgers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
