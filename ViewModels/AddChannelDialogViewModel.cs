using HanumanInstitute.MvvmDialogs;

namespace RssReader.ViewModels;

public class AddChannelDialogViewModel : ViewModelBase, IModalDialogViewModel
{
    public bool? DialogResult { get; }
}