using System;

namespace RssReader.Models;

/// <summary>
/// This model represents the <c>image</c> sub-element of a channel
/// as per the <see href="https://www.rssboard.org/rss-specification">RSS specification</see>.
/// </summary>
public class ChannelImageModel(string url, string title, string link)
{
    /// <summary>
    /// The URL pointing to the channel's image.
    /// </summary>
    //TODO: Implement image caching
    public string ImageUrl { get; set; } = url;
    
    /// <summary>
    /// The image's description.
    /// </summary>
    public string Title { get; init; } = title;
    
    /// <summary>
    /// A link to the original site.
    /// </summary>
    public string Link { get; init; } = link;

    private uint _width = 88;
    private uint _height = 31;
    
    
    
    /// <summary>
    /// Image's width. Maximum value is 144.
    /// </summary>
    public uint Width
    {
        get => _width;
        set{
            if (value > 144) throw new ArgumentException("Width must be less than 144");
            else _width = value;
        }
    }

    /// <summary>
    /// Image's Height. Maximum value is 400
    /// </summary>
    public uint Height
    {
        get => _height;
        set
        {
            if (value > 400) throw new ArgumentException("Height must be less than 400");
            else _height = value;
        }
    }
}