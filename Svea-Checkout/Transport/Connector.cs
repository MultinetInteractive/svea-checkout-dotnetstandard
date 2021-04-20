using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Svea.Checkout.Models;

namespace Svea.Checkout.Transport
{
    /// <summary>
    /// Used for authentication and connect with Svea Checkout API over HTTP.
    /// </summary>
    public class Connector
    {
        /// <summary>
        /// Base URL For Svea Checkout Production server
        /// </summary>
        public const string PROD_BASE_URL = "https://checkoutapi.svea.com";

        /// <summary>
        /// Base URL For Svea Checkout Demo server
        /// </summary>
        public const string TEST_BASE_URL = "https://checkoutapistage.svea.com";

        /// <summary>
        /// Base URL For Svea Checkout Administration Production server
        /// </summary>
        public const string PROD_ADMIN_BASE_URL = "https://paymentadminapi.svea.com";

        /// <summary>
        /// Base URL For Svea Checkout Administration Demo server
        /// </summary>
        public const string TEST_ADMIN_BASE_URL = "https://paymentadminapistage.svea.com";

        /// <summary>
        /// <para>This request creates a new order and returns the checkout to the webshop.</para>
        /// <para>You can add preset values to the call, as well. These values will prefill the identification in the checkout. If a preset value has IsReadOnly, the customer will not be able to modify the value.</para>
        /// </summary>
        /// <param name="data"><see cref="CreateOrderModel" /></param>
        /// <returns><see cref="CheckoutOrder" /></returns>
        internal Task<CheckoutOrder> CreateOrderAsync(CreateOrderModel data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This request replaces the order rows of the specified order with the new appended in the call and sets the MerchantData on the order to the provided value.
        /// <para>HTTP status code 200 indicates success, everything else indicates a failure.</para>
        /// </summary>
        /// <param name="orderId">The order Id you got from either <see cref="GetOrderAsync" /> or have stored since earlier</param>
        /// <param name="data"><see cref="UpdateOrderModel" /></param>
        /// <returns><see cref="CheckoutOrder" /></returns>
        internal Task<CheckoutOrder> UpdateOrderAsync(long orderId, UpdateOrderModel data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This request returns a data structure that contains all information about the order and what is needed for the GUI.
        /// <para>HTTP status code 200 indicates success, everything else indicates a failure.</para>
        /// </summary>
        /// <param name="orderId">Checkoutorderid of the specified order.</param>
        /// <returns><see cref="CheckoutOrder" /></returns>
        internal Task<CheckoutOrder> GetOrderAsync(long orderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This request returns a list of available B2C/B2B part payment campaigns.
        /// <para>HTTP status code 200 indicates success, everything else indicates a failure.</para>
        /// </summary>
        /// <param name="isCompany">True for B2B, false for B2C</param>
        /// <returns>Collection of <see cref="CampaignCodeInfo" /></returns>
        internal Task<List<CampaignCodeInfo>> GetAvailablePartPaymentCampaignsAsync(bool isCompany)
        {
            throw new NotImplementedException();
        }
    }
}
