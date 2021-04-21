using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Svea.Checkout.Models
{
    /// <summary>
    /// <para>At certain points in an order’s lifetime, we will attempt to call endpoints on your side. You provide the URI:s for these endpoints in the MerchantSettings object when you call CreateOrder.</para>
    /// <para>Make sure that your server accepts calls to these URIs and that your firewall whitelists connections from our IP-range: <c>193.13.207/24</c>. Some URIs, for example <c>localhost</c> and <c>svea.com</c>, are blocked and no callback will be made.</para>
    /// </summary>
    public class MerchantSettings
    {
        /// <summary>
        /// <para>An optional URI to a location that expects callbacks from the Checkout to validate an order’s stock status It also has the possibility to update the checkout with an updated ClientOrderNumber.</para>
        /// <para>May contain a <c>{checkout.order.uri}</c> placeholder which will be replaced with the checkoutorderid.</para>
        /// <para>Requests for this endpoint are made with HTTP Method GET.</para>
        /// <para>
        /// Your response's HTTP Status Code is interpreted as:
        /// <list type="bullet">
        /// <item><description>200-299 is interpreted as validation passed.</description></item>
        /// <item><description>Everything else is interpreted as validation failure.</description></item>
        /// </list>
        /// </para>
        /// <para>See CheckoutValidationCallbackResponse for a description of the expected response content.</para>
        /// </summary>
        /// <remarks>Data type: Url. Max length: 500.</remarks>
        [JsonProperty("CheckoutValidationCallBackUri")]
        public Uri CheckoutValidationCallBackUri { get; set; }

        /// <summary>
        /// <para>URI to a location that expects callbacks from the Checkout whenever an order’s state is changed (confirmed, final, etc.).</para>
        /// <para>May contain a <c>{checkout.order.uri}</c> placeholder which will be replaced with the checkoutorderid.</para>
        /// <para>Requests for this endpoint are made with HTTP Method POST.</para>
        /// <para>
        /// Your response's HTTP Status Code is interpreted as:
        /// <list type="bullet">
        /// <item><description>100-199 are ignored.</description></item>
        /// <item><description>200-299 is interpreted as OK.</description></item>
        /// <item><description>300-399 are ignored.</description></item>
        /// <item><description>404 - the order hasn't been created on your side yet. We will try pushing again. All other 400 status codes are ignored.</description></item>
        /// <item><description>500 and above is interpreted as error on your side. We will try pushing again.</description></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <remarks>Required. Data type: Url. Max length: 500. Min length: 1.</remarks>
        [JsonProperty("PushUri")]
        public Uri PushUri { get; set; }

        /// <summary>
        /// URI to a page with webshop specific terms.
        /// </summary>
        /// <remarks>Required. Data type: Url. Max length: 500. Min length: 1.</remarks>
        [JsonProperty("TermsUri")]
        public Uri TermsUri { get; set; }

        /// <summary>
        /// URI to the page in the webshop displaying the Checkout. May not contain order specific information.
        /// </summary>
        /// <remarks>Required. Data type: Url. Max length: 500. Min length: 1.</remarks>
        [JsonProperty("CheckoutUri")]
        public Uri CheckoutUri { get; set; }

        /// <summary>
        /// URI to the page in the webshop displaying specific information to a customer after the order has been confirmed. May not contain order specific information.
        /// </summary>
        /// <remarks>Required. Data type: Url. Max length: 500. Min length: 1.</remarks>
        [JsonProperty("ConfirmationUri")]
        public Uri ConfirmationUri { get; set; }

        /// <summary>
        /// List of valid CampaignIDs. If used, a list of available part payment campaign options will be filtered through the chosen list.
        /// </summary>
        [JsonProperty("ActivePartPaymentCampaigns")]
        public List<long> ActivePartPaymentCampaigns { get; set; }

        /// <summary>
        /// If used, the chosen campaign will be listed first in all payment method lists.
        /// </summary>
        [JsonProperty("PromotedPartPaymentCampaign")]
        public long? PromotedPartPaymentCampaign { get; set; }
    }
}
