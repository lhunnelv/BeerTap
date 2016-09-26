namespace LVBeerTap.WebApi.Hypermedia
{
    using Model;
    using IQ.Platform.Framework.WebApi.Hypermedia;
    using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
    using IQ.Platform.Framework.WebApi.Model.Hypermedia;
    using ApiServices;
    using System.Collections.Generic;

    public class ReplaceKegSpec : SingleStateResourceSpec<ReplaceKeg, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeid})/Kegs({kegid})/ReplaceKeg");

        protected override IEnumerable<ResourceLinkTemplate<ReplaceKeg>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.KegId, x => x.Parameters.OfficeId);
        }
        public override IResourceStateSpec<ReplaceKeg, NullState, int> StateSpec
        {
            get
            {
                return new SingleStateSpec<ReplaceKeg, int>
                {
                    Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Kegs.ReplaceKeg, KegSpec.Uri, c => c.Parameters.OfficeId, c => c.Parameters.KegId)
                    },
                    Operations =
                    {
                        InitialPost = ServiceOperations.Create,
                        Get = ServiceOperations.Get
                    }

                };
            }
        }
    }
}