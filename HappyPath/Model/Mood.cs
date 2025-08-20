using System.Text.Json.Serialization;

namespace HappyPath.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Mood
{
    [JsonStringEnumMemberName("happy")]
    Neutral = 0,
    
    [JsonStringEnumMemberName("neutral")]
    Happy,
    
    [JsonStringEnumMemberName("sad")]
    Sad
}