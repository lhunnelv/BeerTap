﻿namespace LVBeerTap.Model
{
    using IQ.Platform.Framework.Common;
    using IQ.Platform.Framework.WebApi.Model.Hypermedia;

    /// <summary>
    /// A DispenseBeer, used as a placeholder.
    /// </summary>
    public class NewGlass : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier for the DispenseBeer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Glass Amount in Mililiters 
        /// </summary>
        public decimal AmountinMililiters { get; set; }
    }
}