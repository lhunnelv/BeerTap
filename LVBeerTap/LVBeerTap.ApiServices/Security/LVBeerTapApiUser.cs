using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace LVBeerTap.ApiServices.Security
{

    public class LVBeerTapApiUser : ApiUser<UserAuthData>
    {
        public LVBeerTapApiUser(string name, Option<UserAuthData> authData)
            : base(authData)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }

    public class LVBeerTapUserFactory : ApiUserFactory<LVBeerTapApiUser, UserAuthData>
    {
        public LVBeerTapUserFactory() :
            base(new HttpRequestDataStore<UserAuthData>())
        {
        }

        protected override LVBeerTapApiUser CreateUser(Option<UserAuthData> auth)
        {
            return new LVBeerTapApiUser("LVBeerTap user", auth);
        }
    }

}
