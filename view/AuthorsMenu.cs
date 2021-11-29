using System;

public class AuthorsMenu : AbstractMenu
{
    public override void Create()
    {
        int option = 0;

        do
        {
            Console.WriteLine("\n");
            Console.WriteLine("..:: AUTHORS MENU ::..");
            Console.WriteLine("31. Insert");
            Console.WriteLine("32. Update");
            Console.WriteLine("33. Delete");
            Console.WriteLine("34. Select");
            Console.WriteLine("39. Quit");
            Console.WriteLine("Type an option: ");
            option = Int32.Parse(Console.ReadLine());

            AuthorModel author = new AuthorModel();
            AuthorController authorController = new AuthorController();

            switch (option)
            {
                case 31:
                    Console.WriteLine("\nAuthor ID:");
                    author.id = (Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Author name:");
                    author.name = (Console.ReadLine());
                    Console.WriteLine("Author pseudonym:");
                    author.pseudonym = (Console.ReadLine());
                    Console.WriteLine("Author description:");
                    author.description = (Console.ReadLine());

                    authorController.Insert(author);

                    break;

                case 32:

                    Console.WriteLine("\nAuthor ID:");
                    author.id = (Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Author name:");
                    author.name = (Console.ReadLine());
                    Console.WriteLine("Author pseudonym:");
                    author.pseudonym = (Console.ReadLine());
                    Console.WriteLine("Author description:");
                    author.description = (Console.ReadLine());

                    if (authorController.Update(author)) {
                        Console.WriteLine("\nAuthor updated");
                    } else {
                        Console.WriteLine("\nAuthor not found!");
                    }

                    break;

                case 33:
                    Console.WriteLine("\nAuthor ID:");
                    if (authorController.Delete(Int32.Parse(Console.ReadLine()))) {
                        Console.WriteLine("\nAuthor deleted");
                    } else {
                        Console.WriteLine("\nAuthor not found!");
                    }

                    break;

                case 34:
                    Console.WriteLine("\nAuthor ID:");
                    author = authorController.Select(Int32.Parse(Console.ReadLine()));

                    if (author != null) {
                        Console.WriteLine("\nAuthor ID:");
                        Console.WriteLine(author.id);
                        Console.WriteLine("Author name:");
                        Console.WriteLine(author.name);
                        Console.WriteLine("Author pseudonym:");
                        Console.WriteLine(author.pseudonym);
                        Console.WriteLine("Author description:");
                        Console.WriteLine(author.description);
                    } else {
                        Console.WriteLine("\nAuthor not found!");
                    }

                    break;

                case 39:
                    break;

                default:
                    Console.WriteLine("-> Invalid Option");
                    break;
            }

        } while (option != 39);
    }
}
