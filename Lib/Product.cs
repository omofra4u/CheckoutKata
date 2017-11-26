using CheckoutKata.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    /// <summary>
    /// Class representing an item that can be scan on checkout store
    /// </summary>
    public class Product
    {
        private PricingScheme _pricingScheme = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the product name is null or empty</exception>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public Product( string name, PricingScheme amount )
        {
            Guard.NotNullOrEmpty( name, name );
            Guard.NotNull( amount, nameof(amount) );

            Name = name;
            _pricingScheme = amount;
        }

        /// <summary>
        /// Get the name of the product
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Get the price of the product
        /// </summary>
        public double Price => _pricingScheme.Price;

        /// <summary>
        /// Get whether discount has been applied to the product or not 
        /// </summary>
        public bool IsDiscounted { get; private set; }
    }
}
