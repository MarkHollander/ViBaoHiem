using BALOTA.ViBaoHiem.MainDal.Databases.Common;
using System.Data;
using System.Data.SqlClient;
using VB.Common.CustomConfig;
using VB.Common.Security;

namespace BALOTA.ViBaoHiem.MainDal.Databases
{
    public class CmsMainDb : CmsMainDbBase
    {
        private const string ConnectionStringName = "CmsMainDb";

        /// <summary>
        /// Creates a new connection to the database.
        /// </summary>
        /// <returns>An <see cref="System.Data.IDbConnection"/> object.</returns>
        protected override IDbConnection CreateConnection()
        {
            //var strConn = TripleDesEncryption.DesDecrypt(CurrentConfig.GetConnectionString(ConnectionStringName), Constants.ConnectionDecryptKey);
            var strConn = CurrentConfig.GetConnectionString(ConnectionStringName);
            return new SqlConnection(strConn);
        }
    }
}
