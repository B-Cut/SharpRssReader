using CommunityToolkit.Mvvm.ComponentModel;
using RssReader.Enums;

namespace RssReader.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty ]
    private PageNames _pageName;
}