﻿using Ereceipt.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public WebRequest(string baseUrl, string accessToken = "", int timeout = 10)
        {
            this.accessToken = accessToken;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            if (!string.IsNullOrEmpty(accessToken))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public void SetAccessToken(string accessToken)
        {
            this.accessToken = accessToken;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<Response<T>> GetAsync<T>(string url)
        {
            var resposne = await httpClient.GetAsync(url);
            CheckResponse(resposne);
            return JsonSerializer.Deserialize<Response<T>>(await resposne.Content.ReadAsStringAsync());
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




        private void CheckResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApiErrorException("Response was returned as error");
        }
    }
}