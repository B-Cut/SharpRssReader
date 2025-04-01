using System;
using RssReader.Models;

namespace RssReader.ViewModels;

public class DesignChannelViewModel : ChannelsViewModel
{
    public DesignChannelViewModel()
    {
        for (int i = 0; i < 10; i++)
        {
            Channels.Add(
                new ChannelModel(
                    "Title " + i.ToString(),
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean pretium aliquam iaculis. Vestibulum risus",
                    "Sample Link"
                    )
                {
                    LastBuildDate = DateTime.Now
                }
                );
        }
    }
}