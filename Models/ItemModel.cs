using System;
using System.Collections;
using System.Collections.Generic;

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
    /// Title of the channel.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// An url linking to the HTML version of the channel.
    /// </summary>
    public string Link { get; set; }
    
    /// <summary>
    /// A description of the channel.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Email address of the author.
    /// </summary>
    public string? Author { get; set; }
    
    public List<string>? Categories { get; set; }
    
    /// <summary>
    /// The URL to a page containing comments related to the item
    /// </summary>
    public string? Comments { get; set; }
    
    public EnclosureModel? Enclosure { get; set; }
    
    /// <summary>
    /// A string that uniquely identifies an item
    /// </summary>
    public string? Guid { get; set; }
    
    /// <summary>
    /// The date the item was published in.
    /// </summary>
    public DateTime? PublishDate { get; set; }
    
    /// <summary>
    /// The RSS channel that originated the item
    /// </summary>
    public string? Source { get; set; }
    
    /// <summary>
    /// An optional extension of the RSS protocol designed to contain a page's actual content. If not <c>null</c> it
    /// should be displayed instead of <see cref="Description"/>.
    /// <seealso href="https://web.resource.org/rss/1.0/modules/content/"/>
    /// </summary>
    public string? Content { get; set; }
}