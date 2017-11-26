namespace CheckoutKata.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISpecialPricingRule
    {
        /// <summary>
        /// Get the name of this promo pricing rule
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get the product actual price
        /// </summary>
        double OriginalPrice { get; }

        /// <summary>
        /// get the number of items to purchase before discout can be applied
        /// </summary>
        int NumberOfItem { get; }

        /// <summary>
        /// Get the discount amount that should be applied if all conditions are met
        /// </summary>
        double DiscountAmount { get; }
    }
}
