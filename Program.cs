/* 
Week 3 Assignment
You have been asked to develop a simple command line program for a bookstore. The program should allow users to view and manage
their inventory of books. The program will present the user with the following options:

1. Add a new book to the inventory.
a. Enter the book’s title.
b. Enter the books author.
c. Enter the book’s genre
d. Enter the book’s ID, this can be anything you decide as long as it will be unique to the book.
e. Validate all of the above so that the user cannot enter incorrect data.
2. Display the list of all books in the inventory.
3. Display a book by looking up a book ID given by the user.
4. Remove a book from the inventory (by the book’s ID).
5. Exit the program.

The majority of this program should take place within a BookManagerService class. Program.cs should simply instantiate the
BookManagerService and start the process.
You must DOCUMENT ALL OF YOUR CLASSES AND METHODS PROPERLY USING XML DOCUMENTATION.

*/

/*

        Book book = new Book();
        Console.WriteLine($"Please Enter the Title of the book: ");
        string Title = console.ReadLine();
        Console.WriteLine($" Thank you! Now please enter the ");)
*/
//By Zackary Paulson
using System;
namespace Bookstore

///<summary>
///This calls the BookManagerService function from the BookMaker.cs file
/// </summary>
{
    class Program
    {
        static void Main()
        {
            BookManagerService bookManagerService = new BookManagerService();
            bookManagerService.AddingBooks();
        }
    }
}
