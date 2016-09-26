namespace LVBeerTap.Model
{
    /// <summary>
    /// A Keg Status, used as a placeholder.
    /// </summary>
    public enum KegState
    {
        /// <summary>
        /// Keg is full.
        /// </summary>
        New,

        /// <summary>
        /// Keg is going down
        /// </summary>
        GoingDown,

        /// <summary>
        /// Keg is Almost Empty.
        /// </summary>
        AlmostEmpty,

        /// <summary>
        /// Keg is Empty.
        /// </summary>
        ShelsDryMate
    }
}
