using System;
using System.Threading.Tasks;

namespace RssReader;

public static class Events
{
    public delegate Task AsyncEventHandler(object sender, EventArgs e);
    
    public static event AsyncEventHandler? ChannelAdded;
    public static event AsyncEventHandler? ChannelRemoved;

    public static async Task OnChannelAddedAsync(object sender, EventArgs e)
    {
        if (ChannelAdded is not null) await ChannelAdded(sender, e);
    }
    
    public static async Task OnChannelRemoved(object sender, EventArgs e)
    {
        if (ChannelRemoved is not null) await ChannelRemoved(sender, e);
    }
}