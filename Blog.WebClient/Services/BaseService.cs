using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Blog.WebClient.Services;

public class BaseService<T> : IBaseService<T>
    where T : class
{
    [Inject]
    protected HttpClient Http { get; set; }
    protected readonly JsonSerializerOptions options;

    public string ControllerName { get; set; } = string.Empty;

    public BaseService(HttpClient client)
    {
        Http = client;
        options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
        };
    }

    public async Task<List<T>> GetListAsync()
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"api/{ControllerName}");
        request.SetBrowserRequestCache(BrowserRequestCache.NoCache);
        using var response = await Http.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<T>>(options) ?? [];          
        }
        return [];
    }

    public async Task<T?> GetById(int id)
    {
        var response = await Http.GetAsync($"api/{ControllerName}/{id}");
        return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<T>(options) : null;
    }   

    public async Task<T?> InsertAsync(T entity)
    {
        var httpResponse = await Http.PostAsJsonAsync($"api/{ControllerName}", entity, options);
        return httpResponse.IsSuccessStatusCode ? await httpResponse.Content.ReadFromJsonAsync<T>(options) : null;
    }

    public async Task UpdateAsync(T entity)
    {
        await Http.PutAsJsonAsync($"api/{ControllerName}", entity, options);       
    }

    public async Task<bool> DeleteAsync(int entityId)
    {
        var requestUri = $"api/{ControllerName}/{entityId}";
        var request = new HttpRequestMessage(HttpMethod.Delete, requestUri);
        var response = await Http.SendAsync(request);

        return response.IsSuccessStatusCode;
    }
}
