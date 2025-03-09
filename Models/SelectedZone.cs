namespace timezone.Models;

public readonly struct SelectedZone
    {
    public readonly Zone Timezone {get; }
    public readonly bool IsDefault {get; }
    public SelectedZone(Zone? inTimezone, bool isDefault)
        {
        if (inTimezone != null)
            Timezone = inTimezone.Value;

        IsDefault = isDefault;
        }
    }
