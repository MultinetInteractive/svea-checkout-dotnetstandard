using Newtonsoft.Json;
using Svea.Checkout.Validation;

namespace Svea.Checkout.Models
{
    public class UpdateOrderModel : IOrderData
    {
        [JsonProperty("cart")]
        public Cart Cart { get; set; }

        /// <summary>
        /// Metadata visible to the store
        /// </summary>
        /// <remarks>Max length: 6000. Optional. Cleaned up from Checkout database after 45 days.</remarks>
        [JsonProperty("merchantData")]
        public string MerchantData { get; set; }

        public void PrepareData()
        {
            throw new System.NotImplementedException();
        }

        public void Validate()
        {
            ValidationService.MustNotBeEmpty(Cart, "Order Cart");
            ValidationService.MustNotBeEmptyList(Cart?.Items, "Order items");

            if (!string.IsNullOrEmpty(MerchantData))
            {
                ValidationService.LengthMustBeBetween(MerchantData, 0, 6000, "MerchantData");
            }

            foreach (var cartItem in Cart?.Items)
            {
                if (!string.IsNullOrEmpty(cartItem.MerchantData))
                {
                    ValidationService.LengthMustBeBetween(cartItem.MerchantData, 0, 255, "Order Cart: MerchantData");
                }
            }
        }
    }
}
