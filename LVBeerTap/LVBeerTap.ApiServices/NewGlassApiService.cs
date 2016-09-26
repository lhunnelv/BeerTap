namespace LVBeerTap.ApiServices
{
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Model;
    using IQ.Platform.Framework.WebApi;

    public class NewGlassApiService : INewGlassApiService
    {
        public Task<ResourceCreationResult<NewGlass, int>> CreateAsync(NewGlass resource, IRequestContext context, CancellationToken cancellation)
        {
            var kegId = ApiServiceHelper.GetIdFromUrlParameters<Keg>(context, "KegId");
            var officeId = ApiServiceHelper.GetIdFromUrlParameters<Office>(context, "OfficeId");
            var selectedkeg = ModelData.GetKegs(kegId);
            
            if (selectedkeg == null) throw context.CreateHttpResponseException<Keg>("Invalid Keg Request.", HttpStatusCode.NotFound);
            if (selectedkeg.AmountinMililiters - resource.AmountinMililiters < 0) throw context.CreateHttpResponseException<NewGlass>("Amount of Keg is less then the requested.", HttpStatusCode.BadRequest);
            selectedkeg.AmountinMililiters = selectedkeg.AmountinMililiters - resource.AmountinMililiters;

            ///Update Transaction Table
            /// TODO: Temp coding
            var trans = new TransactionData() { KegId = 1, Product = selectedkeg.Product, AmountinMililiters = resource .AmountinMililiters};
            ModelData.LogTransaction(trans);

            context.LinkParameters.Set(new LinksParametersSource(officeId, kegId));
            return Task.FromResult(new ResourceCreationResult<NewGlass, int>(resource)); 
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
