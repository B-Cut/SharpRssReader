using RssReader.Enums;

namespace RssReader.ViewModels;

public partial class ChannelsViewModel : PageViewModel
{
    public ChannelsViewModel()
    {
        PageName = PageNames.Channel;
    }
}