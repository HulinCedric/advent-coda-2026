namespace SockMatch;

public static class SockMatcher
{
    private const int IdenticalPatternPoints = 25;
    private const int IdenticalColorPoints = 20;
    private const int IdenticalMaterialPoints = 20;
    private const int MaxSizePoints = 20;
    private const int PenaltyPerSizeApart = 4;
    private const int MaxWarmthPoints = 15;
    private const int PenaltyPerWarmthPointApart = 3;
    private const int QualityBonus = 5;
    private const int PairThreshold = 100;

    public static int ComputeCompatibilityScore(Sock lonelySock, Sock sockFromStock)
    {
        var score = 0;

        var identicalPattern = lonelySock.Pattern == sockFromStock.Pattern;
        var identicalColor = lonelySock.Color == sockFromStock.Color;
        var identicalMaterial = lonelySock.Material == sockFromStock.Material;
        var identicalSize = lonelySock.Size == sockFromStock.Size;
        var identicalWarmth = lonelySock.Warmth == sockFromStock.Warmth;

        score += PatternPoints(lonelySock, sockFromStock);
        score += ColorPoints(lonelySock, sockFromStock);
        score += MaterialPoints(lonelySock, sockFromStock);
        score += SizePoints(lonelySock, sockFromStock);
        score += WarmthPoints(lonelySock, sockFromStock);

        if (identicalPattern && identicalColor && identicalMaterial && identicalSize && identicalWarmth)
            score += QualityBonus;

        return score;
    }

    public static bool IsPair(Sock lonelySock, Sock sockFromStock)
        => IsPair(ComputeCompatibilityScore(lonelySock, sockFromStock));

    public static bool IsPair(int compatibilityScore) => compatibilityScore >= PairThreshold;

    private static int PatternPoints(Sock lonelySock, Sock sockFromStock)
        => lonelySock.Pattern == sockFromStock.Pattern ? IdenticalPatternPoints : 0;

    private static int ColorPoints(Sock lonelySock, Sock sockFromStock)
        => lonelySock.Color == sockFromStock.Color ? IdenticalColorPoints : 0;

    private static int MaterialPoints(Sock lonelySock, Sock sockFromStock)
        => lonelySock.Material == sockFromStock.Material ? IdenticalMaterialPoints : 0;

    private static int SizePoints(Sock lonelySock, Sock sockFromStock)
        => Math.Max(0, MaxSizePoints - Math.Abs(lonelySock.Size - sockFromStock.Size) * PenaltyPerSizeApart);

    private static int WarmthPoints(Sock lonelySock, Sock sockFromStock)
        => Math.Max(0, MaxWarmthPoints - Math.Abs(lonelySock.Warmth - sockFromStock.Warmth) * PenaltyPerWarmthPointApart);
}