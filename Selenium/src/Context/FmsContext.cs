using Microsoft.EntityFrameworkCore;

namespace FmsDbContext
{
    public class FmsContext : DbContext
    {
        // Acc
        public virtual DbSet<CareLocationsToUsersView> CareLocationsToUsersView { get; set; }
        public virtual DbSet<Programs> Programs { get; set; }
        public virtual DbSet<ProgramsCareLocations> ProgramsCareLocations { get; set; }


        // Admin
        public virtual DbSet<ConnectivityRulesView> ConnectivityRulesView { get; set; }

        // Auth
        public virtual DbSet<ApplicationRoles> ApplicationRoles { get; set; }
        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<ChallengeQuestions> ChallengeQuestions { get; set; }
        public virtual DbSet<EnterprisesAuthentication> EnterprisesAuthentication { get; set; }
        public virtual DbSet<HealthcareAppUrls> HealthcareAppUrls { get; set; }
        public virtual DbSet<HumanUsers> HumanUsers { get; set; }
        public virtual DbSet<HumanUsersApplications> HumanUsersApplications { get; set; }
        public virtual DbSet<HumanUsersDeactivations> HumanUsersDeactivations { get; set; }
        public virtual DbSet<HumanUsersHealthcareAppUrls> HumanUsersHealthcareAppUrls { get; set; }
        public virtual DbSet<RpDeviceUsers> RpDeviceUsers { get; set; }
        public virtual DbSet<Specialties> Specialties { get; set; }
        public virtual DbSet<UnconfirmedUsers> UnconfirmedUsers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersActivity> UsersActivity { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }

