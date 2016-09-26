namespace LVBeerTap.Model
{
    using IQ.Platform.Framework.Common;
    using IQ.Platform.Framework.WebApi.Model.Hypermedia;

    /// <summary>
    /// A DispenseBeer, used as a placeholder.
    /// </summary>
    public class ReplaceKeg : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier for the DispenseBeer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Product of Keg
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// The Capacity of Keg in Liters
        /// </summary>
        public decimal CapacityinMiliLiters { get; set; }

        /// <summary>
        /// Glass Amount in Mililiters 
        /// </summary>
        public decimal AmountinMililiters { get; set; }
    }
}
