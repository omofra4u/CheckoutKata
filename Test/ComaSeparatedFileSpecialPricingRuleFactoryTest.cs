using CheckoutKata.Business.DiscountPrice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CheckoutKataTest
{
    /// <summary>
    /// Test class for the <c>ComaSeparatedFilePromotionPricingRuleFactory</c>
    /// </summary>
    [TestClass]
    public class ComaSeparatedFileSpecialPricingRuleFactoryTest
    {
        private const string PROMORULEHEADER = "Number, Name, OriginalPrice, NumberOfItem, DiscountAmount";
        private const string RULEONE = "1, Buy 3 get £20 off, 50, 3, 20";
        private const string RULETWO = "2, Buy 2 get £15 off, 30, 3, 15";

        /// <summary>
        /// Tests that if there is no promo rule values set on the promolist file, calling GetPromoRules will return an empty list 
        /// </summary>
        [TestMethod]
        public void TestIfNoPromoGetPromoRulesReturnsEmptyList( )
        {
            var ruleFile = TestAssistant.GetPromoRuleFileNameFromAppConfig( );
            File.AppendAllText( ruleFile, string.Empty );
            var ruleFactory = new ComaSeparatedFileSpecialPricingRuleFactory( ruleFile );
            var rules = ruleFactory.GetPromoRules( );

            Assert.IsNotNull( rules );
            Assert.IsTrue( 0 == rules.Count( ) );
        }

        /// <summary>
        /// Test that the GetPromoRules returns a list of initialised <c>IPromotionPricingRule</c> instance
        /// </summary>
        [TestMethod]
        public void TestGetPromoRulesReturnsListOfInitialisedRules( )
        {
            var ruleFile = TestAssistant.GetPromoRuleFileNameFromAppConfig( );
            var allLines = new List<string>( ) { PROMORULEHEADER, RULEONE, RULETWO };

            File.AppendAllLines( ruleFile, allLines );

            var ruleFactory = new ComaSeparatedFileSpecialPricingRuleFactory( ruleFile );

            var rules = ruleFactory.GetPromoRules( );

            File.Delete( ruleFile );

            Assert.IsNotNull( rules );
            Assert.IsTrue( 2 == rules.Count( ) ); // We should expected 2 rules excluding the header 
        }
    }
}
