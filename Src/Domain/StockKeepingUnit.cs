using CheckoutKata.Business;
using CheckoutKata.Util;

namespace CheckoutKata.Domain
{
    /// <summary>
    /// Class representing an item that can be scan on checkout store
    /// </summary>
    public class StockKeepingUnit
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the product name is null or empty</exception>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public StockKeepingUnit( string name, double price )
        {
            Guard.NotNullOrEmpty( name, name );

            Name = name;
            Price = price;
            IsPromoProduct = false;
        }

        /// <summary>
        /// Get the name of the product
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Get the price of the product
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// Get whether discount has been applied to the product or not 
        /// </summary>
        public bool IsPromoProduct { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ISpecialPricingRule CurrentPromoPricingRule { get; private set; }

        /// <summary>
        /// Apply a new promotional price for the product
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the given <c>IPromotionPricingRule</c> is null</exception>
        /// <param name="theRule">the promotion rule</param>
        public void AppyPromotionRule( ISpecialPricingRule theRule )
        {
            Guard.NotNull( theRule, nameof( theRule ) );
            CurrentPromoPricingRule = theRule;
            Price = theRule.OriginalPrice;
            IsPromoProduct = true;
        }

        /// <summary>
        /// Set a new price for the product and remove any promo rules currently 
        /// </summary>
        /// <param name="newPrice">The new price for the product after all promotion is ended</param>
        public void EndPromo( double newPrice )
        {
            CurrentPromoPricingRule = null;
            Price = newPrice;
            IsPromoProduct = false;
        }
    }
}
