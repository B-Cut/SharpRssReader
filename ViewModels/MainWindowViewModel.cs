using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using RssReader.Enums;
using RssReader.Factories;
using RssReader.Models;
using RssReader.Services;

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
    private IDialogService _dialogService;
    
    [ObservableProperty] 
    private PageViewModel _currentPage;
    
    public MainWindowViewModel(PageFactory factory, IDialogService dialogService)
    {
        _pageFactory = factory;
        _dialogService = dialogService;
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

    [RelayCommand]
    private async Task ShowAddChannelDialog()
    {
        await _dialogService.ShowAddChannelDialogAsync(this);
    }
}