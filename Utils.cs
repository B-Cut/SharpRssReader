using System;
using System.Globalization;

namespace RssReader;

public static class Utils
{
    public static DateTime? ConvertToDateTime(string value)
    {
        try
        {
            return DateTime.ParseExact(value, CultureInfo.InvariantCulture.DateTimeFormat.RFC1123Pattern,
                CultureInfo.InvariantCulture.DateTimeFormat);
        }
        catch (FormatException)
        {
            // The format used by RSS for date time is the RFC 1123, which only recognizes the GMT timezone
            // However, the received date may not conform to that pattern, so we need to do the conversion
            
            // TODO: Create timezone codes list
            
            /*
            var pattern = @"[a-zA-Z]+, [0-9]+ [a-zA-Z]+ [0-9]+ [0-9]+:[0-9]+:[0-9]+ (?<timezone>[a-zA-Z]+)";
            Regex findTimezone = new Regex(pattern, RegexOptions.Compiled);

            var timezoneCode = findTimezone.Match(value).Groups["timezone"].Value;
            TimeZoneInfo timezone;
            TimeZoneInfo.TryFindSystemTimeZoneById(timezoneCode, out timezone);
            if(timezone is not null)
            {
                // Changes the format from TMZ to HH:MM
                var newTimeZone = findTimezone.Replace("$timezone", timezone.BaseUtcOffset.ToString());
                return DateTime.Parse(newTimeZone);
            }
            else
            {
                Console.Error.WriteLine($"Timezone {timezoneCode} not found");
                return null;
            }
            */
            return null;
        }
    }
}