using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace RssReader.Models;

/// <summary>
/// The model of an RSS Channel item as per <see href="https://www.rssboard.org/rss-specification">RSS specification</see>.
/// </summary>
public class ItemModel
{
    internal ItemModel() {}

    public ItemModel(string title, string link, string description)
    {
        Title = title;
        Link = link;
        Description = description;
    }
    
    /// <summary>
    /// The ID of the item in the database
    /// </summary>
    [XmlIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [XmlIgnore]
    public long ChannelId { get; set; }

    [XmlIgnore] // may not be needed
    private string _title;
    /// <summary>
    /// Title of the channel.
    /// </summary>
    [XmlElement("title")]
    public string Title
    {
        get { return _title ?? "No Title"; }
        set { _title = value; }
    }

    /// <summary>
    /// An url linking to the HTML version of the channel.
    /// </summary>
    [XmlElement("link")]
    public string Link { get; set; }
    
    [XmlIgnore]
    private string _description;

    /// <summary>
    /// A description of the channel.
    /// </summary>
    [XmlElement("description")]
    public string Description
    {
        get { return _description ?? "No Description"; ;} 
        set { _description = value; }
    }
    
    /// <summary>
    /// Email address of the author.
    /// </summary>
    [XmlElement("author")]
    public string? Author { get; set; }
    
    [XmlElement("category")]
    public List<string>? Categories { get; set; }
    
    /// <summary>
    /// The URL to a page containing comments related to the item
    /// </summary>
    [XmlElement("comments")]
    public string? Comments { get; set; }
    
    [XmlElement("enclusure")]
    public EnclosureModel? Enclosure { get; set; }
    
    /// <summary>
    /// A string that uniquely identifies an item
    /// </summary>
    [XmlElement("guid")]
    public string? Guid { get; set; }
    
    /// <summary>
    /// The date the item was published in.
    /// </summary>
    [XmlIgnore]
    public DateTime? PublishDate { get; set; }

    public string? PubDateProxy
    {
        get => PublishDate.ToString();
        set => PublishDate = Utils.ConvertToDateTime(value);
    }
    
    /// <summary>
    /// The RSS channel that originated the item
    /// </summary>
    [XmlElement("source")]
    public string? Source { get; set; }
    
    /// <summary>
    /// An optional extension of the RSS protocol designed to contain a page's actual content. If not <c>null</c> it
    /// should be displayed instead of <see cref="Description"/>.
    /// <seealso href="https://web.resource.org/rss/1.0/modules/content/"/>
    /// </summary>
    [XmlElement("content:encoded")]
    public string? Content { get; set; }
}