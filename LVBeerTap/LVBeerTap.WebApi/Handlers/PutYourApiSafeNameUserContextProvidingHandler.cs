using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using LVBeerTap.ApiServices.Security;

namespace LVBeerTap.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<LVBeerTapApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<LVBeerTapApiUser> apiUserInRequestStore)
            : base(new LVBeerTapUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<LVBeerTapApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<LVBeerTapApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}