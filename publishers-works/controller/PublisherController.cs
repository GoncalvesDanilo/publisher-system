using System;
using System.Collections.Generic;

using System.IO;
using System.Xml.Serialization;

public class PublisherController
{
    private List<PublisherModel> publishersList = new List<PublisherModel>();

    public void Insert(PublisherModel publisher)
    {
        ReadDB();
        publishersList.Add(publisher);
        SaveToDB();
    }

    public bool Update(PublisherModel publisher)
    {
        ReadDB();
        bool updated = false;

        foreach (var item in publishersList)
        {
            if (item.id == publisher.id)
            {
                item.name = publisher.name;
                item.abbreviation = publisher.abbreviation;
                item.description = publisher.description;
                updated = true;
            }
        }

        SaveToDB();
        return updated;
    }

    public bool Delete(Int32 publisherId)
    {
        ReadDB();
        int index = -1;

        foreach (var item in publishersList)
        {
            if (item.id == publisherId)
            {
                index = publishersList.IndexOf(item);
            }
        }

        if (index != -1)
        {
            publishersList.RemoveAt(index);
            SaveToDB();
            return true;
        }

        return false;
    }

    public PublisherModel Select(Int32 publisherId)
    {
        ReadDB();
        PublisherModel publisher = null;

        foreach (var item in publishersList)
        {
            if (item.id == publisherId)
            {
                publisher = item;
            }
        }

        return publisher;
    }

    private void ReadDB()
    {
        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Publishers.xml")) == false)
        {
            SaveToDB();
        }

        XmlSerializer xml = new XmlSerializer(typeof(List<PublisherModel>));
        FileStream file = new FileStream("Publishers.xml", FileMode.OpenOrCreate);
        publishersList = (List<PublisherModel>)xml.Deserialize(file);
        file.Close();
    }

    private void SaveToDB()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<PublisherModel>));
        TextWriter file = new StreamWriter("Publishers.xml");
        xml.Serialize(file, publishersList);
        file.Close();
    }

}
