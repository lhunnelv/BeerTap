namespace LVBeerTap.ApiServices
{
    using Model;
    using IQ.Platform.Framework.WebApi;

    public interface IReplaceKegApiService :
        ICreateAResourceAsync<ReplaceKeg, int>
    {
    }
}
