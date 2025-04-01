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
    }
    
    [ObservableProperty]
    private ObservableCollection<ChannelModel> _channels = new ObservableCollection<ChannelModel>();
}