using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(CareLocations), Schema = Schemas.Fms)]
    public partial class CareLocations
    {
        public CareLocations()
        {
            CanSaveMedia = true;
            CareLocationTypeId = 0;
            CompanyOwned = false;
            GeoLocationId = 0;
            IsEnabled = true;
            MonitoringLevel = 2;
        }

        [Key]
        public long CareLocationId { get; set; }

        public string Address { get; set; }

        public string AddressTwo { get; set; }

        public bool AllowMultiEndpoint { get; set; }

        public bool AutoAnswer { get; set; }

        public bool BlockEmergencyAccess { get; set; }

        public bool CanSaveMedia { get; set; }

        public long CareLocationsGroupId { get; set; }

        public long CareLocationTypeId { get; set; }

        public string City { get; set; }

        public string Comments { get; set; }

        public bool CompanyOwned { get; set; }

        public long ConnectivityGroupId { get; set; }

        public int CountryId { get; set; }

        public long? GeoLocationId { get; set; }

        public bool IsDemo { get; set; }

        public bool IsEnabled { get; set; }

        public string ModifiedBy { get; set; }

        public byte MonitoringLevel { get; set; }

        public string Name { get; set; }

        public Guid? OrganizationId { get; set; }

        public string Phone { get; set; }

        public long RegionId { get; set; }

        public string State { get; set; }

        public int? WorkOrder { get; set; }

        public string Zip { get; set; }

        public ICollection<CareLocationsAdmins> CareLocationsAdmins { get; set; }

        public ICollection<Products> Products { get; set; }

        public ICollection<ProgramsCareLocations> ProgramsCareLocations { get; set; }
    }
}
