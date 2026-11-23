using SockMatch.CompatibilityRules;

namespace SockMatch;

public static class SockMatcher
{
    private const int PairThreshold = 100;

    private static readonly PatternRule Pattern = new();
    private static readonly ColorRule Color = new();
    private static readonly MaterialRule Material = new();
    private static readonly SizeRule Size = new();
    private static readonly WarmthRule Warmth = new();
    private static readonly QualityBonusRule QualityBonus = new();

    public static int ComputeCompatibilityScore(Sock lonelySock, Sock sockFromStock)
    {
        var score = 0;

        score += PatternPoints(lonelySock, sockFromStock);
        score += ColorPoints(lonelySock, sockFromStock);
        score += MaterialPoints(lonelySock, sockFromStock);
        score += SizePoints(lonelySock, sockFromStock);
        score += WarmthPoints(lonelySock, sockFromStock);
        score += QualityBonusPoints(lonelySock, sockFromStock);

        return score;
    }

    public static bool IsPair(Sock lonelySock, Sock sockFromStock)
        => IsPair(ComputeCompatibilityScore(lonelySock, sockFromStock));

    public static bool IsPair(int compatibilityScore) => compatibilityScore >= PairThreshold;

    private static int PatternPoints(Sock lonelySock, Sock sockFromStock)
        => Pattern.PointsFor(lonelySock, sockFromStock);

    private static int ColorPoints(Sock lonelySock, Sock sockFromStock)
        => Color.PointsFor(lonelySock, sockFromStock);

    private static int MaterialPoints(Sock lonelySock, Sock sockFromStock)
        => Material.PointsFor(lonelySock, sockFromStock);

    private static int SizePoints(Sock lonelySock, Sock sockFromStock)
        => Size.PointsFor(lonelySock, sockFromStock);

    private static int WarmthPoints(Sock lonelySock, Sock sockFromStock)
        => Warmth.PointsFor(lonelySock, sockFromStock);

    private static int QualityBonusPoints(Sock lonelySock, Sock sockFromStock)
        => QualityBonus.PointsFor(lonelySock, sockFromStock);
}