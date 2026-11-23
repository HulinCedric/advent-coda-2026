using SockMatch.CompatibilityRules;

namespace SockMatch;

public static class SockMatcher
{
    private const int PairThreshold = 100;

    private static readonly ICompatibilityRule[] CompatibilityRules =
    [
        new PatternRule(),
        new ColorRule(),
        new MaterialRule(),
        new SizeRule(),
        new WarmthRule(),
        new QualityBonusRule()
    ];

    public static int ComputeCompatibilityScore(Sock lonelySock, Sock sockFromStock)
        => CompatibilityRules.Sum(rule => rule.PointsFor(lonelySock, sockFromStock));

    public static bool IsPair(Sock lonelySock, Sock sockFromStock)
        => IsPair(ComputeCompatibilityScore(lonelySock, sockFromStock));

    public static bool IsPair(int compatibilityScore) => compatibilityScore >= PairThreshold;
}