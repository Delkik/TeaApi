namespace TeaApi.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string? StatusDescription { get; set; }
        public IEnumerable<T>? Data { get; set; }
    }
}
