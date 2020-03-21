using System.Configuration;

namespace BALOTA.ViBaoHiem.Bo.DatabaseMapping
{
    public class DatabaseCacheMapping
    {
        public static int DefaultCacheExprired = 1000 * 60 * 60 * 24; // 24 hours

        private static string _databaseName;
        public static string DatabaseName
        {
            get
            {
                if (string.IsNullOrEmpty(_databaseName))
                {
                    //var connectionString = Connections.Current;
                    //var match = Regex.Match(connectionString, "initial catalog[ =](.*?);", RegexOptions.IgnoreCase);
                    //if (match.Success && match.Groups.Count > 0)
                    //{
                    //    _databaseName = match.Groups[0].Value;
                    //    _databaseName =
                    //        _databaseName.Substring(_databaseName.IndexOf("=", StringComparison.CurrentCultureIgnoreCase) + 1);
                    //    _databaseName = _databaseName.Replace(";", "").Trim();
                    //}
                    _databaseName = ConfigurationManager.AppSettings["SqlCacheDependencyConfigName"];
                }
                return _databaseName;
            }
        }

        public class TableNames
        {
        }
    }
}
