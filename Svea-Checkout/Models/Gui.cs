namespace Svea.Checkout.Models
{
    public class Gui
    {
        /// <summary>
        /// Defines the orientation of the device, either “desktop” or “portrait”.
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// HTML-snippet including javascript to populate the iFrame.
        /// </summary>
        public string Snippet { get; set; }
    }
}
