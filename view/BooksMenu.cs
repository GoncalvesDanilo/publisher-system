using System;

public class BooksMenu : AbstractMenu
{
    public override void Create()
    {
        int option = 0;

        do
        {
            Console.WriteLine("\n");
            Console.WriteLine("..:: BOOKS MENU ::..");
            Console.WriteLine("21. Insert");
            Console.WriteLine("22. Update");
            Console.WriteLine("23. Delete");
            Console.WriteLine("24. Select");
            Console.WriteLine("29. Quit");
            Console.WriteLine("Type an option: ");
            option = Int32.Parse(Console.ReadLine());

            BookModel book = new BookModel();
            BookController bookController = new BookController();

            switch (option)
            {
                case 21:
                    Console.WriteLine("\nBook ID:");
                    book.id = (Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Book name:");
                    book.name = (Console.ReadLine());
                    Console.WriteLine("Book year:");
                    book.year = (Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Book ISBN:");
                    book.isbn = (Console.ReadLine());
                    Console.WriteLine("Book description:");
                    book.description = (Console.ReadLine());
                    Console.WriteLine("Publisher ID:");
                    book.publisherId = (Int32.Parse(Console.ReadLine()));

                    bookController.Insert(book);

                    break;

                case 22:
                    Console.WriteLine("\nBook ID:");
                    book.id = (Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Book name:");
                    book.name = (Console.ReadLine());
                    Console.WriteLine("Book year:");
                    book.year = (Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Book ISBN:");
                    book.isbn = (Console.ReadLine());
                    Console.WriteLine("Book description:");
                    book.description = (Console.ReadLine());
                    Console.WriteLine("Publisher ID:");
                    book.publisherId = (Int32.Parse(Console.ReadLine()));

                    if (bookController.Update(book)) {
                        Console.WriteLine("\nBook updated");
                    } else {
                        Console.WriteLine("\nBook not found!");
                    }

                    break;

                case 23:
                    Console.WriteLine("\nBook ID:");
                    if (bookController.Delete(Int32.Parse(Console.ReadLine()))) {
                        Console.WriteLine("\nBook deleted");
                    } else {
                        Console.WriteLine("\nBook not found!");
                    }

                    break;

                case 24:
                    Console.WriteLine("\nBook ID:");
                    book = bookController.Select(Int32.Parse(Console.ReadLine()));

                    if (book != null) {
                        Console.WriteLine("\nBook ID:");
                        Console.WriteLine(book.id);
                        Console.WriteLine("Book name:");
                        Console.WriteLine(book.name);
                        Console.WriteLine("Book year:");
                        Console.WriteLine(book.year);
                        Console.WriteLine("Book ISBN:");
                        Console.WriteLine(book.isbn);
                        Console.WriteLine("Book description:");
                        Console.WriteLine(book.description);
                        Console.WriteLine("Publisher ID:");
                        Console.WriteLine(book.publisherId);
                    } else {
                        Console.WriteLine("\nBook not found!");
                    }

                    break;

                case 29:
                    break;

                default:
                    Console.WriteLine("-> Invalid Option");
                    break;
            }

        } while (option != 29);
    }
}
