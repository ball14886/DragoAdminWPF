using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Models
{
    public class Meter
    {
        public Guid MeterID { get; set; }
        public string MBusID { get; set; }
        public string Description { get; set; }
        public string AreaDescription { get; set; }
        public string DragoConnexDescription { get; set; }
        public string DragoConnexID { get; set; }
        public string MeterSetting { get; set; }
        public decimal MaxTreshold { get; set; }
        public string MeterType { get; set; }
        public string RoomNo { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
