namespace LVBeerTap.Model
{
    using IQ.Platform.Framework.Common;
    using IQ.Platform.Framework.WebApi.Model.Hypermedia;

    /// <summary>
    /// A Office, used as a placeholder.
    /// </summary>
    public class Office : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier for the Office.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name for the Office.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// limit per Glass.
        /// </summary>
        public double Limit { get; set; }
    }
}
