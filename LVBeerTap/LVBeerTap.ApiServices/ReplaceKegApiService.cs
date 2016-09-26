namespace LVBeerTap.ApiServices
{
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Model;
    using IQ.Platform.Framework.WebApi;

    public class ReplaceKegApiService : IReplaceKegApiService
    {
        public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var kegId = ApiServiceHelper.GetIdFromUrlParameters<Keg>(context, "KegId");
            var officeId = ApiServiceHelper.GetIdFromUrlParameters<Office>(context, "OfficeId");
            var selectedkeg = ModelData.GetKegs(kegId);
            
            if (selectedkeg == null) throw context.CreateHttpResponseException<Keg>("Invalid Keg Request.", HttpStatusCode.NotFound);
            
            selectedkeg.Product = resource.Product;
            selectedkeg.CapacityinMililiters = resource.CapacityinMiliLiters;
            selectedkeg.AmountinMililiters = resource.AmountinMililiters;

            context.LinkParameters.Set(new LinksParametersSource(officeId, kegId));
            return Task.FromResult(new ResourceCreationResult<ReplaceKeg, int>(resource)); 
        }

        public Task<Keg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = ApiServiceHelper.GetIdFromUrlParameters<Office>(context, "OfficeId");

            var keg = ModelData.GetKegs(officeId, id);

            if (keg == null)
                throw context.CreateHttpResponseException<Keg>(string.Format("Keg Id {0} does not exist", id),
                    HttpStatusCode.BadRequest);

            var results = AutoMapper.Mapper.Map<Keg>(keg);

            return Task.FromResult(results);
        }
    }
}
