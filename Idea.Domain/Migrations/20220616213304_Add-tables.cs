using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Idea.Domain.Migrations
{
    public partial class Addtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachmentTypes",
                columns: table => new
                {
                    AttachmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentTypes", x => x.AttachmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    EmailTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBodyHtml = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.EmailTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "OperatorSettings",
                columns: table => new
                {
                    OperatorSettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Smtp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorSettings", x => x.OperatorSettingsId);
                });

            migrationBuilder.CreateTable(
                name: "PhonePrefixes",
                columns: table => new
                {
                    PhonePrefixId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsImportant = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhonePrefixes", x => x.PhonePrefixId);
                });

            migrationBuilder.CreateTable(
                name: "PriceSearchFilters",
                columns: table => new
                {
                    PriceSearchFilterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceSearchFilters", x => x.PriceSearchFilterId);
                });

            migrationBuilder.CreateTable(
                name: "PublicationMainCategories",
                columns: table => new
                {
                    PublicationMainCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationMainCategories", x => x.PublicationMainCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PublicationStates",
                columns: table => new
                {
                    PublicationStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationStates", x => x.PublicationStateId);
                });

            migrationBuilder.CreateTable(
                name: "PublicationStatuses",
                columns: table => new
                {
                    PublicationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationStatuses", x => x.PublicationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PublicationTypes",
                columns: table => new
                {
                    PublicationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationTypes", x => x.PublicationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PublisherTypes",
                columns: table => new
                {
                    PublisherTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherTypes", x => x.PublisherTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RejectionReasons",
                columns: table => new
                {
                    RejectionReasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectionReasons", x => x.RejectionReasonId);
                });

            migrationBuilder.CreateTable(
                name: "RoomsNumberSearchFilters",
                columns: table => new
                {
                    RoomsNumberSearchFilterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsNumberSearchFilters", x => x.RoomsNumberSearchFilterId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingsId);
                });

            migrationBuilder.CreateTable(
                name: "SortOrder",
                columns: table => new
                {
                    SortOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortOrder", x => x.SortOrderId);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    UnitTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.UnitTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentsMetaData",
                columns: table => new
                {
                    AttachmentsMetaDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentTypeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentSize = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsMetaData", x => x.AttachmentsMetaDataId);
                    table.ForeignKey(
                        name: "FK_AttachmentsMetaData_AttachmentTypes_AttachmentTypeId",
                        column: x => x.AttachmentTypeId,
                        principalTable: "AttachmentTypes",
                        principalColumn: "AttachmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    TownId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TownCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.TownId);
                    table.ForeignKey(
                        name: "FK_Towns_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationCategories",
                columns: table => new
                {
                    PublicationCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationMainCategoryId = table.Column<int>(type: "int", nullable: false),
                    HasQuadrature = table.Column<bool>(type: "bit", nullable: true),
                    HasArea = table.Column<bool>(type: "bit", nullable: true),
                    ShowFirst = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationCategories", x => x.PublicationCategoryId);
                    table.ForeignKey(
                        name: "FK_PublicationCategories_PublicationMainCategories_PublicationMainCategoryId",
                        column: x => x.PublicationMainCategoryId,
                        principalTable: "PublicationMainCategories",
                        principalColumn: "PublicationMainCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "UnitTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationCategoriesProperties",
                columns: table => new
                {
                    PublicationCategoriesPropertiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicationCategoryId = table.Column<int>(type: "int", nullable: false),
                    HasProperty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationCategoriesProperties", x => x.PublicationCategoriesPropertiesId);
                    table.ForeignKey(
                        name: "FK_PublicationCategoriesProperties_PublicationCategories_PublicationCategoryId",
                        column: x => x.PublicationCategoryId,
                        principalTable: "PublicationCategories",
                        principalColumn: "PublicationCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistancesFromLocationRange",
                columns: table => new
                {
                    DistanceFromLocationRangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceFrom = table.Column<int>(type: "int", nullable: true),
                    DistanceTo = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistancesFromLocationRange", x => x.DistanceFromLocationRangeId);
                    table.ForeignKey(
                        name: "FK_DistancesFromLocationRange_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "PublicationPublishedRange",
                columns: table => new
                {
                    PublicationPublishedRangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedFrom = table.Column<int>(type: "int", nullable: true),
                    PublishedTo = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationPublishedRange", x => x.PublicationPublishedRangeId);
                    table.ForeignKey(
                        name: "FK_PublicationPublishedRange_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    PublicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherTypeId = table.Column<int>(type: "int", nullable: false),
                    PublicationTypeId = table.Column<int>(type: "int", nullable: false),
                    PublicationCategoryId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsappPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViberPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhonePrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsappPrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViberPrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quadrature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QuadratureUnitId = table.Column<int>(type: "int", nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AreaUnitId = table.Column<int>(type: "int", nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceUnitId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressObject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AddressLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KitchenRoomNumber = table.Column<int>(type: "int", nullable: true),
                    RoomsNumber = table.Column<int>(type: "int", nullable: true),
                    KitchenNumber = table.Column<int>(type: "int", nullable: true),
                    BedroomsNumber = table.Column<int>(type: "int", nullable: true),
                    WarehouseroomsNumber = table.Column<int>(type: "int", nullable: true),
                    BathroomsNumber = table.Column<int>(type: "int", nullable: true),
                    HasElevator = table.Column<bool>(type: "bit", nullable: true),
                    HasAirConditioner = table.Column<bool>(type: "bit", nullable: true),
                    HasCentralHeating = table.Column<bool>(type: "bit", nullable: true),
                    HasTV = table.Column<bool>(type: "bit", nullable: true),
                    HasInternet = table.Column<bool>(type: "bit", nullable: true),
                    HasClothesWasher = table.Column<bool>(type: "bit", nullable: true),
                    HasDishWasher = table.Column<bool>(type: "bit", nullable: true),
                    HasPrivateGarage = table.Column<bool>(type: "bit", nullable: true),
                    HasPublicParking = table.Column<bool>(type: "bit", nullable: true),
                    HasAlarm = table.Column<bool>(type: "bit", nullable: true),
                    HasSwimmingPool = table.Column<bool>(type: "bit", nullable: true),
                    HasBalcony = table.Column<bool>(type: "bit", nullable: true),
                    HasTerrace = table.Column<bool>(type: "bit", nullable: true),
                    HasElectricCentralHeating = table.Column<bool>(type: "bit", nullable: true),
                    HasRollerShutters = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationStatusId = table.Column<int>(type: "int", nullable: false),
                    ParentPublicationId = table.Column<int>(type: "int", nullable: true),
                    PublicationStateId = table.Column<int>(type: "int", nullable: true),
                    ByAgreement = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.PublicationId);
                    table.ForeignKey(
                        name: "FK_Publications_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_PublicationCategories_PublicationCategoryId",
                        column: x => x.PublicationCategoryId,
                        principalTable: "PublicationCategories",
                        principalColumn: "PublicationCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_Publications_ParentPublicationId",
                        column: x => x.ParentPublicationId,
                        principalTable: "Publications",
                        principalColumn: "PublicationId");
                    table.ForeignKey(
                        name: "FK_Publications_PublicationStates_PublicationStateId",
                        column: x => x.PublicationStateId,
                        principalTable: "PublicationStates",
                        principalColumn: "PublicationStateId");
                    table.ForeignKey(
                        name: "FK_Publications_PublicationStatuses_PublicationStatusId",
                        column: x => x.PublicationStatusId,
                        principalTable: "PublicationStatuses",
                        principalColumn: "PublicationStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_PublicationTypes_PublicationTypeId",
                        column: x => x.PublicationTypeId,
                        principalTable: "PublicationTypes",
                        principalColumn: "PublicationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_PublisherTypes_PublisherTypeId",
                        column: x => x.PublisherTypeId,
                        principalTable: "PublisherTypes",
                        principalColumn: "PublisherTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "TownId");
                    table.ForeignKey(
                        name: "FK_Publications_Units_AreaUnitId",
                        column: x => x.AreaUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId");
                    table.ForeignKey(
                        name: "FK_Publications_Units_PriceUnitId",
                        column: x => x.PriceUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId");
                    table.ForeignKey(
                        name: "FK_Publications_Units_QuadratureUnitId",
                        column: x => x.QuadratureUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "QuadraturesRange",
                columns: table => new
                {
                    QuadratureRangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuadratureFrom = table.Column<int>(type: "int", nullable: true),
                    QuadratureTo = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuadraturesRange", x => x.QuadratureRangeId);
                    table.ForeignKey(
                        name: "FK_QuadraturesRange_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "FavoritePublications",
                columns: table => new
                {
                    FavoritePublicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePublications", x => x.FavoritePublicationId);
                    table.ForeignKey(
                        name: "FK_FavoritePublications_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "PublicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationRejectionReasons",
                columns: table => new
                {
                    PublicationRejectionReasonsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RejectionReasonId = table.Column<int>(type: "int", nullable: false),
                    PublicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationRejectionReasons", x => x.PublicationRejectionReasonsId);
                    table.ForeignKey(
                        name: "FK_PublicationRejectionReasons_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "PublicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationRejectionReasons_RejectionReasons_RejectionReasonId",
                        column: x => x.RejectionReasonId,
                        principalTable: "RejectionReasons",
                        principalColumn: "RejectionReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchedPublications",
                columns: table => new
                {
                    WatchedPublicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchedPublications", x => x.WatchedPublicationId);
                    table.ForeignKey(
                        name: "FK_WatchedPublications_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "PublicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentsMetaData_AttachmentTypeId",
                table: "AttachmentsMetaData",
                column: "AttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DistancesFromLocationRange_UnitId",
                table: "DistancesFromLocationRange",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePublications_PublicationId",
                table: "FavoritePublications",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationCategories_PublicationMainCategoryId",
                table: "PublicationCategories",
                column: "PublicationMainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationCategoriesProperties_PublicationCategoryId",
                table: "PublicationCategoriesProperties",
                column: "PublicationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationPublishedRange_UnitId",
                table: "PublicationPublishedRange",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationRejectionReasons_PublicationId",
                table: "PublicationRejectionReasons",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationRejectionReasons_RejectionReasonId",
                table: "PublicationRejectionReasons",
                column: "RejectionReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_AreaUnitId",
                table: "Publications",
                column: "AreaUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_DistrictId",
                table: "Publications",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ParentPublicationId",
                table: "Publications",
                column: "ParentPublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PriceUnitId",
                table: "Publications",
                column: "PriceUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PublicationCategoryId",
                table: "Publications",
                column: "PublicationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PublicationStateId",
                table: "Publications",
                column: "PublicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PublicationStatusId",
                table: "Publications",
                column: "PublicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PublicationTypeId",
                table: "Publications",
                column: "PublicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PublisherTypeId",
                table: "Publications",
                column: "PublisherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_QuadratureUnitId",
                table: "Publications",
                column: "QuadratureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_TownId",
                table: "Publications",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_QuadraturesRange_UnitId",
                table: "QuadraturesRange",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_DistrictId",
                table: "Towns",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedPublications_PublicationId",
                table: "WatchedPublications",
                column: "PublicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentsMetaData");

            migrationBuilder.DropTable(
                name: "DistancesFromLocationRange");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "FavoritePublications");

            migrationBuilder.DropTable(
                name: "OperatorSettings");

            migrationBuilder.DropTable(
                name: "PhonePrefixes");

            migrationBuilder.DropTable(
                name: "PriceSearchFilters");

            migrationBuilder.DropTable(
                name: "PublicationCategoriesProperties");

            migrationBuilder.DropTable(
                name: "PublicationPublishedRange");

            migrationBuilder.DropTable(
                name: "PublicationRejectionReasons");

            migrationBuilder.DropTable(
                name: "QuadraturesRange");

            migrationBuilder.DropTable(
                name: "RoomsNumberSearchFilters");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SortOrder");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "WatchedPublications");

            migrationBuilder.DropTable(
                name: "AttachmentTypes");

            migrationBuilder.DropTable(
                name: "RejectionReasons");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "PublicationCategories");

            migrationBuilder.DropTable(
                name: "PublicationStates");

            migrationBuilder.DropTable(
                name: "PublicationStatuses");

            migrationBuilder.DropTable(
                name: "PublicationTypes");

            migrationBuilder.DropTable(
                name: "PublisherTypes");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "PublicationMainCategories");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "UnitTypes");
        }
    }
}
