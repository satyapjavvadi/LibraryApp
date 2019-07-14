using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    enum AccountType
    {
        //  For regular use
        Standard,
        // For children 
        Child,
        // For teachers
        Teacher,
        // For companies or non-profits
        Firm
    }
    class Account
    {
        #region Properties 

        /// <summary>
        /// Type of account
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// The account number
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// The email id for the account
        /// </summary>
        public string  EmailId { get; set; }

        /// <summary>
        /// The account created time
        /// </summary>
        public DateTime AccountCreated { get; set; }

        /// <summary>
        /// The number of books checked out on this account
        /// </summary>
        public int CheckedoutBooksCount { get; set; }

        #endregion

        #region Constructor

        public Account()
        {
            AccountCreated = DateTime.Now;
            CheckedoutBooksCount = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check out books into the account
        /// </summary>
        /// <param name="bookCount">Number of books to be checked out</param>
        /// <returns>Total checked out book count on the account</returns>
        public int CheckoutBooks(int bookCount)
        {
            CheckedoutBooksCount += bookCount;
            return CheckedoutBooksCount;            
        }

        /// <summary>
        /// Check in books from the account
        /// </summary>
        /// <param name="bookCount">The number of books to be checked in</param>
        /// <returns>Total checked out book count on the account</returns>
        public int CheckinBooks(int bookCount)
        {
            if(bookCount > CheckedoutBooksCount)
            {
                throw new ArgumentException("You don't have anymore books to return");
            }
            CheckedoutBooksCount -= bookCount;
            return CheckedoutBooksCount;
        }
        
        #endregion
    }
}