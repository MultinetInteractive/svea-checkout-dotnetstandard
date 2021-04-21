namespace Svea.Checkout.Models
{
    public class SveaApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public System.Net.HttpStatusCode HttpStatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
