using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Models
{
    public class Area
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public long AreaID { get; set; }
        public long SiteID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDatetime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedByUserName { get; set; }
        public string UpdatedByUserName { get; set; }
        public bool IsActive { get; set; }
        public string SiteDescription { get; set; }

        public bool IsDeleted { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public long OwnerID { get; set; }
        public Owner Owner { get; set; }
        public Site Site { get; set; }
        public List<User> Users { get; set; }
    }
}
