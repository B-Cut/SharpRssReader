using System;
using System.Globalization;
using RssReader.Models;

namespace RssReader.ViewModels;

public class ChannelCardViewModel : ViewModelBase
{
    private readonly ChannelModel _channel;
    private readonly uint _descriptionCharLength = 100;
    
    public ChannelCardViewModel(ChannelModel channel)
    {
        _channel = channel;
    }

    /// <summary>
    /// For design only
    /// </summary>
    public ChannelCardViewModel()
    {
        _channel = new ChannelModel(
            "Sample Title", 
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean pretium aliquam iaculis. Vestibulum risus justo, maximus non purus vitae, finibus rutrum orci. Quisque euismod dolor lectus. Donec dignissim vitae leo congue iaculis. Aenean imperdiet quam nec dolor scelerisque dictum. Duis ultricies lacus eu est porta viverra. Ut a cursus lectus.",
            "Sample Link")
        {
            LastBuildDate = DateTime.Now
        };
    }
    
    public string Title => _channel.Title;
    public string Link => _channel.Link;
    public string Description
    {
        get
        {
            if (_channel.Description.Length < _descriptionCharLength) return _channel.Description;
            
            return _channel.Description.Substring(0, (int)_descriptionCharLength) + "...";
        } 
        set { _channel.Description = value; }
    }

    public string LastBuildDate
    {
        get
        {
            if (_channel.LastBuildDate == null) return "N/A";
            
            // TODO: Define proper localization for date
            return _channel.LastBuildDate.Value.ToString("dd MMMM yyyy");
        }
    }
}