using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Business.DiscountPrice
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProtionalPricingScheme
    {
        /// <summary>
        /// Calculates the total price for the given products and apply appropriate discount as needed
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        int ApplyDiscount( IEnumerable<Product> product );
    }
}
