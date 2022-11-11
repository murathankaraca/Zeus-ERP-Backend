using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZeusERP.DataAccess.Migrations.Zeus
{
    public partial class IndeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    JobPosition = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WebsiteLink = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    ExtraInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 75, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    ParentCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    LocationTypeId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    ParentLocationId = table.Column<int>(nullable: false),
                    IsInternalLocation = table.Column<bool>(nullable: false),
                    IsScrapLocation = table.Column<bool>(nullable: false),
                    IsReturnLocation = table.Column<bool>(nullable: false),
                    ExternalNote = table.Column<string>(nullable: true),
                    StockId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_orders_delivery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(nullable: true),
                    DeliveryAddressId = table.Column<int>(nullable: true),
                    SourceLocationId = table.Column<int>(nullable: true),
                    ScheduledDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_orders_delivery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_orders_delivery_ops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryOrderId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: false),
                    ReservedQuantity = table.Column<decimal>(nullable: false),
                    DoneQuantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_orders_delivery_ops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_orders_replenishment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(nullable: false),
                    ProductToReplenishId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    OnHandQuantity = table.Column<decimal>(nullable: false),
                    OrderQuantity = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_orders_replenishment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_orders_transfer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(nullable: true),
                    ReceiveFromId = table.Column<int>(nullable: false),
                    OperationTypeId = table.Column<int>(nullable: false),
                    DestinationLocationId = table.Column<int>(nullable: false),
                    ScheduledDate = table.Column<DateTime>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    TransferProductsId = table.Column<int>(nullable: false),
                    ResponsibleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_orders_transfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_product_boms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    BoMType = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_product_boms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_product_boms_comps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BomId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_product_boms_comps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    BarcodeNumber = table.Column<string>(nullable: true),
                    UnitCount = table.Column<decimal>(nullable: false),
                    UnitCost = table.Column<decimal>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    BillOfMaterialsId = table.Column<int>(nullable: true),
                    CanBePurchased = table.Column<bool>(nullable: false),
                    CanBeSold = table.Column<bool>(nullable: false),
                    ResponsibleId = table.Column<int>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false),
                    BoMId = table.Column<int>(nullable: true),
                    ImgPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_routes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FromLocationId = table.Column<int>(nullable: false),
                    ToLocationId = table.Column<int>(nullable: false),
                    OperationTypeId = table.Column<int>(nullable: false),
                    RequiresValidation = table.Column<bool>(nullable: false),
                    RulesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    HasLimitedStockCount = table.Column<bool>(nullable: false),
                    StockLimit = table.Column<decimal>(nullable: false),
                    UsedForManufacture = table.Column<bool>(nullable: false),
                    RouteListId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_manu_orders_manufacturing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    BillOfMaterialsId = table.Column<int>(nullable: false),
                    BillOfMaterialsReference = table.Column<string>(nullable: true),
                    QuantityToManufacture = table.Column<decimal>(nullable: false),
                    QuantityManufactured = table.Column<decimal>(nullable: false),
                    ScheduledDate = table.Column<DateTime>(nullable: false),
                    ResponsibleId = table.Column<int>(nullable: false),
                    ComponentsId = table.Column<int>(nullable: false),
                    ComponentsLocationId = table.Column<int>(nullable: false),
                    FinishedProductsLocationId = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_manu_orders_manufacturing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_manu_orders_manufacturing_comps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    QuantityToConsume = table.Column<decimal>(nullable: false),
                    QuantityConsumed = table.Column<decimal>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_manu_orders_manufacturing_comps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_manu_orders_unbuild",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(nullable: true),
                    ManufacturingOrderId = table.Column<int>(nullable: false),
                    BoMId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    SourceLocationId = table.Column<int>(nullable: false),
                    DestinationLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_manu_orders_unbuild", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_plm_eco_tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ColorCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_plm_eco_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_plm_eco_types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EmailAlias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_plm_eco_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_plm_ecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(nullable: true),
                    ResponsibleId = table.Column<int>(nullable: false),
                    ApplyOn = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Effectivity = table.Column<bool>(nullable: false),
                    EffectivityDate = table.Column<DateTime>(nullable: false),
                    ECOTagsId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ApproverId = table.Column<int>(nullable: false),
                    EcoStage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_plm_ecos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_contacts");

            migrationBuilder.DropTable(
                name: "t_inv_addresses");

            migrationBuilder.DropTable(
                name: "t_inv_categories");

            migrationBuilder.DropTable(
                name: "t_inv_locations");

            migrationBuilder.DropTable(
                name: "t_inv_orders_delivery");

            migrationBuilder.DropTable(
                name: "t_inv_orders_delivery_ops");

            migrationBuilder.DropTable(
                name: "t_inv_orders_replenishment");

            migrationBuilder.DropTable(
                name: "t_inv_orders_transfer");

            migrationBuilder.DropTable(
                name: "t_inv_product_boms");

            migrationBuilder.DropTable(
                name: "t_inv_product_boms_comps");

            migrationBuilder.DropTable(
                name: "t_inv_products");

            migrationBuilder.DropTable(
                name: "t_inv_routes");

            migrationBuilder.DropTable(
                name: "t_inv_warehouses");

            migrationBuilder.DropTable(
                name: "t_manu_orders_manufacturing");

            migrationBuilder.DropTable(
                name: "t_manu_orders_manufacturing_comps");

            migrationBuilder.DropTable(
                name: "t_manu_orders_unbuild");

            migrationBuilder.DropTable(
                name: "t_plm_eco_tags");

            migrationBuilder.DropTable(
                name: "t_plm_eco_types");

            migrationBuilder.DropTable(
                name: "t_plm_ecos");
        }
    }
}
