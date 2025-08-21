using System.Text.Json.Serialization;

namespace HappyPath.Model;

[JsonConverter(typeof(JsonStringEnumConverter<Mood>))]
public enum Mood
{
    [JsonStringEnumMemberName("neutral")]
    Neutral = 0,
    
    [JsonStringEnumMemberName("happy")]
    Happy,
    
    [JsonStringEnumMemberName("sad")]
    Sad
}