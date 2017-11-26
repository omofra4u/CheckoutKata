using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Business.DiscountPrice
{
    /// <summary>
    /// Pricing scheme where you get £20 off if you buy three or more Items
    /// </summary>
    public class BuyThreeGetTwentyPoundsOffPricingScheme : IProtionalPricingScheme
    {
        /// <summary>
        /// Calculates and returns th total, after applying the the discount to the given products
        /// </summary>
        /// <param name="product">The List of products</param>
        /// <returns>0 if list is empty,total price if items on the list are less than 3 or total after disacount is applied
        /// if items on the list are three or greater than</returns>
        public int ApplyDiscount( IEnumerable<Product> product )
        {
            int total = 0;
            List<Product> products = product?.ToList( );
            while ( products != null && products.Count > 0 )
            {
                total += CalculateDiscout( ref products );
            }

            return total;
        }

        /// <summary>
        /// Calculate the discount that is applicable to the given products
        /// </summary>
        /// <param name="product">list of product. This list will be modified</param>
        /// <returns>The calculated total</returns>
        private static int CalculateDiscout( ref List<Product> product )
        {
            if ( product == null || product.Count == 0 )
            {
                return 0;
            }
            if ( product.Count( ) < 3 )
            {
                int total = (int)product.Sum( x => x.Price );

                product.Clear( );

                return total;
            }

            List<Product> threeItems = product.Take( 3 ).ToList( );
            foreach ( var item in threeItems )
            {
                product.Remove( item );
            }

            return (int)threeItems.Sum( x => x.Price ) - 20;
        }
    }
}
