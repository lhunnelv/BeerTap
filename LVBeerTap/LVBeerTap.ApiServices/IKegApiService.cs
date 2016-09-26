namespace LVBeerTap.ApiServices
{
    using Model;
    using IQ.Platform.Framework.WebApi;

    public interface IKegApiService :
        IGetAResourceAsync<Keg, int>,
        IGetManyOfAResourceAsync<Keg, int>
    {
    }
}
