using CheckoutKata.Business;
using CheckoutKata.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKataTest
{
    /// <summary>
    /// Test class for the <c>Checkout</c> class 
    /// </summary>
    [TestClass]
    public class CheckoutTest
    {
        /// <summary>
        /// Test that when an item is scan, the item is tract 
        /// </summary>
        [TestMethod]
        public void TestScanItemsAreTract( )
        {
            // Arrange
            var initialPrice = 50;
            var repo = TestAssistant.StockKeepingUnits( 3, "A", initialPrice );

            var checkOut = new Checkout( repo, null );

            // Act
            foreach ( var item in repo )
            {
                checkOut.Scan( item.Name );
            }

            //Assert
            Assert.IsTrue( repo.Count( ) == checkOut.NumberOfScanItems );

            // Arrange  
            repo = TestAssistant.StockKeepingUnits( 15, "C", initialPrice );
            checkOut = new Checkout( repo, null );
            var itemsToscan = repo.Take( 5 ).ToList( );

            // Act
            itemsToscan.ForEach( x => checkOut.Scan( x.Name ) );

            //Assert
            Assert.IsTrue( 5 == checkOut.NumberOfScanItems );
        }

        /// <summary>
        /// Test that all tract items are cleared when the the total price is called.
        /// </summary>
        [TestMethod]
        public void TestScannedItemsAreClearedWhenGetTotalPriceIsCalled( )
        {
            // Arrange
            var repo = TestAssistant.StockKeepingUnits( 15, "A", 30 );
            var checkOut = new Checkout( repo, new DiscountApplicator( null ) );

            var itemsToscan = repo.Take( 3 ).ToList( ); // Lets scan 3 items first

            // Act
            itemsToscan.ForEach( x => checkOut.Scan( x.Name ) );
            Assert.IsTrue( 3 == checkOut.NumberOfScanItems );

            // now clear get the total price 
            checkOut.GetTotalPrice( );

            Assert.IsTrue( 0 == checkOut.NumberOfScanItems );
        }

        /// <summary>
        /// Test that if no item was scan, and get total price is called, it returns 0
        /// </summary>
        [TestMethod]
        public void TestGetTotalPriceReturnsZeroIfNoItemScan( )
        {
            var producInvent = TestAssistant.StockKeepingUnits( 5, "C", 30 );
            var checkOut = new Checkout( producInvent, null );
            var expected = 0;

            var actual = checkOut.GetTotalPrice( );

            Assert.AreEqual( expected, actual );

            // Now scan an item that is not in the invetory
            checkOut.Scan( "B" );

            actual = checkOut.GetTotalPrice( );

            Assert.AreEqual( expected, actual );

        }

        /// <summary>
        /// Test that the total price of all items are returned, if products are scanned and the get total price is called 
        /// </summary>
        [TestMethod]
        public void TestGetTotalPriceReturnsTotalPriceOfAllScanItems( )
        {
            var producInvent = TestAssistant.StockKeepingUnits( 5, "C", 30 );
            var checkOut = new Checkout( producInvent, new DiscountApplicator( null ) );
            var expected = 150;

            foreach ( var item in producInvent )
            {
                checkOut.Scan( item.Name );
            }
            var actual = checkOut.GetTotalPrice( );

            Assert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Test that discount is applied for products which are on promo and they meet the promo rules
        /// </summary>
        [TestMethod]
        public void TestGetTotalPriceAppliedDiscountToScannedProducts( )
        {
            var rules = TestAssistant.CreateRulesFromTexFile( );
            var producInvent = TestAssistant.StockKeepingUnits( 2, "C", 30 ).ToList( );

            // Apply discount rule to the product
            ApplyDiscountToProducts( producInvent, rules[ 1 ] );
            
            var checkOut = new Checkout( producInvent, new DiscountApplicator( rules ) );
            var expected = 45;

            foreach ( var item in producInvent )
            {
                checkOut.Scan( item.Name );
            }
            var actual = checkOut.GetTotalPrice( );

            Assert.AreEqual( expected, actual );

            // Repeat test again
            producInvent = TestAssistant.StockKeepingUnits( 8, "A", 50 ).ToList( );
            // Apply discount rule to the product
            ApplyDiscountToProducts( producInvent, rules[ 0 ] );

            checkOut = new Checkout( producInvent, new DiscountApplicator( rules ) );
            expected = 360;

            foreach ( var item in producInvent )
            {
                checkOut.Scan( item.Name );
            }
            actual = checkOut.GetTotalPrice( );

            Assert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Test that discount are applied to product irrespective of how they were scanned
        /// </summary>
        [TestMethod]
        public void TestGetTotalPriceAppliedDiscountIrrespectiveOfScannedOrder( )
        {
            var rules = TestAssistant.CreateRulesFromTexFile( );
            var SKUAs = TestAssistant.StockKeepingUnits( 4, "A", 50 ).ToList( );
            var SKUBs = TestAssistant.StockKeepingUnits( 5, "B", 30 ).ToList( );
            var SKUCs = TestAssistant.StockKeepingUnits( 1, "C", 20 ).ToList( );
            var SKUDs = TestAssistant.StockKeepingUnits( 2, "D", 15 ).ToList( );

            // Apply discount rule to the product
            ApplyDiscountToProducts( SKUAs, rules[ 0 ] );
            ApplyDiscountToProducts( SKUBs, rules[ 1 ] );

            var productInvent = SKUAs.Concat( SKUBs ).Concat( SKUCs ).Concat( SKUDs );

            var checkOut = new Checkout( productInvent, new DiscountApplicator( rules ) );
            var expected = 350;

            List<StockKeepingUnit> shuffledList = new List<StockKeepingUnit>( productInvent );
            TestAssistant.ShuffleStockKeepingUnitList( ref shuffledList );

            foreach ( var item in shuffledList )
            {
                checkOut.Scan( item.Name );
            }
            var actual = checkOut.GetTotalPrice( );

            Assert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Apply the given <c>ISpecialPricingRule</c> to the list of <c>StockKeepingUnit</c>
        /// </summary>
        /// <param name="discountedProducts">The rule to apply</param>
        /// <param name="rule">The list on which to apply the rule</param>
        private void ApplyDiscountToProducts( List<StockKeepingUnit> discountedProducts, ISpecialPricingRule rule )
        {
            discountedProducts.ForEach( x => x.AppyPromotionRule( rule ) );
        }
    }
}
