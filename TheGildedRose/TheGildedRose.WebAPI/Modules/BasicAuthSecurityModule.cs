using System;
using System.Security.Principal;
using System.Web;
using System.Threading;
using System.Web.Security;
using System.Net.Http.Headers;

namespace TheGildedRose.WebAPI.Modules
{
    /// <summary>
    /// 
    /// </summary>
    public class BasicAuthSecurityModule : IHttpModule
    {
        private const string Realm = "The Gilded Rose API";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {

            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];

            // Allow CORS OPTIONS request...
            if (request.RequestType == "OPTIONS")
                return;

            if (authHeader != null)
            {                
                AuthenticationHeaderValue authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
                else
                {
                    // Bad request - bad Auth header!
                    HttpContext.Current.Response.StatusCode = 401;
                }
            }
            else
            {
                // Bad request - missing Auth header!
                HttpContext.Current.Response.StatusCode = 401;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;

            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate",
                    string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            //clean-up code here.
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

    }
}