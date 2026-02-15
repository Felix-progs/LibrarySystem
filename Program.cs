using System;
using LibrarySystem.Services;
using System.Linq;



namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool running = true;

            while (running)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Welcome to the Library System!");
                Console.WriteLine("===============================");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. Search Books");
                Console.WriteLine("3. Sort Books by Title");
                Console.WriteLine("4. Show statistics");
                Console.WriteLine("5. Borrow book");
                Console.WriteLine("6. Return Book");
                Console.WriteLine("0. Exit Menu");

                switch (Console.ReadLine())
                {
                    case "1":

                        foreach (var book in library.GetAllBooks())
                        {
                            Console.WriteLine(book.GetInfo());
                        }
                        break;

                    case "2":
                        Console.WriteLine("Search: ");
                        foreach (var book in library.SearchBooks(Console.ReadLine()))
                        {
                            Console.WriteLine(book.GetInfo());
                        }
                        break;


                    case "3":
                        foreach (var book in library.SortByTitle())
                        {
                            Console.WriteLine(book.GetInfo());
                        }
                        break;

                    case "4":
                        Console.WriteLine($"Total books: {library.GetTotalBooks()}");
                        Console.WriteLine($"Borrowed: {library.GetBorrowedBooksCount()}");

                        var activeBorrower = library.GetMostActiveBorrower();
                        if (activeBorrower != null)
                        
                            Console.WriteLine($"Most Active Borrower: {activeBorrower.Name}");
                        else
                            Console.WriteLine("No active borrowers found.");


                        break;

                    case "5":
                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Enter Member ID: (M001-M004):");
                        string memberId = Console.ReadLine();

                        var loan = library.BorrowBook(isbn, memberId);
                        if (loan != null)
                        {
                            Console.WriteLine($"Success! Due date: {loan.DueDate:yyyy-MM-dd}");
                        }
                        else
                        {
                            Console.WriteLine("Failed! Book not available or not found");
                        }
                        break;
                    
                    case "6":
                        Console.Write("Enter ISBN to return your book: ");
                        string returnIsbn = Console.ReadLine();

                        var allLoans = library.GetAllLoans();
                        var loanToReturn = allLoans.FirstOrDefault(loan => loan.Book.ISBN == returnIsbn && !loan.IsReturned);

                        if (loanToReturn != null)
                        {
                            library.ReturnBook(loanToReturn);
                            Console.WriteLine("Book Returned!");
                        }
                        else 
                        {
                            Console.WriteLine("no active loan found for this book.");

                        }
                        break;

                    case "0":
                        running = false;

                        Console.WriteLine("Bye");

                        break;
                    }
            }
        }
    }
}


                    

            
    

