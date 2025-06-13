namespace MyTask.Api.Client.Interface
{
    public interface ICookieService
    {
        public Task SetToken(HttpResponse response, string token);
    }
}
