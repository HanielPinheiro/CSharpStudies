namespace Web.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(bool error, T? response, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }

        public T? Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetErrorMessage()
        {
            if (!Error) return null;

            var codeStatus = HttpResponseMessage.StatusCode;

            switch(codeStatus)
            {
                case System.Net.HttpStatusCode.NotFound:
                    return "Resource not found!";
                case System.Net.HttpStatusCode.BadRequest:
                    return await HttpResponseMessage.Content.ReadAsStringAsync();
                case System.Net.HttpStatusCode.Unauthorized:
                    return "The user credentials are not valid!";
                case System.Net.HttpStatusCode.Forbidden:
                    return "Permission denied!";
                default: 
                    return "An unpredictable error was mistake!";
            }
        }
    }
}
