using System;
using NUnit.Framework;
using RssReader.Models;
using RssReader.Services;
using Path = System.IO.Path;

namespace RssReader.Tests.Services;

[TestFixture]
public class XmlParsingServiceTest
{
    private string _testFilePath = Path.Join(TestUtils.GetResourcesDirectory(), "sample-rss-2.xml");
    
    [Test]
    public void ChannelIsCreatedTest()
    {
        ChannelModel model = XmlParsingService.CreateChannelModelFromXml(_testFilePath);
        
        /*TODO: Find a more robust way to determine if deserialization was successful*/
        
        // Check if the model generated has been initialized
        Assert.That(model, Is.Not.Null);
        Assert.That(model.Title, Is.Not.Null);
        Assert.That(model.Description, Is.Not.Null);
        Assert.That(model.Link, Is.Not.Null);
    }

    [Test]
    public void ItemsAreCreatedTest()
    {
        ChannelModel model = XmlParsingService.CreateChannelModelFromXml(_testFilePath);
        
        // The test file has items properties that should be parsed
        Assert.That(model.Items, Is.Not.Empty);
        foreach (var item in model.Items!)
        {
            Assert.That(item.Title, Is.Not.Null);
            Assert.That(item.Description, Is.Not.Null);
            Assert.That(item.Link, Is.Not.Null);
        }
    }
    
    [TestCase<string>("BadRss.xml")]
    [TestCase<string>("test.json")]
    public void InvalidFileShouldReturnExceptionTest(string filename)
    {
        string path = Path.Join(TestUtils.GetResourcesDirectory(), filename);
        Assert.Throws<FormatException>((() => XmlParsingService.CreateChannelModelFromXml(path)));
    }
}