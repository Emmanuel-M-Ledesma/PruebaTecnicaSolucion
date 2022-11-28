namespace PruebaTecnica.Client.Services
{
    public class HttpRespuesta<T>
    {
        public T Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage httpresponsemessage { get; }

        public HttpRespuesta(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            this.httpresponsemessage = httpResponseMessage;
        }

        public async Task<string> GetBody()
        {
            var resp = await httpresponsemessage.Content.ReadAsStringAsync();
            return resp;
        }
    }
}
