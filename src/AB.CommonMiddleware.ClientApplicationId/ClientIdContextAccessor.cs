using System.Threading;

namespace AB.CommonMiddleware
{
    /// <inheritdoc />
    public class ClientIdContextAccessor : IClientIdContextAccessor
    {
        private static AsyncLocal<ClientApplicationIdContext> _correlationContext = new AsyncLocal<ClientApplicationIdContext>();

        /// <inheritdoc />
        public ClientApplicationIdContext CorrelationContext
        {
            get => _correlationContext.Value;
            set => _correlationContext.Value = value;
        }
    }
}