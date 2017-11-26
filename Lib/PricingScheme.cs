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
    public abstract class PricingScheme
    {
        /// <summary>
        /// Constructor that accepts the initial price 
        /// </summary>
        /// <param name="price"></param>
        protected PricingScheme( double price )
        {
            Price = price;
        }

        /// <summary>
        /// Get the price 
        /// </summary>
        public double Price {
            get;
            private set;
        }

        /// <summary>
        /// Get the type of <c>PricingScheme</c>
        /// </summary>
        public abstract PricingSchemeType Scheme
        {
            get;
        }
    }

    /// <summary>
    /// A representation of the type of pricing scheme that is available
    /// </summary>
    public enum PricingSchemeType
    {
        /// <summary>
        /// Represent a normal pricing scheme. 
        /// </summary>
        Normal,

        /// <summary>
        /// A promotional pricing scheme
        /// </summary>
        Promotional
    }
}
