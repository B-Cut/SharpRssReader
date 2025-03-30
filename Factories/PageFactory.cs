using System;
using RssReader.Enums;
using RssReader.ViewModels;

namespace RssReader.Factories;

public class PageFactory(Func<PageNames, PageViewModel> factory)
{
    public PageViewModel Create(PageNames pageName) => factory.Invoke(pageName);
}