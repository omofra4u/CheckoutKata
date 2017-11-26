using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutKata
{
	public interface ICheckout
	{
        /// <summary>
        /// Get the number of items that have been scanned 
        /// </summary>
        int NumberOfScanItems { get; }
        void Scan( string item );

		int GetTotalPrice();
	}
}
