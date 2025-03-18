using System;
using System.Collections.Generic;
using Avalonia.Controls.Chrome;

namespace RssReader.Models;
/// <summary>
/// The model of an RSS Channel. Follows the definitions found in
/// the <see href="https://www.rssboard.org/rss-specification">RSS specification</see>.
/// The <c>cloud</c> property is not used in this application
/// </summary>
public class ChannelModel(string title, string link, string description)
{
    // Mandatory Elements
    
    /// <summary>
    /// Title of the channel.
    /// </summary>
    public string Title { get; } = title;

    /// <summary>
    /// An url linking to the HTML version of the channel.
    /// </summary>
    public string Link { get; set; } = link;
    
    /// <summary>
    /// A description of the channel.
    /// </summary>
    public string Description { get; set; } = description;
    
    // Optional elements
    
    /// <summary>
    /// The language specified by the channel.
    /// </summary>
    public string? Language { get; set; }
    
    /// <summary>
    /// Copyright notice for the channel's content
    /// </summary>
    public string? Copyright { get; set; }
    
    /// <summary>
    /// Email address of the person responsible for managing the channel's content
    /// </summary>
    public string? ManagingDirector { get; set; }
    
    /// <summary>
    /// Email address of the person responsible for handling technical issues of the channel
    /// </summary>
    public string? WebMaster { get; set; }
    
    /// <summary>
    /// Publication date of the content in the channel.
    /// </summary>
    public DateTime? PublishedDate { get; set; }

    /// <summary>
    /// Last time the content of the channel changed.
    /// </summary>
    public DateTime? LastBuildDate { get; set; }
    /// <summary>
    /// A list containing the channel's categories.
    /// </summary>
    public List<string>? Category { get; set; }
    
    /// <summary>
    /// The program used to generate the channel.
    /// </summary>
    public string? Generator { get; set; }
    
    /// <summary>
    /// An url pointing to the documentation used for the format in the RSS file.
    /// </summary>
    public string? Docs { get; set; }
    
    /// <summary>
    /// Number of minutes a channel can be cached before needing to be refreshed.
    /// </summary>
    public uint? TimeToLive { get; set; }
    
    /// <summary>
    /// Specifies an image that can be displayed along with the channel.
    /// </summary>
    public string? ImageUrl { get; set; }
    
    /// <summary>
    /// <see href="">PICS</see> rating of the channel.
    /// </summary>
    public uint? Rating { get; set; }

    /// <summary>
    /// Array containing the hours in which this channel can be skipped when checking for new updates.
    /// </summary>
    public uint[]? SkipHours { get; set; }
    
    /// <summary>
    /// Array containing the hours in which this channel can be skipped when checking for new updates.
    /// </summary>
    public Enums.Weekdays[]? SkipDays { get; set; }
}