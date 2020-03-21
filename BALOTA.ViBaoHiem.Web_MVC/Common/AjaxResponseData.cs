using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BALOTA.ViBaoHiem.Web.Common
{
    public class AjaxResponseData
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}