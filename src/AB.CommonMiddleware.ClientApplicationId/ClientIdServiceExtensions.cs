using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AB.CommonMiddleware
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
        public static void AddCorrelationId(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IClientIdContextAccessor, ClientIdContextAccessor>();
            serviceCollection.TryAddTransient<IClientIdContextFactory, ClientIdContextFactory>();
        }
    }
}
