using System.Text.Json;
using System.Text;

namespace PruebaTecnica.Client.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient http)
        {
            _httpClient = http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            //Error en editar
            var RespGet = await _httpClient.GetAsync(url);
            if (RespGet.IsSuccessStatusCode)
            {
                var resp = await DeserializarRespuesta<T>(RespGet);
                return new HttpRespuesta<T>(resp, false, RespGet);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, RespGet);
            }
        }
        public async Task<HttpRespuesta<T>> Get2<T>(string url,string token)
        {
            
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Basic "+ token);
            var RespGet = await _httpClient.GetAsync(url);
            if (RespGet.IsSuccessStatusCode)
            {
                var resp = await DeserializarRespuesta<T>(RespGet);
                _httpClient.DefaultRequestHeaders.Clear();
                return new HttpRespuesta<T>(resp, false, RespGet);
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Clear();
                return new HttpRespuesta<T>(default, true, RespGet);
            }
        }
        public async Task<HttpRespuesta<object>> Post<T>(string url, T send)
        {
            try
            {
                var SendJson = JsonSerializer.Serialize(send);
                var SendContent = new StringContent(SendJson, Encoding.UTF8, "application/json");
                var RespPost = await _httpClient.PostAsync(url, SendContent);

                return new HttpRespuesta<object>(null, !RespPost.IsSuccessStatusCode, RespPost);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<HttpRespuesta<object>> Put<T>(string url, T send)
        {
            try
            {
                var SendJson = JsonSerializer.Serialize(send);
                var SendContent = new StringContent(SendJson, Encoding.UTF8, "application/json");
                var RespPut = await _httpClient.PutAsync(url, SendContent);

                return new HttpRespuesta<object>(null, !RespPut.IsSuccessStatusCode, RespPut);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<HttpRespuesta<object>> Delete(string url)
        {
            var RespDel = await _httpClient.DeleteAsync(url);
            return new HttpRespuesta<object>(null, !RespDel.IsSuccessStatusCode, RespDel);
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpRespuesta)
        {
            var RepuestaString = await httpRespuesta.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(RepuestaString,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}


