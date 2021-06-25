using Ereceipt.API.Exceptions;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Ereceipt.API.Settings
{
    public class WebRequest
    {
        private string accessToken;
        private HttpClient httpClient;
        public WebRequest(string accessToken = "", int timeout = 20)
        {
            this.accessToken = accessToken;
            httpClient = new HttpClient();
            httpClient.DefaultRequestVersion = new Version("2.0");
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            if (!string.IsNullOrEmpty(accessToken))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
        public async Task<Response<T>> GetAsync<T>(string url)
        {
            var resposne = await httpClient.GetAsync(url);
            CheckResponse(resposne);
            var content = JsonSerializer.Deserialize<Response<T>>(await resposne.Content.ReadAsStringAsync());
            return content;
        }
        public async Task<Response<T>> PostAsync<T>(string url, object Data)
        {
            var con = JsonSerializer.Serialize(Data);
            var content = new StringContent(con, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var resposne = await httpClient.PostAsync(url, content);
            CheckResponse(resposne);
            return JsonSerializer.Deserialize<Response<T>>(await resposne.Content.ReadAsStringAsync());
        }
        public async Task<Response<T>> PostAsync<T>(string url)
        {
            var resposne = await httpClient.PostAsync(url, null);
            CheckResponse(resposne);
            return JsonSerializer.Deserialize<Response<T>>(await resposne.Content.ReadAsStringAsync());
        }
        public async Task<Response<T>> PutAsync<T>(string url, object Data)
        {
            var con = JsonSerializer.Serialize(Data);
            var content = new StringContent(con, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var resposne = await httpClient.PutAsync(url, content);
            CheckResponse(resposne);
            return JsonSerializer.Deserialize<Response<T>>(await resposne.Content.ReadAsStringAsync());
        }
        public async Task<Response<T>> DeleteAsync<T>(string url)
        {
            var resposne = await httpClient.DeleteAsync(url);
            CheckResponse(resposne);
            return JsonSerializer.Deserialize<Response<T>>(await resposne.Content.ReadAsStringAsync());
        }
        public async Task<Response<T>> DeleteAsync<T>(string url, object Data)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(Data), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url)
            };
            var resposne = await httpClient.SendAsync(request);


            //var resposne = await httpClient.DeleteAsync(url);
            CheckResponse(resposne);
            return JsonSerializer.Deserialize<Response<T>>(await resposne.Content.ReadAsStringAsync());
        }
        private void CheckResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException("User is unauthorized");
                throw new ApiErrorException("Response was returned as error");
            }
        }
    }
}