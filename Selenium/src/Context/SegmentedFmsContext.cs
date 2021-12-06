using System;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FmsDbContext
{
    public class SegmentedFmsContext : FmsContext
    {
        public SegmentedFmsContext(DbContextOptions<SegmentedFmsContext> options) : base(options) { }

        public Guid UserId { get; set; }

        public IQueryable<CareLocations> CareLocationsSegmented => CareLocations
            .Where(cl => OrganizationsAdmins
                .Where(h => h.UserId == UserId)
                .Select(o => o.OrganizationId)
                .Contains(cl.OrganizationId ?? Guid.Empty));

        public IQueryable<ConnectivityRulesView> ConnectivityRulesViewSegmented => ConnectivityRulesView
            .Where(crv => OrganizationsAdmins
                .Where(h => h.UserId == UserId)
                .Select(o => o.OrganizationId)
                .Contains(crv.CareLocationOrganizationId))
            .Where(crv => OrganizationsAdmins
                .Where(h => h.UserId == UserId)
                .Select(o => o.OrganizationId)
                .Contains(crv.UserOrganizationId));

        public IQueryable<GeoLocations> GeoLocationsSegmented => GeoLocations
                    .Where(gl => OrganizationsAdmins
                        .Where(h => h.UserId == UserId)
                        .Select(o => o.OrganizationId)
                        .Contains(gl.OrganizationId ?? Guid.Empty));

        public IQueryable<HumanUsers> HumanUsersSegmented => HumanUsers
                    .Where(hu => OrganizationsAdmins
                        .Where(oa => oa.UserId == UserId)
                        .Select(o => o.OrganizationId)
                        .Contains(hu.OrganizationLicenseId ?? Guid.Empty));
    }
}
