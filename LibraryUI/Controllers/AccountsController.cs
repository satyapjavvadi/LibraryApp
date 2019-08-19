using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace LibraryUI.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        public string Username { get; set; }
        // GET: Accounts
        public IActionResult Index()
        {
            if (HttpContext != null && HttpContext.User != null)
                Username = HttpContext.User.Identity.Name;

            return View(Library.GetAccountsByEmailAddress(Username));
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Library.FindAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/CheckinBooks
        public IActionResult CheckinBooks(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Library.FindAccountByAccountNumber(id.Value);
            return View(account);
        }
        
        // POST: Accounts/CheckinBooks
        [HttpPost]
        public IActionResult CheckinBooks(IFormCollection data)
        {
            var accountNumber = Convert.ToInt32(data["AccountNumber"]);
            var bookCount = Convert.ToInt32(data["BookCount"]);
            Library.CheckinBooks(accountNumber, bookCount);
            return RedirectToAction(nameof(Index));

        }

        // GET: Accounts/CheckoutBooks
        public IActionResult CheckoutBooks(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Library.FindAccountByAccountNumber(id.Value);
            return View(account);
        }

        // POST: Accounts/CheckoutBooks
        [HttpPost]
        public IActionResult CheckoutBooks(IFormCollection data)
        {
            var accountNumber = Convert.ToInt32(data["AccountNumber"]);
            var bookCount = Convert.ToInt32(data["BookCount"]);
            Library.CheckoutBooks(accountNumber, bookCount);
            return RedirectToAction(nameof(Index));

        }

        // GET: Accounts/Activity
        public IActionResult Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var activities = Library.GetActivitiesByAccountNumber(id.Value);
            return View(activities);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountType,EmailId,")] Account account)
        {
            if (ModelState.IsValid)
            {
                Library.CreateAccount(account.EmailId, account.AccountType);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Library.FindAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountType,AccountNumber,EmailId")] Account account)
        {
            if (id != account.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Library.EditAccount(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Library.FindAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Library.DeleteAccount(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return (Library.FindAccountByAccountNumber(id) != null) ? true : false;
        }
    }
}
