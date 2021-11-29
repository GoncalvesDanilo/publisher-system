using System;

public class MainMenu : AbstractMenu
{
    public override void Create()
    {
        int option = 0;

        do
        {
            Console.WriteLine("\n");
            Console.WriteLine("..:: PUBLISHERS MENU ::..");
            Console.WriteLine("1. Publishers");
            Console.WriteLine("2. Books");
            Console.WriteLine("3. Authors");
            Console.WriteLine("9. Quit");
            Console.WriteLine("Type an option: ");
            option = Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    PublishersMenu publishersMenu = new PublishersMenu();
                    publishersMenu.Create();
                    break;
                case 2:
                    BooksMenu booksMenu = new BooksMenu();
                    booksMenu.Create();
                    break;
                case 3:
                    AuthorsMenu authorsMenu = new AuthorsMenu();
                    authorsMenu.Create();
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("-> Invalid Option");
                    break;
            }

        } while (option != 9);
    }
}
