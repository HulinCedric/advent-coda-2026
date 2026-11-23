namespace SockMatch;

public static class SockMatcher
{
    private const int PatternWeight = 25;
    private const int ColorWeight = 20;
    private const int MaterialWeight = 20;
    private const int SizeWeight = 20;
    private const int SizePenaltyPerPoint = 4;
    private const int WarmthWeight = 15;
    private const int WarmthPenaltyPerPoint = 3;
    private const int MatchBonus = 5;
    private const int PerfectMatchScore = 100;

    public static int ComputeCompatibilityScore(Sock a, Sock b)
    {
        var score = 0;

        var samePattern = a.Pattern == b.Pattern;
        var sameColor = a.Color == b.Color;
        var sameMaterial = a.Material == b.Material;
        var sameSize = a.Size == b.Size;
        var sameWarmth = a.Warmth == b.Warmth;

        score += PatternPoints(a, b);
        score += ColorPoints(a, b);
        score += MaterialPoints(a, b);
        score += SizePoints(a, b);
        score += WarmthPoints(a, b);

        if (samePattern && sameColor && sameMaterial && sameSize && sameWarmth)
            score += MatchBonus;

        return score;
    }

    public static bool IsPair(Sock a, Sock b) => IsPair(ComputeCompatibilityScore(a, b));

    public static bool IsPair(int compatibilityScore) => compatibilityScore >= PerfectMatchScore;

    private static int PatternPoints(Sock a, Sock b) => a.Pattern == b.Pattern ? PatternWeight : 0;

    private static int ColorPoints(Sock a, Sock b) => a.Color == b.Color ? ColorWeight : 0;

    private static int MaterialPoints(Sock a, Sock b) => a.Material == b.Material ? MaterialWeight : 0;

    private static int SizePoints(Sock a, Sock b)
        => Math.Max(0, SizeWeight - Math.Abs(a.Size - b.Size) * SizePenaltyPerPoint);

    private static int WarmthPoints(Sock a, Sock b)
        => Math.Max(0, WarmthWeight - Math.Abs(a.Warmth - b.Warmth) * WarmthPenaltyPerPoint);
}