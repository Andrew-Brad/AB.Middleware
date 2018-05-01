using System;

namespace AB.CommonMiddleware
{
    /// <summary>
    /// Provides access to per request correlation properties.
    /// </summary>
    public class ClientApplicationIdContext
    {
        internal ClientApplicationIdContext(string correlationId, string header)
        {
            if (string.IsNullOrEmpty(correlationId))
                throw new ArgumentNullException(nameof(correlationId));

            if (string.IsNullOrEmpty(header))
                throw new ArgumentNullException(nameof(header));

            ClientApplicationId = correlationId;
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
