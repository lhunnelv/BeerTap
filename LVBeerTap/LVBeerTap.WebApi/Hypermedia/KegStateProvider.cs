namespace LVBeerTap.WebApi.Hypermedia
{
    using System.Collections.Generic;
    using IQ.Platform.Framework.Common;
    using IQ.Platform.Framework.WebApi.Hypermedia;
    using IQ.Platform.Framework.WebApi.Model.Hypermedia;
    using LVBeerTap.Model;

    public class KegStateProvider : KegStateProvider<Keg>
    {
    }
    public abstract class KegStateProvider<TKegResource> : ResourceStateProviderBase<TKegResource, KegState>
    where TKegResource : IStatefulResource<KegState>, IStatefulKeg
    {
        public override KegState GetFor(TKegResource resource)
        {
            return resource.KegState;
        }
        protected override IDictionary<KegState, IEnumerable<KegState>> GetTransitions()
        {
            return new Dictionary<KegState, IEnumerable<KegState>>
            { 
                { KegState.New, new[] { KegState.GoingDown } },
                { KegState.GoingDown, new[] { KegState.AlmostEmpty } },
                { KegState.AlmostEmpty, new[] { KegState.ShelsDryMate } }
            };
        }
        public override IEnumerable<KegState> All
        {
            get { return EnumEx.GetValuesFor<KegState>(); }
        }
    }
}