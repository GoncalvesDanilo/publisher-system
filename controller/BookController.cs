using System;
using System.Collections.Generic;

using System.IO;
using System.Xml.Serialization;

public class BookController
{
    private List<BookModel> booksList = new List<BookModel>();

    public void Insert(BookModel book)
    {
        ReadDB();
        booksList.Add(book);
        SaveToDB();
    }

    public bool Update(BookModel book)
    {
        ReadDB();
        bool updated = false;

        foreach (var item in booksList)
        {
            if (item.id == book.id)
            {
                item.name = book.name;
                item.year = book.year;
                item.isbn = book.isbn;
                item.description = book.description;
                item.publisherId = book.publisherId;
                updated = true;
            }
        }

        SaveToDB();
        return updated;
    }

    public bool Delete(Int32 bookId)
    {
        ReadDB();
        int index = -1;

        foreach (var item in booksList)
        {
            if (item.id == bookId)
            {
                index = booksList.IndexOf(item);
            }
        }

        if (index != -1)
        {
            booksList.RemoveAt(index);
            SaveToDB();
            return true;
        }

        return false;
    }

    public BookModel Select(Int32 bookId)
    {
        ReadDB();
        BookModel book = null;

        foreach (var item in booksList)
        {
            if (item.id == bookId)
            {
                book = item;
            }
        }

        return book;
    }

    private void ReadDB()
    {
        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Books.xml")) == false)
        {
            SaveToDB();
        }

        XmlSerializer xml = new XmlSerializer(typeof(List<BookModel>));
        FileStream file = new FileStream("Books.xml", FileMode.Open);
        booksList = (List<BookModel>)xml.Deserialize(file);
        file.Close();
    }

    private void SaveToDB()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<BookModel>));
        TextWriter file = new StreamWriter("Books.xml");
        xml.Serialize(file, booksList);
        file.Close();
    }

}
