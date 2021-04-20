using Newtonsoft.Json;

namespace Svea.Checkout.Models
{
    public abstract class PresetValue
    {
        [JsonProperty("TypeName")]
        public string TypeName { get; set; }

        [JsonProperty("Value")]
        public object Value { get; set; }

        [JsonProperty("IsReadonly")]
        public bool IsReadonly { get; set; }
    }

    public abstract class PresetValue<T> : PresetValue
    {
        [JsonProperty("Value")]
        public new T Value { get; set; }
    }

    public class NationalIdPreset : PresetValue<string>
    {
        public NationalIdPreset(string nationalId) : base()
        {
            TypeName = "NationalId";
            Value = nationalId;
        }
    }

    public class EmailAddress : PresetValue<string>
    {
        public EmailAddress(string emailAddress) : base()
        {
            TypeName = "EmailAddress";
            Value = emailAddress;
        }
    }

    public class PhoneNumber : PresetValue<string>
    {
        public PhoneNumber(string phoneNumber) : base()
        {
            TypeName = "PhoneNumber";
            Value = phoneNumber;
        }
    }

    public class PostalCode : PresetValue<string>
    {
        public PostalCode(string postalCode) : base()
        {
            TypeName = "PostalCode";
            Value = postalCode;
        }
    }

    public class IsCompany : PresetValue<bool>
    {
        public IsCompany(bool isCompany) : base()
        {
            TypeName = "IsCompany";
            Value = isCompany;
        }
    }
}
