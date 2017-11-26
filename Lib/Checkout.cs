using CheckoutKata;
using CheckoutKata.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutKata
{
    public class Checkout : ICheckout
    {
        /// <summary>
        /// Holds a collection of product inventory in the store 
        /// </summary>
        private IEnumerable<Product> _productInventory = null;

        /// <summary>
        /// Hold a collection all item that was scanned 
        /// </summary>
        private List<Product> _scannedProducts = null;

        private IDiscountApplicator _discountApplicator = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepo">product inventory</param>
        public Checkout( IEnumerable<Product> productRepo, IDiscountApplicator discountApplicator )
        {
            //TODO: Make sure you check the test to guard against null discount applicator 
            _discountApplicator = discountApplicator;
            _productInventory = productRepo;
            _scannedProducts = new List<Product>( );
        }

        /// <summary>
        /// Get the number of items that have been scanned 
        /// </summary>
        public int NumberOfScanItems => _scannedProducts.Count( );

        /// <summary>
        /// Get the total price of each <c>Product</c> scanned
        /// Calling this method will clear the list of all previous items scanned
        /// </summary>
        /// <returns>Returns the amount all scanned item or 0 if no item was scanned</returns>
        public int GetTotalPrice()
		{
            if ( _scannedProducts.Count == 0 )
            {
                return 0;
            }

            int totalPrice = _discountApplicator.ApplyDicountForCheckoutItems( _scannedProducts );
            _scannedProducts.Clear( );
            return totalPrice;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
		public void Scan( string item )
		{
            var product = _productInventory.FirstOrDefault( x => x.Name == item );
            if ( product == null )
            {
                return; // Perharps we should log a message an throw here?
            }
            _scannedProducts.Add( product );
		}
	}
}
