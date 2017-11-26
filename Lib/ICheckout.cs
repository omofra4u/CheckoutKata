namespace CheckOutKata
{
    /// <summary>
    /// 
    /// </summary>
	public interface ICheckout
    {
        /// <summary>
        /// Get the number of items that have been scanned 
        /// </summary>
        int NumberOfScanItems { get; }

        /// <summary>
        /// Add the given item to the list of <c>StockKeepingUnit</c>. Does nothing if the given item is not in the product inventory
        /// </summary>
        /// <param name="item">The item to scan</param>
        void Scan( string item );

        /// <summary>
        /// Get the total price of all scanned item, applying discount to items that on the SpecialPricing offer.
        /// </summary>
        /// <returns>the total price, including discount for all scanned items</returns>
		int GetTotalPrice( );
    }
}
