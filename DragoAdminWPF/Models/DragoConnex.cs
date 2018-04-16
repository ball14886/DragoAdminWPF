using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Models
{
    public class DragoConnex
    {
        public string Description { get; set; }
        public string DragoConnexID { get; set; }
        public long AreaID { get; set; }
        public string AreaDescription { get; set; }
        public string DragoSetting { get; set; }
        public string Code { get; set; }
        public Area Area { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDatetime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
