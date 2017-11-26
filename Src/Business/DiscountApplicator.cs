using CheckoutKata.Business.DiscountPrice;
using CheckoutKata.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class DiscountApplicator : IDiscountApplicator
    {
        /// <summary>
        /// List of discount rule to be applied on the products
        /// </summary>
        private IEnumerable<ISpecialPricingRule> _discountRules = null;

       /// <summary>
       /// Constructor
       /// </summary>
       /// <param name="discountRules">List of the discount rule</param>
        public DiscountApplicator( IEnumerable<ISpecialPricingRule> discountRules )
        {
            _discountRules = discountRules;
            if ( _discountRules == null )
            {
                _discountRules = new List<ISpecialPricingRule>( );
            }
        }

        /// <summary>
        /// Apply discout for all StockKeepingUnit on the list and returns the total price
        /// </summary>
        /// <param name="scannedProducts">The list of items to apply the discount on</param>
        /// <returns>total price after discount has been applied on the items or 0 if the list is empty</returns>
        public int ApplyDicountForCheckoutItems( List<StockKeepingUnit> scannedProducts )
        {
            if ( _discountRules.Count( ) == 0 )
            {
                return (int)scannedProducts.Sum( x => x.Price );
            }

            List<StockKeepingUnit> nonePromoProducts = scannedProducts.Where( x => !x.IsPromoProduct ).ToList( );
            List<StockKeepingUnit> promotionalProducts = scannedProducts.Where( x => x.IsPromoProduct  ).ToList( );

            int totalDiscountedPrice = DiscountFactory.GetTotalPriceAfterDiscountForProducts( promotionalProducts, _discountRules );

            return totalDiscountedPrice + (int)nonePromoProducts.Sum(x => x.Price);
        }
    }
}
