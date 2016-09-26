namespace LVBeerTap.ApiServices
{
    using Model;
    using IQ.Platform.Framework.WebApi;

    public interface IOfficeApiService :
        IGetAResourceAsync<Office, int>,
        IGetManyOfAResourceAsync<Office, int>
    {
    }
}
