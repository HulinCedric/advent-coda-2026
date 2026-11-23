namespace SockMatch.CompatibilityRules;

internal sealed class ColorRule : ICompatibilityRule
{
    private const int IdenticalColorPoints = 20;

    public int PointsFor(Sock lonelySock, Sock sockFromStock)
        => lonelySock.Color == sockFromStock.Color ? IdenticalColorPoints : 0;
}