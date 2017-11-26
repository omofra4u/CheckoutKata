using CheckoutKata.Business.DiscountPrice;
using CheckoutKata.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CheckoutKataTest
{
    /// <summary>
    /// Helper class for unit test
    /// </summary>
    public static class TestAssistant
    {
        private const string PROMORULELISTFILEKEY = "PromoRule";
        private const string RULEONE = "1,Buy 3 get £20 off,50,3,20";
        private const string RULETWO = "2,Buy 2 get £15 off,30,2,15";
        private const string PROMORULEHEADER = "Number, Name, OriginalPrice, NumberOfItem, DiscountAmount";

        /// <summary>
        ///  Creates and return a list of <c>Product</c>s
        /// </summary>
        /// <param name="numberOfProducts">The number of <c>Product</c>s to create</param>
        /// <param name="productName">The name of the <c>Product</c>s to create</param>
        /// <param name="productPrice">The price</param>
        /// <returns>A list of <c>Product</c>s </returns>
        public static IEnumerable<StockKeepingUnit> StockKeepingUnits( int numberOfProducts, string productName, double productPrice )
        {
            for ( int items = 0; items < numberOfProducts; items++ )
            {
                yield return new StockKeepingUnit( productName, productPrice );
            }
        }


        /// <summary>
        /// Creates and load a temp text file path from the App config settings
        /// </summary>
        /// <param name="key">The key to the value of setting to load. The value will always be the name if the file</param>
        /// <returns>The fullu qualified path to the file in the appdata folder</returns>
        public static string GetFileNameFromAppConfig( string key )
        {
            var returnVal = ConfigurationManager.AppSettings[ key ];
            if ( returnVal.Contains( "AppPath" ) )
            {
                returnVal = returnVal.Replace( "[AppPath]", Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ) );
            }
            return returnVal;
        }

        /// <summary>
        /// Creates and load a temp text file path from the App config settings, using the promo rule key
        /// </summary>
        /// <param name="key">The key to the value of setting to load. The value will always be the name if the file</param>
        /// <returns>The fullu qualified path to the file in the appdata folder</returns>
        public static string GetPromoRuleFileNameFromAppConfig(  )
        {
            return GetFileNameFromAppConfig( PROMORULELISTFILEKEY );
        }

        /// <summary>
        /// Get rules
        /// </summary>
        /// <returns></returns>
        public static List<CheckoutKata.Business.ISpecialPricingRule> CreateRulesFromTexFile( )
        {
            var ruleFile = TestAssistant.GetPromoRuleFileNameFromAppConfig( );
            var allLines = new List<string>( ) { PROMORULEHEADER, RULEONE, RULETWO };

            // Write the promotion rules to the file
            File.AppendAllLines( ruleFile, allLines );

            var ruleFactory = new ComaSeparatedFileSpecialPricingRuleFactory( ruleFile );

            File.Delete( ruleFile );

            // Any test calling this will fail if the an exception is thrown whist tring to get the List of promo rules.
            // Its ok, as it is a test. It will force the engineer to debug why their test is failing
            return ruleFactory.GetPromoRules( ).ToList( );
        }

        /// <summary>
        /// Shuffled/scrambled the the list of <c>StockKeepingUnit</c> by using the Fisher-Yates shuffle algorithm
        /// </summary>
        public static void ShuffleStockKeepingUnitList( ref List<StockKeepingUnit> list )
        {
            Random random = new Random( );
            for ( int index = 0; index < list.Count; index++ )
            {
                int randomNumber = index + random.Next( list.Count - index );
                StockKeepingUnit unit = list[ randomNumber ];
                list[ randomNumber ] = list[ index ];
                list[ index ] = unit;
            }
        }

    }
}
