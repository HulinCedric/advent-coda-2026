using FluentAssertions;
using static SockMatch.Tests.Socks;

namespace SockMatch.Tests;

public class SockMatcherCompatibilityScoreShould
{
    [Fact]
    public void Be_0_When_Nothing_Is_In_Common()
        => SockMatcher.ComputeCompatibilityScore(LonelySock, TotallyDifferentSock)
            .Should()
            .Be(0);

    [Fact]
    public void Be_25_When_Only_Patterns_Are_The_Same()
    {
        var other = TotallyDifferentSock.WithSamePatternAs(LonelySock);

        SockMatcher.ComputeCompatibilityScore(LonelySock, other)
            .Should()
            .Be(25);
    }
}