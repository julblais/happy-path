using System.Text.Json.Serialization;

namespace HappyPath.Model;

[JsonConverter(typeof(JsonStringEnumConverter<Mood>))]
public enum Mood
{
    [JsonStringEnumMemberName("happy")]
    Neutral = 0,
    
    [JsonStringEnumMemberName("neutral")]
    Happy,
    
    [JsonStringEnumMemberName("sad")]
    Sad
}