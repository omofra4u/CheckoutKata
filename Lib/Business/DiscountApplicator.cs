using CheckoutKata.Business.DiscountPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Business
{
    public class DiscountApplicator : IDiscountApplicator
    {
        

        /// <summary>
        /// 
        /// </summary>
        public DiscountApplicator(  )
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scannedProducts"></param>
        /// <returns></returns>
        public int ApplyDicountForCheckoutItems( List<Product> scannedProducts )
        {
            List<Product> nonePromoProducts = scannedProducts.Where( x => !x.IsDiscounted ).ToList( );
            List<Product> promotionalProducts = scannedProducts.Where( x => x.IsDiscounted  ).ToList( );

            int totalDiscountedPrice = DiscountFactory.GetTotalPriceAfterDiscountForProducts( promotionalProducts );

            return totalDiscountedPrice + (int)nonePromoProducts.Sum(x => x.Price);
        }
    }
}
