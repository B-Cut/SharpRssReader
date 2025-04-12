using HanumanInstitute.MvvmDialogs;
using RssReader.Services;

namespace RssReader.ViewModels;

public class AddChannelDialogViewModel : ViewModelBase, IModalDialogViewModel
{
    private ChannelManagementService _channelManager;

    public AddChannelDialogViewModel(ChannelManagementService channelManager)
    {
        _channelManager = channelManager;
    }
    
    public bool? DialogResult { get; }
}