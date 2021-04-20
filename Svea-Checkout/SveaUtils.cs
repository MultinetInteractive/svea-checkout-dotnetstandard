using System;

namespace Svea.Checkout
{
    public static class Utilities
    {
        public static string GetLocaleString(this Locale locale)
        {
            return locale switch
            {
                Locale.Swedish => "sv-SE",
                Locale.Danish => "da-DK",
                Locale.German => "de-DE",
                Locale.English => "en-US",
                Locale.Finnish => "fi-FI",
                Locale.Norwegian => "nn-NO",
                _ => throw new ArgumentException("Invalid value")
            };
        }
    }
}
