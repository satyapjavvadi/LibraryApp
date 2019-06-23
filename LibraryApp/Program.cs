using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the account
            var account1 = new Account()
            {
                EmailId = "test1@gmail.com"
            };
           
            Console.WriteLine($"Account Number: {account1.AccountNumber}, Email: {account1.EmailId}, Created Date: {account1.AccountCreated}, Checkedout Books: {account1.CheckedoutBooksCount}");

            account1.CheckoutBooks(4);

            Console.WriteLine($"Account Number: {account1.AccountNumber}, Email: {account1.EmailId}, Created Date: {account1.AccountCreated}, Checkedout Books: {account1.CheckedoutBooksCount}");

            account1.CheckinBooks(2);

            Console.WriteLine($"Account Number: {account1.AccountNumber}, Email: {account1.EmailId}, Created Date: {account1.AccountCreated}, Checkedout Books: {account1.CheckedoutBooksCount}");

            // Create second instance of the account
            var account2 = new Account()
            {
                EmailId = "test2@gmail.com"
            };

            Console.WriteLine($"Account Number: {account2.AccountNumber}, Email: {account2.EmailId}, Created Date: {account2.AccountCreated}, Checkedout Books: {account2.CheckedoutBooksCount}");
        }
    }
}