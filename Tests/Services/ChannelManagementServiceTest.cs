using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using RssReader.Data;
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
        _context = new AppDatabaseContext("TestDB");
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        _context.SaveChanges();
        _sut = new ChannelManagementService(_context);
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
}