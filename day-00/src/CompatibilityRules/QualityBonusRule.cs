namespace SockMatch.CompatibilityRules;

internal sealed class QualityBonusRule : ICompatibilityRule
{
    private const int QualityBonus = 5;

    public int PointsFor(Sock lonelySock, Sock sockFromStock)
        => lonelySock.Pattern == sockFromStock.Pattern
           && lonelySock.Color == sockFromStock.Color
           && lonelySock.Material == sockFromStock.Material
           && lonelySock.Size == sockFromStock.Size
           && lonelySock.Warmth == sockFromStock.Warmth
            ? QualityBonus
            : 0;
}