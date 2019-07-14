using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Library");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create a new library account");
                Console.WriteLine("2. Checkout books");
                Console.WriteLine("3. Checkin books");
                Console.WriteLine("4. Print all accounts");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the Library");
                        return;

                    case "1":
                        Console.Write("Email Address : ");
                        var emailAddress = Console.ReadLine();

                        Console.WriteLine("Account types : ");
                        var accountTypes = Enum.GetNames(typeof(AccountType));
                        for(var i = 0; i <accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}.{accountTypes[i]}");
                        }

                        Console.Write("Select an account type : ");
                        var accountType = Convert.ToInt32(Console.ReadLine());

                        var account = Library.CreateAccount(emailAddress, (AccountType)accountType);
                        Console.WriteLine("Created a new account");
                        Console.WriteLine($"Account number: {account.AccountNumber}, Account type: {account.AccountType}, Email : {account.EmailId}, Creted date : {account.AccountCreated}, Checkedout book count: {account.CheckedoutBooksCount}");
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account number : ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Number of books to be checked out : ");
                        var bookCount = Convert.ToInt32(Console.ReadLine());
                        Library.CheckoutBooks(accountNumber, bookCount);
                        Console.WriteLine($"Checked-out {bookCount} books successfully!");
                        break;
                    case "3":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Account number : ");
                            accountNumber = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Books to be checked in : ");
                            bookCount = Convert.ToInt32(Console.ReadLine());
                            Library.CheckinBooks(accountNumber, bookCount);
                            Console.WriteLine($"Checked-in {bookCount} books successfully!");
                        }
                        catch(ArgumentException ax)
                        {
                            Console.WriteLine(ax.Message);
                        }
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    default:
                        break;
                }
            }
             
        }

        private static void PrintAllAccounts()
        {
            Console.Write("EmailAddress : ");
            var emailAddress = Console.ReadLine();
            var accounts = Library.GetAccountsByEmailAddress(emailAddress);
            foreach (var acct in accounts)
            {
                Console.WriteLine($"Account number: {acct.AccountNumber}, Account type: {acct.AccountType}, Email : {acct.EmailId}, Created date : {acct.AccountCreated}, Checkedout book count: {acct.CheckedoutBooksCount}");
            }
        }
    }
}