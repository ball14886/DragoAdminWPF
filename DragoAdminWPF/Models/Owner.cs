using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Models
{
    public class Owner
    {
        public long UserID { get; set; }
        public string UserDescription { get; set; }
        public long OwnerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }

        public string Telephone2 { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string BuildingDescription { get; set; }

        public string RoomNumber { get; set; }
        public string FloorNumber { get; set; }
        public string Number { get; set; }

        public string Moo { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public long ProvinceID { get; set; }
        public long DistrictID { get; set; }
        public long SubDistrictID { get; set; }
        public string PostalCode { get; set; }

        public List<Site> SiteList { get; set; }
        public List<Area> BuildingList { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
    }
}
