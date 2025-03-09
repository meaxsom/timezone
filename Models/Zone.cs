namespace timezone.Models;

public readonly struct Zone
{
    public String Name {get; }
    public int Offset {get; }
    public int DSTOffset {get; }
    public Zone(String inName, int inOffset, int inDSTOffset)
        {
        Name = inName;
        Offset = inOffset;
        DSTOffset = inDSTOffset;
        }
    }