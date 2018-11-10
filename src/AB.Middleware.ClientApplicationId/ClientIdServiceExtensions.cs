using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AB.Middleware
{
    /// <summary>
    /// Extensions on the <see cref="IServiceCollection"/>.
    /// </summary>
    public static class CorrelationIdServiceExtensions
    {
        /// <summary>
        /// Adds required services to support the Client Id functionality.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddClientId(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IClientIdContextAccessor, ClientIdContextAccessor>();
            serviceCollection.TryAddTransient<IClientIdContextFactory, ClientIdContextFactory>();
        }
    }
}
