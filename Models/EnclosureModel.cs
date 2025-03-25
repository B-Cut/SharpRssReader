using System.Xml.Serialization;

namespace RssReader.Models;

/// <summary>
/// Model of the <c>enclosure</c> property of an RSS Item
/// as per <see href="https://www.rssboard.org/rss-specification">RSS specification</see>. This may containt any
/// kind of Hypermedia.
/// </summary>
public class EnclosureModel
{
    
    internal EnclosureModel() { }

    public EnclosureModel(string link, uint length, string mimeType)
    {
        Link = link;
        Length = length;
        MimeType = mimeType;
    }
    
    /// <summary>
    /// A link pointing to the enclosure content.
    /// </summary>
    [XmlElement("link")]
    public string Link { get; set; }
    
    /// <summary>
    /// The size, in bytes, of the content.
    /// </summary>
    [XmlElement("length")]
    public uint Length { get; set; }

    /// <summary>
    /// The MIME type of the enclosure's content.
    /// </summary>
    [XmlElement("type")]
    public string MimeType { get; set; }
}