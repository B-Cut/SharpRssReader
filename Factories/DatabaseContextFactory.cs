using System;
using RssReader.Data;

namespace RssReader.Factories;

/// <summary>
/// This class serves as a middleman between <c>AppDatabaseContext</c> and the dependency injection service
/// </summary>
public class DatabaseContextFactory
{
    public DatabaseContextFactory()
    { }
    
    public string DbName { get; set; }
    
    public AppDatabaseContext Create()
    {
        return new AppDatabaseContext(DbName);
    }
}