namespace AB.CommonMiddleware
{
    /// <summary>
    /// Options for Client Ids.
    /// </summary>
    public class ClientIdOptions
    {
        private const string DefaultHeader = "X-AB-Client-Application-ID";

        /// <summary>
        /// The name of the header from which the Client Id is read/written.
        /// </summary>
        public string Header { get; set; } = DefaultHeader;

        /// <summary>
        /// <para>
        /// Controls whether the Client Id is returned in the response headers.
        /// </para>
        /// <para>Default: true</para>
        /// </summary>
        public bool IncludeInResponse { get; set; } = true;
    }
}
