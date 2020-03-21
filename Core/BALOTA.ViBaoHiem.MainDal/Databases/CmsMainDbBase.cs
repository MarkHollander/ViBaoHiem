using System.Data;
using VB.Common.DAL;

namespace BALOTA.ViBaoHiem.MainDal.Databases
{
    public abstract class CmsMainDbBase : MainDbBase
    {
        #region Store procedures

        #region User
        private UserDal _UserDal;
        public UserDal UserMainDal
        {
            get { return _UserDal ?? (_UserDal = new UserDal((CmsMainDb)this)); }
        }
        #endregion

        #region UserHasPermission
        private UserHasPermissionDal _UserHasPermissionDal;
        public UserHasPermissionDal UserHasPermissionMainDal
        {
            get { return _UserHasPermissionDal ?? (_UserHasPermissionDal = new UserHasPermissionDal((CmsMainDb)this)); }
        }
        #endregion

        #region UserPermission
        private UserPermissionDal _UserPermissionDal;
        public UserPermissionDal UserPermissionMainDal
        {
            get { return _UserPermissionDal ?? (_UserPermissionDal = new UserPermissionDal((CmsMainDb)this)); }
        }
        #endregion

        #region MemberList
        private MemberListDal _MemberListDal;
        public MemberListDal MemberListMainDal
        {
            get { return _MemberListDal ?? (_MemberListDal = new MemberListDal((CmsMainDb)this)); }
        }
        #endregion

        #endregion

        #region Member
        
        private MemberDal _MemberDal;
        public MemberDal MemberMainDal
        {
            get { return _MemberDal ?? (_MemberDal = new MemberDal((CmsMainDb)this)); }
        }
        

        #endregion

        #region Constructors

        protected CmsMainDbBase()
        {
        }
        protected CmsMainDbBase(bool init)
        {
            if (init)
            {
                InitConnection();
            }
        }

        #endregion

        #region Protected members

        protected override sealed void InitConnection()
        {
            _connection = CreateConnection();
            _connection.Open();
        }

        /// <summary>
        /// Creates a new connection to the database.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.IDbConnection"/> object.</returns>
        protected abstract IDbConnection CreateConnection();

        #endregion
    }
}
