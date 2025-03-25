using System.IO;
using System.Xml.Serialization;
using RssReader.Models;

namespace RssReader.Services;

public static class XmlParsingService
{
    public static ChannelModel CreateChannelModelFromXml(string path) {
        XmlSerializer serializer = new XmlSerializer(typeof(Rss));
        
        FileStream fs = new FileStream(path, FileMode.Open);
        TextReader tr = new StreamReader(fs);

        var Rss = (Rss) serializer.Deserialize(tr);
        
        // Not sure if needed but safe
        tr.Close();
        fs.Close();
        
        return Rss.Channel;
    }
}