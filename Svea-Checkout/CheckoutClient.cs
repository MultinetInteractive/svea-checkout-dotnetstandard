﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Svea.Checkout.Exceptions;
using Svea.Checkout.Models;
using Svea.Checkout.Validation;

namespace Svea.Checkout
{
    public class CheckoutClient
    {
        /// <summary>
        /// Base URL For Svea Checkout Production server
        /// </summary>
        public const string PROD_BASE_URL = "https://checkoutapi.svea.com";

        /// <summary>
        /// Base URL For Svea Checkout Demo server
        /// </summary>
        public const string TEST_BASE_URL = "https://checkoutapistage.svea.com";

        private readonly string _merchantId;
        private readonly string _sharedSecret;
        private readonly string _baseApiUrl;

        private static HttpClient ApiClient { get; set; }

        /// <summary>
        /// Creates a new instance of the CheckoutClient that is used to communicate with the Svea API
        /// </summary>
        /// <param name="merchantId">Merchant Id, you get this from Svea</param>
        /// <param name="sharedSecret">Shared secret, you get this from Svea</param>
        /// <param name="baseApiUrl">Use one of <see cref="PROD_BASE_URL" /> or <see cref="TEST_BASE_URL" /></param>
        public CheckoutClient(string merchantId, string sharedSecret, string baseApiUrl)
        {
            _merchantId = merchantId;
            _sharedSecret = sharedSecret;
            _baseApiUrl = baseApiUrl;

            if (ApiClient == null)
            {
                ApiClient = new HttpClient();
                ApiClient.DefaultRequestHeaders.Remove("User-Agent");
                ApiClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "MultiNet Svea Checkout API Client");
            }

            ValidateData();
        }

        private void ValidateData()
        {
            ValidationService.MustNotBeEmpty(_merchantId, "Merchant Id");
            ValidationService.MustNotBeEmpty(_sharedSecret, "Shared secret");
            ValidationService.MustNotBeEmpty(_baseApiUrl, "Base Api Url");

            var validUrls = new[] { PROD_BASE_URL, TEST_BASE_URL };
            if (!validUrls.Contains(_baseApiUrl))
            {
                throw new SveaInputValidationException("Base Api Url must be one of the available constants in the CheckoutClient-class");
            }
        }

        /// <summary>
        /// <para>This request creates a new order and returns the checkout to the webshop.</para>
        /// <para>You can add preset values to the call, as well. These values will prefill the identification in the checkout. If a preset value has IsReadOnly, the customer will not be able to modify the value.</para>
        /// </summary>
        /// <param name="data"><see cref="CreateOrderModel" /></param>
        /// <returns><see cref="CheckoutOrder" /></returns>
        public async Task<SveaApiResponse<CheckoutOrder>> CreateOrderAsync(CreateOrderModel data)
        {
            data.Validate();
            throw new NotImplementedException();
        }

        /// <summary>
        /// This request replaces the order rows of the specified order with the new appended in the call and sets the MerchantData on the order to the provided value.
        /// <para>HTTP status code 200 indicates success, everything else indicates a failure.</para>
        /// </summary>
        /// <param name="orderId">The order Id you got from either <see cref="GetOrderAsync" /> or have stored since earlier</param>
        /// <param name="data"><see cref="UpdateOrderModel" /></param>
        /// <returns><see cref="CheckoutOrder" /></returns>
        public async Task<SveaApiResponse<CheckoutOrder>> UpdateOrderAsync(long orderId, UpdateOrderModel data)
        {
            data.Validate();
            throw new NotImplementedException();
        }

        /// <summary>
        /// This request returns a data structure that contains all information about the order and what is needed for the GUI.
        /// <para>HTTP status code 200 indicates success, everything else indicates a failure.</para>
        /// </summary>
        /// <param name="orderId">Checkoutorderid of the specified order.</param>
        /// <returns><see cref="CheckoutOrder" /></returns>
        public async Task<SveaApiResponse<CheckoutOrder>> GetOrderAsync(long orderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This request returns a list of available B2C/B2B part payment campaigns.
        /// <para>HTTP status code 200 indicates success, everything else indicates a failure.</para>
        /// </summary>
        /// <param name="isCompany">True for B2B, false for B2C</param>
        /// <returns>Collection of <see cref="CampaignCodeInfo" /></returns>
        public async Task<SveaApiResponse<List<CampaignCodeInfo>>> GetAvailablePartPaymentCampaignsAsync(bool isCompany)
        {
            throw new NotImplementedException();
        }
    }
}
