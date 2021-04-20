using Newtonsoft.Json;

namespace Svea.Checkout.Models
{
    /// <summary>
    /// Quantity, UnitPrice, DiscountPercent and VatPercent for each order row is expected to be given in minor currency.
    /// </summary>
    public class OrderRow
    {
        /// <summary>
        /// Articlenumber as a string, can contain letters and numbers.
        /// </summary>
        /// <remarks>Max length: 256. Min length: 0.</remarks>
        [JsonProperty("ArticleNumber")]
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Article name.
        /// </summary>
        /// <remarks>Max length: 40. Min length: 0.</remarks>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Quantity of the product. 1-9 digits.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty("Quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// Price of the product including VAT. 1-13 digits, can be negative.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty("UnitPrice")]
        public long UnitPrice { get; set; }

        /// <summary>
        /// <para>The discountpercent of the product.</para>
        /// <para>Examples:</para>
        /// <para>0-10000 - No fractions</para>
        /// <para>0 = 0%</para>
        /// <para>100 = 1%</para>
        /// <para>1000 = 10%</para>
        /// <para>9900 = 99%</para>
        /// <para>10000 = 100%</para>
        /// </summary>
        [JsonProperty("DiscountPercent")]
        public long DiscountPercent { get; set; }

        /// <summary>
        /// The VAT percentage of the current product. Valid vat percentage for that country.
        /// </summary>
        [JsonProperty("VatPercent")]
        public long VatPercent { get; set; }

        /// <summary>
        /// The unit type, e.g., “st”, “pc”, “kg” etc.
        /// </summary>
        /// <remarks>Max length: 4. Min length: 0.</remarks>
        [JsonProperty("Unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Can be used when creating or updating an order. The returned rows will have their corresponding temporaryreference as they were given in the indata. It will not be stored and will not be returned in GetOrder.
        /// </summary>
        [JsonProperty("TemporaryReference")]
        public string TemporaryReference { get; set; }

        /// <summary>
        /// The row number the row will have in the Webpay system
        /// </summary>
        [JsonProperty("RowNumber")]
        public int? RowNumber { get; set; }

        /// <summary>
        /// Metadata visible to the store
        /// </summary>
        /// <remarks>Max length: 255. Optional. Cleaned up from Checkout database after 45 days.</remarks>
        [JsonProperty("MerchantData")]
        public string MerchantData { get; set; }
    }
}
