using CheckoutKata.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Business.DiscountPrice
{
    /// <summary>
    /// Class for getting promo rules that has been set in a comma separated file.
    /// </summary>
    public class ComaSeparatedFileSpecialPricingRuleFactory : ISpecialPricingRuleFactory
    {
        /// <summary>
        /// Processed promo rule
        /// </summary>
        private string[ ] _promoRules = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// /// <exception cref="ArgumentNullException">Thrown if path is null, empty or file does not exist</exception>
        /// <param name="filePath">The path to the file that contains the promo rules</param>
        public ComaSeparatedFileSpecialPricingRuleFactory( string filePath )
        {
            _promoRules = FileReader.ReadFile( filePath );
        }

        /// <summary>
        /// Retuns a list of rules set on the given coma separated file. Exception will be thrown if the file is not in the right format
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the data on the given could not be read, or parsed</exception>
        /// <returns>An initialised list of <c>IPromotionPricingRule</c>/returns>
        public IEnumerable<ISpecialPricingRule> GetPromoRules( )
        {
            if ( _promoRules.Length == 0 )
            {
                return new List<ISpecialPricingRule>( );
            }
            try
            {
                return _promoRules.Skip( 1 ).Select( RemoveNumberColumn ).ToList( );
            }
            catch ( Exception )
            {
                // Ok we couldn't process the file. There could be number of reasons for this, but we will just throw 
                // ArgumentException
                throw new ArgumentException( "Invalid data on the given file" );
            }
        }

        /// <summary>
        /// Split a given string and create an instance of the <c>IPromotionPricingRule</c>
        /// </summary>
        /// <param name="arg">The string containing the row of data</param>
        /// <returns>An instance of the <c>IPromotionPricingRule</c></returns>
        private ISpecialPricingRule RemoveNumberColumn( string arg )
        {
            var rowData = arg.Split( ',' );

            var rules = rowData.Skip( 1 ).ToArray( );

            var name = rules[ 0 ];
            double originalPrice = Convert.ToDouble( rules[ 1 ] );
            int condition = Convert.ToInt32( rules[ 2 ] );
            double discount = Convert.ToDouble( rules[ 3 ] );

            return new SpecialPricingRule( name, originalPrice, condition, discount );
        }
    }
}
