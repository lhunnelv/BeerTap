namespace LVBeerTap.WebApi.Hypermedia
{
    using Model;
    using IQ.Platform.Framework.WebApi.Hypermedia;
    using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
    using IQ.Platform.Framework.WebApi.Model.Hypermedia;

    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");

        public override string EntrypointRelation => LinkRelations.Office;

        public override IResourceStateSpec<Office, NullState, int> StateSpec
        {
            get
            {
                return new SingleStateSpec<Office, int>
                {
                    Links =
                        {
                            CreateLinkTemplate(LinkRelations.Keg, KegSpec.Uri.Many, c => c.Id)
                        },
                    Operations =
                        {
                            Get = ServiceOperations.Get
                        }
                };
            }
        }
    }
}