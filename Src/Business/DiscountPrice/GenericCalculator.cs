using CheckoutKata.Domain;
using CheckoutKata.Util;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Business.DiscountPrice
{
    /// <summary>
    /// Pricing scheme where you get £20 off if you buy three or more Items
    /// </summary>
    public class GenericCalculator : ISpecialPricingRuleCalculator
    {
        private ISpecialPricingRule _discountRule = null;
        public GenericCalculator( ISpecialPricingRule discountRule)
        {
            _discountRule = discountRule;
            Guard.NotNull( _discountRule, nameof(_discountRule) );
        }

        /// <summary>
        /// Calculates and returns th total, after applying the the discount to the given products
        /// </summary>
        /// <param name="product">The List of products</param>
        /// <returns>0 if list is empty,total price if items on the list are less than 3 or total after disacount is applied
        /// if items on the list are three or greater than</returns>
        public int ApplyDiscount( IEnumerable<StockKeepingUnit> product )
        {
            int total = 0;
            List<StockKeepingUnit> products = product?.ToList( );
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
        private  int CalculateDiscout( ref List<StockKeepingUnit> product )
        {
            if ( product == null || product.Count == 0 )
            {
                return 0;
            }

            if ( _discountRule.NumberOfItem == 0 )
            {
                return Sum( product ) - (int)_discountRule.DiscountAmount;
            }
            if ( product.Count( ) < _discountRule.NumberOfItem )
            {
                int total = Sum( product );

                product.Clear( );

                return total;
            }

            List<StockKeepingUnit> threeItems = product.Take( _discountRule.NumberOfItem ).ToList( );
            foreach ( var item in threeItems )
            {
                product.Remove( item );
            }

            return Sum(threeItems ) - (int)_discountRule.DiscountAmount;
        }

        /// <summary>
        /// Take a list of product, and return the sum of their prices
        /// </summary>
        /// <param name="products">the list products</param>
        /// <returns>the sum of their prices</returns>
        private static int Sum( List<StockKeepingUnit> products )
        {
            return (int)products.Sum( x => x.Price );
        }
    }
}
