using HappyPath.Model;

namespace HappyPath.Providers;

public class MoodProvider(HttpClient client, Uri uri)
{
    public async Task<IEnumerable<string>> FetchCategories()
    {
        await Task.Delay(1000);
        //var results = await httpClient.GetFromJsonAsync<List<Result>>(fetchUrl);
        return new List<string>();
    }
}