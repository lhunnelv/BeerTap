namespace LVBeerTap.Model
{
    using IQ.Platform.Framework.Common;
    using IQ.Platform.Framework.WebApi.Model.Hypermedia;

    /// <summary>
    /// A Keg, used as a placeholder.
    /// </summary>
    public class Keg : IStatefulResource<KegState>, IIdentifiable<int>, IStatefulKeg
    {
        /// <summary>
        /// Unique Identifier for the Keg
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique Identifier of the Office
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// The Product of Keg
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// The Capacity of Keg in Mililiters
        /// </summary>
        public decimal CapacityinMililiters { get; set; }

        /// <summary>
        /// The Current Amount of Keg in Mililiters
        /// </summary>
        public decimal AmountinMililiters { get; set; }

        /// <summary>
        /// Keg Status
        /// </summary>
        public KegState KegState {
            get
            {
                if (0 <= AmountinMililiters && (CapacityinMililiters / 4) > AmountinMililiters) return KegState.ShelsDryMate;
                if ((CapacityinMililiters / 2) > AmountinMililiters && (CapacityinMililiters / 4) <= AmountinMililiters) return KegState.AlmostEmpty;
                return (CapacityinMililiters / 2) <= AmountinMililiters && CapacityinMililiters > AmountinMililiters ? KegState.GoingDown : KegState.New;
            }
        }
    }
}
