using Newtonsoft.Json;

namespace Svea.Checkout.Models
{
    public class CampaignCodeInfo
    {
        [JsonProperty("CampaignCode")]
        public long CampaignCode { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("PaymentPlanType")]
        public PaymentPlanTypeCode PaymentPlanType { get; set; }

        [JsonProperty("ContractLengthInMonths")]
        public int ContractLengthInMonths { get; set; }

        [JsonProperty("MonthlyAnnuityFactor")]
        public decimal MonthlyAnnuityFactor { get; set; }

        [JsonProperty("InitialFee")]
        public decimal InitialFee { get; set; }

        [JsonProperty("NotificationFee")]
        public decimal NotificationFee { get; set; }

        [JsonProperty("InterestRatePercent")]
        public decimal InterestRatePercent { get; set; }

        [JsonProperty("NumberOfInterestFreeMonths")]
        public int NumberOfInterestFreeMonths { get; set; }

        [JsonProperty("NumberOfPaymentFreeMonths")]
        public int NumberOfPaymentFreeMonths { get; set; }

        [JsonProperty("FromAmount")]
        public decimal FromAmount { get; set; }

        [JsonProperty("ToAmount")]
        public decimal ToAmount { get; set; }
    }
}
