namespace LVBeerTap.WebApi.Hypermedia
{
    using Model;
    using IQ.Platform.Framework.WebApi.Hypermedia;
    using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
    using System.Collections.Generic;
    using IQ.Platform.Framework.WebApi.Model.Hypermedia;

    public class KegSpec : ResourceSpec<Keg, KegState ,int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeid})/Kegs({id})");

        //protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        //{
        //    yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId, c => c.Id);
        //}
        //protected override IEnumerable<IResourceStateSpec<Keg, KegState, int>> GetStateSpecs()
        //{
        //    //throw new System.NotImplementedException();
        //    yield return new ResourceStateSpec<Keg, KegState, int>(KegState.SheIsDryMate)
        //    {
        //        Links =
        //            {
        //                CreateLinkTemplate(LinkRelations.Kegs.ReplaceKeg, ReplaceKegSpec.Uri, x => x.OfficeId, c => c.Id)
        //            },
        //        Operations = new StateSpecOperationsSource<Keg, int>()
        //        {
        //            Post = ServiceOperations.Update
        //        }
        //    };
        //}

        protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.Id, c => c.Id);
        }

        //public override IResourceStateSpec<Keg, NullState, int> StateSpec
        //{
        //    get
        //    {
        //        return
        //          new SingleStateSpec<Keg, int>
        //          {
        //              Links =
        //              {
        //                   CreateLinkTemplate(LinkRelations.Keg , KegSpec.Uri.Many , r => r.Id),
        //              },
        //              Operations = new StateSpecOperationsSource<Keg, int>
        //              {
        //                  Get = ServiceOperations.Get
        //              },
        //          };
        //    }
        //}

        protected override IEnumerable<IResourceStateSpec<Keg, KegState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.New)
            {
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Kegs.NewGlass, NewGlassSpec.Uri, x => x.OfficeId, c => c.Id)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create
                }
            };

            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.GoingDown)
            {
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Kegs.NewGlass, NewGlassSpec.Uri, x => x.OfficeId, c => c.Id)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create
                }
            };

            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.AlmostEmpty)
            {
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Kegs.NewGlass, NewGlassSpec.Uri, x => x.OfficeId, c => c.Id)
                        ,CreateLinkTemplate(LinkRelations.Kegs.ReplaceKeg, ReplaceKegSpec.Uri, x => x.OfficeId, c => c.Id)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create
                }
            };

            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.ShelsDryMate)
            {
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Kegs.ReplaceKeg, ReplaceKegSpec.Uri, x => x.OfficeId, c => c.Id)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create
                }
            };
        }

        public override string EntrypointRelation => LinkRelations.Keg;
    }
}