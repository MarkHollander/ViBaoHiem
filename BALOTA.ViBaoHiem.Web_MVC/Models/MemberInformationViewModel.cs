using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BALOTA.ViBaoHiem.Entity;

namespace BALOTA.ViBaoHiem.Web_MVC.Models
{
    public class MemberInformationViewModel
    {
        public MemberEntity member { get; set; }
        public List<MemberListEntity> memberlist { get; set; }
    }
}