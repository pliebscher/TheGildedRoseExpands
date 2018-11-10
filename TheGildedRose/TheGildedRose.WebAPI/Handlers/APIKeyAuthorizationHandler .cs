using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TheGildedRose.WebAPI.Handlers
{
    /// <summary>
    /// Simple handler to validate an API key header exists with a valid key.
    /// </summary>
    public class APIKeyAuthorizationHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            IEnumerable<string> headers;
            bool hasHeaders = request.Headers.TryGetValues("APIKEY", out headers);

            if (hasHeaders)
            {
                if (headers.FirstOrDefault().Equals("52212679-87F3-484B-893B-C7329F74876A")) // replace this with a call to some API key store.
                {
                    //Allow the request to continue...
                    return await base.SendAsync(request, cancellationToken);
                }
            }

            // Missing header or invalid key!
            return request.CreateResponse(HttpStatusCode.Forbidden, "Missing or Invalid API Key!");

        }
    }
}