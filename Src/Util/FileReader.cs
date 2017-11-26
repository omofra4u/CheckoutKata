using System;
using System.IO;

namespace CheckoutKata.Util
{
    /// <summary>
    /// Helper class for reading text line by line, from a given file
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// Read all the line in the file on the given file path 
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if path is null, empty or file does not exist</exception>
        /// <param name="path">The path to the file location</param>
        /// <returns>Returns all lines read</returns>
        public static string[ ] ReadFile( string path )
        {
            Guard.NotNullOrEmpty( path, path );
            if ( !File.Exists( path ) )
            {
                throw new ArgumentNullException( "File does not exist" );
            }

            return File.ReadAllLines( path );
        }
    }
}
