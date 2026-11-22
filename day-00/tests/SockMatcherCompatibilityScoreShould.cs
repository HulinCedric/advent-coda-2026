using FluentAssertions;
using static SockMatch.Tests.Socks;

namespace SockMatch.Tests;

public class SockMatcherCompatibilityScoreShould
{
    [Fact]
    public void Be_0_When_Nothing_Is_In_Common()
        => LonelySock.CompatibilityWith(TotallyDifferentSock)
            .Should()
            .Be(0);

    [Fact]
    public void Be_25_When_Only_Patterns_Are_The_Same()
        => LonelySock.CompatibilityWith(TotallyDifferentSock.WithSamePatternAs(LonelySock))
            .Should()
            .Be(25);

    [Fact]
    public void Be_20_When_Only_Colors_Are_The_Same()
        => LonelySock.CompatibilityWith(TotallyDifferentSock.WithSameColorAs(LonelySock))
            .Should()
            .Be(20);

    [Fact]
    public void Be_20_When_Only_Materials_Are_The_Same()
        => LonelySock.CompatibilityWith(TotallyDifferentSock with { Material = LonelySock.Material })
            .Should()
            .Be(20);
}