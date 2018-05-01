namespace AB.CommonMiddleware
{
    /// <summary>
    /// Provides access to the <see cref="CorrelationContext"/> for the current request.
    /// </summary>
    public interface IClientIdContextAccessor
    {
        /// <summary>
        /// The <see cref="CorrelationContext"/> for the current request.
        /// </summary>
        ClientApplicationIdContext CorrelationContext { get; set; }
    }
}
