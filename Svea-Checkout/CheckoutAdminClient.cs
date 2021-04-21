using System.Linq;
using System.Net.Http;
using Svea.Checkout.Exceptions;
using Svea.Checkout.Validation;

namespace Svea.Checkout
{
    public class CheckoutAdminClient
    {
        /// <summary>
        /// Base URL For Svea Checkout Administration Production server
        /// </summary>
        public const string PROD_ADMIN_BASE_URL = "https://paymentadminapi.svea.com";

        /// <summary>
        /// Base URL For Svea Checkout Administration Demo server
        /// </summary>
        public const string TEST_ADMIN_BASE_URL = "https://paymentadminapistage.svea.com";

        private readonly string _merchantId;
        private readonly string _sharedSecret;
        private readonly string _baseApiUrl;

        private static HttpClient ApiClient { get; set; }

        /// <summary>
        /// Creates a new instance of the CheckoutAdminClient that is used to communicate with the Svea API
        /// </summary>
        /// <param name="merchantId">Merchant Id, you get this from Svea</param>
        /// <param name="sharedSecret">Shared secret, you get this from Svea</param>
        /// <param name="baseApiUrl">Use one of <see cref="PROD_BASE_URL" /> or <see cref="TEST_BASE_URL" /></param>
        public CheckoutAdminClient(string merchantId, string sharedSecret, string baseApiUrl)
        {
            _merchantId = merchantId;
            _sharedSecret = sharedSecret;
            _baseApiUrl = baseApiUrl;

            if (ApiClient == null)
            {
                ApiClient = new HttpClient();
                ApiClient.DefaultRequestHeaders.Remove("User-Agent");
                ApiClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "MultiNet Svea Checkout Admin API Client");
            }

            ValidateData();
        }

        private void ValidateData()
        {
            ValidationService.MustNotBeEmpty(_merchantId, "Merchant Id");
            ValidationService.MustNotBeEmpty(_sharedSecret, "Shared secret");
            ValidationService.MustNotBeEmpty(_baseApiUrl, "Base Api Url");

            var validUrls = new[] { PROD_ADMIN_BASE_URL, TEST_ADMIN_BASE_URL };
            if (!validUrls.Contains(_baseApiUrl))
            {
                throw new SveaInputValidationException("Base Api Url must be one of the available constants in the CheckoutClient-class");
            }
        }
    }
}
