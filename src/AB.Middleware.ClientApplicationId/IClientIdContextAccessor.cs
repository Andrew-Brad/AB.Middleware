namespace AB.Middleware
{
    /// <summary>
    /// Provides access to the <see cref="ClientContext"/> for the current request.
    /// </summary>
    public interface IClientIdContextAccessor
    {
        /// <summary>
        /// The <see cref="ClientContext"/> for the current request.
        /// </summary>
        ClientApplicationIdContext ClientContext { get; set; }
    }
}
