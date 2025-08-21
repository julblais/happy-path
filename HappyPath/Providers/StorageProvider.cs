namespace HappyPath.Providers;

public static class StorageProvider
{
    const string LocalStorageKey = "sheet-url";
    
    public static async Task<Uri> GetApiUrlAsync(Blazored.LocalStorage.ILocalStorageService localStorage)
    {
        if (await localStorage.ContainKeyAsync(LocalStorageKey))
        {
            var url = await localStorage.GetItemAsync<string>(LocalStorageKey);
            return new Uri(url);
        }

        return null;
    }
    
    public static async Task SetApiUrlAsync(Blazored.LocalStorage.ILocalStorageService localStorage, Uri url)
    {
        await localStorage.SetItemAsync(LocalStorageKey, url.ToString());
    }
    
    public static async Task Reset(Blazored.LocalStorage.ILocalStorageService localStorage)
    {
        await localStorage.RemoveItemAsync(LocalStorageKey);
    }
}