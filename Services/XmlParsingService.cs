using System;
using System.IO;
using System.Xml.Serialization;
using RssReader.Models;

namespace RssReader.Services;

public static class XmlParsingService
{
    public static ChannelModel CreateChannelModelFromFile(string path) {
        XmlSerializer serializer = new XmlSerializer(typeof(Rss));
        
        FileStream fs = new FileStream(path, FileMode.Open);
        TextReader tr = new StreamReader(fs);

        Rss rss;
        try
        {
            rss = serializer.Deserialize(tr) as Rss;
        }
        catch (InvalidOperationException e)
        {
            throw new FormatException("Invalid Rss file", e);
        }
        
        // Not sure if needed but safe
        tr.Close();
        fs.Close();
        
        return rss.Channel;
    }

    public static ChannelModel CreateChannelModelFromString(string xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Rss));
        StringReader tr = new StringReader(xml);
        
        Rss rss;
        try
        {
            rss = serializer.Deserialize(tr) as Rss;
        }
        catch (InvalidOperationException e)
        {
            throw new FormatException("Invalid Rss file", e);
        }
        
        tr.Close();
        
        return rss.Channel;
    }
}