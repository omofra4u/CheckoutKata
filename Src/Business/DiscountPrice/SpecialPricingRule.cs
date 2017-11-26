namespace CheckoutKata.Business.DiscountPrice
{
    /// <summary>
    /// Encapsulates the Promotional pricing rule 
    /// </summary>
    public class SpecialPricingRule : ISpecialPricingRule
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the rule</param>
        /// <param name="originalPrice">The original price of the product</param>
        /// <param name="ruleCondition">Number of item to purchase before discount can be applied</param>
        /// <param name="discAmount">The amount of discount to apply</param>
        public SpecialPricingRule( string name, double originalPrice, int ruleCondition, double discAmount )
        {
            Name = name;
            OriginalPrice = originalPrice;
            DiscountAmount = discAmount;
            NumberOfItem = ruleCondition;
        }


        /// <summary>
        /// Get the name of the promo pricing rule 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Get the original price of the product before discount is applied
        /// </summary>
        public double OriginalPrice { get; private set; }

        /// <summary>
        /// Get if whether there are number of item to be purchased before a discount is applied 
        /// </summary>
        public int NumberOfItem { get; private set; }

        /// <summary>
        /// Get the amount of discount to be applied 
        /// </summary>
        public double DiscountAmount { get; private set; }
    }
}
