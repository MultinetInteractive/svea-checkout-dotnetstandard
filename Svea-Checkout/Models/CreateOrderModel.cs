using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Svea.Checkout.Validation;
using System;
using System.Collections.Generic;

namespace Svea.Checkout.Models
{
    public class CreateOrderModel : IOrderData
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }


        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Locale for the order
        /// </summary>
        /// <remarks>Supported: sv-SE, da-DK, de-DE, en-US, fi-FI, nn-NO.</remarks>
        [JsonProperty("locale"), JsonConverter(typeof(StringEnumConverter))]
        public Locale Locale { get; set; }

        /// <summary>
        /// 	A string that identifies the order in the merchant’s systems. The ClientOrderNumber is unique per order. Attempting to create a new order with a previously used ClientOrderNumber will result in the create method returning the already existing order instead.
        /// </summary>
        /// <remarks>Max length: 32.</remarks>
        [JsonProperty("clientOrderNumber")]
        public string ClientOrderNumber { get; set; }


        [JsonProperty("merchantSettings")]
        public MerchantSettings MerchantSettings { get; set; }


        [JsonProperty("cart")]
        public Cart Cart { get; set; }


        [JsonProperty("presetValues")]
        public List<PresetValue> PresetValues { get; set; }


        [JsonProperty("identityFlags")]
        public IdentityFlags IdentityFlags { get; set; }


        [JsonProperty("requiresElectronicIdAuthentication")]
        public bool? RequiresElectronicIdAuthentication { get; set; }

        /// <summary>
        /// Provided by Svea to select partners.
        /// </summary>
        [JsonProperty("partnerKey")]
        public Guid? PartnerKey { get; set; }

        /// <summary>
        /// Metadata visible to the store
        /// </summary>
        /// <remarks>Max length: 6000. Optional. Cleaned up from Checkout database after 45 days.</remarks>
        [JsonProperty("merchantData")]
        public string MerchantData { get; set; }

        public void PrepareData()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            ValidateGeneralData();
            ValidateMerchant();
            ValidateOrderCart();
            ValidateClientOrderNumber();
            ValidateMerchantData();
        }

        private void ValidateGeneralData()
        {
            ValidationService.MustNotBeEmpty(MerchantSettings, "Merchant Settings");
            ValidationService.MustNotBeEmpty(Cart, "Order Cart");
            ValidationService.MustNotBeEmpty(Locale, "Locale");
            ValidationService.MustNotBeEmpty(Currency, "Currency");
            ValidationService.MustNotBeEmpty(CountryCode, "CountryCode");
        }
        private void ValidateMerchant()
        {
            ValidationService.MustNotBeEmpty(MerchantSettings, "Merchant Settings");

            ValidationService.LengthMustBeBetween(MerchantSettings.TermsUri?.ToString(), 1, 500, $"Merchant Settings: TermsUri");
            ValidationService.LengthMustBeBetween(MerchantSettings.CheckoutUri?.ToString(), 1, 500, $"Merchant Settings: CheckoutUri");
            ValidationService.LengthMustBeBetween(MerchantSettings.ConfirmationUri?.ToString(), 1, 500, $"Merchant Settings: ConfirmationUri");
            ValidationService.LengthMustBeBetween(MerchantSettings.PushUri?.ToString(), 1, 500, $"Merchant Settings: PushUri");
            ValidationService.LengthMustBeBetween(MerchantSettings.CheckoutValidationCallBackUri?.ToString(), 0, 500, $"Merchant Settings: PushUri");
        }
        private void ValidateOrderCart()
        {
            ValidationService.MustNotBeEmpty(Cart, "Order Cart");
            ValidationService.MustNotBeEmptyList(Cart?.Items, "Order items");

            foreach (var item in Cart?.Items)
            {
                ValidationService.LengthMustBeBetween(item.ArticleNumber, 0, 256, "Order item: ArticleNumber");
                ValidationService.LengthMustBeBetween(item.Name, 0, 40, "Order item: Name");
                ValidationService.LengthMustBeBetween(item.Unit, 0, 4, "Order item: Unit");
            }
        }
        private void ValidateClientOrderNumber()
        {
            ValidationService.LengthMustBeBetween(ClientOrderNumber, 1, 32, "Client Order Number");
        }

        private void ValidateMerchantData()
        {
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
