using System;

namespace AB.Middleware
{
    /// <summary>
    /// Provides access to per request context properties.
    /// </summary>
    public class ClientApplicationIdContext
    {
        internal ClientApplicationIdContext(string clientId, string header)
        {
            if (string.IsNullOrEmpty(header)) throw new ArgumentNullException(nameof(header));

            ClientApplicationId = clientId;
            Header = header;
        }

        /// <summary>
        /// The Client Id which is applicable to the current request.
        /// </summary>
        public string ClientApplicationId { get; }

        /// <summary>
        /// The name of the header from which the Client Id is read/written.
        /// </summary>
        public string Header { get; }
    }
}
