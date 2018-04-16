using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Models
{
    public class User
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
    }
}
