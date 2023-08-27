namespace Web.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<TResponse>> Post<TResponse>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);
    }
}