        // Fms
        public virtual DbSet<CareLocations> CareLocations { get; set; }
        public virtual DbSet<CareLocationsAdmins> CareLocationsAdmins { get; set; }
        public virtual DbSet<CareLocationsGroups> CareLocationsGroups { get; set; }
        public virtual DbSet<CareLocationTypes> CareLocationTypes { get; set; }
        public virtual DbSet<ConnectivityGroups> ConnectivityGroups { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Datacenters> Datacenters { get; set; }
        public virtual DbSet<Enterprises> Enterprises { get; set; }
        public virtual DbSet<EnterprisesAdmins> EnterprisesAdmins { get; set; }
        public virtual DbSet<GeoLocations> GeoLocations { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<OrganizationsAdmins> OrganizationsAdmins { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Servers> Servers { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<StaffMembers> StaffMembers { get; set; }
        public virtual DbSet<Timezones> Timezones { get; set; }

        // Prod
        public virtual DbSet<Gateways> Gateways { get; set; }
        public virtual DbSet<GatewaysGeoLocations> GatewaysGeoLocations { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductKeys> ProductKeys { get; set; }
        public virtual DbSet<SerialsRanges> SerialsRanges { get; set; }
        public virtual DbSet<Subtypes> Subtypes { get; set; }
        public virtual DbSet<Types> Types { get; set; }

        // Sip
        public virtual DbSet<ConnectivityRules> ConnectivityRules { get; set; }
        public virtual DbSet<ConnectivityRulesHistory> ConnectivityRulesHistory { get; set; }
        public virtual DbSet<SipSettings> SipSettings { get; set; }
        public virtual DbSet<SynchronizationCache> SynchronizationCache { get; set; }

        public FmsContext(DbContextOptions<FmsContext> options) : base(options)
        {
        }

        protected FmsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CareLocationsAdmins>(entity =>
            {
                entity.HasKey(cla => new { cla.UserId, cla.CareLocationId });

                entity.HasOne(cla => cla.CareLocation)
                    .WithMany(cl => cl.CareLocationsAdmins)
                    .HasForeignKey(cla => cla.CareLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CareLocationsAdmins_CareLocations");

                entity.HasOne(cla => cla.Admin)
                    .WithMany(u => u.CareLocationsAdmins)
                    .HasForeignKey(cla => cla.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CareLocationsAdmins_HumanUsers");
            });

            modelBuilder.Entity<CareLocationsToUsersView>(entity =>
            {
                entity.HasKey(e => new { e.CareLocationId, e.ToUserId });
            });

            modelBuilder.Entity<EnterprisesAdmins>(entity =>
            {
                entity.HasKey(ea => new { ea.UserId, ea.EnterpriseId });

                entity.HasOne(ea => ea.Enterprise)
                    .WithMany(e => e.EnterprisesAdmins)
                    .HasForeignKey(ea => ea.EnterpriseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnterprisesAdmins_Enterprises");

                entity.HasOne(ea => ea.Admin)
                    .WithOne(u => u.EnterprisesAdmins)
                    .HasForeignKey<EnterprisesAdmins>(cla => cla.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnterprisesAdmins_HumanUsers");
            });

            modelBuilder.Entity<GatewaysGeoLocations>(entity =>
            {
                entity.HasKey(e => new { e.GatewayId, e.GeoLocationId });
            });

            modelBuilder.Entity<HumanUsers>(entity =>
            {
                entity.HasIndex(e => e.ConnectivityGroupId)
                    .HasName("FKIX_AUTH_HumanUsers_ConnectivityGroupId");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ_HumanUsers_Email")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasDefaultValueSql("('')");

                entity.Property(e => e.City).HasDefaultValueSql("('')");

                entity.Property(e => e.Comments).HasDefaultValueSql("('')");

                entity.Property(e => e.ConnectivityGroupId).HasDefaultValueSql("((44))");

                entity.Property(e => e.CountryId).HasDefaultValueSql("('')");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Email2).IsUnicode(false);

                entity.Property(e => e.Employer).IsUnicode(false);

                entity.Property(e => e.EnterpriseId).HasDefaultValueSql("('')");

                entity.Property(e => e.EpicEmpId).HasDefaultValueSql("('')");

                entity.Property(e => e.FirstName).HasDefaultValueSql("('')");

                entity.Property(e => e.IsEmployee).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEnabled).IsUnicode(false);

                entity.Property(e => e.LastName).HasDefaultValueSql("('')");

                entity.Property(e => e.Mobile).HasDefaultValueSql("('')");

                entity.Property(e => e.NationalProviderIdentifier).HasDefaultValueSql("('')");

                entity.Property(e => e.OfficePhone).HasDefaultValueSql("('')");

                entity.Property(e => e.OrganizationLicenseId).HasDefaultValueSql("('')");

                entity.Property(e => e.OrganizationProviderId).HasDefaultValueSql("('')");

                entity.Property(e => e.PreferredTimezone).HasDefaultValueSql("('Pacific Standard Time')");

                entity.Property(e => e.SpecialtyId);

                entity.Property(e => e.StateId);

                entity.Property(e => e.Title);

                entity.Property(e => e.UsersGroupId).HasDefaultValueSql("(1)");

                entity.Property(e => e.ConnectivityGroupId).HasDefaultValueSql("(311)");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.HumanUsers)
                    .HasForeignKey<HumanUsers>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HumanUsers_Users");

                entity.Property(e => e.Zip);
            });

            modelBuilder.Entity<HumanUsersApplications>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ApplicationId });
            });

            modelBuilder.Entity<OrganizationsAdmins>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.OrganizationId });
            });

            modelBuilder.Entity<ProductKeys>(entity =>
            {
                entity.HasIndex(e => e.AllocatedForProductId)
                    .HasName("FKIX_ProductKeys_AllocatedForProductId");

                entity.HasIndex(e => e.ProductKey)
                    .HasName("UQ_ProductKeys_Key")
                    .IsUnique()
                    .HasFilter("([ProductKey] IS NOT NULL)");

                entity.Property(e => e.IsDelivered).HasComputedColumnSql("(case when [DeliveredDate] IS NULL then (0) else (1) end)");

                entity.HasOne(d => d.AllocatedForProduct)
                    .WithMany(p => p.ProductKeys)
                    .HasForeignKey(d => d.AllocatedForProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductKeys_Products");
            });

            modelBuilder.Entity<ProgramsCareLocations>(entity =>
            {
                entity.HasKey(e => new { e.ProgramId, e.CareLocationId });

                entity.HasOne(d => d.CareLocation)
                    .WithMany(p => p.ProgramsCareLocations)
                    .HasForeignKey(d => d.CareLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProgramsCareLocations_CareLocations");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.ProgramsCareLocations)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProgramsCareLocations_Programs");
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });
        }
    }
}
