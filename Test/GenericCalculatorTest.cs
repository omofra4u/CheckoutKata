using CheckoutKata.Domain;
using CheckoutKata.Business.DiscountPrice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CheckoutKataTest
{
    /// <summary>
    /// Test class for the <c>BuyThreeGetTwentyPoundsOffPricingScheme</c>
    /// </summary>
    [TestClass]
    public class GenericCalculatorTest
    {
        
        /// <summary>
        /// Test that if the number of Item provided is null or less than 1, applying discount returns 0;
        /// </summary>
        [TestMethod]
        public void TestApplyDiscountReturnsZeroIfNoProductIsProcided( )
        {
            var rules = TestAssistant.CreateRulesFromTexFile( );

            // Arrange
            List<StockKeepingUnit> disCountProduct = null;
            var wh = new GenericCalculator( rules[0] );
            var expected = 0;

            var actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );

            // Now initialised with no item on the list
            disCountProduct = new List<StockKeepingUnit>();

            actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Test that if the number of item on the list is less that 3 no discount is applied 
        /// </summary>
        [TestMethod]
        public void TestNoDiscountAppliedIfNumberOfItemsIsLessThanThree( )
        {
            List<CheckoutKata.Business.ISpecialPricingRule> rules = TestAssistant.CreateRulesFromTexFile( );

            var disCountProduct = TestAssistant.StockKeepingUnits( 2, "A", 50 );

            var wh = new GenericCalculator( rules[ 0 ] );

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
            List<CheckoutKata.Business.ISpecialPricingRule> rules = TestAssistant.CreateRulesFromTexFile( );
            var wh = new GenericCalculator( rules[0] );
            // Arrange
            var disCountProduct = TestAssistant.StockKeepingUnits( 3, "A", 50 );
            
            var expected = 130;

            var actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );

            disCountProduct = TestAssistant.StockKeepingUnits( 5, "A", 50 );
            expected = 230;

            actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );

            disCountProduct = TestAssistant.StockKeepingUnits( 10, "A", 50 );
            expected = 440;

            actual = wh.ApplyDiscount( disCountProduct );

            Assert.AreEqual( expected, actual );
        }


        
    }
}
