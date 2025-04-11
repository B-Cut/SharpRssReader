using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using HanumanInstitute.Validators;
using RssReader.ViewModels;

namespace RssReader;

public static class DialogExtensions
{
    public static async Task ShowAddChannelDialogAsync(this IDialogService dialogService, INotifyPropertyChanged ownerViewModel)
    {
        dialogService.CheckNotNull(nameof(dialogService));
        
        var viewModel = dialogService.CreateViewModel<AddChannelDialogViewModel>();
        var settings = new DialogHostSettings()
        {
            Content = viewModel,
            CloseOnClickAway = true
        };
        
        var result = await dialogService.ShowDialogHostAsync(ownerViewModel, settings);
    }
}