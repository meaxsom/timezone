namespace timezone.Models;

public readonly struct SelectedZones
    {
    public readonly List<SelectedZone> Zones = new List<SelectedZone>();
    public SelectedZones()
        {
        }

    public SelectedZones(Zone inDefaultZone)
        {
        AddZone(inDefaultZone, true);
        }

    public void AddZone(Zone? inZone, bool isDefault)
        {
        if (inZone != null)
            Zones.Add(new SelectedZone(inZone, isDefault));
        } 
    }
