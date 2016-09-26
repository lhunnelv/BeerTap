namespace LVBeerTap.ApiServices
{
    /// <summary>
    /// The class is used to pass additional parameters to hypermedia links definitions in resource specifications.
    /// </summary>
    public class LinksParametersSource
    {
        public LinksParametersSource(int kegId, int officeId)
        {
            OfficeId = officeId;
            KegId = kegId;
        }

        public int OfficeId { get; private set; }
        public int KegId { get; set; }
    }
}