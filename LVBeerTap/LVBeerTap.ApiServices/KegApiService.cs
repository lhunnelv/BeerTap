namespace LVBeerTap.ApiServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using IQ.Platform.Framework.WebApi.Services.Security;
    using Security;
    using Model;
    using IQ.Platform.Framework.WebApi;

    public class KegApiService : IKegApiService
    {
        public KegApiService(IApiUserProvider<LVBeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException(nameof(userProvider));
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

        public Task<IEnumerable<Keg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officeId = ApiServiceHelper.GetIdFromUrlParameters<Office>(context, "OfficeId");

            var keg = ModelData.GetKegsperOffice(officeId);
            var returnkegs = keg.Select(AutoMapper.Mapper.Map<Keg>);
            return Task.FromResult(returnkegs);
        }
    }
}
