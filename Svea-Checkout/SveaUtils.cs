using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Svea.Checkout
{
    public static class SveaUtils
    {
        public static void CreateAuthenticationToken(out string token, out string timestamp, string _merchantId, string _sharedSecret, string message = null)
        {
            message ??= string.Empty;
            timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            using var sha512 = SHA512.Create();
            var hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(message + _sharedSecret + timestamp));
            var hashString = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            token = Convert.ToBase64String(Encoding.UTF8.GetBytes(_merchantId + ":" + hashString));
        }

        public static string ObjectToJsonConverter(object inputObject)
        {
            if (inputObject == null) return null;

            return JsonConvert.SerializeObject(inputObject, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
