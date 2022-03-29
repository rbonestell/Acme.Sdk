using System.Text;
using Newtonsoft.Json;

namespace Acme.Common.Utils;

public static class ServiceClient
{

    public enum Endpoint
    {
        Math
    }

    /// <summary>
    /// Serialize request object and post data to specified endpoint
    /// </summary>
    /// <returns>Response data deserialized to expected <typeparamref name="T"/> type</returns>
    /// <param name="requestObject">Object to serialize for request body</param>
    /// <param name="endpoint">Destination URL</param>
    /// <typeparam name="T">Type to which response content should be deserialized</typeparam>
    public static async Task<T> Post<T>(object requestObject, Endpoint endpoint, string path)
    {
        path = SetEndpointHost(endpoint, path);
        StringContent requestContent = new(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json");
        using HttpClient client = new();
        using HttpResponseMessage response = await client.PostAsync(path, requestContent);
        if (!response.IsSuccessStatusCode)
        {
            // TODO: Add logging!
            throw new HttpRequestException(string.Format("HTTP {0} Response: {1}", response.StatusCode, response.ReasonPhrase));
        }
        using HttpContent content = response.Content;
        string responseData = await content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(responseData)!;
        return result;
    }

    /// <summary>
    /// Sets the endpoint host.
    /// </summary>
    /// <returns>The endpoint host.</returns>
    /// <param name="endpoint">Endpoint</param>
    /// <param name="path">Path</param>
    private static string SetEndpointHost(Endpoint endpoint, string path)
    {
        switch (endpoint)
        {
            case Endpoint.Math:
                path = "http://acme.sdk.math/" + path;
                break;
        }
        return path;
    }
}
