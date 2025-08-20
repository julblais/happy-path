namespace HappyPath.Model;

public readonly record struct Result
{
    public Mood mood { get; init; }
    public string reason { get; init; }
}