using System.Collections.Generic;
using Newtonsoft.Json;

namespace Svea.Checkout.Models
{
    public class Address
    {
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("StreetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("StreetAddress2")]
        public string StreetAddress2 { get; set; }

        [JsonProperty("StreetAddress3")]
        public string StreetAddress3 { get; set; }

        [JsonProperty("CoAddress")]
        public string CoAddress { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Returns true if the address is a generic/international address i.e. one where we don't what fields there might be. Generic addresses only have values in fullName and addressLines.
        /// </summary>
        [JsonProperty("IsGeneric")]
        public bool IsGeneric { get; set; }

        /// <summary>
        /// This is only populated if the address is a generic/international address (IsGeneric returns true).
        /// </summary>
        [JsonProperty("AddressLines")]
        public List<string> AddressLines { get; set; }
    }
}
