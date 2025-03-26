using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using RssReader.Models;
using RssReader.Services;

namespace RssReader.Tests.Services;

[TestFixture]
[TestOf(typeof(ChannelManagementService))]
public class ChannelManagementServiceTest
{
    private string _testFilePath = Path.Join(TestUtils.GetResourcesDirectory(), "sample-rss-2.xml");
    private string _testFileUrl = "https://www.rssboard.org/files/sample-rss-2.xml";
    
    [Test]
    public void ShouldCreateChannelModelFromFile()
    {
        var model = ChannelManagementService.ReceiveFromFile(_testFilePath);
        
        Assert.That(model, Is.Not.Null);
    }

    [Test]
    public async Task ShouldCreateChannelModelFromUrl()
    {
        var model = await ChannelManagementService.ReceiveFromUrl(_testFileUrl);
        
        Assert.That(model, Is.Not.Null);
    }
}