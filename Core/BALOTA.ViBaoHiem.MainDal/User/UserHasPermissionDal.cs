using BALOTA.ViBaoHiem.MainDal.Databases;

namespace BALOTA.ViBaoHiem.MainDal
{
    public class UserHasPermissionDal : UserHasPermissionDalBase
    {
        internal UserHasPermissionDal(CmsMainDb db)
            : base(db)
        {
        }
    }
}
