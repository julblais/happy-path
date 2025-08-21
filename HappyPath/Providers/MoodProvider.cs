using System.Net.Http.Json;
using System.Text.Json;
using HappyPath.Model;

namespace HappyPath.Providers;

public class MoodProvider(HttpClient client, Uri uri)
{
    readonly SourceGenerationContext m_Context = new();
    
    static string[] ExcludedCategories =
    [
        "Date", "Reason", "Raison"
    ];
    
    public async Task<(string error, string[])> FetchCategories()
    {
        await Task.Delay(1000);
        try
        {
            var result = await client.GetFromJsonAsync(uri, m_Context.StringArray);
            return (null, result.Except(ExcludedCategories).ToArray());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending results: {ex.Message}");
            return (ex.Message, []);
        }
    }

    public async Task<string> SendResult(IEnumerable<Result> results)
    {
        await Task.Delay(1000);
        try
        {
            var content = JsonSerializer.Serialize(results.ToArray(), m_Context.ResultArray);
            Console.WriteLine("Sending: " + content);
            HttpContent c = new StringContent(content);
            var result = await client.PostAsync(uri, c);
            return result.IsSuccessStatusCode ? null : result.ReasonPhrase;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending results: {ex.Message}");
            return ex.Message;
        }
    }
}