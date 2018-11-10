using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace AB.Middleware
{
    /// <summary>
    /// Extension methods for the CorrelationIdMiddleware.
    /// </summary>
    public static class ClientIdExtensions
    {
        /// <summary>
        /// Enables Client Ids for the request.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseClientId(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseClientId(new ClientIdOptions());
        }

        /// <summary>
        /// Enables Client Ids for the request.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="header">The header field name to use for the Client Id.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseClientId(this IApplicationBuilder app, string header)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseClientId(new ClientIdOptions
            {
                Header = header
            });
        }

        /// <summary>
        /// Enables Client Ids for the request.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseClientId(this IApplicationBuilder app, ClientIdOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (app.ApplicationServices.GetService(typeof(IClientIdContextFactory)) == null)
            {
                throw new InvalidOperationException("Unable to find the required services. You must call the AddClientId method in ConfigureServices in the application startup code.");
            }

            return app.UseMiddleware<ClientIdMiddleware>(Options.Create(options));
        }
    }
}
