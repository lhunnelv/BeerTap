namespace LVBeerTap.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Office.
        /// </summary>
        public const string Office = "iq:Office";

        /// <summary>
        /// link relation to describe the Keg.
        /// </summary>
        public const string Keg = "iq:Keg";

        /// <summary>
        /// The Kegs
        /// </summary>
        public static class Kegs
        {
            /// <summary>
            /// link relation to describe the NewGlass.
            /// </summary>
            public const string NewGlass = "iq:NewGlass";

            /// <summary>
            /// link relation to describe the Replace Keg.
            /// </summary>
            public const string ReplaceKeg = "iq:ReplaceKeg";
        }

    }
}
