using System.Runtime.Serialization;

namespace Svea.Checkout
{
    public enum Locale
    {
        [EnumMember(Value = "sv-SE")]
        Swedish,
        [EnumMember(Value = "da-DK")]
        Danish,
        [EnumMember(Value = "de-DE")]
        German,
        [EnumMember(Value = "en-US")]
        English,
        [EnumMember(Value = "fi-FI")]
        Finnish,
        [EnumMember(Value = "nn-NO")]
        Norwegian
    }
}
