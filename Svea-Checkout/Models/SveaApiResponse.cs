namespace Svea.Checkout.Models
{
    public class SveaApiResponse<T> {
        public T Data { get; set; }
        public bool Success { get; set; }
        public int HttpStatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
