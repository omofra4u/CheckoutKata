using CheckoutKata.Domain;
using System.Collections.Generic;

namespace CheckoutKata.Business.DiscountPrice
{
    /// <summary>
    /// An interface for calculating the discount applicable to purchased <c>StockKeepingUnit</c>
    /// </summary>
    public interface ISpecialPricingRuleCalculator
    {
        /// <summary>
        /// Calculates the total price for the given products and apply appropriate discount as needed
        /// </summary>
        /// <param name="product">the list of products</param>
        /// <returns>total price including discount or zero, if the list is empty</returns>
        int ApplyDiscount( IEnumerable<StockKeepingUnit> product );
    }
}
