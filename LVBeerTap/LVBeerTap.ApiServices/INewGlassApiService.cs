namespace LVBeerTap.ApiServices
{
    using Model;
    using IQ.Platform.Framework.WebApi;

    public interface INewGlassApiService :
        ICreateAResourceAsync<NewGlass, int>,
        IGetAResourceAsync<Keg, int>
    {
    }
}
