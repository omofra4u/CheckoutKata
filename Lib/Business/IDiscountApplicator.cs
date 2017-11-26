using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Business
{
    public interface IDiscountApplicator
    {
        int ApplyDicountForCheckoutItems( List<StockKeepingUnit> scannedProducts );
    }
}
