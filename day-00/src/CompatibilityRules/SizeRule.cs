namespace SockMatch.CompatibilityRules;

internal sealed class SizeRule : ICompatibilityRule
{
    private const int MaxPoints = 20;
    private const int PenaltyPerSizeApart = 4;

    public int PointsFor(Sock lonelySock, Sock sockFromStock)
        => Math.Max(0, MaxPoints - Math.Abs(lonelySock.Size - sockFromStock.Size) * PenaltyPerSizeApart);
}