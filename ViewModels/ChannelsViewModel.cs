using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using RssReader.Enums;
using RssReader.Models;
using RssReader.Services;

namespace RssReader.ViewModels;

public partial class ChannelsViewModel : PageViewModel
{
    private ChannelManagementService _channelManager;
    
    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty] private bool _channelsEmpty;
    
    [ObservableProperty]
    private ObservableCollection<ChannelModel> _channels = new ObservableCollection<ChannelModel>();
    
    public ChannelsViewModel(ChannelManagementService channelManager)
    {
        PageName = PageNames.Channel;
        _channelManager = channelManager;
        IsLoading = true;
        Task.Run(_getAllChannels);
    }

    private async Task _getAllChannels()
    {
        var channelsList = await _channelManager.GetAllChannels();

        if (channelsList.Count == 0)
        {
            ChannelsEmpty = true;
            IsLoading = false;
            return;
        }
        
        foreach (var channel in channelsList)
        {
            Channels.Add(channel);
        }
        
        IsLoading = false;
    }
   
}