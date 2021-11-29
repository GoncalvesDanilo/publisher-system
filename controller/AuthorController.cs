using System;
using System.Collections.Generic;

using System.IO;
using System.Xml.Serialization;

public class AuthorController
{
    private List<AuthorModel> authorsList = new List<AuthorModel>();

    public void Insert(AuthorModel author)
    {
        ReadDB();
        authorsList.Add(author);
        SaveToDB();
    }

    public bool Update(AuthorModel author)
    {
        ReadDB();
        bool updated = false;

        foreach (var item in authorsList)
        {
            if (item.id == author.id)
            {
                item.name = author.name;
                item.pseudonym = author.pseudonym;
                item.description = author.description;
                updated = true;
            }
        }

        SaveToDB();
        return updated;
    }

    public bool Delete(Int32 authorId)
    {
        ReadDB();
        int index = -1;

        foreach (var item in authorsList)
        {
            if (item.id == authorId)
            {
                index = authorsList.IndexOf(item);
            }
        }

        if (index != -1)
        {
            authorsList.RemoveAt(index);
            SaveToDB();
            return true;
        }

        return false;
    }

    public AuthorModel Select(Int32 authorId)
    {
        ReadDB();
        AuthorModel author = null;

        foreach (var item in authorsList)
        {
            if (item.id == authorId)
            {
                author = item;
            }
        }

        return author;
    }

    private void ReadDB()
    {
        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Authors.xml")) == false)
        {
            SaveToDB();
        }

        XmlSerializer xml = new XmlSerializer(typeof(List<AuthorModel>));
        FileStream file = new FileStream("Authors.xml", FileMode.Open);
        authorsList = (List<AuthorModel>)xml.Deserialize(file);
        file.Close();
    }

    private void SaveToDB()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<AuthorModel>));
        TextWriter file = new StreamWriter("Authors.xml");
        xml.Serialize(file, authorsList);
        file.Close();
    }

}
