using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sigmaHashAlpha.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompleteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptInorOptOut = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    FactorMother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopPositionPSU = table.Column<bool>(type: "bit", nullable: false),
                    SideWindow = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RGBControl = table.Column<bool>(type: "bit", nullable: false),
                    USB20front = table.Column<short>(type: "smallint", nullable: true),
                    USB30front = table.Column<short>(type: "smallint", nullable: true),
                    USBTypeC = table.Column<short>(type: "smallint", nullable: true),
                    USBTypeCInternal = table.Column<short>(type: "smallint", nullable: true),
                    HDFrontAudio = table.Column<bool>(type: "bit", nullable: false),
                    Width = table.Column<short>(type: "smallint", nullable: true),
                    Height = table.Column<short>(type: "smallint", nullable: true),
                    Lenght = table.Column<short>(type: "smallint", nullable: true),
                    MaxCPUHeight = table.Column<short>(type: "smallint", nullable: true),
                    Fans80mmSupported = table.Column<short>(type: "smallint", nullable: true),
                    Fans80mmIncluded = table.Column<short>(type: "smallint", nullable: true),
                    Fans120mmSupported = table.Column<short>(type: "smallint", nullable: true),
                    Fans120mmIncluded = table.Column<short>(type: "smallint", nullable: true),
                    Fans140mmSupported = table.Column<short>(type: "smallint", nullable: true),
                    Fans140mmIncluded = table.Column<short>(type: "smallint", nullable: true),
                    Fans200mmSupported = table.Column<short>(type: "smallint", nullable: true),
                    Fans200mmIncluded = table.Column<short>(type: "smallint", nullable: true),
                    Radiator240mmSupport = table.Column<short>(type: "smallint", nullable: true),
                    Radiator280mmSupport = table.Column<short>(type: "smallint", nullable: true),
                    Radiator360mmSupport = table.Column<short>(type: "smallint", nullable: true),
                    Radiator420mmSupport = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cpus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cores = table.Column<short>(type: "smallint", nullable: true),
                    Frequency = table.Column<double>(type: "float", nullable: true),
                    GPUChipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Threads = table.Column<short>(type: "smallint", nullable: true),
                    TurboFrequency = table.Column<double>(type: "float", nullable: true),
                    TDP = table.Column<short>(type: "smallint", nullable: true),
                    IncludesCooler = table.Column<bool>(type: "bit", nullable: false),
                    L3 = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gpus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    HDMI = table.Column<short>(type: "smallint", nullable: true),
                    VGA = table.Column<short>(type: "smallint", nullable: true),
                    DVIdigital = table.Column<short>(type: "smallint", nullable: true),
                    DisplayPorts = table.Column<short>(type: "smallint", nullable: true),
                    DoubleBridge = table.Column<bool>(type: "bit", nullable: false),
                    USBtypeC = table.Column<short>(type: "smallint", nullable: true),
                    SLIorCrossfire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<short>(type: "smallint", nullable: true),
                    Lenght = table.Column<short>(type: "smallint", nullable: true),
                    Consumption = table.Column<short>(type: "smallint", nullable: true),
                    RecommendedWatts = table.Column<short>(type: "smallint", nullable: true),
                    Backplate = table.Column<bool>(type: "bit", nullable: false),
                    VGAWaterCooling = table.Column<bool>(type: "bit", nullable: false),
                    AmountOfCoolers = table.Column<short>(type: "smallint", nullable: true),
                    MemorySpeed = table.Column<short>(type: "smallint", nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryCapacity = table.Column<short>(type: "smallint", nullable: true),
                    MemoryInterface = table.Column<short>(type: "smallint", nullable: true),
                    CoreTurboSpeed = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keyboards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    MechanismType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwitchFamily = table.Column<int>(type: "int", nullable: true),
                    RGBColor = table.Column<bool>(type: "bit", nullable: false),
                    AntiGhosting = table.Column<bool>(type: "bit", nullable: false),
                    NKeyRollover = table.Column<bool>(type: "bit", nullable: false),
                    width = table.Column<short>(type: "smallint", nullable: true),
                    lenght = table.Column<short>(type: "smallint", nullable: true),
                    Wireless = table.Column<bool>(type: "bit", nullable: false),
                    CanRemoveCable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Miscellaneous",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miscellaneous", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    RetroilluminationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCurved = table.Column<bool>(type: "bit", nullable: false),
                    Inches = table.Column<short>(type: "smallint", nullable: true),
                    MaxResolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshRate = table.Column<short>(type: "smallint", nullable: true),
                    NvidiaGSync = table.Column<bool>(type: "bit", nullable: false),
                    AMDFreeSync = table.Column<bool>(type: "bit", nullable: false),
                    TouchScreen = table.Column<bool>(type: "bit", nullable: false),
                    HDMI = table.Column<short>(type: "smallint", nullable: true),
                    DVI = table.Column<short>(type: "smallint", nullable: true),
                    VGA = table.Column<short>(type: "smallint", nullable: true),
                    DisplayPort = table.Column<short>(type: "smallint", nullable: true),
                    Usb20Ports = table.Column<short>(type: "smallint", nullable: true),
                    Usb30Ports = table.Column<short>(type: "smallint", nullable: true),
                    Usb31Ports = table.Column<short>(type: "smallint", nullable: true),
                    MiniDisplayPort = table.Column<short>(type: "smallint", nullable: true),
                    Width = table.Column<short>(type: "smallint", nullable: true),
                    Height = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCIE16Xslots = table.Column<short>(type: "smallint", nullable: true),
                    PCIE1Xslots = table.Column<short>(type: "smallint", nullable: true),
                    MultiGPU = table.Column<short>(type: "smallint", nullable: true),
                    SATAports = table.Column<short>(type: "smallint", nullable: true),
                    VGAoutputs = table.Column<short>(type: "smallint", nullable: true),
                    HDMIoutputs = table.Column<short>(type: "smallint", nullable: true),
                    DIVoutputs = table.Column<short>(type: "smallint", nullable: true),
                    DisplayPorts = table.Column<short>(type: "smallint", nullable: true),
                    M2slots = table.Column<short>(type: "smallint", nullable: true),
                    BuiltInWifi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RGBconnection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USB20 = table.Column<short>(type: "smallint", nullable: true),
                    USB30 = table.Column<short>(type: "smallint", nullable: true),
                    USB31 = table.Column<short>(type: "smallint", nullable: true),
                    USB32 = table.Column<short>(type: "smallint", nullable: true),
                    USBtypeC = table.Column<short>(type: "smallint", nullable: true),
                    PCIE4X = table.Column<short>(type: "smallint", nullable: true),
                    M2SATA = table.Column<short>(type: "smallint", nullable: true),
                    M2nvme = table.Column<short>(type: "smallint", nullable: true),
                    factor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxCpuWatts = table.Column<short>(type: "smallint", nullable: true),
                    CPU4pins = table.Column<short>(type: "smallint", nullable: true),
                    CPU4pinsplus = table.Column<short>(type: "smallint", nullable: true),
                    pins24 = table.Column<short>(type: "smallint", nullable: true),
                    consumption = table.Column<short>(type: "smallint", nullable: true),
                    DDRslots = table.Column<short>(type: "smallint", nullable: true),
                    DDR2slots = table.Column<short>(type: "smallint", nullable: true),
                    DDR3slots = table.Column<short>(type: "smallint", nullable: true),
                    DDR4slots = table.Column<short>(type: "smallint", nullable: true),
                    DDR5slots = table.Column<short>(type: "smallint", nullable: true),
                    SoundCard = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mouses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    ButtonAmount = table.Column<short>(type: "smallint", nullable: true),
                    SwitchesType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SensorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wireless = table.Column<bool>(type: "bit", nullable: false),
                    Wired = table.Column<bool>(type: "bit", nullable: false),
                    AdjustableDPI = table.Column<bool>(type: "bit", nullable: false),
                    MinimumDPI = table.Column<short>(type: "smallint", nullable: true),
                    MaximumDPI = table.Column<short>(type: "smallint", nullable: true),
                    Weight = table.Column<short>(type: "smallint", nullable: true),
                    CanChangeWeights = table.Column<bool>(type: "bit", nullable: false),
                    Width = table.Column<short>(type: "smallint", nullable: true),
                    lenght = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    MainImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    VisitCounter = table.Column<int>(type: "int", nullable: false),
                    SoldCounter = table.Column<int>(type: "int", nullable: false),
                    Popularity = table.Column<float>(type: "real", nullable: true),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Psus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WattsNominal = table.Column<short>(type: "smallint", nullable: true),
                    WattsReal = table.Column<short>(type: "smallint", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HybridMode = table.Column<bool>(type: "bit", nullable: false),
                    CableType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitalPSU = table.Column<bool>(type: "bit", nullable: false),
                    CPU4Pin = table.Column<short>(type: "smallint", nullable: true),
                    CPU4PinPlus = table.Column<short>(type: "smallint", nullable: true),
                    Pin24 = table.Column<short>(type: "smallint", nullable: true),
                    PCI6Pin = table.Column<short>(type: "smallint", nullable: true),
                    PCI2PinPlus = table.Column<short>(type: "smallint", nullable: true),
                    SataConnection = table.Column<short>(type: "smallint", nullable: true),
                    MolexConnection = table.Column<short>(type: "smallint", nullable: true),
                    FloppyConnection = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    Capacity = table.Column<short>(type: "smallint", nullable: true),
                    Speed = table.Column<short>(type: "smallint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voltage = table.Column<double>(type: "float", nullable: true),
                    HeatSink = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DNI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankTransferReceipt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Created = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                });

            migrationBuilder.CreateTable(
                name: "RoledUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoledUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    ReservationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DNI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankTransferReceipt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Created = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.ReservationId);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<short>(type: "smallint", nullable: false),
                    ShipsNational = table.Column<bool>(type: "bit", nullable: false),
                    ShipsInternational = table.Column<bool>(type: "bit", nullable: false),
                    StorageSize = table.Column<short>(type: "smallint", nullable: true),
                    ConnectionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consumption = table.Column<short>(type: "smallint", nullable: true),
                    StorageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPM = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserReservations",
                columns: table => new
                {
                    UserReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReservations", x => x.UserReservationId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Cpus");

            migrationBuilder.DropTable(
                name: "Gpus");

            migrationBuilder.DropTable(
                name: "Keyboards");

            migrationBuilder.DropTable(
                name: "Miscellaneous");

            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Mouses");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Psus");

            migrationBuilder.DropTable(
                name: "Rams");

            migrationBuilder.DropTable(
                name: "ReservationItems");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RoledUsers");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "UserReservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
