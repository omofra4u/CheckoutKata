using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Util
{
    /// <summary>
    /// Helper class for throwing exception 
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Checks if the given param is null, and throws an exception if it is, with the given param name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the given param is null</exception>
        /// <param name="param">An instance of the object to check against</param>
        /// <param name="paramName">The name of the parameter that causes the exception</param>
        public static void NotNull( object param, string paramName )
        {
            if ( param == null )
            {
                throw new ArgumentNullException( paramName );
            }
        }

        /// <summary>
        /// Checks if the given string param,is null or empty. Throws an exception if it is, with the given param name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the given param is null</exception>
        /// <param name="param">An instance of the string object to check against</param>
        /// <param name="paramName">The name of the parameter that causes the exception</param>
        public static void NotNullOrEmpty( string param, string paramName )
        {
            if ( string.IsNullOrEmpty( param ) )
            {
                throw new ArgumentNullException( paramName );
            }
        }
    }
}
