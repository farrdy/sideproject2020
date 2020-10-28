using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RatesCalculator.Data.Models
{
    public partial class RatesTariffsContext : DbContext
    {
        public RatesTariffsContext()
        {
        }

        public RatesTariffsContext(DbContextOptions<RatesTariffsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditEntity> AuditEntity { get; set; }
        public virtual DbSet<AuditEntityField> AuditEntityField { get; set; }
        public virtual DbSet<CentInRand> CentInRand { get; set; }
        public virtual DbSet<Electricity> Electricity { get; set; }
        public virtual DbSet<ElectricityFreeBenefit> ElectricityFreeBenefit { get; set; }
        public virtual DbSet<IndigentIncomeLevel> IndigentIncomeLevel { get; set; }
        public virtual DbSet<PensionerDisabledIncome> PensionerDisabledIncome { get; set; }
        public virtual DbSet<PersonType> PersonType { get; set; }
        public virtual DbSet<PropertyRebates> PropertyRebates { get; set; }
        public virtual DbSet<PropertyValueRefuseRebates> PropertyValueRefuseRebates { get; set; }
        public virtual DbSet<Refuse> Refuse { get; set; }
        public virtual DbSet<RefuseRebates> RefuseRebates { get; set; }
        public virtual DbSet<RefuseRebatesIndigent> RefuseRebatesIndigent { get; set; }
        public virtual DbSet<RefuseResidentialType> RefuseResidentialType { get; set; }
        public virtual DbSet<ResidentWasteCollection> ResidentWasteCollection { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sanitation> Sanitation { get; set; }
        public virtual DbSet<SanitationFreeBenefit> SanitationFreeBenefit { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Vat> Vat { get; set; }
        public virtual DbSet<Water> Water { get; set; }
        public virtual DbSet<WaterFixedCharges> WaterFixedCharges { get; set; }
        public virtual DbSet<WaterMeter> WaterMeter { get; set; }
        public virtual DbSet<WaterPropertyBenefit> WaterPropertyBenefit { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer("Data Source=DESKTOP-O6SSLKV;Initial Catalog=RatesTariffs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditEntity>(entity =>
            {
                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Reference).HasMaxLength(3072);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AuditEntityField>(entity =>
            {
                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AuditEntity)
                    .WithMany(p => p.AuditEntityField)
                    .HasForeignKey(d => d.AuditEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditEntityField_ToAuditEntity");
            });

            modelBuilder.Entity<CentInRand>(entity =>
            {
                entity.Property(e => e.Value).HasColumnType("decimal(18, 5)");
            });

            modelBuilder.Entity<Electricity>(entity =>
            {
                entity.Property(e => e.ConstumptionMaxLevel).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ConsumptionMinLevel).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MaxPropertyValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MinPropertyValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PropposedTariff).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TariffAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TypeOfElectricity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ElectricityFreeBenefit>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FreeUnits).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MaxConsumption).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MinConsumption).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<IndigentIncomeLevel>(entity =>
            {
                entity.HasKey(e => e.IncomeId)
                    .HasName("PK_IncomeLevel");

                entity.Property(e => e.IncomeHigherLevel).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.IncomeLowerLevel).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Rebate).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<PensionerDisabledIncome>(entity =>
            {
                entity.HasKey(e => e.IncomeLevelId);

                entity.Property(e => e.HigherIncomeLevel).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LowerIncomeLevel).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Rebate).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<PersonType>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PropertyRebates>(entity =>
            {
                entity.Property(e => e.PropertyRebatesId).ValueGeneratedOnAdd();

                entity.Property(e => e.MaxIncome).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MinIncome).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.RebatePercent)
                    .HasColumnName("Rebate_Percent")
                    .HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.PropertyRebatesNavigation)
                    .WithOne(p => p.PropertyRebates)
                    .HasForeignKey<PropertyRebates>(d => d.PropertyRebatesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyRebates_PersonType");
            });

            modelBuilder.Entity<PropertyValueRefuseRebates>(entity =>
            {
                entity.Property(e => e.PropertyMaxValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PropertyMinValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.RebatePercent)
                    .HasColumnName("Rebate_Percent")
                    .HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Refuse>(entity =>
            {
                entity.Property(e => e.ChargeAmountExVat).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ChargeAmountIncVat).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefuseRebates>(entity =>
            {
                entity.Property(e => e.PropertyMaxValue)
                    .HasColumnName("Property_Max_Value")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PropertyMinValue)
                    .HasColumnName("Property_Min_Value")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RebatePercent).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<RefuseRebatesIndigent>(entity =>
            {
                entity.Property(e => e.MaxIncome).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.MinIncome).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.RebatePercentage).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<RefuseResidentialType>(entity =>
            {
                entity.Property(e => e.RefuseFrequencyWeekly).HasColumnName("RefuseFrequency_weekly");

                entity.Property(e => e.ResidentialType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResidentWasteCollection>(entity =>
            {
                entity.Property(e => e.ChargeAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sanitation>(entity =>
            {
                entity.Property(e => e.ChargeAmountExVat).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MaxConstumptValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinConstumptValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SanitationUnit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SanitationFreeBenefit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FreeConsumption).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PropertyMaxValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PropertyMinValue).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Roleid).HasColumnName("roleid");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("User_Role");

                entity.Property(e => e.UserRoleId).ValueGeneratedOnAdd();

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithOne(p => p.UserRole)
                    .HasForeignKey<UserRole>(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role_Role");

                entity.HasOne(d => d.UserRole1)
                    .WithOne(p => p.UserRole)
                    .HasForeignKey<UserRole>(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role_User");
            });

            modelBuilder.Entity<Vat>(entity =>
            {
                entity.Property(e => e.PercentageValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Water>(entity =>
            {
                entity.Property(e => e.ChargeAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MaxValue)
                    .HasColumnName("Max_value")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MinValue)
                    .HasColumnName("Min_value")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ProposedTariff).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.WaterType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WaterUnit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WaterFixedCharges>(entity =>
            {
                entity.HasKey(e => e.FixedChargeId);

                entity.Property(e => e.ChargeAmount).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<WaterMeter>(entity =>
            {
                entity.Property(e => e.MeterSize).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ValueExclVat).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ValueWithVat).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<WaterPropertyBenefit>(entity =>
            {
                entity.HasKey(e => e.WaterPropertyId);

                entity.Property(e => e.FreeConsumptionKl).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PropertyMaxValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PropertyMinValue).HasColumnType("decimal(18, 4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
