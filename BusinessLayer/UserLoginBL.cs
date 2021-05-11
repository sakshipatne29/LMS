using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserLoginBL
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string grant_type { get; set; }
    }
}
