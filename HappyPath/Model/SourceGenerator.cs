using System.Text.Json.Serialization;

namespace HappyPath.Model;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Mood))]
[JsonSerializable(typeof(Result))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}