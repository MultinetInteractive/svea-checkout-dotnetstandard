using System.Collections.Generic;

namespace Svea.Checkout.Models
{
    public class Cart
    {
        /// <summary>
        /// Collection of <see cref="OrderRow" />
        /// </summary>
        public List<OrderRow> Items { get; set; } = new List<OrderRow>();
    }
}
