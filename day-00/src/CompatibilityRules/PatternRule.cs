namespace SockMatch.CompatibilityRules;

internal sealed class PatternRule : ICompatibilityRule
{
    private const int IdenticalPatternPoints = 25;

    public int PointsFor(Sock lonelySock, Sock sockFromStock)
        => lonelySock.Pattern == sockFromStock.Pattern ? IdenticalPatternPoints : 0;
}