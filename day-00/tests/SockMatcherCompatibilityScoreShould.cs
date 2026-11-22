using FluentAssertions;

namespace SockMatch.Tests;

public class SockMatcherCompatibilityScoreShould
{
    private static readonly Sock LonelySock = new(36, "rouge", "laine", "rayures", 1);
    private static readonly Sock TotallyDifferentSock = new(46, "bleu", "coton", "pois", 10);

    [Fact]
    public void Be_0_When_Nothing_Is_In_Common()
        => SockMatcher.ComputeCompatibilityScore(LonelySock, TotallyDifferentSock)
            .Should()
            .Be(0);

    [Fact]
    public void Be_25_When_Only_Patterns_Are_The_Same()
    {
        var other = TotallyDifferentSock with { Pattern = LonelySock.Pattern };

        SockMatcher.ComputeCompatibilityScore(LonelySock, other)
            .Should()
            .Be(25);
    }
}