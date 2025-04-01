using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RssReader.Models;
using RssReader.ViewModels;

namespace RssReader.Views;

public partial class ChannelCardView : UserControl
{
    public ChannelCardView()
    {
        InitializeComponent();
    }

    private void StyledElement_OnDataContextChanged(object? sender, EventArgs e)
    {
        Card.DataContext = new ChannelCardViewModel( (ChannelModel) this.DataContext );
    }
}