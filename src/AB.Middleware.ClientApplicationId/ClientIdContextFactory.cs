namespace AB.Middleware
{
    /// <inheritdoc />
    public class ClientIdContextFactory : IClientIdContextFactory
    {
        private readonly IClientIdContextAccessor _clientIdContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AB.CommonMiddleware.CorrelationContextFactory" /> class.
        /// </summary>
        public ClientIdContextFactory()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientIdContextFactory"/> class.
        /// </summary>
        /// <param name="clientIdContextAccessor">The <see cref="IClientIdContextAccessor"/> through which the <see cref="ClientApplicationIdContext"/> will be set.</param>
        public ClientIdContextFactory(IClientIdContextAccessor clientIdContextAccessor)
        {
            _clientIdContextAccessor = clientIdContextAccessor;
        }

        /// <inheritdoc />
        public ClientApplicationIdContext Create(string correlationId, string header)
        {
            var correlationContext = new ClientApplicationIdContext(correlationId, header);

            if (_clientIdContextAccessor != null)
            {
                _clientIdContextAccessor.ClientContext = correlationContext;
            }

            return correlationContext;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_clientIdContextAccessor != null)
            {
                _clientIdContextAccessor.ClientContext = null;
            }
        }
    }
}