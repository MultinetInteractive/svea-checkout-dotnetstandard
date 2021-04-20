using System.Collections.Generic;
using System.Threading.Tasks;
using Svea.Checkout.Models;
using Svea.Checkout.Transport;

namespace Svea.Checkout
{
    public class CheckoutClient
    {
        private readonly Connector _connector;

        public CheckoutClient(Connector connector)
        {
            _connector = connector;
        }

        public async Task<CheckoutOrder> CreateOrderAsync(CreateOrderModel data)
        {
            data.Validate();
            return await _connector.CreateOrderAsync(data);
        }

        public async Task<CheckoutOrder> UpdateOrderAsync(long orderId, UpdateOrderModel data)
        {
            data.Validate();
            return await _connector.UpdateOrderAsync(orderId, data);
        }

        public async Task<CheckoutOrder> GetOrderAsync(long orderId)
        {
            return await _connector.GetOrderAsync(orderId);
        }

        public async Task<List<CampaignCodeInfo>> GetAvailablePartPaymentCampaignsAsync(bool isCompany)
        {
            return await _connector.GetAvailablePartPaymentCampaignsAsync(isCompany);
        }
    }
}
