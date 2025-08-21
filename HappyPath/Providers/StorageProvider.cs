namespace HappyPath.Providers;

public static class StorageProvider
{
    const string LocalUriKey = "sheet-url";
    const string LocalCategoryCacheKey = "categorie-cache";
    
    public static async Task<Uri> GetApiUrlAsync(Blazored.LocalStorage.ILocalStorageService localStorage)
    {
        if (await localStorage.ContainKeyAsync(LocalUriKey))
        {
            var url = await localStorage.GetItemAsync<string>(LocalUriKey);
            return new Uri(url);
        }

        return null;
    }
    
    public static async Task SetApiUrlAsync(Blazored.LocalStorage.ILocalStorageService localStorage, Uri url)
    {
        await localStorage.SetItemAsync(LocalUriKey, url.ToString());
    }

    public static async Task<string[]> GetCachedCategories(Blazored.LocalStorage.ILocalStorageService localStorage)
    {
        if (await localStorage.ContainKeyAsync(LocalCategoryCacheKey))
           return await localStorage.GetItemAsync<string[]>(LocalCategoryCacheKey);

        return null;
    }
    
    public static async Task SetCachedCategories(Blazored.LocalStorage.ILocalStorageService localStorage, string[] categories)
    {
        await localStorage.SetItemAsync(LocalCategoryCacheKey, categories);
    }
    
    public static async Task Reset(Blazored.LocalStorage.ILocalStorageService localStorage)
    {
        await localStorage.RemoveItemAsync(LocalUriKey);
        await localStorage.RemoveItemAsync(LocalCategoryCacheKey);
    }
}