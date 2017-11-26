using CheckoutKata.Business;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Checkout : ICheckout
    {
        /// <summary>
        /// Holds a collection of product inventory in the store 
        /// </summary>
        private IEnumerable<StockKeepingUnit> _productInventory = null;

        /// <summary>
        /// Hold a collection all item that was scanned 
        /// </summary>
        private List<StockKeepingUnit> _scannedProducts = null;

        private IDiscountApplicator _discountApplicator = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepo">product inventory</param>
        public Checkout( IEnumerable<StockKeepingUnit> productRepo, IDiscountApplicator discountApplicator )
        {
            _discountApplicator = discountApplicator;
            _productInventory = productRepo;
            _scannedProducts = new List<StockKeepingUnit>( );
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
        public int GetTotalPrice( )
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
        /// Scan the given item and add it to the list of scanned items. Does notthing if the scanned item is not in the product inventry
        /// </summary>
        /// <param name="item">The item to scan</param>
		public void Scan( string item )
        {
            var product = _productInventory.FirstOrDefault( x => x.Name == item );
            if ( product == null )
            {
                return; // Perharps I should log a message and throw here?
            }
            _scannedProducts.Add( product );
        }
    }
}
