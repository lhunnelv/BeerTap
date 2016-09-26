namespace LVBeerTap.WebApi.Hypermedia
{
    using Model;
    using IQ.Platform.Framework.WebApi.Hypermedia;
    using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
    using IQ.Platform.Framework.WebApi.Model.Hypermedia;
    using ApiServices;
    using System.Collections.Generic;

    public class NewGlassSpec : SingleStateResourceSpec<NewGlass ,int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeid})/Kegs({kegid})/NewGlass");

        protected override IEnumerable<ResourceLinkTemplate<NewGlass>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.KegId, x => x.Parameters.OfficeId);
        }
        public override IResourceStateSpec<NewGlass, NullState, int> StateSpec
        {
            get
            {
                return new SingleStateSpec<NewGlass, int>
                {
                    Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Kegs.NewGlass, KegSpec.Uri, c => c.Parameters.OfficeId, c => c.Parameters.KegId)
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