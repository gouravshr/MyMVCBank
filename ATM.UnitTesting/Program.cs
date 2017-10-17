using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Entity.Models;
using ATM.Data;
using System.Data.Entity;

namespace ATM.UnitTesting
{
    public delegate int Calculate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {

            //EntityFrameWorkExamples();
            //DelegateExamples();
            //AsyncCallExample().RunSynchronously();

            DymanicTypeExample(" Hello World ");
            DymanicTypeExample(Math.Asin(89.89d));
            DymanicTypeExample(DateTime.Now);
            Console.Read();
        }
        public static void DymanicTypeExample(dynamic val)
        {
            Console.WriteLine("Dynamic Result: " + val);
        }
        static async Task<int> LongRunningProcess() {

            await Task.Delay(1000);
            return 1;
        }

        public static async Task AsyncCallExample()
        {
            Task<int> lRun = LongRunningProcess();
            Console.WriteLine("Before sync Result");
            int result = await lRun;
            Console.WriteLine("After sync Result: " + result);


        }

        public static void DelegateExamples()
        {
            int x = Convert.ToInt32( Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());

            Calculate add =  Add;
            
            Calculate sub = Substrac;
            
            Calculate mul = Multiple;
            
            Calculate div = Divide;
         

            Calculate final = div + add + sub + mul;
            Console.WriteLine("Final Result", x, y, final(x,y));
            final -= add;
            Console.WriteLine("Final Result", x, y, final(x, y));

        }

        public static int Add(int x, int y)
    {
            int a = x + y;
            Console.WriteLine("Addition {0} + {1} = {2}",x,y,a);
            return a;
        }

    public static int Substrac(int x, int y)
    {
            int a = x - y;
            Console.WriteLine("Substract {0} - {1} = {2}", x, y, a);
            return a; }

    public static int Divide(int x, int y)
    {
            int a = x / y;
            Console.WriteLine("Divide {0} * {1} = {2}", x, y, a);
            return a; }

    public static int Multiple(int x, int y)
    {
            int a = x * y;
            Console.WriteLine("Multiple {0} * {1} = {2}", x, y, a);
            return a; }

    public static void EntityFrameWorkExamples()
        {
            MyBankDB ctx = new MyBankDB();
            var chkAccout = ctx.CheckingAccounts.Include(x => x.AccLedger).Select(x => x);
            //var chkAccout = ctx.CheckingAccounts.AsQueryable<CheckingAccount>().Select(x=> x);
            var accLedger = ctx.AccountLedgers.AsQueryable<AccountLedger>().Select(x => x);
            var chkAcc = from cA in ctx.CheckingAccounts
                         join aL in ctx.AccountLedgers
                         on cA.CheckingAccountId equals aL.CheckingAccountId into eGroup
                         select new
                         {
                             CheckingAccount = cA,
                             AccountLedger = eGroup

                         };
            var accountJoin = chkAccout.Join(ctx.AccountLedgers, bA => bA.CheckingAccountId, aL => aL.CheckingAccountId,
                (acc, ledger) =>
            new { FirstName = acc.FirstName, LastName = acc.LastName, balance = ledger.Deposit });

            var accounts = chkAccout.GroupJoin(ctx.AccountLedgers.AsQueryable(), bA => bA.CheckingAccountId, aL => aL.CheckingAccountId,
                (acc, ledger) =>
            new { FirstName = acc.FirstName, LastName = acc.LastName, balance = ledger.Select(x => x) });

            Console.WriteLine("Example 1 :- using Include");
            foreach (var acc in chkAccout)
            {
                Console.WriteLine("Name: {0} {1}, AccountNumber:{2}, Balance:-", acc.FirstName, acc.LastName, acc.AccountNumber);

                foreach (var al in acc.AccLedger)
                    Console.WriteLine("\t Transaction Date: {0}, Deposit: {1}, Withdraw:{2}", al.TransactionDT, al.Deposit, al.Withdraw);
                Console.WriteLine("------------------------------------------------------------------");
            }

            Console.WriteLine("Example 2 :- using OuterJoin (GroupJoin)");
            foreach (var acc in accounts)
            {
                Console.WriteLine("Name: {0} {1}, AccountNumber: {2}, Deposit: {3}, Withdraw: {4}", acc.FirstName, acc.LastName, acc.FirstName, acc.balance.Sum(x => x.Deposit), acc.balance.Sum(x => x.Withdraw));
                foreach (var al in acc.balance)
                    Console.WriteLine("\t Transaction Date: {0}, Deposit: {1}, Withdraw:{2}", al.TransactionDT, al.Deposit, al.Withdraw);
                Console.WriteLine("------------------------------------------------------------------");
            }

            Console.WriteLine("Example 3 :- using Group by");
            var acountSummary = from acc in ctx.CheckingAccounts
                                join ledger in ctx.AccountLedgers
                                on acc.CheckingAccountId equals ledger.CheckingAccountId
                                group new { acc.AccountNumber, acc.FirstName, acc.LastName, ledger.Deposit, ledger.Withdraw }
                                by new { acc.AccountNumber, acc.FirstName, acc.LastName } into grouped
                                select new
                                {
                                    depositTotal = grouped.Sum(a => a.Deposit),
                                    withdrawTotal = grouped.Sum(b => b.Withdraw),
                                    AccountNumber = grouped.Select(x => x.AccountNumber).FirstOrDefault(),
                                    FirstName = grouped.Select(x => x.FirstName).FirstOrDefault(),
                                    LastName = grouped.Select(x => x.LastName).FirstOrDefault()
                                };
            foreach (var acc in acountSummary)
            {
                Console.WriteLine("GroupBY Name: {0} {1}, AccountNumber: {2} \n Deposit: {3}, Withdraw: {4}, Balance: {5}", acc.FirstName, acc.LastName, acc.AccountNumber, acc.depositTotal, acc.withdrawTotal, (acc.depositTotal - acc.withdrawTotal));
                //foreach (var al in acc.AccountLedger)
                //  Console.WriteLine("\t Transaction Date: {0}, Deposit: {1}, Withdraw:{2}", al.TransactionDT, al.Deposit, al.Withdraw);
            }
        }
    }
}
