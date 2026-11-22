using FluentAssertions;

namespace SockMatch.Tests;

public class SockMatcherIsPairShould
{
    [Theory]
    [InlineData(0)]
    [InlineData(99)]
    public void Be_False_When_Score_Is_Below_100(int compatibilityScore)
        => SockMatcher.IsPair(compatibilityScore)
            .Should()
            .BeFalse();

    [Theory]
    [InlineData(100)]
    [InlineData(105)]
    public void Be_True_When_Score_Is_100_Or_More(int compatibilityScore)
        => SockMatcher.IsPair(compatibilityScore)
            .Should()
            .BeTrue();
}