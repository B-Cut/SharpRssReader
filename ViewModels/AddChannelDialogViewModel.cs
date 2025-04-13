using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using RssReader.Services;

namespace RssReader.ViewModels;

public partial class AddChannelDialogViewModel : ViewModelBase, IModalDialogViewModel
{
    private ChannelManagementService _channelManager;

    // We can keep it as bool, change to Enum if more channel adding methods are introduced
    [ObservableProperty]
    private bool _addViaUrl = true;

    [ObservableProperty]
    private string _inputContent = string.Empty;
    
    // This is bad OOP, but it will do for now
    [RelayCommand]
    private async Task AddNewChannel()
    {
        Console.WriteLine(InputContent);
        Console.WriteLine($"Add via URL: {AddViaUrl}");
        if(string.IsNullOrWhiteSpace(InputContent)) return;
        // TODO: Implement error messages

        /*
        if (AddViaUrl)
        {
            await _channelManager.ReceiveFromUrl(InputContent);
        }
        else
        {
            await _channelManager.ReceiveFromFile(InputContent);
        }*/
    }
    
    public AddChannelDialogViewModel(ChannelManagementService channelManager)
    {
        _channelManager = channelManager;
    }
    
    public bool? DialogResult { get; }
}