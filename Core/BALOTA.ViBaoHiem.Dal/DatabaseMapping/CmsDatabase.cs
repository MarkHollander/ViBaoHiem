using VB.Common.CustomConfig;

namespace BALOTA.ViBaoHiem.Dal.DatabaseMapping
{
    public class CmsDatabase
    {
        //public static int DefaultCacheExprired = 1000 * 60 * 60 * 24; // 24 hours
        public static int DefaultCacheExprired = 1000 * 60 * 5; // 5 minutes

        private static string _databaseName;
        public static string DatabaseName
        {
            get
            {
                if (string.IsNullOrEmpty(_databaseName))
                {
                    _databaseName = CurrentConfig.GetAppSetting("SqlCacheDependencyConfigName");
                }
                return _databaseName;
            }
        }

        public class TableNames
        {
            public const string Member = "Member";
            public const string StockMonitor = "StockMonitor";
            public const string MemberStockMonitor = "MemberStockMonitor";
            public const string StockSignal = "StockSignal";
            public const string StockRobot = "StockRobot";
        }
    }
}
