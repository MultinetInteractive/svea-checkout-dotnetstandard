using Newtonsoft.Json;

namespace Svea.Checkout.Models
{
    /// <summary>
    /// <para>The final payment method for the order. Will only have a value when the order is finalized, otherwise null.</para>
    /// <para>Some payment methods might include unique fields that are not available on other payment methods.</para>
    /// </summary>
    public class PaymentInfo
    {
        /// <summary>
        /// The final payment method type for the order:
        /// <list type="bullet">
        /// <item><description>AccountCredit</description></item>
        /// <item><description>Card</description></item>
        /// <item><description>DirectBank</description></item>
        /// <item><description>Invoice</description></item>
        /// <item><description>Leasing</description></item>
        /// <item><description>PaymentPlan</description></item>
        /// <item><description>Trustly</description></item>
        /// </list>
        /// </summary>
        [JsonProperty("PaymentMethodType")]
        public string PaymentMethodType { get; set; }

        /// <summary>
        /// Only available for PaymentPlan
        /// </summary>
        [JsonProperty("CampaignCode")]
        public long? CampaignCode { get; set; }
    }
}
