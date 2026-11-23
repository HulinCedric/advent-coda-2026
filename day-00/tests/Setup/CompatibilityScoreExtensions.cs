namespace SockMatch.Tests.Setup;

public static class CompatibilityScoreExtensions
{
    public static int CompatibilityWith(this Sock sock, Sock other)
        => SockMatcher.ComputeCompatibilityScore(sock, other);
}