namespace SockMatch.CompatibilityRules;

internal sealed class WarmthRule : ICompatibilityRule
{
    private const int MaxPoints = 15;
    private const int PenaltyPerWarmthPointApart = 3;

    public int PointsFor(Sock lonelySock, Sock sockFromStock)
        => Math.Max(0, MaxPoints - Math.Abs(lonelySock.Warmth - sockFromStock.Warmth) * PenaltyPerWarmthPointApart);
}