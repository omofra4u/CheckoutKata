using CheckoutKata.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CheckoutKataTest
{
    /// <summary>
    /// Test class for the <c>FileReader</c>
    /// </summary>
    [TestClass]
    public class FileReaderTest
    {
        private const string BADFILENAME = @"C:\FileNotExist.Evil";
        private const string TEXTTOWRITE = "Code kata is fun";
        private const string GOODFILENAMEKEY = "GoodFileName";

        /// <summary>
        /// Test if the given path is null or empty an exception is throw
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestReadFileThrowsExceptionIfPathIsNullOrEmpty( )
        {
            FileReader.ReadFile( "" );
        }

        /// <summary>
        /// Test if given file path does not exist an exception is thrown
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestReadFileThrowsExceptionIfFileNameDoesNotExist( )
        {
            FileReader.ReadFile( BADFILENAME );
        }

        /// <summary>
        /// Test if the given file path exist all line from the text file are read and returned to calling client
        /// </summary>
        [TestMethod]
        public void TestReadFileReturnsAllLineRead( )
        {

            var goodFileName = TestAssistant.GetFileNameFromAppConfig( GOODFILENAMEKEY );
            File.AppendAllText( goodFileName, TEXTTOWRITE );

            var linesRead = FileReader.ReadFile( goodFileName );

            File.Delete( goodFileName );

            Assert.IsNotNull( linesRead );
            Assert.AreEqual( 1, linesRead.Length );
            Assert.IsTrue( linesRead[ 0 ].Equals( TEXTTOWRITE ) );
        }
    }
}
