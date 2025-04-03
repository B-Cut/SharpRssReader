using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Avalonia.Controls.Chrome;

namespace RssReader.Models;


/// <summary>
/// This class only exists to us within XML deserialization and should not be used.
/// </summary>
[XmlRoot("rss")]
public class Rss
{
    [XmlElement("channel")]
    public ChannelModel Channel { get; set; }
}

/// <summary>
/// The model of an RSS Channel. Follows the definitions found in
/// the <see href="https://www.rssboard.org/rss-specification">RSS specification</see>.
/// The <c>cloud</c> property is not used in this application
/// </summary>
public class ChannelModel
{
    // This constructor only exists for the purposes of deserialization
    internal ChannelModel()
    { }
    
    /// <summary>
    /// The channel ID on the local database
    /// </summary>
    [XmlIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    
    public ChannelModel(string title, string description, string link)
    {
        Title = title;
        Description = description;
        Link = link;
    }
    
    // Mandatory Elements
    
    /// <summary>
    /// Title of the channel.
    /// </summary>
    [XmlElement("title")]
    public string Title { get; set; }

    /// <summary>
    /// An url linking to the HTML version of the channel.
    /// </summary>
    [XmlElement("link")]
    public string Link { get; set; }
    
    /// <summary>
    /// A description of the channel.
    /// </summary>
    [XmlElement("description")]
    public string Description { get; set; }
    
    // Optional elements
    
    /// <summary>
    /// The language specified by the channel.
    /// </summary>
    [XmlElement("language")]
    public string? Language { get; set; }
    
    /// <summary>
    /// Copyright notice for the channel's content
    /// </summary>
    [XmlElement("copyright")]
    public string? Copyright { get; set; }
    
    /// <summary>
    /// Email address of the person responsible for managing the channel's content
    /// </summary>
    [XmlElement("managingEditor")]
    public string? ManagingDirector { get; set; }
    
    /// <summary>
    /// Email address of the person responsible for handling technical issues of the channel
    /// </summary>
    [XmlElement("webMaster")]
    public string? WebMaster { get; set; }
    
    /// <summary>
    /// Publication date of the content in the channel.
    /// </summary>
    [XmlIgnore]
    public DateTime? PublishedDate { get; set; }

    [XmlElement("pubDate")]
    public string? ProxyPublishedDate
    {
        get { return PublishedDate.ToString(); }
        set { PublishedDate = Utils.ConvertToDateTime(value); }
    }
    /// <summary>
    /// Last time the content of the channel changed.
    /// </summary>
    [XmlIgnore]
    public DateTime? LastBuildDate { get; set; }

    [XmlElement("lastBuildDate")]
    public string? ProxyLastBuildDate
    {
        get { return LastBuildDate.ToString(); }
        set { LastBuildDate = Utils.ConvertToDateTime(value);  }
    }
    /// <summary>
    /// A list containing the channel's categories.
    /// </summary>
    [XmlElement("category")]
    public List<string>? Category { get; set; }
    
    /// <summary>
    /// The program used to generate the channel.
    /// </summary>
    [XmlElement("generator")]
    public string? Generator { get; set; }
    
    /// <summary>
    /// Items associated with this channel.
    /// </summary>Xml
    [XmlElement("item")]
    public List<ItemModel>? Items { get; set; }
    
    /// <summary>
    /// An url pointing to the documentation used for the format in the RSS file.
    /// </summary>
    [XmlElement("docs")]
    public string? Docs { get; set; }
    
    /// <summary>
    /// Number of minutes a channel can be cached before needing to be refreshed.
    /// </summary>
    [XmlElement("ttl")]
    public uint? TimeToLive { get; set; }
    
    /// <summary>
    /// Specifies an image that can be displayed along with the channel.
    /// </summary>
    [XmlElement("imageUrl")]
    public string? ImageUrl { get; set; }
    
    /// <summary>
    /// <see href="">PICS</see> rating of the channel.
    /// </summary>
    [XmlElement("rating")]
    public uint? Rating { get; set; }

    /// <summary>
    /// Array containing the hours in which this channel can be skipped when checking for new updates.
    /// </summary>
    [XmlElement("skipHours")]
    public uint[]? SkipHours { get; set; }
    
    /// <summary>
    /// Array containing the hours in which this channel can be skipped when checking for new updates.
    /// </summary>
    [XmlElement("skipDays")]
    public Enums.Weekdays[]? SkipDays { get; set; }
}