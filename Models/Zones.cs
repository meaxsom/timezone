namespace timezone.Models;

using System.Globalization;
using CsvHelper;

public readonly struct Zones
    {
    private readonly Dictionary <String, Zone> zones = [];
    
    public Zones()
        {
        }

    public Zones(String inZoneFile)
        {
        if (inZoneFile != null)
            Populate(inZoneFile);
        }

    public readonly Zone GetZone(String inZoneName)
        {
        return zones[inZoneName];
        }

    private void Populate(String inZoneFilePath)
        {
        try
            {
            var theReader = new StreamReader(inZoneFilePath);
            var theCSV = new CsvReader(theReader, CultureInfo.InvariantCulture);

            theCSV.Read();
            theCSV.ReadHeader();
            while (theCSV.Read())
                {
                var theZone = theCSV.GetField<String>("timezone");
                var theOffset = theCSV.GetField<int>("offset");
                var theDSTOffset = theCSV.GetField<int>("offset_dst");

                if (theZone != null)
                    zones.Add(theZone, new Zone(theZone, theOffset, theDSTOffset));
                }
            }
        catch (Exception theErr)
            {
            Console.Write($"Error: {theErr.Message}");
            }
        }
    }