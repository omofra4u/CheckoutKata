using CheckoutKata;
using CheckoutKata.Business;
using CheckOutKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var initialPrice = new NormalPrice( 50 );
            var repo = ProductFactory.CreateProduct( 3, "A", initialPrice );

            var checkOut = new Checkout( repo, null );

            // Act
            foreach ( var item in repo )
            {
                checkOut.Scan( item.Name );
            }

            //Assert
            Assert.IsTrue( repo.Count() == checkOut.NumberOfScanItems );

            // Arrange  
            repo = ProductFactory.CreateProduct( 15, "C", initialPrice );
            checkOut = new Checkout( repo, null );
            var itemsToscan = repo.Take( 5 ).ToList();

            // Act
            itemsToscan.ForEach( x => checkOut.Scan(x.Name));

            //Assert
            Assert.IsTrue( 5 == checkOut.NumberOfScanItems );
        }

        /// <summary>
        /// Test that all tract items are cleared when the the total price is called.
        /// </summary>
        [TestMethod]
        public void TestScanItemsArelearedWhenGetTotalPriceIsCalled( )
        {
            // Arrange
            var initialPrice = new NormalPrice( 30 );
            var repo = ProductFactory.CreateProduct( 15, "A", initialPrice );
            var checkOut = new Checkout( repo, new DiscountApplicator() );

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
            var producInvent = ProductFactory.CreateProduct( 5, "C", new PromotionalPricing( 30 ) );
            var checkOut = new Checkout( producInvent, null );
            var expected = 0;

            var actual = checkOut.GetTotalPrice();

            Assert.AreEqual( expected, actual );

            // Now scan an item that is not in the invetory
            checkOut.Scan( "B" );

            actual = checkOut.GetTotalPrice();

            Assert.AreEqual( expected, actual );

        }

        /// <summary>
        /// Test that the total price of all items are returned, if products are scanned and the get total price is called 
        /// </summary>
        [TestMethod]
        public void TestGetTotalPriceReturnsTotalPriceOfAllScanItems( )
        {
            var producInvent = ProductFactory.CreateProduct( 5, "C", new PromotionalPricing( 30 ) );
            var checkOut = new Checkout( producInvent, new DiscountApplicator( ) );
            var expected = 150;

            foreach ( var item in producInvent )
            {
                checkOut.Scan( item.Name );
            }
            var actual = checkOut.GetTotalPrice( );

            Assert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Test that the total price of all items are returned, if products are scanned and the get total price is called 
        /// </summary>
        [TestMethod]
        public void TestGetTotalPriceAppliedDiscountToScannedProducts( )
        {
            var producInvent = ProductFactory.CreateProduct( 2, "C", new PromotionalPricing( 30 ) );
            var checkOut = new Checkout( producInvent, new DiscountApplicator( ) );
            var expected = 45;

            foreach ( var item in producInvent )
            {
                checkOut.Scan( item.Name );
            }
            var actual = checkOut.GetTotalPrice( );

            Assert.AreEqual( expected, actual );
        }
    }
}
