using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp
{
    public static class Library
    {
        private static LibraryContext db = new LibraryContext();
        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="emailAddress">Email address of the user</param>
        /// <param name="accountType">Type of the account</param>
        /// <param name="checkedOutBookCount">Number of books checked out</param>
        /// <returns>The newly created account</returns>
        public static Account CreateAccount(string emailAddress, AccountType accountType = AccountType.Standard, int checkedOutBookCount = 0)
        {
            var account = new Account
            {
                EmailId = emailAddress,
                AccountType = accountType
            };

            if (checkedOutBookCount > 0)
            {
                account.CheckoutBooks(checkedOutBookCount);
            }

            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static IEnumerable<Activity> GetActivitiesByAccountNumber(int accountNumber)
        {
            return db.Activities.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.ActivityDate);
        }

        public static IEnumerable<Account> GetAccountsByEmailAddress(string emailAddress)
        {
            if(string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("emailAddress","Email Address is required");
            }
            return db.Accounts.Where(a => a.EmailId == emailAddress);
        }

        public static void CheckoutBooks(int accountNumber, int bookCount)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            account.CheckoutBooks(bookCount);

            var activity = new Activity
            {
                ActivityDate = DateTime.Now,
                Description = "Checkout Books",
                BookCount = bookCount,
                AccountNumber = accountNumber,
                ActivityType = ActivityType.Checkout
            };

            db.Activities.Add(activity);
            db.SaveChanges();
        }

        /// <summary>
        /// Check-in books from the Library
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <param name="bookCount">Number of books to be checked in</param>
        /// <exception cref="ArgumentException"/>
        public static void CheckinBooks(int accountNumber, int bookCount)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            account.CheckinBooks(bookCount);

            var activity = new Activity
            {
                ActivityDate = DateTime.Now,
                Description = "Checkin Books",
                BookCount = bookCount,
                AccountNumber = accountNumber,
                ActivityType = ActivityType.Checkin
            };

            db.Activities.Add(activity);
            db.SaveChanges();
        }

        public static Account FindAccountByAccountNumber(int accountNumber)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentException("Invalid account number");
                
            }
            return account;
        }

        public static void EditAccount(Account updatedAccount)
        {
            var oldAccount = FindAccountByAccountNumber(updatedAccount.AccountNumber);
            oldAccount.EmailId = updatedAccount.EmailId;
            oldAccount.AccountType = updatedAccount.AccountType;
            db.SaveChanges();
        }

        public static void DeleteAccount(int accountNumber)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            db.Accounts.Remove(account);
            db.SaveChanges();
        }
    }
}