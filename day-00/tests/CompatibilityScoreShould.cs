using FluentAssertions;
using SockMatch.Tests.Setup;
using static SockMatch.Tests.Setup.Socks;

namespace SockMatch.Tests;

public class CompatibilityScoreShould
{
    [Fact]
    public void Be_0_When_The_Socks_Have_Nothing_In_Common()
        => LonelySock.CompatibilityWith(TotallyDifferentSock)
            .Should()
            .Be(0);

    [Fact]
    public void Give_25_Points_For_The_Same_Pattern()
        => LonelySock.CompatibilityWith(TotallyDifferentSock.WithSamePatternAs(LonelySock))
            .Should()
            .Be(25);

    [Fact]
    public void Give_20_Points_For_The_Same_Color()
        => LonelySock.CompatibilityWith(TotallyDifferentSock.WithSameColorAs(LonelySock))
            .Should()
            .Be(20);

    [Fact]
    public void Give_20_Points_For_The_Same_Material()
        => LonelySock.CompatibilityWith(TotallyDifferentSock.WithSameMaterialAs(LonelySock))
            .Should()
            .Be(20);

    [Theory]
    [InlineData(0, 20)]
    [InlineData(1, 16)]
    [InlineData(2, 12)]
    [InlineData(3, 8)]
    [InlineData(4, 4)]
    [InlineData(5, 0)]
    public void Give_Up_To_20_Points_For_Size_Minus_4_Per_Size_Apart(int sizesApart, int expectedScore)
        => LonelySock.CompatibilityWith(TotallyDifferentSock.WithSizeApartFrom(LonelySock, by: sizesApart))
            .Should()
            .Be(expectedScore);

    [Theory]
    [InlineData(0, 15)]
    [InlineData(1, 12)]
    [InlineData(2, 9)]
    [InlineData(3, 6)]
    [InlineData(4, 3)]
    [InlineData(5, 0)]
    public void Give_Up_To_15_Points_For_Warmth_Minus_3_Per_Point_Apart(int warmthPointsApart, int expectedScore)
        => LonelySock.CompatibilityWith(TotallyDifferentSock.WithWarmthApartFrom(LonelySock, by: warmthPointsApart))
            .Should()
            .Be(expectedScore);

    [Fact]
    public void Reach_105_With_The_Quality_Bonus_When_The_Socks_Are_Strictly_Identical()
        => LonelySock.CompatibilityWith(LonelySock.Twin())
            .Should()
            .Be(105);
}