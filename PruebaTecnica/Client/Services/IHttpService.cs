namespace PruebaTecnica.Client.Services
{
    public interface IHttpService
    {
        Task<HttpRespuesta<object>> Delete(string url);
        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<T>> Get2<T>(string url, string token);
        Task<HttpRespuesta<object>> Post<T>(string url, T send);
        Task<HttpRespuesta<object>> Put<T>(string url, T send);
    }
}
