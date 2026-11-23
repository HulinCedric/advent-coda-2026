namespace SockMatch.CompatibilityRules;

internal sealed class QualityBonusRule : ICompatibilityRule
{
    private const int QualityBonus = 5;

    public int PointsFor(Sock lonelySock, Sock sockFromStock)
        => lonelySock == sockFromStock ? QualityBonus : 0;
}