namespace SockMatch.CompatibilityRules;

internal sealed class MaterialRule : ICompatibilityRule
{
    private const int IdenticalMaterialPoints = 20;

    public int PointsFor(Sock lonelySock, Sock sockFromStock)
        => lonelySock.Material == sockFromStock.Material ? IdenticalMaterialPoints : 0;
}