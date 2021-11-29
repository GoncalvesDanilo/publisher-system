using System;

public class PublishersMenu : AbstractMenu
{
    public override void Create()
    {
        int option = 0;

        do
        {
            Console.WriteLine("\n");
            Console.WriteLine("..:: PUBLISHERS MENU ::..");
            Console.WriteLine("11. Insert");
            Console.WriteLine("12. Update");
            Console.WriteLine("13. Delete");
            Console.WriteLine("14. Select");
            Console.WriteLine("19. Quit");
            Console.WriteLine("Type an option: ");
            option = Int32.Parse(Console.ReadLine());

            PublisherModel publisher = new PublisherModel();
            PublisherController publisherController = new PublisherController();

            switch (option)
            {
                case 11:
                    Console.WriteLine("\nPublisher ID:");
                    publisher.id = (Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Publisher name:");
                    publisher.name = (Console.ReadLine());
                    Console.WriteLine("Publisher abbreviation:");
                    publisher.abbreviation = (Console.ReadLine());
                    Console.WriteLine("Publisher description:");
                    publisher.description = (Console.ReadLine());

                    publisherController.Insert(publisher);

                    break;

                case 12:
                    Console.WriteLine("\nPublisher ID:");
                    publisher.id = (Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Publisher name:");
                    publisher.name = (Console.ReadLine());
                    Console.WriteLine("Publisher abbreviation:");
                    publisher.abbreviation = (Console.ReadLine());
                    Console.WriteLine("Publisher description:");
                    publisher.description = (Console.ReadLine());

                    if (publisherController.Update(publisher)) {
                        Console.WriteLine("\nPublisher updated");
                    } else {
                        Console.WriteLine("\nPublisher not found!");
                    }

                    break;

                case 13:
                    Console.WriteLine("\nPublisher ID:");
                    if (publisherController.Delete(Int32.Parse(Console.ReadLine()))) {
                        Console.WriteLine("\nPublisher deleted");
                    } else {
                        Console.WriteLine("\nPublisher not found!");
                    }

                    break;

                case 14:
                    Console.WriteLine("\nPublisher ID:");
                    publisher = publisherController.Select(Int32.Parse(Console.ReadLine()));

                    if (publisher != null) {
                        Console.WriteLine("\nPublisher ID:");
                        Console.WriteLine(publisher.id);
                        Console.WriteLine("Publisher name:");
                        Console.WriteLine(publisher.name);
                        Console.WriteLine("Publisher abbreviation:");
                        Console.WriteLine(publisher.abbreviation);
                        Console.WriteLine("Publisher description:");
                        Console.WriteLine(publisher.description);
                    } else {
                        Console.WriteLine("\nPublisher not found!");
                    }

                    break;

                case 19:
                    break;

                default:
                    Console.WriteLine("-> Invalid Option");
                    break;
            }

        } while (option != 19);
    }
}
