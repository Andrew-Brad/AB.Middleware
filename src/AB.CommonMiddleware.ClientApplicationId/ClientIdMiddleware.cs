using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace AB.CommonMiddleware
{
    /// <summary>
    /// Middleware which attempts to reads / creates a Client Id that can then be used in logs and 
    /// passed to upstream requests.
    /// </summary>
    public class ClientIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ClientIdOptions _options;

        /// <summary>
        /// Creates a new instance of the CorrelationIdMiddleware.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <param name="options">The configuration options.</param>
        public ClientIdMiddleware(RequestDelegate next, IOptions<ClientIdOptions> options)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Processes a request to synchronise TraceIdentifier and Client Id headers. Also creates a 
        /// <see cref="ClientApplicationIdContext"/> for the current request and disposes of it when the request is completing.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/> for the current request.</param>
        /// <param name="clientIdContextFactory">The <see cref="IClientIdContextFactory"/> which can create a <see cref="ClientApplicationIdContext"/>.</param>
        public async Task Invoke(HttpContext context, IClientIdContextFactory clientIdContextFactory)
        {
            var clientId = SetClientId(context);

            clientIdContextFactory.Create(clientId, _options.Header);

            if (_options.IncludeInResponse)
            {
                // apply the Client Id to the response header for client side tracking
                context.Response.OnStarting(() =>
                {
                    if (!context.Response.Headers.ContainsKey(_options.Header))
                    {
                        context.Response.Headers.Add(_options.Header, clientId);
                    }
                    return Task.CompletedTask;
                });
            }

            await _next(context);

            clientIdContextFactory.Dispose();
        }

        private StringValues SetClientId(HttpContext context)
        {
            bool clientIdFoundInRequestHeader = context.Request.Headers.TryGetValue(_options.Header, out var clientId);

            if (clientIdFoundInRequestHeader == false) clientId = Guid.Empty.ToString();

            return clientId;
        }
    }
}
