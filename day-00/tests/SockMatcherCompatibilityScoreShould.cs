using FluentAssertions;

namespace SockMatch.Tests;

public class SockMatcherCompatibilityScoreShould
{
    private static readonly Sock Scanned = new(36, "rouge", "laine", "rayures", 1);
    private static readonly Sock NothingInCommon = new(46, "bleu", "coton", "pois", 10);

    [Fact]
    public void Be_0_When_Nothing_Is_In_Common()
        => SockMatcher.ComputeCompatibilityScore(Scanned, NothingInCommon)
            .Should()
            .Be(0);
}