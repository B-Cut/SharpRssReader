using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using RssReader.Data;
using RssReader.Factories;
using RssReader.Models;
using RssReader.Services;

namespace RssReader.Tests.Services;

[TestFixture]
[TestOf(typeof(ChannelManagementService))]
public class ChannelManagementServiceTest
{
    private string _testFilePath = Path.Join(TestUtils.GetResourcesDirectory(), "sample-rss-2.xml");
    private string _testFileUrl = "https://www.rssboard.org/files/sample-rss-2.xml";
    
    // Our database is lightweight enough to be worth just creating a new one
    private AppDatabaseContext _context;
    private ChannelManagementService _sut;

    [SetUp]
    public void Setup()
    {
        var collection = new ServiceCollection();
        collection.AddTransient(
            typeof(DatabaseContextFactory), (_) => new DatabaseContextFactory(){DbName = "TestDB"});
        collection.AddTransient<ChannelManagementService>();
        var serviceProvider = collection.BuildServiceProvider();
        
        _context = serviceProvider.GetRequiredService<DatabaseContextFactory>().Create();
        
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        _context.SaveChanges();
        
        _sut = serviceProvider.GetRequiredService<ChannelManagementService>();
    }

    
    
    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }
    
    [Test]
    public async Task ShouldCreateChannelModelFromFile()
    {
        
        var model = await _sut.ReceiveFromFile(_testFilePath);
        
        Assert.That(model, Is.Not.Null);
        Assert.That(model, Is.InstanceOf<ChannelModel>());
        
        var numElementsInChannel = _context.Channels.Count();
        Assert.That(numElementsInChannel, Is.EqualTo(1));
        
        Assert.That(_context.Channels.Single().Title, Is.EqualTo(model.Title));
        
        Assert.That(_context.Items.Count(), Is.EqualTo(5));
    }

    [Test]
    public async Task ShouldCreateChannelModelFromUrl()
    {
        var model = await _sut.ReceiveFromUrl(_testFileUrl);
        
        Assert.That(model, Is.Not.Null);
    }

    [Test]
    public async Task ShouldReturnAllChannelsFromDatabase()
    {
        await _sut.ReceiveFromFile(_testFilePath);
        var channels = await _sut.GetAllChannels();
        Assert.That(channels, Is.Not.Null);
        Assert.That(channels, Is.Not.Empty);
        Assert.That(channels.Count(), Is.EqualTo(1));
    }
}