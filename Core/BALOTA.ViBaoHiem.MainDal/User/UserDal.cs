using BALOTA.ViBaoHiem.MainDal.Databases;

namespace BALOTA.ViBaoHiem.MainDal
{
    public class UserDal : UserDalBase
    {
        internal UserDal(CmsMainDb db)
            : base(db)
        {
        }
    }
}
