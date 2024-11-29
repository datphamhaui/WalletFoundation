using System;
using System.Threading;
using System.Threading.Tasks;

namespace Reown.AppKit.Unity.Http
{
    public class AppKitApiHeaderDecorator : HttpClientDecorator
    {
        protected override Task<HttpResponseContext> SendAsyncCore(HttpRequestContext requestContext, CancellationToken cancellationToken, Func<HttpRequestContext, CancellationToken, Task<HttpResponseContext>> next)
        {
            requestContext.RequestHeaders["x-project-id"] = AppKit.Config.ProjectId;
            requestContext.RequestHeaders["x-sdk-type"] = "appkit";
            requestContext.RequestHeaders["x-sdk-version"] = AppKit.Version;

            return next(requestContext, cancellationToken);
        }
    }
}