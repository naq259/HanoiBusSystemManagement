using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanoiBusSystemManagement.Common
{
    [Serializable]
    public class Login
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string SoCMTND { get; set; }
        public string AnhCaNhan { get; set; }
        public int DeptID { get; set; }
    }
}