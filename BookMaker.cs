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
// By Zackary Paulson

using System;
using System.Collections.Generic;

namespace Bookstore
{
    /// <summary>
    /// Enum representing different book genres.
    /// </summary>
    public enum Genre
    {
        Action,
        Adventure,
        Fiction,
        Childrens_fiction,
        Classic_fiction,
        Contemporary_fiction,
        Fantasy,
        Graphic_novel,
        Historical_fiction,
        Horror,
        LGBTQplus,
        Literary_fiction,
        Mystery,
        New_adult_Romance,
        Satire,
        Science_fiction,
        Short_story,
        Thriller_Western,
        Womens_fiction,
        Young_adult,
        Art_and_photography,
        Autobiography,
        Memoir,
        Biography,
        Essays,
        Food_and_drink,
        History,
        How_To_Guides,
        Humanities_and_social_sciences,
        Humor,
        Parenting,
        Philosophy,
        Religion_and_spirituality,
        Science_and_technology,
        Self_help,
        Travel,
        True_crime
    }

    /// <summary>
    /// Represents a book in the inventory.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string? Author { get; set; }

        /// <summary>
        /// Gets or sets the genre of the book.
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// Gets the unique identifier of the book.
        /// </summary>
        public Guid BookId { get; private set; } = Guid.NewGuid();
    }

    /// <summary>
    /// Represents a service for managing the book inventory.
    /// </summary>
    public class BookManagerService
    {
        private List<Book> BookStore = new List<Book>();

        /// <summary>
        /// Adds books to the inventory.
        /// </summary>
        public void AddingBooks()
        {
            string answer = "Y"; // Initialize answer with a default value
            do
            {
                Book book = new Book(); //I'm instantiating a new instance of the class Book
                Console.WriteLine($"Please Enter The Title of The Book You Want to Create: ");
                book.Title = Console.ReadLine();
                Console.WriteLine($"Please Enter The Author That Wrote The Book: ");
                book.Author = Console.ReadLine();
                Console.WriteLine($"Please Enter The Genre Of The Book: ");
                if (Enum.TryParse(Console.ReadLine(), out Genre genre))
                {
                    book.Genre = genre;
                }
                else
                {
                    Console.WriteLine("Invalid genre input. Please try again.");
                    continue;
                }
                Console.WriteLine("Thank you for adding a book to our Collection!");
                BookStore.Add(book);
                Console.WriteLine($"Would you like to add another book to the Bookstore? (Y/N): ");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");
        }

        /// <summary>
        /// Displays all of the books in the inventory.
        /// </summary>
        public void DisplayAllBooks()
        {
            Console.WriteLine("Here are all of the books currently in inventory");
            foreach (var book in BookStore)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, ID: {book.BookId}");
            }
        }

        /// <summary>
        /// Displays a book by its ID.
        /// </summary>
        public void DisplayBookByID()
        {
            Console.WriteLine("Please enter the book's ID that you would like to display");
            if (Guid.TryParse(Console.ReadLine(), out Guid bookId))
            {
                var book = BookStore.Find(b => b.BookId == bookId);
                if (book != null)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, ID: {book.BookId}");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Book ID input.");
            }
        }

        /// <summary>
        /// Removes a book from the inventory by its ID.
        /// </summary>
        public void RemoveBookById()
        {
            Console.WriteLine("Please enter the Book ID to remove:");
            if (Guid.TryParse(Console.ReadLine(), out Guid bookId))
            {
                var bookToRemove = BookStore.Find(b => b.BookId == bookId);
                if (bookToRemove != null)
                {
                    BookStore.Remove(bookToRemove);
                    Console.WriteLine("Book removed successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Book ID input.");
            }
        }
    }
}
