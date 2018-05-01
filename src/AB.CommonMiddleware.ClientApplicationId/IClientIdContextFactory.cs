namespace AB.CommonMiddleware
{
    /// <summary>
    /// A factory for creating and disposing an instance of a <see cref="ClientApplicationIdContext"/>.
    /// </summary>
    public interface IClientIdContextFactory
    {
        /// <summary>
        /// Creates a new <see cref="ClientApplicationIdContext"/> with the Client Id set for the current request.
        /// </summary>
        /// <param name="correlationId">The Client Id to set on the context.</param>
        /// /// <param name="header">The header used to hold the Client Id.</param>
        /// <returns>A new instance of a <see cref="ClientApplicationIdContext"/>.</returns>
        ClientApplicationIdContext Create(string correlationId, string header);

        /// <summary>
        /// Disposes of the <see cref="ClientApplicationIdContext"/> for the current request.
        /// </summary>
        void Dispose();
    }
}
