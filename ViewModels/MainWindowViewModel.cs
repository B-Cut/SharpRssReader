using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RssReader.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ViewModelBase _currentViewModel;
    
    // Temporary
    private readonly BookmarksViewModel _bookmarksViewModel = new();
    private readonly FeedViewModel _feedViewModel = new();
    private readonly ChannelsViewModel _channelsViewModel = new();

    public MainWindowViewModel()
    {
        CurrentViewModel = _channelsViewModel;
    }
    
    // The number of pages in this application is rather small
    // So no need of a more elegant solution

    [RelayCommand]
    private void ChangeToFeed()
    {
        CurrentViewModel = _feedViewModel;
    }

    [RelayCommand]
    private void ChangeToChannels()
    {
        CurrentViewModel = _channelsViewModel;
    }

    [RelayCommand]
    private void ChangeToBookmarks()
    {
        CurrentViewModel = _bookmarksViewModel;
    }
}