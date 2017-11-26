using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class NormalPrice : PricingScheme
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        public NormalPrice( double price ) : base( price )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override PricingSchemeType Scheme => PricingSchemeType.Normal;
    }
}
