using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RssReader.Data;
using RssReader.Enums;
using RssReader.Factories;
using RssReader.Services;
using RssReader.ViewModels;
using RssReader.Views;

namespace RssReader;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        
        collection.AddSingleton<MainWindowViewModel>();
        
        collection.AddTransient<BookmarksViewModel>();
        collection.AddTransient<ChannelsViewModel>();
        collection.AddTransient<FeedViewModel>();
        collection.AddTransient<AddChannelDialogViewModel>();

        collection.AddSingleton<Func<PageNames, PageViewModel>>(x => name => name switch
        {
            PageNames.Feed => new FeedViewModel(),
            PageNames.Channel => new ChannelsViewModel(x.GetRequiredService<ChannelManagementService>()),
            PageNames.Bookmarks => new BookmarksViewModel(),
            _ => throw new InvalidOperationException()
        });
        
        collection.AddTransient<PageFactory>();

        collection.AddTransient(
            typeof(DatabaseContextFactory), (_) => new DatabaseContextFactory(){DbName = "RssReaderData"});
        collection.AddTransient<ChannelManagementService>();

        collection.AddSingleton(typeof(IDialogService), (provider) => 
            (IDialogService) new DialogService(
                new DialogManager(
                    dialogFactory: new DialogFactory().AddDialogHost(),
                    viewLocator: new ViewLocator()
                    ), viewModelFactory: x => provider.GetRequiredService(x)));
        
         var serviceProvider = collection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindowView
            {
                DataContext = serviceProvider.GetService<MainWindowViewModel>(),
            };
        }
        
        
        
        GC.KeepAlive(typeof(DialogService));

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}