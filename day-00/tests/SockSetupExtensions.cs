namespace SockMatch.Tests;

public static class SockSetupExtensions
{
    extension(Sock sock)
    {
        public Sock WithSamePatternAs(Sock other) => sock with { Pattern = other.Pattern };
    }
}