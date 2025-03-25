using System;
using System.IO;

namespace RssReader.Tests;

public static class TestUtils
{
    public static string GetResourcesDirectory()
    {
        // Get path ignoring the bin directory
        var temp = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
        return Path.Join(temp, "Tests/Resources");
    }
}