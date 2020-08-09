using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iSele.Services.Migrations
{
    public partial class InitialWithDbV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "iSele");

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "iSele",
                columns: table => new
                {
                    AreaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(maxLength: 75, nullable: true),
                    NextManufacturingDay = table.Column<short>(nullable: false),
                    NextDispatchDay = table.Column<short>(nullable: false),
                    EstimatedDeliveryDelay = table.Column<short>(nullable: true, defaultValue: (short)0),
                    Note = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "iSele",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "iSele",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClosureDates",
                schema: "iSele",
                columns: table => new
                {
                    ClosureDateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(maxLength: 50, nullable: true),
                    DateClosed = table.Column<DateTime>(nullable: false),
                    DateReopen = table.Column<DateTime>(nullable: false),
                    NextPrepDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosureDates", x => x.ClosureDateID);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                schema: "iSele",
                columns: table => new
                {
                    ContactTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactTypeName = table.Column<string>(maxLength: 100, nullable: false),
                    IsFulfillmentContact = table.Column<bool>(nullable: true, defaultValue: true),
                    IsAccountsContact = table.Column<bool>(nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.ContactTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                schema: "iSele",
                columns: table => new
                {
                    CustomerTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeName = table.Column<string>(maxLength: 100, nullable: false),
                    HasExtendedOptions = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.CustomerTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                schema: "iSele",
                columns: table => new
                {
                    EquipmentTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    EquipmentTypeDesc = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.EquipmentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                schema: "iSele",
                columns: table => new
                {
                    InvoiceTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(nullable: true, defaultValue: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.InvoiceTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                schema: "iSele",
                columns: table => new
                {
                    ItemTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeName = table.Column<string>(maxLength: 75, nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ItemTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ItemUnits",
                schema: "iSele",
                columns: table => new
                {
                    ItemUnitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(maxLength: 50, nullable: false),
                    UnitOfMeasure = table.Column<string>(maxLength: 10, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemUnits", x => x.ItemUnitID);
                });

            migrationBuilder.CreateTable(
                name: "MachineConditions",
                schema: "iSele",
                columns: table => new
                {
                    MachineConditionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionName = table.Column<string>(maxLength: 75, nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Notes = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineConditions", x => x.MachineConditionID);
                });

            migrationBuilder.CreateTable(
                name: "NotificationEmailTexts",
                schema: "iSele",
                columns: table => new
                {
                    NotificationEmailTextID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Footer = table.Column<string>(nullable: true),
                    DateLastChange = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationEmailTexts", x => x.NotificationEmailTextID);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                schema: "iSele",
                columns: table => new
                {
                    NotificationTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.NotificationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "OrderMethodTypes",
                schema: "iSele",
                columns: table => new
                {
                    OrderMethodTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodType = table.Column<string>(maxLength: 50, nullable: true),
                    IsGenerated = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMethodTypes", x => x.OrderMethodTypeID);
                });

            migrationBuilder.CreateTable(
                name: "OrderOptions",
                schema: "iSele",
                columns: table => new
                {
                    OrderOptionsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    InvoiceIsPrepared = table.Column<bool>(nullable: true),
                    EmailConfirmationSent = table.Column<bool>(nullable: true),
                    IsReadyForDispatch = table.Column<bool>(nullable: true),
                    ExpectedDeliveryDate = table.Column<DateTime>(nullable: true),
                    IsDone = table.Column<bool>(nullable: true),
                    PODImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOptions", x => x.OrderOptionsID);
                });

            migrationBuilder.CreateTable(
                name: "Packagings",
                schema: "iSele",
                columns: table => new
                {
                    PackagingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackagingName = table.Column<string>(maxLength: 50, nullable: false),
                    AdditionalNotes = table.Column<string>(maxLength: 255, nullable: true),
                    Symbol = table.Column<string>(maxLength: 2, nullable: true),
                    Colour = table.Column<int>(maxLength: 11, nullable: false),
                    BGColour = table.Column<string>(maxLength: 11, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packagings", x => x.PackagingID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTerms",
                schema: "iSele",
                columns: table => new
                {
                    PaymentTermID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTermName = table.Column<string>(maxLength: 50, nullable: false),
                    PaymentDays = table.Column<int>(nullable: false),
                    DayOfMonth = table.Column<int>(nullable: false),
                    UseDays = table.Column<bool>(nullable: true, defaultValue: false),
                    IsEnabled = table.Column<bool>(nullable: true, defaultValue: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerms", x => x.PaymentTermID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                schema: "iSele",
                columns: table => new
                {
                    PaymentTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(nullable: true, defaultValue: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PreferedDeliveryTimes",
                schema: "iSele",
                columns: table => new
                {
                    PreferedDeliveryTimeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartHour = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferedDeliveryTimes", x => x.PreferedDeliveryTimeID);
                });

            migrationBuilder.CreateTable(
                name: "PriceLevels",
                schema: "iSele",
                columns: table => new
                {
                    PriceLevelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceLevelName = table.Column<string>(maxLength: 50, nullable: false),
                    PriceLeveTypeID = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLevels", x => x.PriceLevelID);
                });

            migrationBuilder.CreateTable(
                name: "PriceTypeByPercents",
                schema: "iSele",
                columns: table => new
                {
                    PriceTypeByPercentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceTypeByPercentName = table.Column<string>(maxLength: 75, nullable: false),
                    Precentage = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTypeByPercents", x => x.PriceTypeByPercentID);
                });

            migrationBuilder.CreateTable(
                name: "PriceTypeByValues",
                schema: "iSele",
                columns: table => new
                {
                    PriceTypeByValueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceTypeByValueName = table.Column<string>(maxLength: 75, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTypeByValues", x => x.PriceTypeByValueID);
                });

            migrationBuilder.CreateTable(
                name: "RecurringTypes",
                schema: "iSele",
                columns: table => new
                {
                    RecurringTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(maxLength: 50, nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringTypes", x => x.RecurringTypeID);
                });

            migrationBuilder.CreateTable(
                name: "RepairFaults",
                schema: "iSele",
                columns: table => new
                {
                    RepairFaultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairFaultName = table.Column<string>(maxLength: 75, nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Notes = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairFaults", x => x.RepairFaultID);
                });

            migrationBuilder.CreateTable(
                name: "RepairStatuses",
                schema: "iSele",
                columns: table => new
                {
                    RepairStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairStatusName = table.Column<string>(maxLength: 50, nullable: false),
                    EmailClient = table.Column<bool>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairStatuses", x => x.RepairStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                schema: "iSele",
                columns: table => new
                {
                    ServiceTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeName = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SystemPreferences",
                schema: "iSele",
                columns: table => new
                {
                    SystemPreferencesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastReccurringDate = table.Column<DateTime>(nullable: false),
                    DoReccuringOrders = table.Column<bool>(nullable: false),
                    DateLastPrepDateCalcd = table.Column<DateTime>(nullable: false),
                    MinReminderDate = table.Column<DateTime>(nullable: false),
                    GroupItemTypeID = table.Column<int>(nullable: false),
                    ImageFolderPath = table.Column<string>(maxLength: 100, nullable: true),
                    DefaultDeliveryPersonID = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemPreferences", x => x.SystemPreferencesID);
                });

            migrationBuilder.CreateTable(
                name: "TimeZones",
                schema: "iSele",
                columns: table => new
                {
                    TimeZoneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISOAbbreviation = table.Column<string>(maxLength: 10, nullable: false),
                    TimeZoneName = table.Column<string>(maxLength: 30, nullable: true),
                    UTCOffset = table.Column<short>(nullable: false),
                    HasDaylightSavings = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZones", x => x.TimeZoneID);
                });

            migrationBuilder.CreateTable(
                name: "TotalCounterTracker",
                schema: "iSele",
                columns: table => new
                {
                    TotalCountTrackerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountDate = table.Column<DateTime>(nullable: false),
                    TotalCount = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalCounterTracker", x => x.TotalCountTrackerID);
                });

            migrationBuilder.CreateTable(
                name: "UsedItemGroups",
                schema: "iSele",
                columns: table => new
                {
                    UsedItemGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    GroupItemD = table.Column<int>(nullable: false),
                    LastItemID = table.Column<int>(nullable: false),
                    LastItemSortPos = table.Column<int>(nullable: false),
                    LastItemDateChanged = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedItemGroups", x => x.UsedItemGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Varieties",
                schema: "iSele",
                columns: table => new
                {
                    VarietyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VarietyName = table.Column<string>(maxLength: 50, nullable: false),
                    AdditionalNotes = table.Column<string>(maxLength: 255, nullable: true),
                    Symbol = table.Column<string>(maxLength: 2, nullable: true),
                    Colour = table.Column<int>(maxLength: 11, nullable: false),
                    BGColour = table.Column<string>(maxLength: 11, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varieties", x => x.VarietyID);
                });

            migrationBuilder.CreateTable(
                name: "VATTaxTypes",
                schema: "iSele",
                columns: table => new
                {
                    VATTaxTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VATTaxName = table.Column<string>(maxLength: 50, nullable: false),
                    VATTaxRate = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    IsDefault = table.Column<bool>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VATTaxTypes", x => x.VATTaxTypeID);
                });

            migrationBuilder.CreateTable(
                name: "WeekDays",
                schema: "iSele",
                columns: table => new
                {
                    WeekDayID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDayName = table.Column<string>(maxLength: 10, nullable: false),
                    IsDispatchDay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.WeekDayID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "iSele",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(maxLength: 75, nullable: false),
                    AreaID = table.Column<int>(nullable: true),
                    CountryCode = table.Column<string>(maxLength: 3, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Cities_Areas_AreaID",
                        column: x => x.AreaID,
                        principalSchema: "iSele",
                        principalTable: "Areas",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "iSele",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "iSele",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "iSele",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "iSele",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "iSele",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "iSele",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "iSele",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "iSele",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "iSele",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "iSele",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "iSele",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemoEquipment",
                schema: "iSele",
                columns: table => new
                {
                    DemoEquipmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemoEquipmentName = table.Column<string>(maxLength: 80, nullable: false),
                    EquipmentTypeID = table.Column<int>(nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 80, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoEquipment", x => x.DemoEquipmentID);
                    table.ForeignKey(
                        name: "FK_DemoEquipment_EquipmentTypes_EquipmentTypeID",
                        column: x => x.EquipmentTypeID,
                        principalSchema: "iSele",
                        principalTable: "EquipmentTypes",
                        principalColumn: "EquipmentTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderPaymentOptions",
                schema: "iSele",
                columns: table => new
                {
                    OrderPaymentOptionsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    PurchaseOrder = table.Column<string>(maxLength: 100, nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaymentTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPaymentOptions", x => x.OrderPaymentOptionsID);
                    table.ForeignKey(
                        name: "FK_OrderPaymentOptions_PaymentTypes_PaymentTypeID",
                        column: x => x.PaymentTypeID,
                        principalSchema: "iSele",
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "iSele",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(maxLength: 80, nullable: false),
                    SKU = table.Column<string>(maxLength: 20, nullable: true),
                    IsEnabled = table.Column<bool>(nullable: true, defaultValue: true),
                    ItemCharacteritics = table.Column<string>(maxLength: 100, nullable: true),
                    ItemDetail = table.Column<string>(maxLength: 255, nullable: true),
                    ItemTypeID = table.Column<int>(nullable: true),
                    ReplacementItemID = table.Column<int>(nullable: true),
                    ItemAbbreviatedame = table.Column<string>(maxLength: 10, nullable: true),
                    SortOrder = table.Column<short>(nullable: false),
                    QtyPerUnits = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    ItemUnitID = table.Column<int>(nullable: true),
                    CostPriceEXVAT = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CostPriceIncVAT = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BasePriceEXVAT = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BasePriceIncVAT = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    VATTaxTypeID = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeID",
                        column: x => x.ItemTypeID,
                        principalSchema: "iSele",
                        principalTable: "ItemTypes",
                        principalColumn: "ItemTypeID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Items_ItemUnits_ItemUnitID",
                        column: x => x.ItemUnitID,
                        principalSchema: "iSele",
                        principalTable: "ItemUnits",
                        principalColumn: "ItemUnitID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Items_Items_ReplacementItemID",
                        column: x => x.ReplacementItemID,
                        principalSchema: "iSele",
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_VATTaxTypes_VATTaxTypeID",
                        column: x => x.VATTaxTypeID,
                        principalSchema: "iSele",
                        principalTable: "VATTaxTypes",
                        principalColumn: "VATTaxTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PriceListTypes",
                schema: "iSele",
                columns: table => new
                {
                    PriceListTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListName = table.Column<string>(maxLength: 80, nullable: true),
                    PriceTypeID = table.Column<int>(nullable: false),
                    VATTaxTypeID = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListTypes", x => x.PriceListTypeID);
                    table.ForeignKey(
                        name: "FK_PriceListTypes_VATTaxTypes_VATTaxTypeID",
                        column: x => x.VATTaxTypeID,
                        principalSchema: "iSele",
                        principalTable: "VATTaxTypes",
                        principalColumn: "VATTaxTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                schema: "iSele",
                columns: table => new
                {
                    PartyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartysName = table.Column<string>(maxLength: 50, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 5, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsForOrderFulfillment = table.Column<bool>(nullable: false),
                    NormalDeliveryDoWID = table.Column<int>(nullable: true),
                    LoginUserID = table.Column<string>(maxLength: 255, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyID);
                    table.ForeignKey(
                        name: "FK_Parties_WeekDays_NormalDeliveryDoWID",
                        column: x => x.NormalDeliveryDoWID,
                        principalSchema: "iSele",
                        principalTable: "WeekDays",
                        principalColumn: "WeekDayID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "iSele",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(maxLength: 75, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 75, nullable: true),
                    AddressLine3 = table.Column<string>(maxLength: 75, nullable: true),
                    CityID = table.Column<int>(nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityID",
                        column: x => x.CityID,
                        principalSchema: "iSele",
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AreaDaySettings",
                schema: "iSele",
                columns: table => new
                {
                    AreaDaySettingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(maxLength: 80, nullable: true),
                    CityID = table.Column<int>(nullable: true),
                    PreperationDayOfWeekID = table.Column<int>(nullable: true),
                    DispatchDelayDays = table.Column<short>(nullable: false),
                    DeliveryOrder = table.Column<short>(nullable: false),
                    EstimateDeliveryDaily = table.Column<short>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaDaySettings", x => x.AreaDaySettingID);
                    table.ForeignKey(
                        name: "FK_AreaDaySettings_Cities_CityID",
                        column: x => x.CityID,
                        principalSchema: "iSele",
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AreaDaySettings_WeekDays_PreperationDayOfWeekID",
                        column: x => x.PreperationDayOfWeekID,
                        principalSchema: "iSele",
                        principalTable: "WeekDays",
                        principalColumn: "WeekDayID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DemoEquipmentUsage",
                schema: "iSele",
                columns: table => new
                {
                    DemoEquipmentUsageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    DemoEquipmentID = table.Column<int>(nullable: false),
                    ReceiveDate = table.Column<DateTime>(nullable: false),
                    ReturneDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoEquipmentUsage", x => x.DemoEquipmentUsageID);
                    table.ForeignKey(
                        name: "FK_DemoEquipmentUsage_DemoEquipment_DemoEquipmentID",
                        column: x => x.DemoEquipmentID,
                        principalSchema: "iSele",
                        principalTable: "DemoEquipment",
                        principalColumn: "DemoEquipmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                schema: "iSele",
                columns: table => new
                {
                    ItemGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupItemID = table.Column<int>(nullable: true),
                    ItemID = table.Column<int>(nullable: true),
                    ItemSortPos = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.ItemGroupID);
                    table.ForeignKey(
                        name: "FK_ItemGroups_Items_GroupItemID",
                        column: x => x.GroupItemID,
                        principalSchema: "iSele",
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ItemGroups_Items_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "iSele",
                        principalTable: "Items",
                        principalColumn: "ItemID");
                });

            migrationBuilder.CreateTable(
                name: "ItemPrices",
                schema: "iSele",
                columns: table => new
                {
                    ItemPriceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(nullable: false),
                    PriceListTypeID = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrices", x => x.ItemPriceID);
                    table.ForeignKey(
                        name: "FK_ItemPrices_PriceListTypes_PriceListTypeID",
                        column: x => x.PriceListTypeID,
                        principalSchema: "iSele",
                        principalTable: "PriceListTypes",
                        principalColumn: "PriceListTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PriceGroups",
                schema: "iSele",
                columns: table => new
                {
                    PriceGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceGroupName = table.Column<string>(maxLength: 75, nullable: false),
                    PriceListTypeID = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceGroups", x => x.PriceGroupID);
                    table.ForeignKey(
                        name: "FK_PriceGroups_PriceListTypes_PriceListTypeID",
                        column: x => x.PriceListTypeID,
                        principalSchema: "iSele",
                        principalTable: "PriceListTypes",
                        principalColumn: "PriceListTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderFulfillments",
                schema: "iSele",
                columns: table => new
                {
                    OrderFulfillmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    DateFulfilled = table.Column<DateTime>(nullable: false),
                    FulfilledByID = table.Column<int>(nullable: true),
                    TrackingNumber = table.Column<string>(maxLength: 60, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFulfillments", x => x.OrderFulfillmentID);
                    table.ForeignKey(
                        name: "FK_OrderFulfillments_Parties_FulfilledByID",
                        column: x => x.FulfilledByID,
                        principalSchema: "iSele",
                        principalTable: "Parties",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccountingOptions",
                schema: "iSele",
                columns: table => new
                {
                    CustomerAccountingOptionsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    VATTaxNum = table.Column<string>(maxLength: 50, nullable: false),
                    PrimaryBillingAddressID = table.Column<int>(nullable: true),
                    PrimaryShippingAddressID = table.Column<int>(nullable: true),
                    AccEmails = table.Column<string>(maxLength: 200, nullable: true),
                    OnlyEmailInvoices = table.Column<bool>(nullable: true, defaultValue: true),
                    PaymentTermsID = table.Column<int>(nullable: true),
                    Limit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FullCompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    AccountContactName = table.Column<string>(maxLength: 100, nullable: true),
                    IsPORequired = table.Column<bool>(nullable: true, defaultValue: false),
                    PriceLevelID = table.Column<int>(nullable: true),
                    InvoiceTypeID = table.Column<int>(nullable: true),
                    AccountIsEnabled = table.Column<bool>(nullable: true, defaultValue: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccountingOptions", x => x.CustomerAccountingOptionsID);
                    table.ForeignKey(
                        name: "FK_CustomerAccountingOptions_InvoiceTypes_InvoiceTypeID",
                        column: x => x.InvoiceTypeID,
                        principalSchema: "iSele",
                        principalTable: "InvoiceTypes",
                        principalColumn: "InvoiceTypeID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CustomerAccountingOptions_PaymentTerms_PaymentTermsID",
                        column: x => x.PaymentTermsID,
                        principalSchema: "iSele",
                        principalTable: "PaymentTerms",
                        principalColumn: "PaymentTermID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CustomerAccountingOptions_PriceLevels_PriceLevelID",
                        column: x => x.PriceLevelID,
                        principalSchema: "iSele",
                        principalTable: "PriceLevels",
                        principalColumn: "PriceLevelID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CustomerAccountingOptions_Addresses_PrimaryBillingAddressID",
                        column: x => x.PrimaryBillingAddressID,
                        principalSchema: "iSele",
                        principalTable: "Addresses",
                        principalColumn: "AddressID");
                    table.ForeignKey(
                        name: "FK_CustomerAccountingOptions_Addresses_PrimaryShippingAddressID",
                        column: x => x.PrimaryShippingAddressID,
                        principalSchema: "iSele",
                        principalTable: "Addresses",
                        principalColumn: "AddressID");
                });

            migrationBuilder.CreateTable(
                name: "PostCodeAreas",
                schema: "iSele",
                columns: table => new
                {
                    PostCodeAreaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCodeStart = table.Column<string>(maxLength: 15, nullable: false),
                    PostCodeEnd = table.Column<string>(maxLength: 15, nullable: false),
                    AreaDayID = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCodeAreas", x => x.PostCodeAreaID);
                    table.ForeignKey(
                        name: "FK_PostCodeAreas_AreaDaySettings_AreaDayID",
                        column: x => x.AreaDayID,
                        principalSchema: "iSele",
                        principalTable: "AreaDaySettings",
                        principalColumn: "AreaDaySettingID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomerContacts",
                schema: "iSele",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Telephone = table.Column<string>(maxLength: 25, nullable: true),
                    Mobile = table.Column<string>(maxLength: 25, nullable: true),
                    ShippingAddressID = table.Column<int>(nullable: true),
                    PostalAddressID = table.Column<int>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: true, defaultValue: true),
                    ContactTypeID = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContacts", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_CustomerContacts_ContactTypes_ContactTypeID",
                        column: x => x.ContactTypeID,
                        principalSchema: "iSele",
                        principalTable: "ContactTypes",
                        principalColumn: "ContactTypeID");
                    table.ForeignKey(
                        name: "FK_CustomerContacts_Addresses_PostalAddressID",
                        column: x => x.PostalAddressID,
                        principalSchema: "iSele",
                        principalTable: "Addresses",
                        principalColumn: "AddressID");
                    table.ForeignKey(
                        name: "FK_CustomerContacts_Addresses_ShippingAddressID",
                        column: x => x.ShippingAddressID,
                        principalSchema: "iSele",
                        principalTable: "Addresses",
                        principalColumn: "AddressID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "iSele",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false),
                    CustomerName = table.Column<int>(maxLength: 100, nullable: false),
                    PrimaryContactFirstName = table.Column<int>(maxLength: 100, nullable: false),
                    PrimaryContactLastName = table.Column<int>(maxLength: 100, nullable: false),
                    PrimaryContactEmail = table.Column<string>(maxLength: 100, nullable: true),
                    Telephone = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    IsMobilePrimary = table.Column<bool>(nullable: false, defaultValue: false),
                    IsEnabled = table.Column<bool>(nullable: true, defaultValue: true),
                    CustomerTypeID = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerAccountingOptions_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "iSele",
                        principalTable: "CustomerAccountingOptions",
                        principalColumn: "CustomerAccountingOptionsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_CustomerTypeID",
                        column: x => x.CustomerTypeID,
                        principalSchema: "iSele",
                        principalTable: "CustomerTypes",
                        principalColumn: "CustomerTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomerEquipment",
                schema: "iSele",
                columns: table => new
                {
                    CustomerEquipmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    EquipmentTypeID = table.Column<int>(nullable: true),
                    EquipSerialNo = table.Column<string>(maxLength: 50, nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEquipment", x => x.CustomerEquipmentID);
                    table.ForeignKey(
                        name: "FK_CustomerEquipment_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "iSele",
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEquipment_EquipmentTypes_EquipmentTypeID",
                        column: x => x.EquipmentTypeID,
                        principalSchema: "iSele",
                        principalTable: "EquipmentTypes",
                        principalColumn: "EquipmentTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPrefPerTypes",
                schema: "iSele",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false),
                    CustomerPrefPerTypeID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: true),
                    PackagingID = table.Column<int>(nullable: true),
                    VarietyID = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPrefPerTypes", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_CustomerPrefPerTypes_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "iSele",
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPrefPerTypes_Items_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "iSele",
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CustomerPrefPerTypes_Packagings_PackagingID",
                        column: x => x.PackagingID,
                        principalSchema: "iSele",
                        principalTable: "Packagings",
                        principalColumn: "PackagingID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CustomerPrefPerTypes_Varieties_VarietyID",
                        column: x => x.VarietyID,
                        principalSchema: "iSele",
                        principalTable: "Varieties",
                        principalColumn: "VarietyID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "NotificationsSentLogs",
                schema: "iSele",
                columns: table => new
                {
                    NotificationsSentLogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    DateSentNotification = table.Column<DateTime>(nullable: false),
                    NotificationTypeID = table.Column<int>(nullable: true),
                    NotificationWasSent = table.Column<bool>(nullable: false),
                    NotificationDesription = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationsSentLogs", x => x.NotificationsSentLogID);
                    table.ForeignKey(
                        name: "FK_NotificationsSentLogs_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "iSele",
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationsSentLogs_NotificationTypes_NotificationTypeID",
                        column: x => x.NotificationTypeID,
                        principalSchema: "iSele",
                        principalTable: "NotificationTypes",
                        principalColumn: "NotificationTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "iSele",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    PreparationDate = table.Column<DateTime>(nullable: false),
                    OrderMethodTypeID = table.Column<int>(nullable: true),
                    DeliveryByID = table.Column<int>(nullable: true),
                    DispatchDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "iSele",
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Orders_Parties_DeliveryByID",
                        column: x => x.DeliveryByID,
                        principalSchema: "iSele",
                        principalTable: "Parties",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Orders_OrderOptions_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "iSele",
                        principalTable: "OrderOptions",
                        principalColumn: "OrderOptionsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderPaymentOptions_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "iSele",
                        principalTable: "OrderPaymentOptions",
                        principalColumn: "OrderPaymentOptionsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderMethodTypes_OrderMethodTypeID",
                        column: x => x.OrderMethodTypeID,
                        principalSchema: "iSele",
                        principalTable: "OrderMethodTypes",
                        principalColumn: "OrderMethodTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                schema: "iSele",
                columns: table => new
                {
                    RepairID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    ContactName = table.Column<string>(maxLength: 75, nullable: true),
                    ContactEmail = table.Column<string>(maxLength: 75, nullable: true),
                    JobCardNumber = table.Column<string>(maxLength: 20, nullable: true),
                    DateLogged = table.Column<DateTime>(nullable: false),
                    LastStatusChange = table.Column<DateTime>(nullable: false),
                    EquipmentTypeID = table.Column<int>(nullable: true),
                    EquipmentSerialNumber = table.Column<string>(maxLength: 75, nullable: true),
                    SwopOutEquipmentID = table.Column<int>(nullable: true),
                    MachineConditionID = table.Column<int>(nullable: true),
                    TakenFrother = table.Column<bool>(nullable: false),
                    TakenBeanLid = table.Column<bool>(nullable: false),
                    TakenWaterLid = table.Column<bool>(nullable: false),
                    IsFrotherWorking = table.Column<bool>(nullable: false),
                    IsBeanLidOk = table.Column<bool>(nullable: false),
                    IsWaterLidOk = table.Column<bool>(nullable: false),
                    RepairFaultID = table.Column<int>(nullable: true),
                    RepairFaultDesc = table.Column<string>(maxLength: 255, nullable: true),
                    RepairStatusID = table.Column<int>(nullable: true),
                    RelatedOrderID = table.Column<int>(nullable: true),
                    Notes = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairID);
                    table.ForeignKey(
                        name: "FK_Repairs_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "iSele",
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Repairs_EquipmentTypes_EquipmentTypeID",
                        column: x => x.EquipmentTypeID,
                        principalSchema: "iSele",
                        principalTable: "EquipmentTypes",
                        principalColumn: "EquipmentTypeID");
                    table.ForeignKey(
                        name: "FK_Repairs_MachineConditions_MachineConditionID",
                        column: x => x.MachineConditionID,
                        principalSchema: "iSele",
                        principalTable: "MachineConditions",
                        principalColumn: "MachineConditionID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Repairs_RepairFaults_RepairFaultID",
                        column: x => x.RepairFaultID,
                        principalSchema: "iSele",
                        principalTable: "RepairFaults",
                        principalColumn: "RepairFaultID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Repairs_RepairStatuses_RepairStatusID",
                        column: x => x.RepairStatusID,
                        principalSchema: "iSele",
                        principalTable: "RepairStatuses",
                        principalColumn: "RepairStatusID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Repairs_DemoEquipment_SwopOutEquipmentID",
                        column: x => x.SwopOutEquipmentID,
                        principalSchema: "iSele",
                        principalTable: "DemoEquipment",
                        principalColumn: "DemoEquipmentID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                schema: "iSele",
                columns: table => new
                {
                    OrderLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: true),
                    QtyOrdered = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    PackagingID = table.Column<int>(nullable: true),
                    VarietyID = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.OrderLineID);
                    table.ForeignKey(
                        name: "FK_OrderLines_Items_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "iSele",
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "iSele",
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Packagings_PackagingID",
                        column: x => x.PackagingID,
                        principalSchema: "iSele",
                        principalTable: "Packagings",
                        principalColumn: "PackagingID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderLines_Varieties_VarietyID",
                        column: x => x.VarietyID,
                        principalSchema: "iSele",
                        principalTable: "Varieties",
                        principalColumn: "VarietyID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPostalAddresses",
                schema: "iSele",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPostalAddresses", x => new { x.CustomerID, x.AddressID });
                });

            migrationBuilder.CreateTable(
                name: "CustomerShippingAddresses",
                schema: "iSele",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerShippingAddresses", x => new { x.CustomerID, x.AddressID });
                });

            migrationBuilder.CreateTable(
                name: "CustomerFulfilmentOptions",
                schema: "iSele",
                columns: table => new
                {
                    CustomerFulfilmentOptionsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    PreferedPostalAddressID = table.Column<int>(nullable: true),
                    PreferedShippingAddressID = table.Column<int>(nullable: true),
                    IsAutoFulfilled = table.Column<bool>(nullable: false),
                    DoesNormallyRespond = table.Column<bool>(nullable: false),
                    AlwaysSendNotification = table.Column<bool>(nullable: false),
                    PredictionIsEnabled = table.Column<bool>(nullable: false),
                    PreferedDispatchDayID = table.Column<int>(nullable: true),
                    PreferedDeliveryTimeID = table.Column<int>(nullable: true),
                    ReminderCount = table.Column<int>(nullable: false),
                    LastReminderDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFulfilmentOptions", x => x.CustomerFulfilmentOptionsID);
                    table.ForeignKey(
                        name: "FK_CustomerFulfilmentOptions_PreferedDeliveryTimes_PreferedDeliveryTimeID",
                        column: x => x.PreferedDeliveryTimeID,
                        principalSchema: "iSele",
                        principalTable: "PreferedDeliveryTimes",
                        principalColumn: "PreferedDeliveryTimeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerFulfilmentOptions_WeekDays_PreferedDispatchDayID",
                        column: x => x.PreferedDispatchDayID,
                        principalSchema: "iSele",
                        principalTable: "WeekDays",
                        principalColumn: "WeekDayID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerFulfilmentOptions_CustomerPostalAddresses_CustomerID_PreferedPostalAddressID",
                        columns: x => new { x.CustomerID, x.PreferedPostalAddressID },
                        principalSchema: "iSele",
                        principalTable: "CustomerPostalAddresses",
                        principalColumns: new[] { "CustomerID", "AddressID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerFulfilmentOptions_CustomerShippingAddresses_CustomerID_PreferedShippingAddressID",
                        columns: x => new { x.CustomerID, x.PreferedShippingAddressID },
                        principalSchema: "iSele",
                        principalTable: "CustomerShippingAddresses",
                        principalColumns: new[] { "CustomerID", "AddressID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecurringOrders",
                schema: "iSele",
                columns: table => new
                {
                    RecurringOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    RecurringTypeID = table.Column<int>(nullable: true),
                    RecurringValue = table.Column<int>(nullable: false),
                    NextDateRequired = table.Column<DateTime>(nullable: false),
                    RequireUntilDate = table.Column<DateTime>(nullable: false),
                    DateLastDone = table.Column<DateTime>(nullable: false),
                    DeliveryByID = table.Column<int>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringOrders", x => x.RecurringOrderID);
                    table.ForeignKey(
                        name: "FK_RecurringOrders_CustomerFulfilmentOptions_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "iSele",
                        principalTable: "CustomerFulfilmentOptions",
                        principalColumn: "CustomerFulfilmentOptionsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecurringOrders_Parties_DeliveryByID",
                        column: x => x.DeliveryByID,
                        principalSchema: "iSele",
                        principalTable: "Parties",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RecurringOrders_RecurringTypes_RecurringTypeID",
                        column: x => x.RecurringTypeID,
                        principalSchema: "iSele",
                        principalTable: "RecurringTypes",
                        principalColumn: "RecurringTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RecurringOrderItem",
                schema: "iSele",
                columns: table => new
                {
                    RecurringOrderItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecurringOrderID = table.Column<int>(nullable: false),
                    ItemRequiredID = table.Column<int>(nullable: true),
                    PackagingRequiredID = table.Column<int>(nullable: true),
                    VarietyRequiredID = table.Column<int>(nullable: true),
                    QtyRequired = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringOrderItem", x => x.RecurringOrderItemID);
                    table.ForeignKey(
                        name: "FK_RecurringOrderItem_Items_ItemRequiredID",
                        column: x => x.ItemRequiredID,
                        principalSchema: "iSele",
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RecurringOrderItem_Packagings_PackagingRequiredID",
                        column: x => x.PackagingRequiredID,
                        principalSchema: "iSele",
                        principalTable: "Packagings",
                        principalColumn: "PackagingID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RecurringOrderItem_RecurringOrders_RecurringOrderID",
                        column: x => x.RecurringOrderID,
                        principalSchema: "iSele",
                        principalTable: "RecurringOrders",
                        principalColumn: "RecurringOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecurringOrderItem_Varieties_VarietyRequiredID",
                        column: x => x.VarietyRequiredID,
                        principalSchema: "iSele",
                        principalTable: "Varieties",
                        principalColumn: "VarietyID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressLine1",
                schema: "iSele",
                table: "Addresses",
                column: "AddressLine1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressLine2",
                schema: "iSele",
                table: "Addresses",
                column: "AddressLine2");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressLine3",
                schema: "iSele",
                table: "Addresses",
                column: "AddressLine3");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityID",
                schema: "iSele",
                table: "Addresses",
                column: "CityID",
                unique: true,
                filter: "[CityID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PostalCode",
                schema: "iSele",
                table: "Addresses",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_AreaDaySettings_AreaName",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "AreaName",
                unique: true,
                filter: "[AreaName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AreaDaySettings_CityID",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_AreaDaySettings_PreperationDayOfWeekID",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "PreperationDayOfWeekID");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_AreaName",
                schema: "iSele",
                table: "Areas",
                column: "AreaName",
                unique: true,
                filter: "[AreaName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "iSele",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "iSele",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "iSele",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "iSele",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "iSele",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "iSele",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "iSele",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_AreaID",
                schema: "iSele",
                table: "Cities",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityName",
                schema: "iSele",
                table: "Cities",
                column: "CityName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClosureDates_EventName",
                schema: "iSele",
                table: "ClosureDates",
                column: "EventName",
                unique: true,
                filter: "[EventName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_ContactTypeName",
                schema: "iSele",
                table: "ContactTypes",
                column: "ContactTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountingOptions_AccEmails",
                schema: "iSele",
                table: "CustomerAccountingOptions",
                column: "AccEmails");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountingOptions_AccountContactName",
                schema: "iSele",
                table: "CustomerAccountingOptions",
                column: "AccountContactName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountingOptions_FullCompanyName",
                schema: "iSele",
                table: "CustomerAccountingOptions",
                column: "FullCompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountingOptions_InvoiceTypeID",
                schema: "iSele",
                table: "CustomerAccountingOptions",
                column: "InvoiceTypeID",
                unique: true,
                filter: "[InvoiceTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountingOptions_PaymentTermsID",
                schema: "iSele",
                table: "CustomerAccountingOptions",
                column: "PaymentTermsID",
                unique: true,
                filter: "[PaymentTermsID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountingOptions_PriceLevelID",
                schema: "iSele",
                table: "CustomerAccountingOptions",
                column: "PriceLevelID",
                unique: true,
                filter: "[PriceLevelID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountingOptions_PrimaryBillingAddressID",
                schema: "iSele",
                table: "CustomerAccountingOptions",
                column: "PrimaryBillingAddressID",
                unique: true,
                filter: "[PrimaryBillingAddressID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountingOptions_PrimaryShippingAddressID",
                schema: "iSele",
                table: "CustomerAccountingOptions",
                column: "PrimaryShippingAddressID",
                unique: true,
                filter: "[PrimaryShippingAddressID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountingOptions_VATTaxNum",
                schema: "iSele",
                table: "CustomerAccountingOptions",
                column: "VATTaxNum");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_ContactTypeID",
                schema: "iSele",
                table: "CustomerContacts",
                column: "ContactTypeID",
                unique: true,
                filter: "[ContactTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CustomerID",
                schema: "iSele",
                table: "CustomerContacts",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_Email",
                schema: "iSele",
                table: "CustomerContacts",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_FirstName",
                schema: "iSele",
                table: "CustomerContacts",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_LastName",
                schema: "iSele",
                table: "CustomerContacts",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_Mobile",
                schema: "iSele",
                table: "CustomerContacts",
                column: "Mobile");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_PostalAddressID",
                schema: "iSele",
                table: "CustomerContacts",
                column: "PostalAddressID",
                unique: true,
                filter: "[PostalAddressID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_ShippingAddressID",
                schema: "iSele",
                table: "CustomerContacts",
                column: "ShippingAddressID",
                unique: true,
                filter: "[ShippingAddressID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_Telephone",
                schema: "iSele",
                table: "CustomerContacts",
                column: "Telephone");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEquipment_CustomerID",
                schema: "iSele",
                table: "CustomerEquipment",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEquipment_EquipSerialNo",
                schema: "iSele",
                table: "CustomerEquipment",
                column: "EquipSerialNo");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEquipment_EquipmentTypeID",
                schema: "iSele",
                table: "CustomerEquipment",
                column: "EquipmentTypeID",
                unique: true,
                filter: "[EquipmentTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFulfilmentOptions_PreferedDeliveryTimeID",
                schema: "iSele",
                table: "CustomerFulfilmentOptions",
                column: "PreferedDeliveryTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFulfilmentOptions_PreferedDispatchDayID",
                schema: "iSele",
                table: "CustomerFulfilmentOptions",
                column: "PreferedDispatchDayID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFulfilmentOptions_CustomerID_PreferedPostalAddressID",
                schema: "iSele",
                table: "CustomerFulfilmentOptions",
                columns: new[] { "CustomerID", "PreferedPostalAddressID" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFulfilmentOptions_CustomerID_PreferedShippingAddressID",
                schema: "iSele",
                table: "CustomerFulfilmentOptions",
                columns: new[] { "CustomerID", "PreferedShippingAddressID" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPrefPerTypes_ItemID",
                schema: "iSele",
                table: "CustomerPrefPerTypes",
                column: "ItemID",
                unique: true,
                filter: "[ItemID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPrefPerTypes_PackagingID",
                schema: "iSele",
                table: "CustomerPrefPerTypes",
                column: "PackagingID",
                unique: true,
                filter: "[PackagingID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPrefPerTypes_VarietyID",
                schema: "iSele",
                table: "CustomerPrefPerTypes",
                column: "VarietyID",
                unique: true,
                filter: "[VarietyID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerName",
                schema: "iSele",
                table: "Customers",
                column: "CustomerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeID",
                schema: "iSele",
                table: "Customers",
                column: "CustomerTypeID",
                unique: true,
                filter: "[CustomerTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Mobile",
                schema: "iSele",
                table: "Customers",
                column: "Mobile");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PrimaryContactEmail",
                schema: "iSele",
                table: "Customers",
                column: "PrimaryContactEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PrimaryContactFirstName",
                schema: "iSele",
                table: "Customers",
                column: "PrimaryContactFirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PrimaryContactLastName",
                schema: "iSele",
                table: "Customers",
                column: "PrimaryContactLastName");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Telephone",
                schema: "iSele",
                table: "Customers",
                column: "Telephone");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypes_CustomerTypeName",
                schema: "iSele",
                table: "CustomerTypes",
                column: "CustomerTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DemoEquipment_DemoEquipmentName",
                schema: "iSele",
                table: "DemoEquipment",
                column: "DemoEquipmentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DemoEquipment_EquipmentTypeID",
                schema: "iSele",
                table: "DemoEquipment",
                column: "EquipmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DemoEquipmentUsage_DemoEquipmentID",
                schema: "iSele",
                table: "DemoEquipmentUsage",
                column: "DemoEquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DemoEquipmentUsage_ReceiveDate",
                schema: "iSele",
                table: "DemoEquipmentUsage",
                column: "ReceiveDate");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTypes_EquipmentTypeName",
                schema: "iSele",
                table: "EquipmentTypes",
                column: "EquipmentTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTypes_InvoiceTypeName",
                schema: "iSele",
                table: "InvoiceTypes",
                column: "InvoiceTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_GroupItemID",
                schema: "iSele",
                table: "ItemGroups",
                column: "GroupItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_ItemID",
                schema: "iSele",
                table: "ItemGroups",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrices_PriceListTypeID",
                schema: "iSele",
                table: "ItemPrices",
                column: "PriceListTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemName",
                schema: "iSele",
                table: "Items",
                column: "ItemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeID",
                schema: "iSele",
                table: "Items",
                column: "ItemTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemUnitID",
                schema: "iSele",
                table: "Items",
                column: "ItemUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ReplacementItemID",
                schema: "iSele",
                table: "Items",
                column: "ReplacementItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SKU",
                schema: "iSele",
                table: "Items",
                column: "SKU",
                unique: true,
                filter: "[SKU] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Items_VATTaxTypeID",
                schema: "iSele",
                table: "Items",
                column: "VATTaxTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_ItemTypeName",
                schema: "iSele",
                table: "ItemTypes",
                column: "ItemTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnits_UnitName",
                schema: "iSele",
                table: "ItemUnits",
                column: "UnitName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineConditions_ConditionName",
                schema: "iSele",
                table: "MachineConditions",
                column: "ConditionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineConditions_SortOrder_ConditionName",
                schema: "iSele",
                table: "MachineConditions",
                columns: new[] { "SortOrder", "ConditionName" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsSentLogs_CustomerID",
                schema: "iSele",
                table: "NotificationsSentLogs",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsSentLogs_DateSentNotification",
                schema: "iSele",
                table: "NotificationsSentLogs",
                column: "DateSentNotification");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsSentLogs_NotificationTypeID",
                schema: "iSele",
                table: "NotificationsSentLogs",
                column: "NotificationTypeID",
                unique: true,
                filter: "[NotificationTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTypes_NotificationTypeName",
                schema: "iSele",
                table: "NotificationTypes",
                column: "NotificationTypeName",
                unique: true,
                filter: "[NotificationTypeName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_DateFulfilled",
                schema: "iSele",
                table: "OrderFulfillments",
                column: "DateFulfilled");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_FulfilledByID",
                schema: "iSele",
                table: "OrderFulfillments",
                column: "FulfilledByID",
                unique: true,
                filter: "[FulfilledByID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_TrackingNumber",
                schema: "iSele",
                table: "OrderFulfillments",
                column: "TrackingNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ItemID",
                schema: "iSele",
                table: "OrderLines",
                column: "ItemID",
                unique: true,
                filter: "[ItemID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderID",
                schema: "iSele",
                table: "OrderLines",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_PackagingID",
                schema: "iSele",
                table: "OrderLines",
                column: "PackagingID",
                unique: true,
                filter: "[PackagingID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_VarietyID",
                schema: "iSele",
                table: "OrderLines",
                column: "VarietyID",
                unique: true,
                filter: "[VarietyID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMethodTypes_MethodType",
                schema: "iSele",
                table: "OrderMethodTypes",
                column: "MethodType",
                unique: true,
                filter: "[MethodType] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentOptions_OrderID",
                schema: "iSele",
                table: "OrderPaymentOptions",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentOptions_PaymentTypeID",
                schema: "iSele",
                table: "OrderPaymentOptions",
                column: "PaymentTypeID",
                unique: true,
                filter: "[PaymentTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                schema: "iSele",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryByID",
                schema: "iSele",
                table: "Orders",
                column: "DeliveryByID",
                unique: true,
                filter: "[DeliveryByID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDate",
                schema: "iSele",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderMethodTypeID",
                schema: "iSele",
                table: "Orders",
                column: "OrderMethodTypeID",
                unique: true,
                filter: "[OrderMethodTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Packagings_PackagingName",
                schema: "iSele",
                table: "Packagings",
                column: "PackagingName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Abbreviation",
                schema: "iSele",
                table: "Parties",
                column: "Abbreviation",
                unique: true,
                filter: "[Abbreviation] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_NormalDeliveryDoWID",
                schema: "iSele",
                table: "Parties",
                column: "NormalDeliveryDoWID",
                unique: true,
                filter: "[NormalDeliveryDoWID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_PartysName",
                schema: "iSele",
                table: "Parties",
                column: "PartysName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTerms_PaymentTermName",
                schema: "iSele",
                table: "PaymentTerms",
                column: "PaymentTermName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_PaymentTypeName",
                schema: "iSele",
                table: "PaymentTypes",
                column: "PaymentTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostCodeAreas_AreaDayID",
                schema: "iSele",
                table: "PostCodeAreas",
                column: "AreaDayID");

            migrationBuilder.CreateIndex(
                name: "IX_PostCodeAreas_PostCodeEnd",
                schema: "iSele",
                table: "PostCodeAreas",
                column: "PostCodeEnd");

            migrationBuilder.CreateIndex(
                name: "IX_PostCodeAreas_PostCodeStart",
                schema: "iSele",
                table: "PostCodeAreas",
                column: "PostCodeStart");

            migrationBuilder.CreateIndex(
                name: "IX_PriceGroups_PriceGroupName",
                schema: "iSele",
                table: "PriceGroups",
                column: "PriceGroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceGroups_PriceListTypeID",
                schema: "iSele",
                table: "PriceGroups",
                column: "PriceListTypeID",
                unique: true,
                filter: "[PriceListTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLevels_PriceLevelName",
                schema: "iSele",
                table: "PriceLevels",
                column: "PriceLevelName");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListTypes_PriceListName",
                schema: "iSele",
                table: "PriceListTypes",
                column: "PriceListName");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListTypes_VATTaxTypeID",
                schema: "iSele",
                table: "PriceListTypes",
                column: "VATTaxTypeID",
                unique: true,
                filter: "[VATTaxTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTypeByPercents_PriceTypeByPercentName",
                schema: "iSele",
                table: "PriceTypeByPercents",
                column: "PriceTypeByPercentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceTypeByValues_PriceTypeByValueName",
                schema: "iSele",
                table: "PriceTypeByValues",
                column: "PriceTypeByValueName");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrderItem_ItemRequiredID",
                schema: "iSele",
                table: "RecurringOrderItem",
                column: "ItemRequiredID",
                unique: true,
                filter: "[ItemRequiredID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrderItem_PackagingRequiredID",
                schema: "iSele",
                table: "RecurringOrderItem",
                column: "PackagingRequiredID",
                unique: true,
                filter: "[PackagingRequiredID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrderItem_RecurringOrderID",
                schema: "iSele",
                table: "RecurringOrderItem",
                column: "RecurringOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrderItem_VarietyRequiredID",
                schema: "iSele",
                table: "RecurringOrderItem",
                column: "VarietyRequiredID",
                unique: true,
                filter: "[VarietyRequiredID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrders_CustomerID",
                schema: "iSele",
                table: "RecurringOrders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrders_DateLastDone",
                schema: "iSele",
                table: "RecurringOrders",
                column: "DateLastDone");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrders_DeliveryByID",
                schema: "iSele",
                table: "RecurringOrders",
                column: "DeliveryByID",
                unique: true,
                filter: "[DeliveryByID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrders_RecurringTypeID",
                schema: "iSele",
                table: "RecurringOrders",
                column: "RecurringTypeID",
                unique: true,
                filter: "[RecurringTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTypes_TypeName",
                schema: "iSele",
                table: "RecurringTypes",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairFaults_RepairFaultName",
                schema: "iSele",
                table: "RepairFaults",
                column: "RepairFaultName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairFaults_SortOrder_RepairFaultName",
                schema: "iSele",
                table: "RepairFaults",
                columns: new[] { "SortOrder", "RepairFaultName" });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CustomerID",
                schema: "iSele",
                table: "Repairs",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_EquipmentSerialNumber",
                schema: "iSele",
                table: "Repairs",
                column: "EquipmentSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_EquipmentTypeID",
                schema: "iSele",
                table: "Repairs",
                column: "EquipmentTypeID",
                unique: true,
                filter: "[EquipmentTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_JobCardNumber",
                schema: "iSele",
                table: "Repairs",
                column: "JobCardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_MachineConditionID",
                schema: "iSele",
                table: "Repairs",
                column: "MachineConditionID",
                unique: true,
                filter: "[MachineConditionID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_RepairFaultID",
                schema: "iSele",
                table: "Repairs",
                column: "RepairFaultID",
                unique: true,
                filter: "[RepairFaultID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_RepairStatusID",
                schema: "iSele",
                table: "Repairs",
                column: "RepairStatusID",
                unique: true,
                filter: "[RepairStatusID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_SwopOutEquipmentID",
                schema: "iSele",
                table: "Repairs",
                column: "SwopOutEquipmentID",
                unique: true,
                filter: "[SwopOutEquipmentID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RepairStatuses_RepairStatusName",
                schema: "iSele",
                table: "RepairStatuses",
                column: "RepairStatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairStatuses_SortOrder_RepairStatusName",
                schema: "iSele",
                table: "RepairStatuses",
                columns: new[] { "SortOrder", "RepairStatusName" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_ServiceTypeName",
                schema: "iSele",
                table: "ServiceTypes",
                column: "ServiceTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeZones_TimeZoneName",
                schema: "iSele",
                table: "TimeZones",
                column: "TimeZoneName",
                unique: true,
                filter: "[TimeZoneName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Varieties_VarietyName",
                schema: "iSele",
                table: "Varieties",
                column: "VarietyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VATTaxTypes_VATTaxName",
                schema: "iSele",
                table: "VATTaxTypes",
                column: "VATTaxName");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContacts_Customers_CustomerID",
                schema: "iSele",
                table: "CustomerContacts",
                column: "CustomerID",
                principalSchema: "iSele",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerFulfilmentOptions_CustomerID",
                schema: "iSele",
                table: "Customers",
                column: "CustomerID",
                principalSchema: "iSele",
                principalTable: "CustomerFulfilmentOptions",
                principalColumn: "CustomerFulfilmentOptionsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPostalAddresses_CustomerFulfilmentOptions_CustomerID",
                schema: "iSele",
                table: "CustomerPostalAddresses",
                column: "CustomerID",
                principalSchema: "iSele",
                principalTable: "CustomerFulfilmentOptions",
                principalColumn: "CustomerFulfilmentOptionsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerShippingAddresses_CustomerFulfilmentOptions_CustomerID",
                schema: "iSele",
                table: "CustomerShippingAddresses",
                column: "CustomerID",
                principalSchema: "iSele",
                principalTable: "CustomerFulfilmentOptions",
                principalColumn: "CustomerFulfilmentOptionsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFulfilmentOptions_WeekDays_PreferedDispatchDayID",
                schema: "iSele",
                table: "CustomerFulfilmentOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFulfilmentOptions_PreferedDeliveryTimes_PreferedDeliveryTimeID",
                schema: "iSele",
                table: "CustomerFulfilmentOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFulfilmentOptions_CustomerPostalAddresses_CustomerID_PreferedPostalAddressID",
                schema: "iSele",
                table: "CustomerFulfilmentOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFulfilmentOptions_CustomerShippingAddresses_CustomerID_PreferedShippingAddressID",
                schema: "iSele",
                table: "CustomerFulfilmentOptions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "ClosureDates",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "CustomerContacts",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "CustomerEquipment",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "CustomerPrefPerTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "DemoEquipmentUsage",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "ItemGroups",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "ItemPrices",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "NotificationEmailTexts",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "NotificationsSentLogs",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "OrderFulfillments",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "OrderLines",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "PostCodeAreas",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "PriceGroups",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "PriceTypeByPercents",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "PriceTypeByValues",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "RecurringOrderItem",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Repairs",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "ServiceTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "SystemPreferences",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "TimeZones",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "TotalCounterTracker",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "UsedItemGroups",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "ContactTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "NotificationTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "AreaDaySettings",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "PriceListTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Packagings",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "RecurringOrders",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Varieties",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "MachineConditions",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "RepairFaults",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "RepairStatuses",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "DemoEquipment",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "OrderOptions",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "OrderPaymentOptions",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "OrderMethodTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "ItemTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "ItemUnits",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "VATTaxTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Parties",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "RecurringTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "EquipmentTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "CustomerAccountingOptions",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "CustomerTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "PaymentTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "InvoiceTypes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "PaymentTerms",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "PriceLevels",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "Areas",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "WeekDays",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "PreferedDeliveryTimes",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "CustomerPostalAddresses",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "CustomerShippingAddresses",
                schema: "iSele");

            migrationBuilder.DropTable(
                name: "CustomerFulfilmentOptions",
                schema: "iSele");
        }
    }
}
