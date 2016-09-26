namespace LVBeerTap.ApiServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using IQ.Platform.Framework.WebApi.Services.Security;
    using IQ.Platform.Framework.WebApi;
    using Security;
    using Model;

    public class OfficeApiService : IOfficeApiService
    {
        public OfficeApiService(IApiUserProvider<LVBeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException(nameof(userProvider));
        }

        public Task<Office> GetAsync(int officeid, IRequestContext context, CancellationToken cancellation)
        {
            var office = ModelData.GetOffices(officeid);
            return Task.FromResult(AutoMapper.Mapper.Map<Office>(office));
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var offices = ModelData.GetOffices();
            var returnOffices = offices.Select(AutoMapper.Mapper.Map<Office>);
            return Task.FromResult(returnOffices);
        }
    }
}
