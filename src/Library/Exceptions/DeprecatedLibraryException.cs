using System;

namespace PoLaKoSz.Portfolio.Exceptions
{
    /// <summary>
    /// Occurs when the wrapper library could not done
    /// something because the wrapped service changed
    /// it's interface (responses from the server).
    /// </summary>
    public class DeprecatedLibraryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the System.Exception class with
        /// a specified error message.
        /// </summary>
        /// <param name="message">Non null.</param>
        public DeprecatedLibraryException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeprecatedLibraryException"/>
        /// class with a specified error message and a reference to the inner exception
        /// that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or
        /// a null reference if no inner exception is specified.</param>
        public DeprecatedLibraryException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
