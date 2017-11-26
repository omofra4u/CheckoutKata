using CheckoutKata.Domain;
using System.Collections.Generic;

namespace CheckoutKata.Business
{
    public interface IDiscountApplicator
    {
        int ApplyDicountForCheckoutItems( List<StockKeepingUnit> scannedProducts );
    }
}
