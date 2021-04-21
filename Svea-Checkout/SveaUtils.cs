using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

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

        public static void CreateAuthenticationToken(out string token, out string timestamp, string _merchantId, string _sharedSecret, string message = null)
        {
            message ??= string.Empty;
            timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            using var sha512 = SHA512.Create();
            var hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(message + _sharedSecret + timestamp));
            var hashString = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            token = Convert.ToBase64String(Encoding.UTF8.GetBytes(_merchantId + ":" + hashString));
        }
    }
}
