using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace QOnTMSSql.Models
{
    public partial class QOnTDbContext : DbContext
    {
        public QOnTDbContext()
        {
        }

        public QOnTDbContext(DbContextOptions<QOnTDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CityPrepDaysTbl> CityPrepDaysTbl { get; set; }
        public virtual DbSet<CityTbl> CityTbl { get; set; }
        public virtual DbSet<ClientUsageHistoryTbl> ClientUsageHistoryTbl { get; set; }
        public virtual DbSet<ClientUsageLinesTbl> ClientUsageLinesTbl { get; set; }
        public virtual DbSet<ClientUsageTbl> ClientUsageTbl { get; set; }
        public virtual DbSet<ClosureDatesTbl> ClosureDatesTbl { get; set; }
        public virtual DbSet<CustomerTrackedServiceItemsTbl> CustomerTrackedServiceItemsTbl { get; set; }
        public virtual DbSet<CustomerTypeTbl> CustomerTypeTbl { get; set; }
        public virtual DbSet<CustomersAccInfoTbl> CustomersAccInfoTbl { get; set; }
        public virtual DbSet<CustomersTbl> CustomersTbl { get; set; }
        public virtual DbSet<EquipTypeTbl> EquipTypeTbl { get; set; }
        public virtual DbSet<InvoiceTypeTbl> InvoiceTypeTbl { get; set; }
        public virtual DbSet<ItemGroupTbl> ItemGroupTbl { get; set; }
        public virtual DbSet<ItemTypeTbl> ItemTypeTbl { get; set; }
        public virtual DbSet<ItemUnitsTbl> ItemUnitsTbl { get; set; }
        public virtual DbSet<ItemUsageTbl> ItemUsageTbl { get; set; }
        public virtual DbSet<LogTbl> LogTbl { get; set; }
        public virtual DbSet<MachineConditionsTbl> MachineConditionsTbl { get; set; }
        public virtual DbSet<NextRoastDateByCityTbl> NextRoastDateByCityTbl { get; set; }
        public virtual DbSet<OrderList> OrderList { get; set; }
        public virtual DbSet<OrdersTbl> OrdersTbl { get; set; }
        public virtual DbSet<OrdersTblApr262008> OrdersTblApr262008 { get; set; }
        public virtual DbSet<PackagingTbl> PackagingTbl { get; set; }
        public virtual DbSet<PaymentTermsTbl> PaymentTermsTbl { get; set; }
        public virtual DbSet<PersonsTbl> PersonsTbl { get; set; }
        public virtual DbSet<PredictedOrdersTbl> PredictedOrdersTbl { get; set; }
        public virtual DbSet<PrepTypesTbl> PrepTypesTbl { get; set; }
        public virtual DbSet<PriceLevelsTbl> PriceLevelsTbl { get; set; }
        public virtual DbSet<ReoccuranceTypeTbl> ReoccuranceTypeTbl { get; set; }
        public virtual DbSet<ReoccuringOrderTbl> ReoccuringOrderTbl { get; set; }
        public virtual DbSet<RepairFaultsTbl> RepairFaultsTbl { get; set; }
        public virtual DbSet<RepairStatusesTbl> RepairStatusesTbl { get; set; }
        public virtual DbSet<RepairsTbl> RepairsTbl { get; set; }
        public virtual DbSet<SectionTypesTbl> SectionTypesTbl { get; set; }
        public virtual DbSet<SendCheckEmailTextsTbl> SendCheckEmailTextsTbl { get; set; }
        public virtual DbSet<SentRemindersLogTbl> SentRemindersLogTbl { get; set; }
        public virtual DbSet<ServiceTypesTbl> ServiceTypesTbl { get; set; }
        public virtual DbSet<SysDataTbl> SysDataTbl { get; set; }
        public virtual DbSet<TmpOrdersReplyTbl> TmpOrdersReplyTbl { get; set; }
        public virtual DbSet<TotalCountTrackerTbl> TotalCountTrackerTbl { get; set; }
        public virtual DbSet<TrackedServiceItemTbl> TrackedServiceItemTbl { get; set; }
        public virtual DbSet<TransactionTypesTbl> TransactionTypesTbl { get; set; }
        public virtual DbSet<UsageAveTbl> UsageAveTbl { get; set; }
        public virtual DbSet<UsageTblByDate> UsageTblByDate { get; set; }
        public virtual DbSet<UsedItemGroupTbl> UsedItemGroupTbl { get; set; }
        public virtual DbSet<VisitLogTbl> VisitLogTbl { get; set; }
        public virtual DbSet<WeekDaysTbl> WeekDaysTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=WARRENSSURFACE\\SQLExpress;Initial Catalog=QOnT;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityPrepDaysTbl>(entity =>
            {
                entity.HasKey(e => e.CityPrepDaysId)
                    .HasName("CityPrepDaysTbl$PrimaryKey");

                entity.HasIndex(e => e.CityId)
                    .HasName("CityPrepDaysTbl$CityTblCityPrepDaysTbl");

                entity.Property(e => e.CityPrepDaysId)
                    .HasColumnName("CityPrepDaysID")
                    .HasComment("Identifier");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.DeliveryDelayDays)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Days after the prep day that we deliver");

                entity.Property(e => e.DeliveryOrder).HasComment("in what order in the day is this deliverred");

                entity.Property(e => e.PrepDayOfWeekId)
                    .HasColumnName("PrepDayOfWeekID")
                    .HasComment("The Day of Week that they do the prep");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CityPrepDaysTbl)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CityPrepDaysTbl$CityTblCityPrepDaysTbl");
            });

            modelBuilder.Entity<CityTbl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.DeliveryDelay)
                    .HasDefaultValueSql("((1))")
                    .HasComment("The days after the roast date that the delivery is made");

                entity.Property(e => e.RoastingDay)
                    .HasDefaultValueSql("((3))")
                    .HasComment("Day of week where 1 = sunday");
            });

            modelBuilder.Entity<ClientUsageHistoryTbl>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("ClientUsageHistoryTbl$PrimaryKey");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("ClientUsageHistoryTbl$CustomerId");

                entity.HasIndex(e => e.HistoryId)
                    .HasName("ClientUsageHistoryTbl$HistoryID");

                entity.Property(e => e.HistoryId).HasColumnName("HistoryID");

                entity.Property(e => e.CustomerId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DailyConsumption)
                    .HasDefaultValueSql("((0))")
                    .HasComment("The amount of coffee they consume per week");

                entity.Property(e => e.DescaleAveCount)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Average count between descalings");

                entity.Property(e => e.FilterAveCount)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Average count between filters");

                entity.Property(e => e.ItemDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Date the that history was stored");

                entity.Property(e => e.LastCupCount)
                    .HasDefaultValueSql("((0))")
                    .HasComment("The last logged cup count");

                entity.Property(e => e.NextCleanOn)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Every time the cup count is divisable by 200");

                entity.Property(e => e.NextCoffeeBy)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Every 100 cups they need 1 kg coffee");

                entity.Property(e => e.NextDescaleEst)
                    .HasColumnType("datetime2(0)")
                    .HasComment("When they need to descale");

                entity.Property(e => e.NextFilterEst)
                    .HasColumnType("datetime2(0)")
                    .HasComment("When they need the new filter");

                entity.Property(e => e.NextServiceEst)
                    .HasColumnType("datetime2(0)")
                    .HasComment("When will the cup count be divisable by 5000");

                entity.Property(e => e.ServiceAveCount)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Average count between services");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ClientUsageLinesTbl>(entity =>
            {
                entity.HasKey(e => e.ClientUsageLineNo)
                    .HasName("ClientUsageLinesTbl$PrimaryKey");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("ClientUsageLinesTbl$CustomerID");

                entity.HasIndex(e => e.Date)
                    .HasName("ClientUsageLinesTbl$Date");

                entity.Property(e => e.CupCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Date of the visit");

                entity.Property(e => e.Notes).HasMaxLength(150);

                entity.Property(e => e.Qty).HasDefaultValueSql("((1))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ClientUsageTbl>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("ClientUsageTbl$PrimaryKey");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("ClientUsageTbl$CustomerId");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.DailyConsumption)
                    .HasDefaultValueSql("((0))")
                    .HasComment("The amount of coffee they consume per week");

                entity.Property(e => e.DescaleAveCount)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Average count between descalings");

                entity.Property(e => e.FilterAveCount)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Average count between filters");

                entity.Property(e => e.LastCupCount)
                    .HasDefaultValueSql("((0))")
                    .HasComment("The last logged cup count");

                entity.Property(e => e.NextCleanOn)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Every time the cup count is divisable by 200");

                entity.Property(e => e.NextCoffeeBy)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Every 100 cups they need 1 kg coffee");

                entity.Property(e => e.NextDescaleEst)
                    .HasColumnType("datetime2(0)")
                    .HasComment("When they need to descale");

                entity.Property(e => e.NextFilterEst)
                    .HasColumnType("datetime2(0)")
                    .HasComment("When they need the new filter");

                entity.Property(e => e.NextServiceEst)
                    .HasColumnType("datetime2(0)")
                    .HasComment("When will the cup count be divisable by 5000");

                entity.Property(e => e.ServiceAveCount)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Average count between services");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ClosureDatesTbl>(entity =>
            {
                entity.HasIndex(e => e.DateClosed)
                    .HasName("ClosureDatesTbl$DateClosed");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments).HasMaxLength(255);

                entity.Property(e => e.DateClosed).HasColumnType("datetime2(0)");

                entity.Property(e => e.DateReopen).HasColumnType("datetime2(0)");

                entity.Property(e => e.NextRoastDate).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<CustomerTrackedServiceItemsTbl>(entity =>
            {
                entity.HasKey(e => e.CustomerTrackedServiceItemsId)
                    .HasName("CustomerTrackedServiceItemsTbl$pk_CustomerTrackedServiceItemsID");

                entity.Property(e => e.CustomerTrackedServiceItemsId).HasColumnName("CustomerTrackedServiceItemsID");

                entity.Property(e => e.CustomerTypeId).HasColumnName("CustomerTypeID");

                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<CustomerTypeTbl>(entity =>
            {
                entity.HasKey(e => e.CustTypeId)
                    .HasName("CustomerTypeTbl$PrimaryKey");

                entity.HasIndex(e => e.CustTypeId)
                    .HasName("CustomerTypeTbl$CustTypeID");

                entity.Property(e => e.CustTypeId).HasColumnName("CustTypeID");

                entity.Property(e => e.CustTypeDesc).HasMaxLength(50);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<CustomersAccInfoTbl>(entity =>
            {
                entity.HasKey(e => e.CustomersAccInfoId)
                    .HasName("CustomersAccInfoTbl$pk_CustomersAccInfoID");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomersAccInfoTbl$UCID_CustomerID")
                    .IsUnique();

                entity.Property(e => e.CustomersAccInfoId).HasColumnName("CustomersAccInfoID");

                entity.Property(e => e.AccEmail).HasMaxLength(50);

                entity.Property(e => e.AccFirstName).HasMaxLength(50);

                entity.Property(e => e.AccLastName).HasMaxLength(50);

                entity.Property(e => e.AltAccEmail).HasMaxLength(50);

                entity.Property(e => e.AltAccFirstName).HasMaxLength(50);

                entity.Property(e => e.AltAccLastName).HasMaxLength(50);

                entity.Property(e => e.BankAccNo).HasMaxLength(30);

                entity.Property(e => e.BankBranch).HasMaxLength(50);

                entity.Property(e => e.BillAddr1).HasMaxLength(50);

                entity.Property(e => e.BillAddr2).HasMaxLength(50);

                entity.Property(e => e.BillAddr3).HasMaxLength(50);

                entity.Property(e => e.BillAddr4).HasMaxLength(50);

                entity.Property(e => e.BillAddr5).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerVatno)
                    .HasColumnName("CustomerVATNo")
                    .HasMaxLength(30);

                entity.Property(e => e.Enabled).HasDefaultValueSql("((0))");

                entity.Property(e => e.FullCoName).HasMaxLength(50);

                entity.Property(e => e.InvoiceTypeId).HasColumnName("InvoiceTypeID");

                entity.Property(e => e.PaymentTermId).HasColumnName("PaymentTermID");

                entity.Property(e => e.PriceLevelId).HasColumnName("PriceLevelID");

                entity.Property(e => e.RegNo).HasMaxLength(30);

                entity.Property(e => e.RequiresPurchOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShipAddr1).HasMaxLength(50);

                entity.Property(e => e.ShipAddr2).HasMaxLength(50);

                entity.Property(e => e.ShipAddr3).HasMaxLength(50);

                entity.Property(e => e.ShipAddr4).HasMaxLength(50);

                entity.Property(e => e.ShipAddr5).HasMaxLength(50);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<CustomersTbl>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("CustomersTbl$PrimaryKey");

                entity.HasIndex(e => e.AltEmailAddress)
                    .HasName("CustomersTbl$UCALTEM_AltEmailAddress");

                entity.HasIndex(e => e.CompanyName)
                    .HasName("CustomersTbl$UCCN_CompanyName")
                    .IsUnique();

                entity.HasIndex(e => e.ContactLastName)
                    .HasName("CustomersTbl$ContactLastName");

                entity.HasIndex(e => e.CustomerTypeId)
                    .HasName("CustomersTbl$CustomerTypeID");

                entity.HasIndex(e => e.EmailAddress)
                    .HasName("CustomersTbl$UCEM_EmailAddress");

                entity.HasIndex(e => e.PostalCode)
                    .HasName("CustomersTbl$PostalCode");

                entity.HasIndex(e => e.PrefPackagingId)
                    .HasName("CustomersTbl$PrefPrepTypeID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AltEmailAddress).HasMaxLength(255);

                entity.Property(e => e.AlwaysSendChkUp)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Always send the checkup email to them");

                entity.Property(e => e.Autofulfill)
                    .HasColumnName("autofulfill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BillingAddress).HasMaxLength(255);

                entity.Property(e => e.CellNumber).HasMaxLength(50);

                entity.Property(e => e.City).HasDefaultValueSql("((1))");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactAltFirstName).HasMaxLength(50);

                entity.Property(e => e.ContactAltLastName).HasMaxLength(50);

                entity.Property(e => e.ContactFirstName).HasMaxLength(30);

                entity.Property(e => e.ContactLastName).HasMaxLength(50);

                entity.Property(e => e.ContactTitle).HasMaxLength(50);

                entity.Property(e => e.ContractNo).HasMaxLength(50);

                entity.Property(e => e.CountryRegion)
                    .HasColumnName("Country/Region")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerTypeId)
                    .HasColumnName("CustomerTypeID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CustomerTypeOld)
                    .IsRequired()
                    .HasColumnName("CustomerTypeOLD")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Coffee Only')");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Extension).HasMaxLength(30);

                entity.Property(e => e.FaxNumber).HasMaxLength(30);

                entity.Property(e => e.LastDateSentReminder).HasColumnType("datetime2(0)");

                entity.Property(e => e.MachineSn)
                    .HasColumnName("MachineSN")
                    .HasMaxLength(50);

                entity.Property(e => e.NormallyResponds)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Does the client normally respond when sent an email");

                entity.Property(e => e.PhoneNumber).HasMaxLength(30);

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.PredictionDisabled).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrefPackagingId).HasColumnName("PrefPackagingID");

                entity.Property(e => e.PrefPrepTypeId).HasColumnName("PrefPrepTypeID");

                entity.Property(e => e.PreferedAgent)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Person who delivers");

                entity.Property(e => e.PriPrefQty).HasDefaultValueSql("((1))");

                entity.Property(e => e.ReminderCount)
                    .HasDefaultValueSql("((0))")
                    .HasComment("count of how many reminders have been sent without orders");

                entity.Property(e => e.SalesAgentId).HasColumnName("SalesAgentID");

                entity.Property(e => e.SecPrefQty)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Secondary Item quantity");

                entity.Property(e => e.SecondaryPreference).HasComment("Secondary Item Preference");

                entity.Property(e => e.SendDeliveryConfirmation).HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StateOrProvince).HasMaxLength(20);

                entity.Property(e => e.TypicallySecToo)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Cleint Always typically both secondary preference when taking primary");

                entity.Property(e => e.UsesFilter).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<EquipTypeTbl>(entity =>
            {
                entity.HasKey(e => e.EquipTypeId)
                    .HasName("EquipTypeTbl$PrimaryKey");

                entity.HasIndex(e => e.EquipTypeId)
                    .HasName("EquipTypeTbl$EquipTypeId");

                entity.Property(e => e.EquipTypeDesc).HasMaxLength(50);

                entity.Property(e => e.EquipTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<InvoiceTypeTbl>(entity =>
            {
                entity.HasKey(e => e.InvoiceTypeId)
                    .HasName("InvoiceTypeTbl$pk_InvoiceTypeID ");

                entity.HasIndex(e => e.InvoiceTypeDesc)
                    .HasName("InvoiceTypeTbl$UIT_InvoiceTypeDesc")
                    .IsUnique();

                entity.Property(e => e.InvoiceTypeId).HasColumnName("InvoiceTypeID");

                entity.Property(e => e.Enabled).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceTypeDesc).HasMaxLength(20);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ItemGroupTbl>(entity =>
            {
                entity.HasKey(e => e.ItemGroupId)
                    .HasName("ItemGroupTbl$pk_ItemGroupID");

                entity.Property(e => e.ItemGroupId).HasColumnName("ItemGroupID");

                entity.Property(e => e.Enabled).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupItemTypeId).HasColumnName("GroupItemTypeID");

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ItemTypeTbl>(entity =>
            {
                entity.HasKey(e => e.ItemTypeId)
                    .HasName("ItemTypeTbl$PrimaryKey");

                entity.HasIndex(e => e.ItemDesc)
                    .HasName("ItemTypeTbl$ItemDesc");

                entity.HasIndex(e => e.ItemTypeId)
                    .HasName("ItemTypeTbl$CoffeeTypeID");

                entity.HasIndex(e => e.ReplacementId)
                    .HasName("ItemTypeTbl$ReplacementID");

                entity.HasIndex(e => e.ServiceTypeId)
                    .HasName("ItemTypeTbl$ServiceTypeId");

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.Property(e => e.ItemDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemShortName).HasMaxLength(10);

                entity.Property(e => e.ItemUnitId).HasColumnName("ItemUnitID");

                entity.Property(e => e.ItemsCharacteritics).HasMaxLength(50);

                entity.Property(e => e.ReplacementId).HasColumnName("ReplacementID");

                entity.Property(e => e.ServiceTypeId).HasDefaultValueSql("((2))");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(20);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ItemUnitsTbl>(entity =>
            {
                entity.HasKey(e => e.ItemUnitId)
                    .HasName("ItemUnitsTbl$pk_ItemUnitsID");

                entity.Property(e => e.ItemUnitId).HasColumnName("ItemUnitID");

                entity.Property(e => e.UnitDescription).HasMaxLength(50);

                entity.Property(e => e.UnitOfMeasure).HasMaxLength(5);
            });

            modelBuilder.Entity<ItemUsageTbl>(entity =>
            {
                entity.HasKey(e => new { e.ClientUsageLineNo, e.CustomerId })
                    .HasName("ItemUsageTbl$PrimaryKey");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("ItemUsageTbl$CustomerID");

                entity.HasIndex(e => e.PackagingId)
                    .HasName("ItemUsageTbl$PrefPackagingID");

                entity.HasIndex(e => e.PrepTypeId)
                    .HasName("ItemUsageTbl$PrefPrepTypeID");

                entity.Property(e => e.ClientUsageLineNo).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AmountProvided).HasDefaultValueSql("((1))");

                entity.Property(e => e.Date).HasColumnType("datetime2(0)");

                entity.Property(e => e.ItemProvided).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes).HasMaxLength(150);

                entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

                entity.Property(e => e.PrepTypeId)
                    .HasColumnName("PrepTypeID")
                    .HasComment("What type of preperation was it.");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<LogTbl>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("LogTbl$pk_LogID");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime2(0)");

                entity.Property(e => e.Details).HasMaxLength(255);

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TranactionTypeId).HasColumnName("TranactionTypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<MachineConditionsTbl>(entity =>
            {
                entity.HasKey(e => e.MachineConditionId)
                    .HasName("MachineConditionsTbl$pk_MachineConditionID");

                entity.Property(e => e.MachineConditionId).HasColumnName("MachineConditionID");

                entity.Property(e => e.ConditionDesc).HasMaxLength(50);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<NextRoastDateByCityTbl>(entity =>
            {
                entity.HasKey(e => e.NextRoastDayId)
                    .HasName("NextRoastDateByCityTbl$PrimaryKey");

                entity.HasIndex(e => e.CityId)
                    .HasName("NextRoastDateByCityTbl$CityID");

                entity.HasIndex(e => e.NextRoastDayId)
                    .HasName("NextRoastDateByCityTbl$NextRoastDayID");

                entity.Property(e => e.NextRoastDayId).HasColumnName("NextRoastDayID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.NextDeliveryDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.NextPreperationDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.PreperationDate).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<OrderList>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alpino).HasMaxLength(255);

                entity.Property(e => e.Antigua).HasMaxLength(255);

                entity.Property(e => e.Asorgan).HasMaxLength(255);

                entity.Property(e => e.Cleints).HasDefaultValueSql("((0))");

                entity.Property(e => e.ClnTb)
                    .HasColumnName("Cln Tb")
                    .HasMaxLength(255);

                entity.Property(e => e.Day).HasMaxLength(255);

                entity.Property(e => e.Decaf).HasMaxLength(255);

                entity.Property(e => e.Decal).HasMaxLength(255);

                entity.Property(e => e.Done)
                    .HasColumnName("done")
                    .HasMaxLength(255);

                entity.Property(e => e.Filter).HasMaxLength(255);

                entity.Property(e => e.Harrar).HasMaxLength(255);

                entity.Property(e => e.LaPiram)
                    .HasColumnName("La Piram")
                    .HasMaxLength(255);

                entity.Property(e => e.Limu).HasMaxLength(255);

                entity.Property(e => e.LosIdol)
                    .HasColumnName("Los Idol")
                    .HasMaxLength(255);

                entity.Property(e => e.Mandheling).HasMaxLength(255);

                entity.Property(e => e.Marango).HasMaxLength(255);

                entity.Property(e => e.Marcala).HasMaxLength(255);

                entity.Property(e => e.NoOrder)
                    .HasColumnName("No order")
                    .HasMaxLength(255);

                entity.Property(e => e.Sidama).HasMaxLength(255);

                entity.Property(e => e.Switch).HasMaxLength(255);

                entity.Property(e => e.Terranova).HasMaxLength(255);

                entity.Property(e => e.Timana).HasMaxLength(255);

                entity.Property(e => e.Time).HasColumnType("datetime2(0)");

                entity.Property(e => e.Yirga).HasMaxLength(255);
            });

            modelBuilder.Entity<OrdersTbl>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("OrdersTbl$PrimaryKey");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("OrdersTbl$CustomerID");

                entity.HasIndex(e => e.ItemTypeId)
                    .HasName("OrdersTbl$CoffeeTypeID");

                entity.HasIndex(e => e.OrderDate)
                    .HasName("OrdersTbl$OrderDate");

                entity.HasIndex(e => e.PackagingId)
                    .HasName("OrdersTbl$PackagingID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Confirmed).HasDefaultValueSql("((1))");

                entity.Property(e => e.Done).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceDone).HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

                entity.Property(e => e.Packed)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Is it packed?");

                entity.Property(e => e.PrepTypeId)
                    .HasColumnName("PrepTypeID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseOrder).HasMaxLength(30);

                entity.Property(e => e.QuantityOrdered).HasDefaultValueSql("((1))");

                entity.Property(e => e.RequiredByDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.RoastDate)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ToBeDeliveredBy).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<OrdersTblApr262008>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("OrdersTbl_Apr26_2008$PrimaryKey");

                entity.ToTable("OrdersTbl_Apr26_2008");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("OrdersTbl_Apr26_2008$CustomerID");

                entity.HasIndex(e => e.ItemTypeId)
                    .HasName("OrdersTbl_Apr26_2008$CoffeeTypeID");

                entity.HasIndex(e => e.OrderDate)
                    .HasName("OrdersTbl_Apr26_2008$OrderDate");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Confirmed).HasDefaultValueSql("((1))");

                entity.Property(e => e.Done).HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuantityOrdered).HasDefaultValueSql("((1))");

                entity.Property(e => e.RequiredByDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.RoastDate)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ToBeDeliveredBy).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PackagingTbl>(entity =>
            {
                entity.HasKey(e => e.PackagingId)
                    .HasName("PackagingTbl$PrimaryKey");

                entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

                entity.Property(e => e.AdditionalNotes).HasMaxLength(255);

                entity.Property(e => e.Bgcolour)
                    .HasColumnName("BGColour")
                    .HasMaxLength(9)
                    .HasComment("Hex number in text format, for colour");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Symbol).HasMaxLength(255);
            });

            modelBuilder.Entity<PaymentTermsTbl>(entity =>
            {
                entity.HasKey(e => e.PaymentTermId)
                    .HasName("PaymentTermsTbl$pk_PaymentTermsID");

                entity.HasIndex(e => e.PaymentTermDesc)
                    .HasName("PaymentTermsTbl$UPT_PaymentTermDesc")
                    .IsUnique();

                entity.Property(e => e.PaymentTermId).HasColumnName("PaymentTermID");

                entity.Property(e => e.Enabled).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentTermDesc).HasMaxLength(20);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UseDays).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PersonsTbl>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PersonsTbl$PrimaryKey");

                entity.HasIndex(e => e.PersonId)
                    .HasName("PersonsTbl$PersonID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Abreviation).HasMaxLength(5);

                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Person).HasMaxLength(50);

                entity.Property(e => e.SecurityUsername).HasMaxLength(255);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<PredictedOrdersTbl>(entity =>
            {
                entity.HasKey(e => e.PredictedOrderId)
                    .HasName("PredictedOrdersTbl$PrimaryKey");

                entity.HasIndex(e => e.ContactId)
                    .HasName("PredictedOrdersTbl$ContactID");

                entity.HasIndex(e => e.ItemId)
                    .HasName("PredictedOrdersTbl$ItemId");

                entity.HasIndex(e => e.PackagingId)
                    .HasName("PredictedOrdersTbl$PackagingID");

                entity.HasIndex(e => e.PrepTypeId)
                    .HasName("PredictedOrdersTbl$PrepTypeID");

                entity.Property(e => e.PredictedOrderId).HasColumnName("PredictedOrderID");

                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .HasComment("For whom is the order");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Delivery Date of item");

                entity.Property(e => e.DeliveryPersonId)
                    .HasColumnName("DeliveryPersonID")
                    .HasComment("Who will deliver it");

                entity.Property(e => e.ItemId).HasComment("Item to be ordered");

                entity.Property(e => e.Notes).HasComment("any additional information");

                entity.Property(e => e.PackagingId)
                    .HasColumnName("PackagingID")
                    .HasComment("Packaging For this type");

                entity.Property(e => e.Pinned)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Used by the form to see if it is selected");

                entity.Property(e => e.PrepDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("date order is to be prepared");

                entity.Property(e => e.PrepTypeId)
                    .HasColumnName("PrepTypeID")
                    .HasComment("Prep type");

                entity.Property(e => e.Quantity).HasComment("Quantity ordered");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<PrepTypesTbl>(entity =>
            {
                entity.HasKey(e => e.PrepId)
                    .HasName("PrepTypesTbl$PrimaryKey");

                entity.HasIndex(e => e.IdentifyingChar)
                    .HasName("PrepTypesTbl$IdentifyingChar");

                entity.HasIndex(e => e.PrepId)
                    .HasName("PrepTypesTbl$PrepID");

                entity.Property(e => e.PrepId).HasColumnName("PrepID");

                entity.Property(e => e.IdentifyingChar).HasMaxLength(1);

                entity.Property(e => e.PrepType).HasMaxLength(50);
            });

            modelBuilder.Entity<PriceLevelsTbl>(entity =>
            {
                entity.HasKey(e => e.PriceLevelId)
                    .HasName("PriceLevelsTbl$pk_PriceLevelID ");

                entity.HasIndex(e => e.PriceLevelDesc)
                    .HasName("PriceLevelsTbl$UPL_PriceLevelDesc")
                    .IsUnique();

                entity.Property(e => e.PriceLevelId).HasColumnName("PriceLevelID");

                entity.Property(e => e.Enabled).HasDefaultValueSql("((0))");

                entity.Property(e => e.PriceLevelDesc).HasMaxLength(20);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ReoccuranceTypeTbl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<ReoccuringOrderTbl>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("ReoccuringOrderTbl$ID");

                entity.HasIndex(e => e.Id)
                    .HasName("ReoccuringOrderTbl$ID1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateLastDone).HasColumnType("datetime2(0)");

                entity.Property(e => e.DeliveryById).HasColumnName("DeliveryByID");

                entity.Property(e => e.ItemRequiredId).HasColumnName("ItemRequiredID");

                entity.Property(e => e.NextDateRequired).HasColumnType("datetime2(0)");

                entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

                entity.Property(e => e.RequireUntilDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<RepairFaultsTbl>(entity =>
            {
                entity.HasKey(e => e.RepairFaultId)
                    .HasName("RepairFaultsTbl$pk_RepairFaultID");

                entity.Property(e => e.RepairFaultId).HasColumnName("RepairFaultID");

                entity.Property(e => e.RepairFaultDesc).HasMaxLength(50);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<RepairStatusesTbl>(entity =>
            {
                entity.HasKey(e => e.RepairStatusId)
                    .HasName("RepairStatusesTbl$pk_RepairStatusID");

                entity.Property(e => e.RepairStatusId).HasColumnName("RepairStatusID");

                entity.Property(e => e.EmailClient).HasDefaultValueSql("((0))");

                entity.Property(e => e.RepairStatusDesc).HasMaxLength(50);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<RepairsTbl>(entity =>
            {
                entity.HasKey(e => e.RepairId)
                    .HasName("RepairsTbl$pk_RepairID");

                entity.Property(e => e.RepairId).HasColumnName("RepairID");

                entity.Property(e => e.BrokenBeanLid).HasDefaultValueSql("((0))");

                entity.Property(e => e.BrokenFrother).HasDefaultValueSql("((0))");

                entity.Property(e => e.BrokenWaterLid).HasDefaultValueSql("((0))");

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateLogged).HasColumnType("datetime2(0)");

                entity.Property(e => e.JobCardNumber).HasMaxLength(20);

                entity.Property(e => e.LastStatusChange).HasColumnType("datetime2(0)");

                entity.Property(e => e.MachineConditionId).HasColumnName("MachineConditionID");

                entity.Property(e => e.MachineSerialNumber).HasMaxLength(50);

                entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

                entity.Property(e => e.RelatedOrderId).HasColumnName("RelatedOrderID");

                entity.Property(e => e.RepairFaultDesc).HasMaxLength(255);

                entity.Property(e => e.RepairFaultId).HasColumnName("RepairFaultID");

                entity.Property(e => e.RepairStatusId).HasColumnName("RepairStatusID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SwopOutMachineId).HasColumnName("SwopOutMachineID");

                entity.Property(e => e.TakenBeanLid).HasDefaultValueSql("((0))");

                entity.Property(e => e.TakenFrother).HasDefaultValueSql("((0))");

                entity.Property(e => e.TakenWaterLid).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SectionTypesTbl>(entity =>
            {
                entity.HasKey(e => e.SectionId)
                    .HasName("SectionTypesTbl$pk_SectionID");

                entity.Property(e => e.SectionId)
                    .HasColumnName("SectionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SectionType).HasMaxLength(50);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<SendCheckEmailTextsTbl>(entity =>
            {
                entity.HasKey(e => e.Scemtid)
                    .HasName("SendCheckEmailTextsTbl$pk_SCEMTID");

                entity.Property(e => e.Scemtid).HasColumnName("SCEMTID");

                entity.Property(e => e.DateLastChange).HasColumnType("datetime2(0)");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<SentRemindersLogTbl>(entity =>
            {
                entity.HasKey(e => e.ReminderId)
                    .HasName("SentRemindersLogTbl$pk_ReminderID");

                entity.Property(e => e.ReminderId).HasColumnName("ReminderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateSentReminder).HasColumnType("datetime2(0)");

                entity.Property(e => e.HadAutoFulfilItem).HasDefaultValueSql("((0))");

                entity.Property(e => e.HadReoccurItems).HasDefaultValueSql("((0))");

                entity.Property(e => e.NextPrepDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.ReminderSent).HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ServiceTypesTbl>(entity =>
            {
                entity.HasKey(e => e.ServiceTypeId)
                    .HasName("ServiceTypesTbl$PrimaryKey");

                entity.HasIndex(e => e.PrepTypeId)
                    .HasName("ServiceTypesTbl$PrepTypeID");

                entity.HasIndex(e => e.ServiceTypeId)
                    .HasName("ServiceTypesTbl$ServiceTypeId");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.PackagingId)
                    .HasColumnName("PackagingID")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.PrepTypeId)
                    .HasColumnName("PrepTypeID")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.ServiceType).HasMaxLength(20);
            });

            modelBuilder.Entity<SysDataTbl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateLastPrepDateCalcd).HasColumnType("datetime2(0)");

                entity.Property(e => e.DoReoccuringOrders).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupItemTypeId).HasColumnName("GroupItemTypeID");

                entity.Property(e => e.LastReoccurringDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.MinReminderDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<TmpOrdersReplyTbl>(entity =>
            {
                entity.ToTable("tmpOrdersReplyTbl");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("tmpOrdersReplyTbl$CustomerId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First Name")
                    .HasMaxLength(50);

                entity.Property(e => e.NextCoffeeBy).HasColumnType("datetime2(0)");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ThisWeekPlease).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TotalCountTrackerTbl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .HasComment("Any comments for manual entry");

                entity.Property(e => e.CountDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Date count was stored");

                entity.Property(e => e.TotalCount).HasComment("Total cup count on date");
            });

            modelBuilder.Entity<TrackedServiceItemTbl>(entity =>
            {
                entity.HasKey(e => e.TrackerServiceItemId)
                    .HasName("TrackedServiceItemTbl$pk_TrackerServiceItemID");

                entity.Property(e => e.TrackerServiceItemId).HasColumnName("TrackerServiceItemID");

                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ThisItemSetsDailyAverage).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsageAveFieldName).HasMaxLength(20);

                entity.Property(e => e.UsageDateFieldName).HasMaxLength(20);
            });

            modelBuilder.Entity<TransactionTypesTbl>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("TransactionTypesTbl$pk_TransactionID");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TransactionType).HasMaxLength(50);
            });

            modelBuilder.Entity<UsageAveTbl>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("UsageAveTbl$PrimaryKey");

                entity.HasIndex(e => e.ClientId)
                    .HasName("UsageAveTbl$ClientId");

                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.Property(e => e.CoffeeCycle)
                    .HasDefaultValueSql("((7))")
                    .HasComment("Number of days between kilo consumption");

                entity.Property(e => e.CoffeeProvided)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Amount of coffee provided per cycle");

                entity.Property(e => e.CupsPerDaysConsumed)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Cups per day we calculate they consume");

                entity.Property(e => e.EstCleanDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Date with estimate tha the machien will be cleaned");

                entity.Property(e => e.EstDescaleDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Date we estimate they will descale");

                entity.Property(e => e.EstFilterDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Date we expect them to require a filter");

                entity.Property(e => e.EstReorderDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("When we expect them to reorder");

                entity.Property(e => e.FitlerOnlyClient)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Do they always use filters");

                entity.Property(e => e.LastCleanDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Date the machine was last cleaned");

                entity.Property(e => e.LastDescaleDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Date we descaled the Machine");

                entity.Property(e => e.LastFilterDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("Date they were provided a filter");

                entity.Property(e => e.LastOrderedDate)
                    .HasColumnType("datetime2(0)")
                    .HasComment("The should be calculated from the usage table");

                entity.Property(e => e.PreferedCoffeeId)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Which coffee they like");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<UsageTblByDate>(entity =>
            {
                entity.HasKey(e => e.UsaageId)
                    .HasName("UsageTblByDate$PrimaryKey");

                entity.HasIndex(e => e.ClientId)
                    .HasName("UsageTblByDate$ClientID");

                entity.HasIndex(e => e.UsaageId)
                    .HasName("UsageTblByDate$UsaageID");

                entity.Property(e => e.UsaageId).HasColumnName("UsaageID");

                entity.Property(e => e.ClientId)
                    .HasColumnName("ClientID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CoffeeProvded).HasDefaultValueSql("((0))");

                entity.Property(e => e.CountCheckOnly).HasDefaultValueSql("((0))");

                entity.Property(e => e.CupCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FilterProvided).HasDefaultValueSql("((0))");

                entity.Property(e => e.MachineCleaned).HasDefaultValueSql("((0))");

                entity.Property(e => e.MachineDescaled).HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<UsedItemGroupTbl>(entity =>
            {
                entity.HasKey(e => e.UsedItemGroupId)
                    .HasName("UsedItemGroupTbl$pk_UsedItemGroupID");

                entity.Property(e => e.UsedItemGroupId).HasColumnName("UsedItemGroupID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.GroupItemTypeId).HasColumnName("GroupItemTypeID");

                entity.Property(e => e.LastItemDateChanged).HasColumnType("datetime2(0)");

                entity.Property(e => e.LastItemTypeId).HasColumnName("LastItemTypeID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<VisitLogTbl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cleaned).HasDefaultValueSql("((0))");

                entity.Property(e => e.Client).HasDefaultValueSql("((0))");

                entity.Property(e => e.CoffeeQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.CoffeeTypeProvided).HasDefaultValueSql("((0))");

                entity.Property(e => e.CupsMade).HasDefaultValueSql("((0))");

                entity.Property(e => e.Descaled).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvRef).HasMaxLength(50);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VisitDate)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<WeekDaysTbl>(entity =>
            {
                entity.HasKey(e => e.WeekDaysId)
                    .HasName("WeekDaysTbl$PrimaryKey");

                entity.Property(e => e.WeekDaysId).HasColumnName("WeekDaysID");

                entity.Property(e => e.WeekDayName).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
