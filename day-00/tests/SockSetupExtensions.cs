namespace SockMatch.Tests;

public static class SockSetupExtensions
{
    extension(Sock sock)
    {
        public Sock WithSamePatternAs(Sock other) => sock with { Pattern = other.Pattern };
        public Sock WithSameColorAs(Sock other) => sock with { Color = other.Color };
        public Sock WithSameMaterialAs(Sock other) => sock with { Material = other.Material };
        public Sock WithSizeApartFrom(Sock other, int by) => sock with { Size = other.Size + by };
    }
}