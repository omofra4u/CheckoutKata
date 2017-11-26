using CheckoutKata.Domain;
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
    internal static class DiscountFactory
    {
        /// <summary>
        /// Get the total price for all products using the list of <c>ISpecialPricingRule</c>
        /// This method will filtered the promotional product list based on the kind of the discout rule that 
        /// is applied on each product
        /// </summary>
        /// <param name="promotionalProducts">The list of scanned <c>StockKeepingUnit</c></param>
        /// <param name="discountRule">List of discount rules to apply</param>
        /// <returns>total price including applied discount</returns>
        internal static int GetTotalPriceAfterDiscountForProducts( List<StockKeepingUnit> promotionalProducts, IEnumerable<ISpecialPricingRule> discountRule )
        {
            int discoutPrice = 0;
            foreach ( var rule in discountRule )
            {
                List<StockKeepingUnit> products = promotionalProducts.Where( x => x.CurrentPromoPricingRule.Name == rule.Name ).ToList( );
                var discounter = new GenericCalculator( rule );
                discoutPrice += discounter.ApplyDiscount( products );
            }

            return discoutPrice;
        }
    }
}
