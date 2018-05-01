using System.Threading;

namespace AB.CommonMiddleware
{
    /// <inheritdoc />
    public class CorrelationContextAccessor : ICorrelationContextAccessor
    {
        private static AsyncLocal<CorrelationContext> _correlationContext = new AsyncLocal<CorrelationContext>();

        /// <inheritdoc />
        public CorrelationContext CorrelationContext
        {
            get => _correlationContext.Value;
            set => _correlationContext.Value = value;
        }
    }
}