using CheckoutKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataTest
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProductFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfProducts"></param>
        /// <param name="productName"></param>
        /// <param name="productPrice"></param>
        /// <returns></returns>
        public static IEnumerable<Product> CreateProduct( int numberOfProducts, string productName, PricingScheme productPrice )
        {
            for ( int items = 0; items < numberOfProducts; items++ )
            {
                yield return new Product( productName, productPrice );
            }
        }
    }
}
