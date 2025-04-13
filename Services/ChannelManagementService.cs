using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RssReader.Data;
using RssReader.Factories;
using RssReader.Models;

namespace RssReader.Services;

public class ChannelManagementService(DatabaseContextFactory dbContextFactory)
{
    private AppDatabaseContext _context = dbContextFactory.Create();

    private async Task _AddChannelToDb(ChannelModel channel)
    {
        var canConnectToDb = await _context.Database.CanConnectAsync();

        if (!canConnectToDb)
        {
            throw new InvalidOperationException("Can't connect to database");
        }
        await _context.AddAsync(channel);
        await _context.SaveChangesAsync();
    }
    public async Task<ChannelModel> ReceiveFromFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File {path} not found");
        }

        var model = XmlParsingService.CreateChannelModelFromFile(path);
        await _AddChannelToDb(model);
        return model;
    }

    public async Task<ChannelModel> ReceiveFromUrl(string url)
    {
        HttpClient tempClient = new HttpClient()
        {
            BaseAddress = new Uri(url)
        };
        
        var response = await tempClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var xml = await response.Content.ReadAsStringAsync();
        
        var model = XmlParsingService.CreateChannelModelFromString(xml);
        await _AddChannelToDb(model);
        return model;
    }

    public async Task<List<ChannelModel>> GetAllChannels()
    {
        return await _context.Channels.ToListAsync();
    }
}