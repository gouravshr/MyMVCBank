using ATM.Data;
using ATM.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    public class BankAccountController : Controller
    {
        // GET: BankAccount
        public ActionResult Index()
        {
            MyBankDB ctx = new MyBankDB();
            var bankAccounts = ctx.CheckingAccounts.ToList();
            /*bankAccounts.Join(ctx.AccountLedgers, bA => bA.CheckingAccountId, aL => aL.CheckingAccountId, 
                (acc, ledger) => new {FirstName=acc.FirstName, LastName=acc.LastName, balance =ledger.Deposit);
    */        
    return View(bankAccounts);
        }

        // GET: BankAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BankAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccount/Create
        [HttpPost]
        public ActionResult Create(CheckingAccount acct )
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    MyBankDB ctx = new MyBankDB();
                    ctx.CheckingAccounts.Add(acct);
                    ctx.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BankAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BankAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BankAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BankAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
