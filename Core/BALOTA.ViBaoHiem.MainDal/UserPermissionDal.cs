using BALOTA.ViBaoHiem.MainDal.Databases;

namespace BALOTA.ViBaoHiem.MainDal
{
    public class UserPermissionDal : UserPermissionDalBase
    {
        internal UserPermissionDal(CmsMainDb db)
            : base(db)
        {
        }
    }
}
