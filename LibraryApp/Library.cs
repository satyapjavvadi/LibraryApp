using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    static class Library
    {
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

            return account;
        }
    }
}