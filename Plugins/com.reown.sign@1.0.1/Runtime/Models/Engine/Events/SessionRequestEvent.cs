using Newtonsoft.Json;
using Reown.Core.Network;

namespace Reown.Sign.Models.Engine.Events
{
    /// <summary>
    ///     An event that is emitted when a session request is received of type T.
    /// </summary>
    /// <typeparam name="T">The type of request data</typeparam>
    public class SessionRequestEvent<T> : SessionEvent
    {
        /// <summary>
        ///     The chainId this request should be performed in
        /// </summary>
        [JsonProperty("chainId")]
        public string ChainId;

        /// <summary>
        ///     The request arguments of this session request
        /// </summary>
        [JsonProperty("request")]
        public IRequestArguments<T> Request;
    }
}