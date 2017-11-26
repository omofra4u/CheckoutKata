using CheckoutKata.Domain;
using CheckoutKata.Business.DiscountPrice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CheckoutKataTest
{
    /// <summary>
    /// Test class for the <c>Product</c>
    /// </summary>
    [TestClass]
    public class StockKeepingUnitTest
    {
        /// <summary>
        /// Test that when a <c>Product</c> item is created, an exception is thrown if the name of the product 
        /// is empty or null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestProductThrowsExceptionIfNameIsNullAtInitialisation( )
        {
            StockKeepingUnit product = product = new StockKeepingUnit( null, 0 );
        }

        /// <summary>
        /// Test that when a <c>Product</c> item is created, an exception is thrown if the name of the product 
        /// is empty
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestProductThrowsExceptionIfNameIsEmptyAtInitialisation( )
        {
            var product = new StockKeepingUnit( string.Empty,  0  );
        }

        /// <summary>
        /// Test product properties are properly initialised with right values
        /// </summary>
        public void TestProductIsInitialisedWithGivenPrice()
        {
            var product = new StockKeepingUnit( "A", 5 );

            Assert.AreEqual( 5, product.Price );
            Assert.IsFalse( product.IsPromoProduct );
            Assert.IsTrue( product.Name.Equals("A") );
            Assert.IsNull( product.CurrentPromoPricingRule );
        }


        /// <summary>
        /// Test that the AppyPromotionRule throws an exception if the given <c>IPromotionPricingRule</c>
        /// is null
        /// </summary>
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestApplyPromoThrowsIfRuleIsNull( )
        {
            var product = new StockKeepingUnit( "A", 5 );
            product.AppyPromotionRule( null );
        }

        /// <summary>
        /// Test that when the AppyPromotionRule called, the <c>Product</c> properties are updated appropriately 
        /// with the given <c>IPromotionPricingRule</c> properties
        /// is null
        /// </summary>
        public void TestAppyPromotionRuleUpdatesProductWithRuleProperties( )
        {
            var product = new StockKeepingUnit( "A", 5 );
            var promoRule = new SpecialPricingRule( "Test", 20, 0, 0 );

            product.AppyPromotionRule( promoRule );

            Assert.AreEqual( 20, product.Price );
            Assert.IsTrue( product.IsPromoProduct );
            Assert.IsTrue( product.Name.Equals( "A" ) );
            Assert.IsNotNull( product.CurrentPromoPricingRule );
        }

        /// <summary>
        /// Test that when the EndPromo called, the <c>Product</c> properties are re-initialised with the given price
        /// with the given <c>IPromotionPricingRule</c> properties
        /// is null
        /// </summary>
        public void TestEndPromoReinitialisedProductWithGivenPrice( )
        {
            var product = new StockKeepingUnit( "A", 5 );
            var promoRule = new SpecialPricingRule( "Test", 40, 0, 0 );

            product.AppyPromotionRule( promoRule );

            // Now end the promo
            product.EndPromo( 6);

            Assert.AreEqual( 6, product.Price );
            Assert.IsFalse( product.IsPromoProduct );
            Assert.IsTrue( product.Name.Equals( "A" ) );
            Assert.IsNull( product.CurrentPromoPricingRule );
        }
    }
}
