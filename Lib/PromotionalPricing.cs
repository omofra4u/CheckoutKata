using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    /// <summary>
    /// 
    /// </summary>
    public class PromotionalPricing : PricingScheme
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        public PromotionalPricing( double price ) : base( price )
        {
        }

        public override PricingSchemeType Scheme => PricingSchemeType.Promotional;
    }
}
