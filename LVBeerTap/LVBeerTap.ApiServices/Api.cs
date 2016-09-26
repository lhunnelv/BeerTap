namespace LVBeerTap.ApiServices
{
    using System.Net;
    using IQ.Platform.Framework.Common;
    using IQ.Platform.Framework.WebApi;

    public class ApiServiceHelper
    {
        public static int GetIdFromUrlParameters<T>(IRequestContext context, string paramName) where T : class
        {
            return context.UriParameters.GetByName<int>(paramName).EnsureValue(() =>
            context.CreateHttpResponseException<T>($"The {paramName} must be supplied in the URI", HttpStatusCode.BadRequest));
        }

    }
}
