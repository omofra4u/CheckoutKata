using CheckoutKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CheckoutKataTest
{
    /// <summary>
    /// Test class for the <c>Product</c>
    /// </summary>
    [TestClass]
    public class ProductTest
    {
        /// <summary>
        /// Test that when a <c>Product</c> item is created, an exception is thrown if the name of the product 
        /// is empty or null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestProductThrowsExceptionIfNameIsNullAtInitialisation( )
        {
            Product product = product = new Product( null, new NormalPrice(0) );
        }

        /// <summary>
        /// Test that when a <c>Product</c> item is created, an exception is thrown if the name of the product 
        /// is empty
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestProductThrowsExceptionIfNameIsEmptyAtInitialisation( )
        {
            var product = new Product( string.Empty, new NormalPrice( 0 ) );
        }

        /// <summary>
        /// Test that when a <c>Product</c> item is created, an exception is thrown if the <c>PricingScheme</c> of the product 
        /// is empty
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestProductThrowsExceptionIfAmountIsNullAtInitialisation( )
        {
            var product = new Product( "A", null );
        }
    }
}
