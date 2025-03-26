using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using RssReader.Models;

namespace RssReader.Services;

public static class ChannelManagementService
{
    public static ChannelModel ReceiveFromFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File {path} not found");
        }
        
        return XmlParsingService.CreateChannelModelFromFile(path);
    }

    public static async Task<ChannelModel> ReceiveFromUrl(string url)
    {
        HttpClient tempClient = new HttpClient()
        {
            BaseAddress = new Uri(url)
        };
        
        var response = await tempClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var xml = await response.Content.ReadAsStringAsync();
        
        return XmlParsingService.CreateChannelModelFromString(xml);
    }
}