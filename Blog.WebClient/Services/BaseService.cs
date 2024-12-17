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
        var result = await response.Content.ReadFromJsonAsync<List<T>>(options);
        return result;
    }

    public async Task<T> GetById(int id)
    {
        var response = await Http.GetAsync($"api/{ControllerName}/{id}");
        return !response.IsSuccessStatusCode ? Activator.CreateInstance<T>() : await response.Content.ReadFromJsonAsync<T>(options);
    }   

    public async Task<ServiceResult<T>> InsertAsync(T entity)
    {
        var httpResponse = await Http.PostAsJsonAsync($"api/{ControllerName}", entity, options);
        if (httpResponse.IsSuccessStatusCode)
        {
            return new ServiceResult<T>
            {
                Data = await httpResponse.Content.ReadFromJsonAsync<T>(options),
                IsSuccess = true
            };
        }

        return new ServiceResult<T>
        {
            IsSuccess = false,
            Response = httpResponse
        };
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var httpResponse = await Http.PutAsJsonAsync($"api/{ControllerName}", entity, options);
        return await httpResponse.Content.ReadFromJsonAsync<T>(options);
    }

    public async Task<bool> DeleteAsync(int entityId)
    {
        var requestUri = $"api/{ControllerName}/{entityId}";
        var request = new HttpRequestMessage(HttpMethod.Delete, requestUri);
        var response = await Http.SendAsync(request);

        return response.IsSuccessStatusCode;
    }
}
