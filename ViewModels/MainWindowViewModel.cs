using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RssReader.Enums;
using RssReader.Factories;

namespace RssReader.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private const string _feedText = "Feed";
    private const string _channelText = "Channel";
    private const string _bookmarksText = "Bookmarks";

    public string FeedText => _feedText;
    public string ChannelText => _channelText;
    public string BookmarksText => _bookmarksText;

    private PageFactory _pageFactory;
    
    [ObservableProperty] 
    private PageViewModel _currentPage;
    
    public MainWindowViewModel(PageFactory factory)
    {
        _pageFactory = factory;
        CurrentPage = _pageFactory.Create(PageNames.Channel);
    }
    
    // The number of pages in this application is rather small
    // So no need of a more elegant solution

    [RelayCommand]
    private void ChangeToPage(string nameStr)
    {
        PageNames name = nameStr switch
        {
            _feedText => PageNames.Feed,
            _channelText => PageNames.Channel,
            _bookmarksText => PageNames.Bookmarks,
            _ => throw new InvalidOperationException()
        };
        
        CurrentPage = _pageFactory.Create(name);
    }
    
}