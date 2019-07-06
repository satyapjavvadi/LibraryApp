using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp
{
    static class Library
    {
        // Creating a list of accounts
        private static List<Account> accounts = new List<Account>();
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

            accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account> GetAccountsByEmailAddress(string emailAddress)
        {
            return accounts.Where(a => a.EmailId == emailAddress);
        }

        public static void CheckoutBooks(int accountNumber, int bookCount)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            account.CheckoutBooks(bookCount);
        }

        public static void CheckinBooks(int accountNumber, int bookCount)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            account.CheckinBooks(bookCount);
        }

        private static Account FindAccountByAccountNumber(int accountNumber)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                // Throws an Exception
                return null;
            }
            return account;
        }
    }
}