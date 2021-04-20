using System.Threading.Tasks;

namespace Svea.Checkout.Models
{
    public interface IOrderData
    {
        void Validate();
        void PrepareData();
    }
}
