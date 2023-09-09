using System.Text;
using System.Text.Json;

namespace Web.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions JsonDefaultOptions => new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Post
        public async Task<HttpResponseWrapper<TResponse>> Post<TResponse>(string url)
        {
            var messageContent = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, messageContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<TResponse>(responseHttp, JsonDefaultOptions);
                return new HttpResponseWrapper<TResponse>(false, response, responseHttp);
            }
            return new HttpResponseWrapper<TResponse>(true, default, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, messageContent);
            return new HttpResponseWrapper<object>(!responseHttp.IsSuccessStatusCode, null, responseHttp);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, messageContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<TResponse>(responseHttp, JsonDefaultOptions);
                return new HttpResponseWrapper<TResponse>(false, response, responseHttp);
            }
            return new HttpResponseWrapper<TResponse>(!responseHttp.IsSuccessStatusCode, default, responseHttp);
        }
        #endregion

        #region Put
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PutAsync(url, messageContent);
            return new HttpResponseWrapper<object>(!responseHttp.IsSuccessStatusCode, null, responseHttp);
        }

        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PutAsync(url, messageContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<TResponse>(responseHttp, JsonDefaultOptions);
                return new HttpResponseWrapper<TResponse>(false, response, responseHttp);
            }
            return new HttpResponseWrapper<TResponse>(!responseHttp.IsSuccessStatusCode, default, responseHttp);
        }
        #endregion

        #region Delete
        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHttp = await _httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(false, null, responseHttp);
        }
        #endregion

        private async Task<T> UnserializeAnswer<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var stringAnswer = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(stringAnswer, jsonSerializerOptions)!;
        }
    }
}
