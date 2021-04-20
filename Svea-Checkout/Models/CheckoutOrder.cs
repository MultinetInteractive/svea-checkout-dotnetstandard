using Newtonsoft.Json;

namespace Svea.Checkout.Models
{
    public class CheckoutOrder
    {
        /// <summary>
        /// Specific merchant URIs
        /// </summary>
        [JsonProperty("MerchantSettings")]
        public MerchantSettings MerchantSettings { get; set; }

        /// <summary>
        /// Order rows.
        /// </summary>
        [JsonProperty("Cart")]
        public Cart Cart { get; set; }

        /// <summary>
        /// Identified customer of the order.
        /// </summary>
        [JsonProperty("Customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Shipping address of identified customer.
        /// </summary>
        [JsonProperty("ShippingAddress")]
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Billing address of identified customer.
        /// </summary>
        [JsonProperty("BillingAddress")]
        public Address BillingAddress { get; set; }

        /// <summary>
        /// The snippet with HTML to output
        /// </summary>
        [JsonProperty("Gui")]
        public Gui Gui { get; set; }

        /// <summary>
        /// The current locale of the checkout, i.e.sv-SE etc.
        /// </summary>
        [JsonProperty("Locale")]
        public string Locale { get; set; }

        /// <summary>
        /// The current currency as defined by ISO 4217, i.e. SEK, NOK etc.
        /// </summary>
        [JsonProperty("Currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Defined by two-letter ISO 3166-1 alpha-2, i.e. SE, DE, FI etc.
        /// </summary>
        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ClientOrderNumber")]
        public string ClientOrderNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("OrderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// The customer’s email address
        /// </summary>
        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The customer’s phone number
        /// </summary>
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The final payment method for the order. Will only have a value when the order is finalized, otherwise null.
        /// <list type="bullet">
        /// <item><description>INVOICE</description></item>
        /// <item><description>ADMININVOICE</description></item>
        /// <item><description>ACCOUNT</description></item>
        /// <item><description>PAYMENTPLAN</description></item>
        /// <item><description>SVEACARDPAY</description></item>
        /// <item><description>SVEACARDPAY_PF</description></item>
        /// <item><description>Or one of the following direct bank types. (For the most recent list of available banks check the Payment Gateway documentation.)
        /// <list type="bullet">
        ///   <item><description>BANKAXESS (BankAxess, Norway)</description></item>
        ///   <item><description>DBAKTIAFI (Aktia, Finland)</description></item>
        ///   <item><description>DBALANDSBANKENFI (Ålandsbanken, Finland)</description></item>
        ///   <item><description>DBDANSKEBANKSE (Danske bank, Sweden)</description></item>
        ///   <item><description>DBNORDEAFI (Nordea, Finland)</description></item>
        ///   <item><description>DBNORDEASE (Nordea, Sweden)</description></item>
        ///   <item><description>DBPOHJOLAFI (OP-Pohjola, Finland)</description></item>
        ///   <item><description>DBSAMPOFI (Sampo, Finland)</description></item>
        ///   <item><description>DBSEBSE (SEB, Individuals, Sweden)</description></item>
        ///   <item><description>DBSEBFTGSE (SEB, companies, Sweden)</description></item>
        ///   <item><description>DBSHBSE (Handelsbanken, Sweden)</description></item>
        ///   <item><description>DBSPANKKIFI (S-Pankki, Finland)</description></item>
        ///   <item><description>DBSWEDBANKSE (Swedbank, Sweden)</description></item>
        ///   <item><description>DBTAPIOLAFI (Tapiola, Finland)</description></item>
        ///   </list>
        ///   </description></item>
        ///   </list>
        /// </summary>
        [JsonProperty("PaymentType")]
        public string PaymentType { get; set; }

        /// <summary>
        ///   The final payment method for the order. Will only have a value when the order is finalized, otherwise null.
        /// </summary>
        [JsonProperty("Payment")]
        public PaymentInfo Payment { get; set; }

        /// <summary>
        /// The current state of the order
        /// </summary>
        [JsonProperty("Status")]
        public CheckoutOrderStatus Status { get; set; }

        /// <summary>
        /// B2B Customer reference
        /// </summary>
        [JsonProperty("CustomerReference")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// <list type="table">
        /// <item>
        /// <term>True</term>
        /// <description>Svea will buy this invoice.</description>
        /// </item>
        /// <item>
        /// <term>False</term>
        /// <description>Svea will not buy this invoice.</description>
        /// </item>
        /// <item>
        /// <term>null</term>
        /// <description>Selected payment method is not Invoice.</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty("SveaWillBuyOrder")]
        public bool SveaWillBuyOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("IdentityFlags")]
        public IdentityFlags IdentityFlags { get; set; }

        /// <summary>
        /// Metadata visible to the store
        /// </summary>
        /// <remarks>
        /// Cleaned up from Checkout database after 45 days.
        /// </remarks>
        [JsonProperty("MerchantData")]
        public string MerchantData { get; set; }

        /// <summary>
        /// A company’s ID in the PEPPOL network, which allows the company to receive PEPPOL invoices. A PEPPOL ID can be entered when placing a B2B order using the payment method invoice.
        /// </summary>
        [JsonProperty("PeppolId")]
        public string PeppolId { get; set; }
    }
}
