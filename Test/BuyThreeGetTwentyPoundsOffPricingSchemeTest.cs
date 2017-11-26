using CheckoutKata;
using CheckoutKata.Business.DiscountPrice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CheckoutKataTest
{
    /// <summary>
    /// Test class for the <c>BuyThreeGetTwentyPoundsOffPricingScheme</c>
    /// </summary>
    [TestClass]
    public class BuyThreeGetTwentyPoundsOffPricingSchemeTest
    {
        /// <summary>
        /// Test that if the number of Item provided is null or less than 1, applying discount returns 0;
        /// </summary>
        [TestMethod]
        public void TestApplyDiscountReturnsZeroIfNoProductIsProcided( )
        {
            // Arrange
            List<Product> disCountProduct = null;
            var wh = new BuyThreeGetTwentyPoundsOffPricingScheme( );
            var expected = 0;

            var actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );

            // Now initialised with no item on the list
            disCountProduct = new List<Product>();

            actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Test that if the number of item on the list is less that 3 no discount is applied 
        /// </summary>
        [TestMethod]
        public void TestNoDiscountAppliedIfNumberOfItemsIsLessThanThree( )
        {
            // Arrange
            var disCountProduct = ProductFactory.CreateProduct(2, "A", new PromotionalPricing(50));
            var wh = new BuyThreeGetTwentyPoundsOffPricingScheme( );
            var expected = 100;

            var actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );

           
        }

        /// <summary>
        /// Test if the number of <c>Product</c>s are three are or greater, then discount is applied
        /// </summary>
        [TestMethod]
        public void TestDiscountIsAppliedIfNumberOfItemsIsThreeOrGreaterThanThree( )
        {
            // Arrange
            var disCountProduct = ProductFactory.CreateProduct( 3, "A", new PromotionalPricing( 50 ) );
            var wh = new BuyThreeGetTwentyPoundsOffPricingScheme( );
            var expected = 130;

            var actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );

            disCountProduct = ProductFactory.CreateProduct( 5, "A", new PromotionalPricing( 50 ) );
            expected = 230;

            actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );

            disCountProduct = ProductFactory.CreateProduct( 10, "A", new PromotionalPricing( 50 ) );
            expected = 440;

            actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );
        }
    }
}
