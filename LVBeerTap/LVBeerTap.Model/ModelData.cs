namespace LVBeerTap.Model
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Model data
    /// </summary>
    public class ModelData
    {
        private static List<Office> _officesDataList;
        private static List<Keg> _kegsDataList;
        private static List<TransactionData> _kegstransactionList = new List<TransactionData> {};
        private const int Oneglass = 250;

        //TODO: lhunnel - refactor separate Iplementation and Models to have repository

        /// <summary>
        /// Get collections of Offices
        /// </summary>
        /// <returns>List of office</returns>
        public static List<Office> GetOffices()
        {
            return SetOffices();
        }

        /// <summary>
        /// Select office
        /// </summary>
        /// <returns>office details</returns>
        public static Office GetOffices(object id)
        {
            return SetOffices().Find(a => a.Id.Equals(id));
        }

        /// <summary>
        /// Collection of office
        /// </summary>
        /// <returns>Mock data for office</returns>
        private static List<Office> SetOffices()
        {
            if (_officesDataList != null) return _officesDataList;
            var offices = new List<Office>();

            var office1 = new Office() { Id = 1, Name = "Vancouver", Limit = 1 };
            offices.Add(office1);

            var office2 = new Office() { Id = 2, Name = "Regina", Limit = 1 };
            offices.Add(office2);

            var office3 = new Office() { Id = 3, Name = "Winnipeg", Limit = 1 };
            offices.Add(office3);

            var office4 = new Office() { Id = 4, Name = "Davidson (NC)", Limit = 1 };
            offices.Add(office4);

            var office5 = new Office() { Id = 5, Name = "Manila Philippines", Limit = 1 };
            offices.Add(office5);

            var office6 = new Office() { Id = 6, Name = "Sydney Australia", Limit = 0.5 };
            offices.Add(office6);

            _officesDataList = offices;

            return _officesDataList;
        }
        
        /// <summary>
        /// List of Keg
        /// </summary>
        /// <returns></returns>
        public static List<Keg> GetKegs()
        {
            return SetKegs();
        }

        /// <summary>
        /// Select Keg
        /// </summary>
        /// <returns>Selected Keg Details</returns>
        public static Keg GetKegs(int id)
        {
            return SetKegs().FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// Select Keg
        /// </summary>
        /// <returns>Selected Keg Details</returns>
        public static IEnumerable<Keg> GetKegsperOffice(int officeid)
        {
            return SetKegs().Where(a => a.OfficeId == officeid);
        }

        /// <summary>
        /// Select Multiple office Keg
        /// </summary>
        /// <returns>Selected Keg Details</returns>
        public static Keg GetKegs(int officeid ,int id)
        {
            return SetKegs().Where(a => a.Id == id).FirstOrDefault(b => b.OfficeId == officeid);

            //Find(a => a.Id.Equals(id)
        }

        /// <summary>
        /// Collection of keg
        /// </summary>
        /// <returns>Mock data for Keg</returns>
        private static List<Keg> SetKegs()
        {
            if (_kegsDataList != null) return _kegsDataList;
            var kegs = new List<Keg>();

            kegs.Add(new Keg() { Id = 1, OfficeId = 1, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 1000 });
            kegs.Add(new Keg() { Id = 2, OfficeId = 1, Product = "Wine", CapacityinMililiters = 1000, AmountinMililiters = 900 });
            kegs.Add(new Keg() { Id = 3, OfficeId = 1, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 800 });
            kegs.Add(new Keg() { Id = 4, OfficeId = 1, Product = "Wine", CapacityinMililiters = 1000, AmountinMililiters = 700 });
            kegs.Add(new Keg() { Id = 5, OfficeId = 1, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 600 });
            kegs.Add(new Keg() { Id = 6, OfficeId = 1, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 500 });
            kegs.Add(new Keg() { Id = 7, OfficeId = 1, Product = "Wine", CapacityinMililiters = 1000, AmountinMililiters = 400 });
            kegs.Add(new Keg() { Id = 8, OfficeId = 1, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 300 });
            kegs.Add(new Keg() { Id = 9, OfficeId = 1, Product = "Wine", CapacityinMililiters = 1000, AmountinMililiters = 200 });
            kegs.Add(new Keg() { Id = 10, OfficeId = 1, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 100 });
            kegs.Add(new Keg() { Id = 11, OfficeId = 2, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 499 });
            kegs.Add(new Keg() { Id = 12, OfficeId = 3, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 400 });
            kegs.Add(new Keg() { Id = 13, OfficeId = 4, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 350 });            
            kegs.Add(new Keg() { Id = 14, OfficeId = 5, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 260 });
            kegs.Add(new Keg() { Id = 15, OfficeId = 6, Product = "Beer", CapacityinMililiters = 1000, AmountinMililiters = 10 });

            _kegsDataList = kegs;

            return _kegsDataList;
        }

        /// <summary>
        /// list of transaction
        /// </summary>
        public static void LogTransaction(TransactionData transaction)
        {
            _kegstransactionList.Add(transaction);
        }
    }
}
