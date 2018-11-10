using System.Threading;

namespace AB.Middleware
{
    /// <inheritdoc />
    public class ClientIdContextAccessor : IClientIdContextAccessor
    {
        private static AsyncLocal<ClientApplicationIdContext> _correlationContext = new AsyncLocal<ClientApplicationIdContext>();

        /// <inheritdoc />
        public ClientApplicationIdContext ClientContext
        {
            get => _correlationContext.Value;
            set => _correlationContext.Value = value;
        }
    }
}