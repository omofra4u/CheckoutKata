using System.Collections.Generic;

namespace CheckoutKata.Business.DiscountPrice
{
    /// <summary>
    /// An interface for getting all existing <c>IPromotionPricingRule</c>
    /// </summary>
    interface ISpecialPricingRuleFactory
    {
        /// <summary>
        /// Get a list <c>ISpecialPricingRule</c>
        /// </summary>
        /// <returns>A list of <c>ISpecialPricingRule</c></returns>
        IEnumerable<ISpecialPricingRule> GetPromoRules( );
    }
}
