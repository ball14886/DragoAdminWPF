using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Models
{
    public class Site
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Owner Owner { get; set; }
        public long SiteID { get; set; }
        public long OwnerID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDatetime { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByUserName { get; set; }
        public string UpdatedByUserName { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long BuildingCount { get; set; }
        public string OwnerDescription { get; set; }
        public List<Area> BuildingList { get; set; }
    }
}
