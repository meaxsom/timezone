using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using timezone.Models;

var app = new CommandApp<Timezoned>();
return app.Run(args);

internal sealed class Timezoned : Command<Timezoned.Settings>
    {
    public sealed class Settings : CommandSettings
        {
        [Description("Source timezone")]
        [CommandArgument(0, "[sourceTimezone]")]
        public string? SourceTimezone { get; init; }

        [Description("timezoneCSVFile")]
        [CommandOption("-f|--timezoneFile")]
        public string? TimeZoneCSVFile { get; init; }

        [Description("Timezones,to,convert,to")]
        [CommandOption("-t|--timezones")]
        public string? OtherZones { get; init; }

        [Description("Sort by: a: alpha, r: relative")]
        [CommandOption("-s|--sort")]
        public string? SortOrder { get; init; }

        [Description("Sort Order: a: ascending, d: descending")]
        [CommandOption("-d|--sort-direction")]
        public string? SortDirection { get; init; }
        }
    
    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
        DateTime utcNow = DateTime.UtcNow;

        var sourceZone = settings.SourceTimezone;

        var theTimezones = new Zones(settings.TimeZoneCSVFile);
        var theSelectedZones = new SelectedZones();

        var theDefaultZone=theTimezones.GetZone(settings.SourceTimezone);
        if (theDefaultZone != null)
            {
            // load up the default timezone
            theSelectedZones.AddZone(theDefaultZone, true);
            Console.WriteLine($"Added default Timezone: {theDefaultZone.Value.Name}\t{theDefaultZone.Value.Offset}");

            var theOtherZones = settings.OtherZones;
            // use LINQ - adapted from Phind answer about parsing strings
            IEnumerable<String> theZoneNames = theOtherZones.Split(",").Select(s => s.Trim()).Where(s => !string.IsNullOrWhiteSpace(s));
 
            // load up other zones
            foreach (var theZoneName in theZoneNames)
                {
                var theZone=theTimezones.GetZone(theZoneName);
                if (theZone != null)
                    {
                    theSelectedZones.AddZone(theZone, false);
                    Console.WriteLine($"Added Timezone: {theZone.Value.Name}\t{theZone.Value.Offset}");
                    }
                }

            // sort
            theSelectedZones.Zones.Sort((a, b) => string.Compare(a.Timezone.Name, b.Timezone.Name, StringComparison.OrdinalIgnoreCase));
            
            foreach (var theZone in theSelectedZones.Zones)
                Console.WriteLine($"Timezone: {theZone.Timezone.Name}\t{theZone.Timezone.Offset}");
            }
        else
            Console.WriteLine("Default Timezone not found");

        /*
        var searchOptions = new EnumerationOptions
            {
            AttributesToSkip = settings.IncludeHidden
                ? FileAttributes.Hidden | FileAttributes.System
                : FileAttributes.System
            };

        var searchPattern = settings.SearchPattern ?? "*.*";
        var searchPath = settings.SearchPath ?? Directory.GetCurrentDirectory();
        var files = new DirectoryInfo(searchPath)
            .GetFiles(searchPattern, searchOptions);

        var totalFileSize = files
            .Sum(fileInfo => fileInfo.Length);
        */

        //AnsiConsole.MarkupLine($"Total file size for [green]{searchPattern}[/] files in [green]{searchPath}[/]: [blue]{totalFileSize:N0}[/] bytes");

        return 0;
        }
    }
