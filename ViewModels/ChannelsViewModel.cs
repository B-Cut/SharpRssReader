using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using RssReader.Enums;
using RssReader.Models;

namespace RssReader.ViewModels;

public partial class ChannelsViewModel : PageViewModel
{
    public ChannelsViewModel()
    {
        PageName = PageNames.Channel;
        // Temporary
        Channels.Add(
            new ChannelModel("A sample title", "A sample description", "link")
            );
    }
    
    [ObservableProperty]
    private ObservableCollection<ChannelModel> _channels = new ObservableCollection<ChannelModel>();
}