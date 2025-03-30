using RssReader.Enums;

namespace RssReader.ViewModels;

public partial class FeedViewModel : PageViewModel
{
    public FeedViewModel()
    {
        PageName = PageNames.Feed;
    }
}