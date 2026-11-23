using FluentAssertions;

namespace SockMatch.Tests;

public class TwoSocksShould
{
    [Theory]
    [InlineData(0)]
    [InlineData(99)]
    public void Not_Form_A_Pair_Until_Their_Compatibility_Score_Reaches_100(int compatibilityScore)
        => SockMatcher.IsPair(compatibilityScore)
            .Should()
            .BeFalse();

    [Theory]
    [InlineData(100)]
    [InlineData(105)]
    public void Form_A_Pair_As_Soon_As_Their_Compatibility_Score_Reaches_100(int compatibilityScore)
        => SockMatcher.IsPair(compatibilityScore)
            .Should()
            .BeTrue();
}