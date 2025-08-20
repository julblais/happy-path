using System.Text.Json.Serialization;

namespace HappyPath.Model;

public readonly record struct Result
{
    [JsonPropertyName("category")]
    public string Category { get; init; }
    
    [JsonPropertyName("mood")]
    public Mood Mood { get; init; }
    
    [JsonPropertyName("reason")]
    public string Reason { get; init; }
}