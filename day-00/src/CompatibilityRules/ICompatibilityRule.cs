namespace SockMatch.CompatibilityRules;

internal interface ICompatibilityRule
{
    int PointsFor(Sock lonelySock, Sock sockFromStock);
}