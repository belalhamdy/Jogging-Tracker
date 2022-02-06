using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jogging_Tracker.Migrations
{
    public partial class CreateTablesAndSeedData : Migration
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "JoggingRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInSeconds = table.Column<double>(type: "float", nullable: false),
                    DistanceInMeters = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoggingRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_JoggingRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d178c2f3-d4fd-49d7-95be-c3e634f0b3ed", "c9461416-8efb-4d7b-b451-3e34c5a04f10", "UserManager", "USERMANAGER" },
                    { "f089b847-caf7-4f59-966c-7d97947fbec7", "30bfff4d-8f6a-47ec-b79d-0d2e39dbc37b", "Admin", "ADMIN" },
                    { "cab13066-9c9d-44b0-9121-5e69d819cbbd", "abd3b43b-0754-4258-a25c-14dbd667edd6", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3c9f608f-929f-479e-b941-f4a342b24f0b", 0, "9e4415e4-e95b-4973-9328-c482ea3b2291", null, false, false, null, null, "MANAGER", "AQAAAAEAACcQAAAAEEDOrEHBipRpsPKFD/jFW/M3jvCgw71OyflMmDXTBJR6TVBUuRHRMDJ3lD/4eV/Ayw==", null, false, "458919ab-ad31-44b0-8cd0-88a8f902038f", false, "manager" },
                    { "a99fe9fd-b635-469f-8c69-1142935609ad", 0, "98e111b3-5d33-4ca7-aa9e-4d136d7ad04c", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAELVxEAUIXlkTzoBAiJcmyZOpYkSm4z6XIrM3/Gwi0J2a5ZzayIC2cOGj+Vq18CRwkw==", null, false, "b2a4daff-3867-42c7-8cdf-413da5422c52", false, "admin" },
                    { "24391000-0a63-4bb1-971f-7611dd87d9f6", 0, "d8af234b-bc68-4405-87fd-15dd38af28ab", null, false, false, null, null, "USER1", "AQAAAAEAACcQAAAAEKX6ER17H86zuyZOb6af9I+GhwyOrKlQE0zYDnqkn5YcD4wNlwlJtHnqHjY8eRnVbg==", null, false, "864509db-0ccd-4c91-a755-276d753dc1bb", false, "user1" },
                    { "2f06b0c6-4f7c-44d7-9a92-44c729247f9e", 0, "ddc99925-c23a-4639-a490-4168685b36ab", null, false, false, null, null, "USER2", "AQAAAAEAACcQAAAAEJxHAOofmNf9urg6j1kLq4axAHkqRFyBuCKTBKFc1qnPqrEHIbaUj12Y5GRvDz2xIQ==", null, false, "1babca91-a280-4367-9c10-43be1ee13f48", false, "user2" },
                    { "877b39aa-4524-4319-98c4-3d1944240264", 0, "2f3e15f7-6e9a-4cf8-afa4-6d7680099840", null, false, false, null, null, "USER3", "AQAAAAEAACcQAAAAEEztmC8lD04RvsoIyVUVMzp4FHwcmYglTF6gfF217CvXbFd5cSIzGoHZ57gtSvz49A==", null, false, "14c4288d-a625-4b05-89eb-472f6c80383a", false, "user3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cab13066-9c9d-44b0-9121-5e69d819cbbd", "877b39aa-4524-4319-98c4-3d1944240264" },
                    { "d178c2f3-d4fd-49d7-95be-c3e634f0b3ed", "3c9f608f-929f-479e-b941-f4a342b24f0b" },
                    { "cab13066-9c9d-44b0-9121-5e69d819cbbd", "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { "cab13066-9c9d-44b0-9121-5e69d819cbbd", "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { "f089b847-caf7-4f59-966c-7d97947fbec7", "a99fe9fd-b635-469f-8c69-1142935609ad" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 452, new DateTime(2022, 1, 19, 1, 55, 12, 0, DateTimeKind.Unspecified), 2386.3352746496394, 17944.25728156343, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 863, new DateTime(2022, 2, 4, 12, 28, 48, 0, DateTimeKind.Unspecified), 428.7740464198049, 15787.978108442221, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 866, new DateTime(2022, 2, 4, 15, 21, 36, 0, DateTimeKind.Unspecified), 8324.8547982599084, 15489.349868163828, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 869, new DateTime(2022, 2, 4, 18, 14, 24, 0, DateTimeKind.Unspecified), 4333.2234095722051, 11780.105415236809, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 872, new DateTime(2022, 2, 4, 21, 7, 12, 0, DateTimeKind.Unspecified), 7268.173232768484, 8737.250650817572, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 875, new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 972.76399694240627, 9677.6161549700792, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 3, new DateTime(2022, 1, 1, 2, 52, 48, 0, DateTimeKind.Unspecified), 7043.3566559613355, 13786.739927708666, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 6, new DateTime(2022, 1, 1, 5, 45, 36, 0, DateTimeKind.Unspecified), 9373.39652056253, 7471.6298418848346, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 9, new DateTime(2022, 1, 1, 8, 38, 24, 0, DateTimeKind.Unspecified), 9472.2475384876398, 17505.613899277254, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 12, new DateTime(2022, 1, 1, 11, 31, 12, 0, DateTimeKind.Unspecified), 3970.6774319494557, 10423.944547793251, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 15, new DateTime(2022, 1, 1, 14, 24, 0, 0, DateTimeKind.Unspecified), 7809.9926019845252, 14437.514669933873, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 18, new DateTime(2022, 1, 1, 17, 16, 48, 0, DateTimeKind.Unspecified), 7194.9652233264633, 4457.7408906805204, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 21, new DateTime(2022, 1, 1, 20, 9, 36, 0, DateTimeKind.Unspecified), 9275.6724518225728, 14018.510131986854, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 24, new DateTime(2022, 1, 1, 23, 2, 24, 0, DateTimeKind.Unspecified), 6442.4063061794377, 13301.34182986441, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 27, new DateTime(2022, 1, 2, 1, 55, 12, 0, DateTimeKind.Unspecified), 9977.0233818740471, 19176.950462352655, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 30, new DateTime(2022, 1, 2, 4, 48, 0, 0, DateTimeKind.Unspecified), 6663.9667842515892, 1107.6638397282593, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 33, new DateTime(2022, 1, 2, 7, 40, 48, 0, DateTimeKind.Unspecified), 3091.6461288974419, 12607.520064879613, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 36, new DateTime(2022, 1, 2, 10, 33, 36, 0, DateTimeKind.Unspecified), 7683.0763154047472, 1372.817695523986, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 39, new DateTime(2022, 1, 2, 13, 26, 24, 0, DateTimeKind.Unspecified), 9189.6773466827708, 19222.691198697346, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 42, new DateTime(2022, 1, 2, 16, 19, 12, 0, DateTimeKind.Unspecified), 2221.0329584239616, 4976.6518987799445, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 45, new DateTime(2022, 1, 2, 19, 12, 0, 0, DateTimeKind.Unspecified), 8123.1169578144245, 11871.334266849912, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 48, new DateTime(2022, 1, 2, 22, 4, 48, 0, DateTimeKind.Unspecified), 731.90170147748211, 13211.24389845853, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 51, new DateTime(2022, 1, 3, 0, 57, 36, 0, DateTimeKind.Unspecified), 5872.2363713527866, 3485.7470337967779, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 54, new DateTime(2022, 1, 3, 3, 50, 24, 0, DateTimeKind.Unspecified), 1051.6242608241641, 3202.4450447188528, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 860, new DateTime(2022, 2, 4, 9, 36, 0, 0, DateTimeKind.Unspecified), 1778.4948084107191, 13368.276550733184, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 57, new DateTime(2022, 1, 3, 6, 43, 12, 0, DateTimeKind.Unspecified), 8163.2066951850884, 13864.20724009854, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 857, new DateTime(2022, 2, 4, 6, 43, 12, 0, DateTimeKind.Unspecified), 2169.0669317204697, 13809.084803718022, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 851, new DateTime(2022, 2, 4, 0, 57, 36, 0, DateTimeKind.Unspecified), 5309.1288297955934, 15940.994744359647, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 782, new DateTime(2022, 2, 1, 6, 43, 12, 0, DateTimeKind.Unspecified), 6834.6891066609251, 2516.1537730676009, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 785, new DateTime(2022, 2, 1, 9, 36, 0, 0, DateTimeKind.Unspecified), 908.45771730528759, 10299.054871127184, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 788, new DateTime(2022, 2, 1, 12, 28, 48, 0, DateTimeKind.Unspecified), 4791.7234435383334, 18796.424157247016, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 791, new DateTime(2022, 2, 1, 15, 21, 36, 0, DateTimeKind.Unspecified), 5060.6335718859928, 17576.915889900676, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 794, new DateTime(2022, 2, 1, 18, 14, 24, 0, DateTimeKind.Unspecified), 9068.085795899191, 6366.9571529554541, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 797, new DateTime(2022, 2, 1, 21, 7, 12, 0, DateTimeKind.Unspecified), 1576.8764011446372, 2260.8629335442051, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 800, new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1538.5959502318876, 8715.2546900798297, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 803, new DateTime(2022, 2, 2, 2, 52, 48, 0, DateTimeKind.Unspecified), 3881.0028211121339, 12525.197443519713, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 806, new DateTime(2022, 2, 2, 5, 45, 36, 0, DateTimeKind.Unspecified), 9022.7871416096896, 14224.262003977892, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 809, new DateTime(2022, 2, 2, 8, 38, 24, 0, DateTimeKind.Unspecified), 4977.1651333998107, 2344.5719756176859, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 812, new DateTime(2022, 2, 2, 11, 31, 12, 0, DateTimeKind.Unspecified), 2766.5085830904568, 4181.881949113972, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 815, new DateTime(2022, 2, 2, 14, 24, 0, 0, DateTimeKind.Unspecified), 8097.172460056503, 4606.3913008952868, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 818, new DateTime(2022, 2, 2, 17, 16, 48, 0, DateTimeKind.Unspecified), 2434.9658753971626, 17661.030402852801, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 821, new DateTime(2022, 2, 2, 20, 9, 36, 0, DateTimeKind.Unspecified), 3067.8095813212399, 1255.9365086873802, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 824, new DateTime(2022, 2, 2, 23, 2, 24, 0, DateTimeKind.Unspecified), 3129.8321098392153, 3021.2899290632972, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 827, new DateTime(2022, 2, 3, 1, 55, 12, 0, DateTimeKind.Unspecified), 7940.9645256758022, 13056.201960013294, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 830, new DateTime(2022, 2, 3, 4, 48, 0, 0, DateTimeKind.Unspecified), 3290.2951509173481, 19254.527417359055, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 833, new DateTime(2022, 2, 3, 7, 40, 48, 0, DateTimeKind.Unspecified), 1331.6239870965326, 8654.9990997187633, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 836, new DateTime(2022, 2, 3, 10, 33, 36, 0, DateTimeKind.Unspecified), 3663.0518717305004, 3839.4449870159419, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 839, new DateTime(2022, 2, 3, 13, 26, 24, 0, DateTimeKind.Unspecified), 4125.4614116232742, 4648.9219953837728, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 842, new DateTime(2022, 2, 3, 16, 19, 12, 0, DateTimeKind.Unspecified), 9162.5347047039741, 14346.751463977047, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 845, new DateTime(2022, 2, 3, 19, 12, 0, 0, DateTimeKind.Unspecified), 6545.145493090633, 19977.856878546747, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 848, new DateTime(2022, 2, 3, 22, 4, 48, 0, DateTimeKind.Unspecified), 4010.4479740726092, 1996.2771144790436, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 854, new DateTime(2022, 2, 4, 3, 50, 24, 0, DateTimeKind.Unspecified), 2299.0626424658772, 12403.087299925019, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 779, new DateTime(2022, 2, 1, 3, 50, 24, 0, DateTimeKind.Unspecified), 8562.6943950622535, 13569.38993844566, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 60, new DateTime(2022, 1, 3, 9, 36, 0, 0, DateTimeKind.Unspecified), 5635.9277372879242, 12459.501255977, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 66, new DateTime(2022, 1, 3, 15, 21, 36, 0, DateTimeKind.Unspecified), 4130.1344990673197, 6916.5117974713257, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 150, new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4077.5759313432977, 1599.4181673358869, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 153, new DateTime(2022, 1, 7, 2, 52, 48, 0, DateTimeKind.Unspecified), 3696.086863493475, 3378.8231520695913, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 156, new DateTime(2022, 1, 7, 5, 45, 36, 0, DateTimeKind.Unspecified), 1626.4929623202397, 5854.4878354682014, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 159, new DateTime(2022, 1, 7, 8, 38, 24, 0, DateTimeKind.Unspecified), 3636.1571144727636, 3967.0987438089064, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 162, new DateTime(2022, 1, 7, 11, 31, 12, 0, DateTimeKind.Unspecified), 525.83532302950925, 6103.8707962347062, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 165, new DateTime(2022, 1, 7, 14, 24, 0, 0, DateTimeKind.Unspecified), 1225.3448482154624, 12636.019558963348, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 168, new DateTime(2022, 1, 7, 17, 16, 48, 0, DateTimeKind.Unspecified), 4251.4464808131052, 11350.633646345292, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 171, new DateTime(2022, 1, 7, 20, 9, 36, 0, DateTimeKind.Unspecified), 2462.1311532274453, 1064.218146271081, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 174, new DateTime(2022, 1, 7, 23, 2, 24, 0, DateTimeKind.Unspecified), 4059.4305276593172, 17227.0737813261, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 177, new DateTime(2022, 1, 8, 1, 55, 12, 0, DateTimeKind.Unspecified), 5474.3348371073371, 12507.854223287546, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 180, new DateTime(2022, 1, 8, 4, 48, 0, 0, DateTimeKind.Unspecified), 1948.4358603784062, 426.7449168939936, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 183, new DateTime(2022, 1, 8, 7, 40, 48, 0, DateTimeKind.Unspecified), 464.75688542555383, 7752.7810380658102, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 186, new DateTime(2022, 1, 8, 10, 33, 36, 0, DateTimeKind.Unspecified), 4277.6405685165555, 17420.025816575624, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 189, new DateTime(2022, 1, 8, 13, 26, 24, 0, DateTimeKind.Unspecified), 1999.9360941514788, 11243.818642253671, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 192, new DateTime(2022, 1, 8, 16, 19, 12, 0, DateTimeKind.Unspecified), 4991.6334429537192, 10561.554967854161, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 195, new DateTime(2022, 1, 8, 19, 12, 0, 0, DateTimeKind.Unspecified), 7660.5935150356363, 11324.253285981455, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 198, new DateTime(2022, 1, 8, 22, 4, 48, 0, DateTimeKind.Unspecified), 1894.111408795734, 12758.859208008158, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 201, new DateTime(2022, 1, 9, 0, 57, 36, 0, DateTimeKind.Unspecified), 9127.1033897850139, 12784.335542067736, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 204, new DateTime(2022, 1, 9, 3, 50, 24, 0, DateTimeKind.Unspecified), 5537.5794283438836, 10178.215823096147, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 207, new DateTime(2022, 1, 9, 6, 43, 12, 0, DateTimeKind.Unspecified), 1488.664854083657, 19821.124691038189, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 210, new DateTime(2022, 1, 9, 9, 36, 0, 0, DateTimeKind.Unspecified), 1897.0650485749034, 4623.6405419687135, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 213, new DateTime(2022, 1, 9, 12, 28, 48, 0, DateTimeKind.Unspecified), 7973.22801775275, 8797.2869827851737, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 216, new DateTime(2022, 1, 9, 15, 21, 36, 0, DateTimeKind.Unspecified), 5500.5574487243857, 5492.0462357163151, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 147, new DateTime(2022, 1, 6, 21, 7, 12, 0, DateTimeKind.Unspecified), 5058.3025513140728, 16206.351621693228, "877b39aa-4524-4319-98c4-3d1944240264" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 63, new DateTime(2022, 1, 3, 12, 28, 48, 0, DateTimeKind.Unspecified), 6800.931856169921, 5337.7745487493057, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 144, new DateTime(2022, 1, 6, 18, 14, 24, 0, DateTimeKind.Unspecified), 256.7409104931632, 148.8255949620239, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 138, new DateTime(2022, 1, 6, 12, 28, 48, 0, DateTimeKind.Unspecified), 9757.8838805434516, 16463.544904685274, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 69, new DateTime(2022, 1, 3, 18, 14, 24, 0, DateTimeKind.Unspecified), 7618.5066210117575, 15159.359752570484, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 72, new DateTime(2022, 1, 3, 21, 7, 12, 0, DateTimeKind.Unspecified), 7938.9014887755829, 19067.179951198101, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 75, new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4704.2023521906576, 11304.760343701346, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 78, new DateTime(2022, 1, 4, 2, 52, 48, 0, DateTimeKind.Unspecified), 3102.4247362686847, 12363.661121134106, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 81, new DateTime(2022, 1, 4, 5, 45, 36, 0, DateTimeKind.Unspecified), 5120.7990330435778, 493.74352830987254, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 84, new DateTime(2022, 1, 4, 8, 38, 24, 0, DateTimeKind.Unspecified), 6042.9726121963395, 9957.6875699722914, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 87, new DateTime(2022, 1, 4, 11, 31, 12, 0, DateTimeKind.Unspecified), 9841.5291130385503, 261.6948258680714, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 90, new DateTime(2022, 1, 4, 14, 24, 0, 0, DateTimeKind.Unspecified), 5280.1143451312446, 1247.3458629688732, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 93, new DateTime(2022, 1, 4, 17, 16, 48, 0, DateTimeKind.Unspecified), 700.40479347387839, 19484.859632273299, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 96, new DateTime(2022, 1, 4, 20, 9, 36, 0, DateTimeKind.Unspecified), 4094.2129615926347, 13793.339390423447, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 99, new DateTime(2022, 1, 4, 23, 2, 24, 0, DateTimeKind.Unspecified), 1865.7782821712467, 15890.873427783952, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 102, new DateTime(2022, 1, 5, 1, 55, 12, 0, DateTimeKind.Unspecified), 390.32947671395311, 13241.562439442352, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 105, new DateTime(2022, 1, 5, 4, 48, 0, 0, DateTimeKind.Unspecified), 9786.2282332830655, 5826.0181154677693, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 108, new DateTime(2022, 1, 5, 7, 40, 48, 0, DateTimeKind.Unspecified), 669.38171007272263, 1214.229134181948, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 111, new DateTime(2022, 1, 5, 10, 33, 36, 0, DateTimeKind.Unspecified), 4100.6298357721917, 11482.303576294278, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 114, new DateTime(2022, 1, 5, 13, 26, 24, 0, DateTimeKind.Unspecified), 4163.1682115751291, 2873.8225720016621, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 117, new DateTime(2022, 1, 5, 16, 19, 12, 0, DateTimeKind.Unspecified), 5717.6127307273282, 19638.981747678146, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 120, new DateTime(2022, 1, 5, 19, 12, 0, 0, DateTimeKind.Unspecified), 6966.9045407909152, 1309.6442627518318, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 123, new DateTime(2022, 1, 5, 22, 4, 48, 0, DateTimeKind.Unspecified), 2863.4468535544147, 1153.1113034643834, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 126, new DateTime(2022, 1, 6, 0, 57, 36, 0, DateTimeKind.Unspecified), 5493.6730751806317, 12192.462286506227, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 129, new DateTime(2022, 1, 6, 3, 50, 24, 0, DateTimeKind.Unspecified), 8360.0999934068077, 3511.5288306059674, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 132, new DateTime(2022, 1, 6, 6, 43, 12, 0, DateTimeKind.Unspecified), 4669.8359865314242, 1196.9036722998524, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 135, new DateTime(2022, 1, 6, 9, 36, 0, 0, DateTimeKind.Unspecified), 4740.4832236636666, 5442.8308438761296, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 141, new DateTime(2022, 1, 6, 15, 21, 36, 0, DateTimeKind.Unspecified), 2763.6691726605732, 10408.988069121649, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 776, new DateTime(2022, 2, 1, 0, 57, 36, 0, DateTimeKind.Unspecified), 5689.4023932702958, 14665.742087441504, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 773, new DateTime(2022, 1, 31, 22, 4, 48, 0, DateTimeKind.Unspecified), 2868.3366662903227, 11767.03181945225, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 219, new DateTime(2022, 1, 9, 18, 14, 24, 0, DateTimeKind.Unspecified), 3694.4752474488846, 4846.3029561574695, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 536, new DateTime(2022, 1, 22, 10, 33, 36, 0, DateTimeKind.Unspecified), 710.30800091081915, 1893.9114628270324, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 539, new DateTime(2022, 1, 22, 13, 26, 24, 0, DateTimeKind.Unspecified), 8302.2782573214645, 4267.8082304952441, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 542, new DateTime(2022, 1, 22, 16, 19, 12, 0, DateTimeKind.Unspecified), 1673.9281983692372, 13647.184409052488, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 545, new DateTime(2022, 1, 22, 19, 12, 0, 0, DateTimeKind.Unspecified), 1346.6697762752394, 18067.558561044902, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 548, new DateTime(2022, 1, 22, 22, 4, 48, 0, DateTimeKind.Unspecified), 2175.666146845102, 7074.2575504147617, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 551, new DateTime(2022, 1, 23, 0, 57, 36, 0, DateTimeKind.Unspecified), 1023.5071659955144, 14667.74795956366, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 554, new DateTime(2022, 1, 23, 3, 50, 24, 0, DateTimeKind.Unspecified), 413.36086363027528, 1080.3427376545258, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 557, new DateTime(2022, 1, 23, 6, 43, 12, 0, DateTimeKind.Unspecified), 8820.6869092156394, 15953.005141867883, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 560, new DateTime(2022, 1, 23, 9, 36, 0, 0, DateTimeKind.Unspecified), 8537.8518982062269, 317.28292002683645, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 563, new DateTime(2022, 1, 23, 12, 28, 48, 0, DateTimeKind.Unspecified), 573.36550851542449, 1251.4671840657127, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 566, new DateTime(2022, 1, 23, 15, 21, 36, 0, DateTimeKind.Unspecified), 4685.1333642296704, 12125.571405123226, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 569, new DateTime(2022, 1, 23, 18, 14, 24, 0, DateTimeKind.Unspecified), 9627.7502774299592, 5495.6028825523827, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 572, new DateTime(2022, 1, 23, 21, 7, 12, 0, DateTimeKind.Unspecified), 8705.8030499703891, 2654.8120441429569, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 575, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 370.02622326734001, 15891.592043368479, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 578, new DateTime(2022, 1, 24, 2, 52, 48, 0, DateTimeKind.Unspecified), 2027.4412248314118, 7677.6698886793356, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 581, new DateTime(2022, 1, 24, 5, 45, 36, 0, DateTimeKind.Unspecified), 6483.0135907854228, 18166.590423555084, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 584, new DateTime(2022, 1, 24, 8, 38, 24, 0, DateTimeKind.Unspecified), 2650.7964284814816, 10349.765878484777, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 587, new DateTime(2022, 1, 24, 11, 31, 12, 0, DateTimeKind.Unspecified), 3714.651254277042, 18747.326525817974, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 590, new DateTime(2022, 1, 24, 14, 24, 0, 0, DateTimeKind.Unspecified), 3204.1681165989976, 15327.575522307327, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 593, new DateTime(2022, 1, 24, 17, 16, 48, 0, DateTimeKind.Unspecified), 6162.019387712674, 14483.351432434563, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 596, new DateTime(2022, 1, 24, 20, 9, 36, 0, DateTimeKind.Unspecified), 2424.016480231181, 17130.005593905775, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 599, new DateTime(2022, 1, 24, 23, 2, 24, 0, DateTimeKind.Unspecified), 8134.2543828869993, 9235.9214165359881, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 602, new DateTime(2022, 1, 25, 1, 55, 12, 0, DateTimeKind.Unspecified), 3039.3296189226303, 11018.707553288996, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 533, new DateTime(2022, 1, 22, 7, 40, 48, 0, DateTimeKind.Unspecified), 585.26762267954507, 16702.037674145162, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 605, new DateTime(2022, 1, 25, 4, 48, 0, 0, DateTimeKind.Unspecified), 1368.4716061595914, 14973.870257584082, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 530, new DateTime(2022, 1, 22, 4, 48, 0, 0, DateTimeKind.Unspecified), 3853.6061021264627, 3592.7040330645723, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 524, new DateTime(2022, 1, 21, 23, 2, 24, 0, DateTimeKind.Unspecified), 4269.9466979119597, 279.61373665342023, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 455, new DateTime(2022, 1, 19, 4, 48, 0, 0, DateTimeKind.Unspecified), 6942.9723980256404, 785.1344775283012, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 458, new DateTime(2022, 1, 19, 7, 40, 48, 0, DateTimeKind.Unspecified), 2059.0135413840389, 2129.8321286832256, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 461, new DateTime(2022, 1, 19, 10, 33, 36, 0, DateTimeKind.Unspecified), 3412.448818044209, 16690.599982169057, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 464, new DateTime(2022, 1, 19, 13, 26, 24, 0, DateTimeKind.Unspecified), 6013.7877556111334, 2245.4093993645433, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 467, new DateTime(2022, 1, 19, 16, 19, 12, 0, DateTimeKind.Unspecified), 9137.6460804536491, 6181.264339080667, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 470, new DateTime(2022, 1, 19, 19, 12, 0, 0, DateTimeKind.Unspecified), 2797.9591927982979, 14025.252716899959, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 473, new DateTime(2022, 1, 19, 22, 4, 48, 0, DateTimeKind.Unspecified), 9835.0750959323032, 7918.9529398502173, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 476, new DateTime(2022, 1, 20, 0, 57, 36, 0, DateTimeKind.Unspecified), 4437.4718215573575, 17801.648632626613, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 479, new DateTime(2022, 1, 20, 3, 50, 24, 0, DateTimeKind.Unspecified), 2384.0915418686163, 15745.025505734653, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 482, new DateTime(2022, 1, 20, 6, 43, 12, 0, DateTimeKind.Unspecified), 3005.1214537734736, 4353.345132526817, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 485, new DateTime(2022, 1, 20, 9, 36, 0, 0, DateTimeKind.Unspecified), 3032.0148802942335, 19034.967575612398, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 488, new DateTime(2022, 1, 20, 12, 28, 48, 0, DateTimeKind.Unspecified), 8415.1669563109481, 4505.8414025993097, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 491, new DateTime(2022, 1, 20, 15, 21, 36, 0, DateTimeKind.Unspecified), 7447.8926493301315, 11126.328194310792, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 494, new DateTime(2022, 1, 20, 18, 14, 24, 0, DateTimeKind.Unspecified), 5016.423204827156, 15277.965474814217, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 497, new DateTime(2022, 1, 20, 21, 7, 12, 0, DateTimeKind.Unspecified), 9692.7648249183712, 7334.7816825207501, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 500, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5230.3443604085369, 19113.755594954844, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 503, new DateTime(2022, 1, 21, 2, 52, 48, 0, DateTimeKind.Unspecified), 928.24275491157277, 6523.2179209676178, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 506, new DateTime(2022, 1, 21, 5, 45, 36, 0, DateTimeKind.Unspecified), 8014.0420795363416, 2030.4046650315704, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 509, new DateTime(2022, 1, 21, 8, 38, 24, 0, DateTimeKind.Unspecified), 9949.7895320190619, 9754.7346872214912, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 512, new DateTime(2022, 1, 21, 11, 31, 12, 0, DateTimeKind.Unspecified), 2877.3158457005679, 14406.306645445595, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 515, new DateTime(2022, 1, 21, 14, 24, 0, 0, DateTimeKind.Unspecified), 8024.0449048081337, 2847.8557639343894, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 518, new DateTime(2022, 1, 21, 17, 16, 48, 0, DateTimeKind.Unspecified), 2385.7225286308794, 7066.1594848319037, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 521, new DateTime(2022, 1, 21, 20, 9, 36, 0, DateTimeKind.Unspecified), 3639.66438101313, 16291.317642131033, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 527, new DateTime(2022, 1, 22, 1, 55, 12, 0, DateTimeKind.Unspecified), 3312.0250271356813, 224.7619694326421, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 608, new DateTime(2022, 1, 25, 7, 40, 48, 0, DateTimeKind.Unspecified), 1333.0783306978351, 17084.347893224309, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 611, new DateTime(2022, 1, 25, 10, 33, 36, 0, DateTimeKind.Unspecified), 2748.233867295914, 8536.7689433926553, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 614, new DateTime(2022, 1, 25, 13, 26, 24, 0, DateTimeKind.Unspecified), 6057.2323259387622, 19667.704386440677, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 701, new DateTime(2022, 1, 29, 0, 57, 36, 0, DateTimeKind.Unspecified), 5797.3231777815527, 7411.7012255917607, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 704, new DateTime(2022, 1, 29, 3, 50, 24, 0, DateTimeKind.Unspecified), 6412.9826200074467, 11177.696908550091, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 707, new DateTime(2022, 1, 29, 6, 43, 12, 0, DateTimeKind.Unspecified), 459.9257678489783, 13912.628400248183, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 710, new DateTime(2022, 1, 29, 9, 36, 0, 0, DateTimeKind.Unspecified), 9980.6962778647885, 19014.427093908005, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 713, new DateTime(2022, 1, 29, 12, 28, 48, 0, DateTimeKind.Unspecified), 4769.9539986736145, 19582.869216487667, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 716, new DateTime(2022, 1, 29, 15, 21, 36, 0, DateTimeKind.Unspecified), 7185.9906216778218, 7138.0035092107501, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 719, new DateTime(2022, 1, 29, 18, 14, 24, 0, DateTimeKind.Unspecified), 8673.1408429994935, 17886.737698556477, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 722, new DateTime(2022, 1, 29, 21, 7, 12, 0, DateTimeKind.Unspecified), 9938.7077015260857, 19794.565107582355, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 725, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7875.7070986776116, 2300.0001542516252, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 728, new DateTime(2022, 1, 30, 2, 52, 48, 0, DateTimeKind.Unspecified), 8462.2537891865486, 159.68104410184856, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 731, new DateTime(2022, 1, 30, 5, 45, 36, 0, DateTimeKind.Unspecified), 7585.5547291918538, 10040.196947379161, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 734, new DateTime(2022, 1, 30, 8, 38, 24, 0, DateTimeKind.Unspecified), 5457.4207579368485, 19494.318178144626, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 737, new DateTime(2022, 1, 30, 11, 31, 12, 0, DateTimeKind.Unspecified), 4084.3272172892976, 3812.9699635485163, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 740, new DateTime(2022, 1, 30, 14, 24, 0, 0, DateTimeKind.Unspecified), 3533.2458103337522, 11853.295125319059, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 743, new DateTime(2022, 1, 30, 17, 16, 48, 0, DateTimeKind.Unspecified), 1926.2042463474268, 14558.725895306074, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 746, new DateTime(2022, 1, 30, 20, 9, 36, 0, DateTimeKind.Unspecified), 6814.7125187642232, 14853.034557655465, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 749, new DateTime(2022, 1, 30, 23, 2, 24, 0, DateTimeKind.Unspecified), 3268.9382953589943, 8570.6906154246863, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 752, new DateTime(2022, 1, 31, 1, 55, 12, 0, DateTimeKind.Unspecified), 1439.4469355175845, 8320.0185205579073, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 755, new DateTime(2022, 1, 31, 4, 48, 0, 0, DateTimeKind.Unspecified), 9574.5575754807705, 386.27346066924872, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 758, new DateTime(2022, 1, 31, 7, 40, 48, 0, DateTimeKind.Unspecified), 969.12807338007974, 5919.8206765110781, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 761, new DateTime(2022, 1, 31, 10, 33, 36, 0, DateTimeKind.Unspecified), 1897.0743459192706, 11083.800886546423, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 764, new DateTime(2022, 1, 31, 13, 26, 24, 0, DateTimeKind.Unspecified), 5730.7815951082457, 16589.19864904655, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 767, new DateTime(2022, 1, 31, 16, 19, 12, 0, DateTimeKind.Unspecified), 5311.852422300035, 151.88711737414246, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 698, new DateTime(2022, 1, 28, 22, 4, 48, 0, DateTimeKind.Unspecified), 698.26072938692232, 11084.861555051091, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 695, new DateTime(2022, 1, 28, 19, 12, 0, 0, DateTimeKind.Unspecified), 2721.0992243164728, 19953.14089533408, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 692, new DateTime(2022, 1, 28, 16, 19, 12, 0, DateTimeKind.Unspecified), 4464.4776851184133, 5614.7952886949051, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 689, new DateTime(2022, 1, 28, 13, 26, 24, 0, DateTimeKind.Unspecified), 4820.8851089581003, 3129.3447927391826, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 617, new DateTime(2022, 1, 25, 16, 19, 12, 0, DateTimeKind.Unspecified), 4116.8469494591991, 13074.62896529815, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 620, new DateTime(2022, 1, 25, 19, 12, 0, 0, DateTimeKind.Unspecified), 8117.0541039707696, 3991.6903615660503, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 623, new DateTime(2022, 1, 25, 22, 4, 48, 0, DateTimeKind.Unspecified), 4869.4063731460237, 15849.583067056359, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 626, new DateTime(2022, 1, 26, 0, 57, 36, 0, DateTimeKind.Unspecified), 391.87249412029132, 19930.564170029687, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 629, new DateTime(2022, 1, 26, 3, 50, 24, 0, DateTimeKind.Unspecified), 7096.4037343266382, 13456.642767352829, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 632, new DateTime(2022, 1, 26, 6, 43, 12, 0, DateTimeKind.Unspecified), 620.97097749065142, 13086.47429417999, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 635, new DateTime(2022, 1, 26, 9, 36, 0, 0, DateTimeKind.Unspecified), 8882.2809198492723, 17102.518322703054, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 638, new DateTime(2022, 1, 26, 12, 28, 48, 0, DateTimeKind.Unspecified), 9308.0015720307692, 7595.6277809190369, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 641, new DateTime(2022, 1, 26, 15, 21, 36, 0, DateTimeKind.Unspecified), 7044.8110295968045, 12311.456469111088, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 644, new DateTime(2022, 1, 26, 18, 14, 24, 0, DateTimeKind.Unspecified), 1948.2155897811861, 18985.584927571006, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 647, new DateTime(2022, 1, 26, 21, 7, 12, 0, DateTimeKind.Unspecified), 6229.2154409530694, 897.73795893536476, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 449, new DateTime(2022, 1, 18, 23, 2, 24, 0, DateTimeKind.Unspecified), 5196.5805279007327, 6149.618921775831, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 650, new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 8924.9025898771652, 2510.87822399282, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 656, new DateTime(2022, 1, 27, 5, 45, 36, 0, DateTimeKind.Unspecified), 8369.7581645973733, 17512.202149631183, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 659, new DateTime(2022, 1, 27, 8, 38, 24, 0, DateTimeKind.Unspecified), 3332.7631030204102, 6645.7903109395738, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 662, new DateTime(2022, 1, 27, 11, 31, 12, 0, DateTimeKind.Unspecified), 1914.8240601629752, 10166.490681596966, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 665, new DateTime(2022, 1, 27, 14, 24, 0, 0, DateTimeKind.Unspecified), 1965.2606313121169, 8434.5423964456968, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 668, new DateTime(2022, 1, 27, 17, 16, 48, 0, DateTimeKind.Unspecified), 3365.0556478299818, 7153.2913820213917, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 671, new DateTime(2022, 1, 27, 20, 9, 36, 0, DateTimeKind.Unspecified), 7725.0008251587424, 13514.522315176382, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 674, new DateTime(2022, 1, 27, 23, 2, 24, 0, DateTimeKind.Unspecified), 205.56232155612156, 19869.324965620668, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 677, new DateTime(2022, 1, 28, 1, 55, 12, 0, DateTimeKind.Unspecified), 1376.3808815578702, 17658.345715572679, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 680, new DateTime(2022, 1, 28, 4, 48, 0, 0, DateTimeKind.Unspecified), 2843.6711299042859, 15480.056562957603, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 683, new DateTime(2022, 1, 28, 7, 40, 48, 0, DateTimeKind.Unspecified), 7930.4804571324648, 2978.7391531055041, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 686, new DateTime(2022, 1, 28, 10, 33, 36, 0, DateTimeKind.Unspecified), 9278.7961076014617, 4562.6181120023157, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 653, new DateTime(2022, 1, 27, 2, 52, 48, 0, DateTimeKind.Unspecified), 7441.264106654995, 1421.7796792966631, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 770, new DateTime(2022, 1, 31, 19, 12, 0, 0, DateTimeKind.Unspecified), 2562.4843433696769, 19455.213955273219, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 222, new DateTime(2022, 1, 9, 21, 7, 12, 0, DateTimeKind.Unspecified), 6450.2979252801888, 9080.2264906714936, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 446, new DateTime(2022, 1, 18, 20, 9, 36, 0, DateTimeKind.Unspecified), 6795.0900796239021, 9938.8007716307693, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 642, new DateTime(2022, 1, 26, 16, 19, 12, 0, DateTimeKind.Unspecified), 4815.5493481310714, 7310.8898600279626, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 645, new DateTime(2022, 1, 26, 19, 12, 0, 0, DateTimeKind.Unspecified), 722.76189941721464, 10037.793977363586, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 648, new DateTime(2022, 1, 26, 22, 4, 48, 0, DateTimeKind.Unspecified), 4475.494315098661, 9909.1026844972039, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 651, new DateTime(2022, 1, 27, 0, 57, 36, 0, DateTimeKind.Unspecified), 9872.1775173738206, 13290.785688458707, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 654, new DateTime(2022, 1, 27, 3, 50, 24, 0, DateTimeKind.Unspecified), 6161.5179397643615, 17869.154486039457, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 657, new DateTime(2022, 1, 27, 6, 43, 12, 0, DateTimeKind.Unspecified), 1679.796245523574, 12382.768120615559, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 660, new DateTime(2022, 1, 27, 9, 36, 0, 0, DateTimeKind.Unspecified), 6653.257234781493, 14453.790444455839, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 663, new DateTime(2022, 1, 27, 12, 28, 48, 0, DateTimeKind.Unspecified), 388.41747302180704, 12783.54337201544, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 666, new DateTime(2022, 1, 27, 15, 21, 36, 0, DateTimeKind.Unspecified), 8472.9669807030132, 2842.7045841093336, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 669, new DateTime(2022, 1, 27, 18, 14, 24, 0, DateTimeKind.Unspecified), 3270.135464335382, 14288.686160533129, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 672, new DateTime(2022, 1, 27, 21, 7, 12, 0, DateTimeKind.Unspecified), 677.70777996038987, 10487.987606501209, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 675, new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 8158.9742802713472, 14385.349261284706, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 678, new DateTime(2022, 1, 28, 2, 52, 48, 0, DateTimeKind.Unspecified), 8882.1701842265102, 588.76255215918945, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 681, new DateTime(2022, 1, 28, 5, 45, 36, 0, DateTimeKind.Unspecified), 2206.2995713428913, 1525.5333875689507, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 684, new DateTime(2022, 1, 28, 8, 38, 24, 0, DateTimeKind.Unspecified), 1182.7995852925233, 7735.3649177515917, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 687, new DateTime(2022, 1, 28, 11, 31, 12, 0, DateTimeKind.Unspecified), 9434.6711657283213, 10057.665476818371, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 690, new DateTime(2022, 1, 28, 14, 24, 0, 0, DateTimeKind.Unspecified), 1932.7756404450663, 14728.843613972636, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 693, new DateTime(2022, 1, 28, 17, 16, 48, 0, DateTimeKind.Unspecified), 5908.0759138437979, 6488.906837808524, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 696, new DateTime(2022, 1, 28, 20, 9, 36, 0, DateTimeKind.Unspecified), 2377.8748350648257, 15264.798842255848, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 699, new DateTime(2022, 1, 28, 23, 2, 24, 0, DateTimeKind.Unspecified), 6761.0867351703218, 6309.4824223141077, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 702, new DateTime(2022, 1, 29, 1, 55, 12, 0, DateTimeKind.Unspecified), 9511.7248826554605, 9334.692701053973, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 705, new DateTime(2022, 1, 29, 4, 48, 0, 0, DateTimeKind.Unspecified), 3251.1123493181422, 12234.931539200965, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 708, new DateTime(2022, 1, 29, 7, 40, 48, 0, DateTimeKind.Unspecified), 3302.3881878708503, 6501.2189223955584, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 639, new DateTime(2022, 1, 26, 13, 26, 24, 0, DateTimeKind.Unspecified), 6613.2530124717759, 14144.13075393251, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 711, new DateTime(2022, 1, 29, 10, 33, 36, 0, DateTimeKind.Unspecified), 8237.5026547004163, 1861.7621632074295, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 636, new DateTime(2022, 1, 26, 10, 33, 36, 0, DateTimeKind.Unspecified), 9848.5381408406793, 11757.1870388931, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 630, new DateTime(2022, 1, 26, 4, 48, 0, 0, DateTimeKind.Unspecified), 7321.9235338844501, 16919.182626581034, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 561, new DateTime(2022, 1, 23, 10, 33, 36, 0, DateTimeKind.Unspecified), 8462.4070656905369, 9885.5169721735438, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 564, new DateTime(2022, 1, 23, 13, 26, 24, 0, DateTimeKind.Unspecified), 9626.0071342901192, 14763.563778961243, "877b39aa-4524-4319-98c4-3d1944240264" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 567, new DateTime(2022, 1, 23, 16, 19, 12, 0, DateTimeKind.Unspecified), 1659.116642791503, 9865.5847039360197, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 570, new DateTime(2022, 1, 23, 19, 12, 0, 0, DateTimeKind.Unspecified), 5512.624246538031, 15106.505782552083, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 573, new DateTime(2022, 1, 23, 22, 4, 48, 0, DateTimeKind.Unspecified), 9004.7008922184214, 8723.465932267527, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 576, new DateTime(2022, 1, 24, 0, 57, 36, 0, DateTimeKind.Unspecified), 9412.8675758401005, 18306.468978339224, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 579, new DateTime(2022, 1, 24, 3, 50, 24, 0, DateTimeKind.Unspecified), 8736.6325737613515, 10713.046656480954, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 582, new DateTime(2022, 1, 24, 6, 43, 12, 0, DateTimeKind.Unspecified), 2996.8022303611383, 1369.8901774273852, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 585, new DateTime(2022, 1, 24, 9, 36, 0, 0, DateTimeKind.Unspecified), 5461.7807388314895, 11643.062311699445, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 588, new DateTime(2022, 1, 24, 12, 28, 48, 0, DateTimeKind.Unspecified), 2400.6590023591866, 2878.3786735276349, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 591, new DateTime(2022, 1, 24, 15, 21, 36, 0, DateTimeKind.Unspecified), 2594.9416525065849, 17861.413035241465, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 594, new DateTime(2022, 1, 24, 18, 14, 24, 0, DateTimeKind.Unspecified), 6522.6370751130307, 477.24645122169875, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 597, new DateTime(2022, 1, 24, 21, 7, 12, 0, DateTimeKind.Unspecified), 6818.1272464741942, 10459.624895527215, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 600, new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8811.9645068646787, 11163.632559182357, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 603, new DateTime(2022, 1, 25, 2, 52, 48, 0, DateTimeKind.Unspecified), 9283.0905873664778, 6780.2872174669737, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 606, new DateTime(2022, 1, 25, 5, 45, 36, 0, DateTimeKind.Unspecified), 9597.0244554831152, 2505.0497495238124, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 609, new DateTime(2022, 1, 25, 8, 38, 24, 0, DateTimeKind.Unspecified), 3479.8682932956594, 19500.482124632177, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 612, new DateTime(2022, 1, 25, 11, 31, 12, 0, DateTimeKind.Unspecified), 8069.7139114937791, 19535.447701811492, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 615, new DateTime(2022, 1, 25, 14, 24, 0, 0, DateTimeKind.Unspecified), 685.90268779532414, 16927.146624501005, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 618, new DateTime(2022, 1, 25, 17, 16, 48, 0, DateTimeKind.Unspecified), 845.91049411918345, 15296.355714304418, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 621, new DateTime(2022, 1, 25, 20, 9, 36, 0, DateTimeKind.Unspecified), 1268.4104356258713, 17949.041019699787, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 624, new DateTime(2022, 1, 25, 23, 2, 24, 0, DateTimeKind.Unspecified), 2883.225505976875, 11471.863824613958, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 627, new DateTime(2022, 1, 26, 1, 55, 12, 0, DateTimeKind.Unspecified), 4687.6275259837957, 10749.154417540909, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 633, new DateTime(2022, 1, 26, 7, 40, 48, 0, DateTimeKind.Unspecified), 3595.1947574996248, 9641.8612771270582, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 714, new DateTime(2022, 1, 29, 13, 26, 24, 0, DateTimeKind.Unspecified), 2285.9392734665025, 1254.7948010793907, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 717, new DateTime(2022, 1, 29, 16, 19, 12, 0, DateTimeKind.Unspecified), 9935.4071079208279, 10240.134805355799, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 720, new DateTime(2022, 1, 29, 19, 12, 0, 0, DateTimeKind.Unspecified), 7706.4461754440872, 3691.2784666785874, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 807, new DateTime(2022, 2, 2, 6, 43, 12, 0, DateTimeKind.Unspecified), 7392.2474464660136, 9294.8014215526127, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 810, new DateTime(2022, 2, 2, 9, 36, 0, 0, DateTimeKind.Unspecified), 7427.372482884286, 16283.580889038938, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 813, new DateTime(2022, 2, 2, 12, 28, 48, 0, DateTimeKind.Unspecified), 4858.2525203259884, 15718.218678189389, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 816, new DateTime(2022, 2, 2, 15, 21, 36, 0, DateTimeKind.Unspecified), 8996.0183517255427, 5780.9800179028762, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 819, new DateTime(2022, 2, 2, 18, 14, 24, 0, DateTimeKind.Unspecified), 6369.1213692600295, 6236.5108891474747, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 822, new DateTime(2022, 2, 2, 21, 7, 12, 0, DateTimeKind.Unspecified), 8917.8570968441727, 11575.92026787909, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 825, new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6337.9407491211077, 12729.683247066259, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 828, new DateTime(2022, 2, 3, 2, 52, 48, 0, DateTimeKind.Unspecified), 3516.3058487738313, 15598.005460699947, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 831, new DateTime(2022, 2, 3, 5, 45, 36, 0, DateTimeKind.Unspecified), 8393.3512973973484, 4922.6790038490099, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 834, new DateTime(2022, 2, 3, 8, 38, 24, 0, DateTimeKind.Unspecified), 6189.1039576467192, 15615.798616695698, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 837, new DateTime(2022, 2, 3, 11, 31, 12, 0, DateTimeKind.Unspecified), 9958.7625559970875, 3007.0011498792505, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 840, new DateTime(2022, 2, 3, 14, 24, 0, 0, DateTimeKind.Unspecified), 6705.1332503918993, 1247.9770502156389, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 843, new DateTime(2022, 2, 3, 17, 16, 48, 0, DateTimeKind.Unspecified), 4193.5194847108387, 4401.8315093474121, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 846, new DateTime(2022, 2, 3, 20, 9, 36, 0, DateTimeKind.Unspecified), 7657.5513912192946, 925.55731864901998, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 849, new DateTime(2022, 2, 3, 23, 2, 24, 0, DateTimeKind.Unspecified), 1650.8138874886886, 18308.825550637597, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 852, new DateTime(2022, 2, 4, 1, 55, 12, 0, DateTimeKind.Unspecified), 2162.9609058839669, 1891.3126953384219, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 855, new DateTime(2022, 2, 4, 4, 48, 0, 0, DateTimeKind.Unspecified), 8387.9400823787655, 14766.357848162605, "877b39aa-4524-4319-98c4-3d1944240264" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 858, new DateTime(2022, 2, 4, 7, 40, 48, 0, DateTimeKind.Unspecified), 2037.7160945131172, 2239.6105693202135, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 861, new DateTime(2022, 2, 4, 10, 33, 36, 0, DateTimeKind.Unspecified), 3487.1708311833195, 2442.7342770967875, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 864, new DateTime(2022, 2, 4, 13, 26, 24, 0, DateTimeKind.Unspecified), 4609.9235917935403, 7158.7913367743276, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 867, new DateTime(2022, 2, 4, 16, 19, 12, 0, DateTimeKind.Unspecified), 4010.8580943040579, 8688.2402660779298, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 870, new DateTime(2022, 2, 4, 19, 12, 0, 0, DateTimeKind.Unspecified), 3786.6263337079317, 8192.7017287738418, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 873, new DateTime(2022, 2, 4, 22, 4, 48, 0, DateTimeKind.Unspecified), 9283.1808814724445, 8344.0135711752537, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 804, new DateTime(2022, 2, 2, 3, 50, 24, 0, DateTimeKind.Unspecified), 4437.6399582028098, 11957.737961352579, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 801, new DateTime(2022, 2, 2, 0, 57, 36, 0, DateTimeKind.Unspecified), 6952.4792396112944, 19814.394644564261, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 798, new DateTime(2022, 2, 1, 22, 4, 48, 0, DateTimeKind.Unspecified), 6490.1873706393089, 11597.78060663528, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 795, new DateTime(2022, 2, 1, 19, 12, 0, 0, DateTimeKind.Unspecified), 8138.5742103221355, 8911.6210753079667, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 723, new DateTime(2022, 1, 29, 22, 4, 48, 0, DateTimeKind.Unspecified), 2310.8522798212948, 11681.259098773213, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 726, new DateTime(2022, 1, 30, 0, 57, 36, 0, DateTimeKind.Unspecified), 7048.1020636967969, 11013.635774219514, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 729, new DateTime(2022, 1, 30, 3, 50, 24, 0, DateTimeKind.Unspecified), 5363.881461347205, 4541.7064658608952, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 732, new DateTime(2022, 1, 30, 6, 43, 12, 0, DateTimeKind.Unspecified), 3670.7325559779474, 10948.685913879148, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 735, new DateTime(2022, 1, 30, 9, 36, 0, 0, DateTimeKind.Unspecified), 7404.1819759211658, 7948.4373586788879, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 738, new DateTime(2022, 1, 30, 12, 28, 48, 0, DateTimeKind.Unspecified), 1714.4590769532122, 2223.0188190362464, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 741, new DateTime(2022, 1, 30, 15, 21, 36, 0, DateTimeKind.Unspecified), 1938.3662746614209, 11835.382602252419, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 744, new DateTime(2022, 1, 30, 18, 14, 24, 0, DateTimeKind.Unspecified), 5720.4998998861538, 2208.7553406654779, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 747, new DateTime(2022, 1, 30, 21, 7, 12, 0, DateTimeKind.Unspecified), 1210.2281278819066, 14451.050188318382, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 750, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 9772.5723864993197, 2942.2623919762705, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 753, new DateTime(2022, 1, 31, 2, 52, 48, 0, DateTimeKind.Unspecified), 5090.0643692905815, 7060.7973440645828, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 558, new DateTime(2022, 1, 23, 7, 40, 48, 0, DateTimeKind.Unspecified), 4858.7456724495296, 9907.703382508942, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 756, new DateTime(2022, 1, 31, 5, 45, 36, 0, DateTimeKind.Unspecified), 3568.1758010550402, 18758.660941120772, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 762, new DateTime(2022, 1, 31, 11, 31, 12, 0, DateTimeKind.Unspecified), 9863.2338021827509, 10724.699883571617, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 765, new DateTime(2022, 1, 31, 14, 24, 0, 0, DateTimeKind.Unspecified), 7165.758530264161, 17743.991459620654, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 768, new DateTime(2022, 1, 31, 17, 16, 48, 0, DateTimeKind.Unspecified), 8867.88640321803, 3099.2496997993544, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 771, new DateTime(2022, 1, 31, 20, 9, 36, 0, DateTimeKind.Unspecified), 2566.6948455789116, 17496.425424302815, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 774, new DateTime(2022, 1, 31, 23, 2, 24, 0, DateTimeKind.Unspecified), 5470.5545759206316, 13704.087035088023, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 777, new DateTime(2022, 2, 1, 1, 55, 12, 0, DateTimeKind.Unspecified), 8161.2211873191982, 8544.5633275830187, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 780, new DateTime(2022, 2, 1, 4, 48, 0, 0, DateTimeKind.Unspecified), 7366.3621953126012, 10579.42570619992, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 783, new DateTime(2022, 2, 1, 7, 40, 48, 0, DateTimeKind.Unspecified), 5383.0637337018898, 6100.034317785633, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 786, new DateTime(2022, 2, 1, 10, 33, 36, 0, DateTimeKind.Unspecified), 6633.3551614232692, 10039.328579657073, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 789, new DateTime(2022, 2, 1, 13, 26, 24, 0, DateTimeKind.Unspecified), 9894.7091127672102, 5933.7936765261193, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 792, new DateTime(2022, 2, 1, 16, 19, 12, 0, DateTimeKind.Unspecified), 8336.6206434464657, 2016.0184925405181, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 759, new DateTime(2022, 1, 31, 8, 38, 24, 0, DateTimeKind.Unspecified), 5055.966996629294, 18110.713483388914, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 555, new DateTime(2022, 1, 23, 4, 48, 0, 0, DateTimeKind.Unspecified), 6535.3223139642487, 11167.469717711574, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 552, new DateTime(2022, 1, 23, 1, 55, 12, 0, DateTimeKind.Unspecified), 2308.5789784677454, 4624.8970853164274, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 549, new DateTime(2022, 1, 22, 23, 2, 24, 0, DateTimeKind.Unspecified), 520.78114009549927, 10980.477592100322, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 315, new DateTime(2022, 1, 13, 14, 24, 0, 0, DateTimeKind.Unspecified), 9791.5826466818326, 16118.89667810569, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 318, new DateTime(2022, 1, 13, 17, 16, 48, 0, DateTimeKind.Unspecified), 2856.3496756397999, 6485.9473734659086, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 321, new DateTime(2022, 1, 13, 20, 9, 36, 0, DateTimeKind.Unspecified), 2363.1924673046647, 8444.1857548208736, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 324, new DateTime(2022, 1, 13, 23, 2, 24, 0, DateTimeKind.Unspecified), 7945.7515632839632, 4463.969662747314, "877b39aa-4524-4319-98c4-3d1944240264" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 327, new DateTime(2022, 1, 14, 1, 55, 12, 0, DateTimeKind.Unspecified), 2514.5285876449043, 14231.559711913289, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 330, new DateTime(2022, 1, 14, 4, 48, 0, 0, DateTimeKind.Unspecified), 6788.5871353227876, 14362.60846698324, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 333, new DateTime(2022, 1, 14, 7, 40, 48, 0, DateTimeKind.Unspecified), 9210.4144777040001, 9912.6607958130389, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 336, new DateTime(2022, 1, 14, 10, 33, 36, 0, DateTimeKind.Unspecified), 7146.2219315834827, 17086.814065776372, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 339, new DateTime(2022, 1, 14, 13, 26, 24, 0, DateTimeKind.Unspecified), 4290.3286815685469, 18046.492314753432, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 342, new DateTime(2022, 1, 14, 16, 19, 12, 0, DateTimeKind.Unspecified), 5592.374600871869, 12748.030217421347, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 345, new DateTime(2022, 1, 14, 19, 12, 0, 0, DateTimeKind.Unspecified), 3367.1670643456059, 974.48240555197026, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 348, new DateTime(2022, 1, 14, 22, 4, 48, 0, DateTimeKind.Unspecified), 5358.1155955614222, 10166.610083801086, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 351, new DateTime(2022, 1, 15, 0, 57, 36, 0, DateTimeKind.Unspecified), 1258.050419475712, 19302.62410337411, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 354, new DateTime(2022, 1, 15, 3, 50, 24, 0, DateTimeKind.Unspecified), 3984.2145100925763, 2765.7366119430576, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 357, new DateTime(2022, 1, 15, 6, 43, 12, 0, DateTimeKind.Unspecified), 9476.6817284591561, 14724.740149704272, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 360, new DateTime(2022, 1, 15, 9, 36, 0, 0, DateTimeKind.Unspecified), 4463.9473333654541, 6903.9041208609251, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 363, new DateTime(2022, 1, 15, 12, 28, 48, 0, DateTimeKind.Unspecified), 9036.565521849172, 18358.449056107627, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 366, new DateTime(2022, 1, 15, 15, 21, 36, 0, DateTimeKind.Unspecified), 7834.9919776003408, 2735.3956685638277, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 369, new DateTime(2022, 1, 15, 18, 14, 24, 0, DateTimeKind.Unspecified), 2327.7024465823115, 9349.8362303351878, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 372, new DateTime(2022, 1, 15, 21, 7, 12, 0, DateTimeKind.Unspecified), 3193.8208843935531, 12673.614621200901, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 375, new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 9836.0700067480866, 3750.8376053408256, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 378, new DateTime(2022, 1, 16, 2, 52, 48, 0, DateTimeKind.Unspecified), 209.79438570612535, 17879.553096961274, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 381, new DateTime(2022, 1, 16, 5, 45, 36, 0, DateTimeKind.Unspecified), 6894.68643973902, 1606.0148787282801, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 312, new DateTime(2022, 1, 13, 11, 31, 12, 0, DateTimeKind.Unspecified), 5515.5780159128117, 2614.6607947456337, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 309, new DateTime(2022, 1, 13, 8, 38, 24, 0, DateTimeKind.Unspecified), 3300.5992970674447, 14210.188925767925, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 306, new DateTime(2022, 1, 13, 5, 45, 36, 0, DateTimeKind.Unspecified), 9605.4554573343248, 4941.9708051297093, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 303, new DateTime(2022, 1, 13, 2, 52, 48, 0, DateTimeKind.Unspecified), 7461.3407238585505, 16464.546798730014, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 231, new DateTime(2022, 1, 10, 5, 45, 36, 0, DateTimeKind.Unspecified), 4926.1175944550541, 11602.945829432698, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 234, new DateTime(2022, 1, 10, 8, 38, 24, 0, DateTimeKind.Unspecified), 8154.1276538894344, 1754.4347686362855, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 237, new DateTime(2022, 1, 10, 11, 31, 12, 0, DateTimeKind.Unspecified), 1381.0377645965104, 3726.8709222292946, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 240, new DateTime(2022, 1, 10, 14, 24, 0, 0, DateTimeKind.Unspecified), 3376.1000078679594, 9048.6561389001126, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 243, new DateTime(2022, 1, 10, 17, 16, 48, 0, DateTimeKind.Unspecified), 5769.6161762517304, 13295.291822869201, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 246, new DateTime(2022, 1, 10, 20, 9, 36, 0, DateTimeKind.Unspecified), 961.70717605693278, 1780.3534860102825, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 249, new DateTime(2022, 1, 10, 23, 2, 24, 0, DateTimeKind.Unspecified), 4655.1431183212253, 13714.319306252692, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 252, new DateTime(2022, 1, 11, 1, 55, 12, 0, DateTimeKind.Unspecified), 9649.4476530537104, 4293.4477555765789, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 255, new DateTime(2022, 1, 11, 4, 48, 0, 0, DateTimeKind.Unspecified), 6381.4184873867007, 13494.102441407224, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 258, new DateTime(2022, 1, 11, 7, 40, 48, 0, DateTimeKind.Unspecified), 408.31273555857251, 1815.4856532495699, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 261, new DateTime(2022, 1, 11, 10, 33, 36, 0, DateTimeKind.Unspecified), 3351.5085143183614, 497.85293657725055, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 384, new DateTime(2022, 1, 16, 8, 38, 24, 0, DateTimeKind.Unspecified), 5100.1466643401282, 17364.102833826932, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 264, new DateTime(2022, 1, 11, 13, 26, 24, 0, DateTimeKind.Unspecified), 6789.4194034954508, 11393.372809883293, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 270, new DateTime(2022, 1, 11, 19, 12, 0, 0, DateTimeKind.Unspecified), 9077.7165646846279, 19315.308659199418, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 273, new DateTime(2022, 1, 11, 22, 4, 48, 0, DateTimeKind.Unspecified), 5145.1784770440208, 8653.2911796959015, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 276, new DateTime(2022, 1, 12, 0, 57, 36, 0, DateTimeKind.Unspecified), 8138.4803074386327, 12598.127395983547, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 279, new DateTime(2022, 1, 12, 3, 50, 24, 0, DateTimeKind.Unspecified), 653.09224525632999, 4747.9313467654047, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 282, new DateTime(2022, 1, 12, 6, 43, 12, 0, DateTimeKind.Unspecified), 7283.0698762020147, 8131.3332103426874, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 285, new DateTime(2022, 1, 12, 9, 36, 0, 0, DateTimeKind.Unspecified), 784.23442087152046, 8043.1252975880579, "877b39aa-4524-4319-98c4-3d1944240264" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 288, new DateTime(2022, 1, 12, 12, 28, 48, 0, DateTimeKind.Unspecified), 5382.9032490414111, 8382.588711972543, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 291, new DateTime(2022, 1, 12, 15, 21, 36, 0, DateTimeKind.Unspecified), 9536.4873428595311, 11531.807055613064, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 294, new DateTime(2022, 1, 12, 18, 14, 24, 0, DateTimeKind.Unspecified), 984.04947442173841, 16581.974637892523, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 297, new DateTime(2022, 1, 12, 21, 7, 12, 0, DateTimeKind.Unspecified), 8586.9256982834704, 8410.1205762437276, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 300, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 6304.2455776763045, 4516.8460303855181, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 267, new DateTime(2022, 1, 11, 16, 19, 12, 0, DateTimeKind.Unspecified), 2199.1342721549795, 9064.3423758207773, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 225, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213.6148163489001, 18731.283997711471, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 387, new DateTime(2022, 1, 16, 11, 31, 12, 0, DateTimeKind.Unspecified), 4036.2836439394641, 18703.930876743067, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 393, new DateTime(2022, 1, 16, 17, 16, 48, 0, DateTimeKind.Unspecified), 9502.630202862385, 6954.653314219152, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 480, new DateTime(2022, 1, 20, 4, 48, 0, 0, DateTimeKind.Unspecified), 5559.0395150170807, 5717.5230967669513, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 483, new DateTime(2022, 1, 20, 7, 40, 48, 0, DateTimeKind.Unspecified), 5296.1188356852726, 6236.2908964677026, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 486, new DateTime(2022, 1, 20, 10, 33, 36, 0, DateTimeKind.Unspecified), 1899.1777782996583, 18386.016932380651, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 489, new DateTime(2022, 1, 20, 13, 26, 24, 0, DateTimeKind.Unspecified), 8066.4201936120435, 16087.009577932693, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 492, new DateTime(2022, 1, 20, 16, 19, 12, 0, DateTimeKind.Unspecified), 4839.2128624367087, 8813.6151837240395, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 495, new DateTime(2022, 1, 20, 19, 12, 0, 0, DateTimeKind.Unspecified), 5744.8396979302961, 18754.396504986285, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 498, new DateTime(2022, 1, 20, 22, 4, 48, 0, DateTimeKind.Unspecified), 2634.7181398353341, 6484.9171647453277, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 501, new DateTime(2022, 1, 21, 0, 57, 36, 0, DateTimeKind.Unspecified), 4922.2765531593941, 16510.162253398237, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 504, new DateTime(2022, 1, 21, 3, 50, 24, 0, DateTimeKind.Unspecified), 7464.2425806500705, 14289.121393436913, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 507, new DateTime(2022, 1, 21, 6, 43, 12, 0, DateTimeKind.Unspecified), 7161.3296425908839, 4882.998452610208, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 510, new DateTime(2022, 1, 21, 9, 36, 0, 0, DateTimeKind.Unspecified), 6072.2762939585136, 13426.891480811029, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 513, new DateTime(2022, 1, 21, 12, 28, 48, 0, DateTimeKind.Unspecified), 7037.6197431943829, 8072.6109751141566, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 516, new DateTime(2022, 1, 21, 15, 21, 36, 0, DateTimeKind.Unspecified), 5623.85367674593, 13945.025459699333, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 519, new DateTime(2022, 1, 21, 18, 14, 24, 0, DateTimeKind.Unspecified), 9372.3212947365973, 8925.4707028661251, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 522, new DateTime(2022, 1, 21, 21, 7, 12, 0, DateTimeKind.Unspecified), 1100.5221665147351, 19072.396932605527, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 525, new DateTime(2022, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 840.83954419769577, 7605.9548210215926, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 528, new DateTime(2022, 1, 22, 2, 52, 48, 0, DateTimeKind.Unspecified), 6215.9673754563946, 9544.1682596542305, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 531, new DateTime(2022, 1, 22, 5, 45, 36, 0, DateTimeKind.Unspecified), 9441.6130260432765, 5776.9562018460456, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 534, new DateTime(2022, 1, 22, 8, 38, 24, 0, DateTimeKind.Unspecified), 7679.1277962456115, 5417.6458870543784, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 537, new DateTime(2022, 1, 22, 11, 31, 12, 0, DateTimeKind.Unspecified), 6499.2384437708479, 16422.753236501107, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 540, new DateTime(2022, 1, 22, 14, 24, 0, 0, DateTimeKind.Unspecified), 5775.9590905915256, 10077.873026010251, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 543, new DateTime(2022, 1, 22, 17, 16, 48, 0, DateTimeKind.Unspecified), 5971.7938360661929, 17829.318009019244, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 546, new DateTime(2022, 1, 22, 20, 9, 36, 0, DateTimeKind.Unspecified), 4449.4963478178734, 5981.1632543875276, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 477, new DateTime(2022, 1, 20, 1, 55, 12, 0, DateTimeKind.Unspecified), 1324.547885860989, 9341.6355815210827, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 474, new DateTime(2022, 1, 19, 23, 2, 24, 0, DateTimeKind.Unspecified), 1177.8065964381103, 5314.8750119604856, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 471, new DateTime(2022, 1, 19, 20, 9, 36, 0, DateTimeKind.Unspecified), 768.79760667680341, 6252.4721930454507, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 468, new DateTime(2022, 1, 19, 17, 16, 48, 0, DateTimeKind.Unspecified), 6579.8007968777601, 17706.593059153336, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 396, new DateTime(2022, 1, 16, 20, 9, 36, 0, DateTimeKind.Unspecified), 8506.2282679713517, 15943.32175478257, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 399, new DateTime(2022, 1, 16, 23, 2, 24, 0, DateTimeKind.Unspecified), 504.6606919181678, 8676.4308128742596, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 402, new DateTime(2022, 1, 17, 1, 55, 12, 0, DateTimeKind.Unspecified), 8696.7661241095084, 17520.899481593115, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 405, new DateTime(2022, 1, 17, 4, 48, 0, 0, DateTimeKind.Unspecified), 5936.4928996589106, 18695.713755672037, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 408, new DateTime(2022, 1, 17, 7, 40, 48, 0, DateTimeKind.Unspecified), 8586.9708957150287, 3895.5510773324499, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 411, new DateTime(2022, 1, 17, 10, 33, 36, 0, DateTimeKind.Unspecified), 7509.9693912824687, 8969.9337761987445, "877b39aa-4524-4319-98c4-3d1944240264" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 414, new DateTime(2022, 1, 17, 13, 26, 24, 0, DateTimeKind.Unspecified), 9156.8999596121739, 18306.125221316233, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 417, new DateTime(2022, 1, 17, 16, 19, 12, 0, DateTimeKind.Unspecified), 5578.9112271108424, 7353.533892196373, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 420, new DateTime(2022, 1, 17, 19, 12, 0, 0, DateTimeKind.Unspecified), 201.44427316174972, 16638.072099430341, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 423, new DateTime(2022, 1, 17, 22, 4, 48, 0, DateTimeKind.Unspecified), 6508.5612683407271, 16602.60171090925, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 426, new DateTime(2022, 1, 18, 0, 57, 36, 0, DateTimeKind.Unspecified), 1017.1320835260351, 15479.956599908652, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 390, new DateTime(2022, 1, 16, 14, 24, 0, 0, DateTimeKind.Unspecified), 8076.8089658705485, 1413.188022976459, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 429, new DateTime(2022, 1, 18, 3, 50, 24, 0, DateTimeKind.Unspecified), 6919.3613414850061, 17555.609303689729, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 435, new DateTime(2022, 1, 18, 9, 36, 0, 0, DateTimeKind.Unspecified), 5840.5295216513405, 16038.20969665114, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 438, new DateTime(2022, 1, 18, 12, 28, 48, 0, DateTimeKind.Unspecified), 4077.2272941903116, 10084.218258990779, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 441, new DateTime(2022, 1, 18, 15, 21, 36, 0, DateTimeKind.Unspecified), 6589.0203628243089, 18179.072410824367, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 444, new DateTime(2022, 1, 18, 18, 14, 24, 0, DateTimeKind.Unspecified), 7773.1796344756267, 11226.727140400064, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 447, new DateTime(2022, 1, 18, 21, 7, 12, 0, DateTimeKind.Unspecified), 5060.8529269794635, 11422.823090541067, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 450, new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 7672.7107991914636, 5783.8433268130802, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 453, new DateTime(2022, 1, 19, 2, 52, 48, 0, DateTimeKind.Unspecified), 829.87365743372641, 19558.456248637995, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 456, new DateTime(2022, 1, 19, 5, 45, 36, 0, DateTimeKind.Unspecified), 4598.0549932387121, 15698.815703783199, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 459, new DateTime(2022, 1, 19, 8, 38, 24, 0, DateTimeKind.Unspecified), 7791.2751053242855, 12282.629717047637, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 462, new DateTime(2022, 1, 19, 11, 31, 12, 0, DateTimeKind.Unspecified), 390.35405582858124, 7853.7885786186953, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 465, new DateTime(2022, 1, 19, 14, 24, 0, 0, DateTimeKind.Unspecified), 7861.5639945764324, 15717.985547262831, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 432, new DateTime(2022, 1, 18, 6, 43, 12, 0, DateTimeKind.Unspecified), 5567.0283801702617, 5635.9942897639803, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 228, new DateTime(2022, 1, 10, 2, 52, 48, 0, DateTimeKind.Unspecified), 5751.2436702565101, 7739.1549084455173, "877b39aa-4524-4319-98c4-3d1944240264" },
                    { 443, new DateTime(2022, 1, 18, 17, 16, 48, 0, DateTimeKind.Unspecified), 6768.02479387536, 14877.752917036631, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 437, new DateTime(2022, 1, 18, 11, 31, 12, 0, DateTimeKind.Unspecified), 8142.1525612829537, 11715.486338970912, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 418, new DateTime(2022, 1, 17, 17, 16, 48, 0, DateTimeKind.Unspecified), 6664.3122419002584, 2768.8495944140386, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 421, new DateTime(2022, 1, 17, 20, 9, 36, 0, DateTimeKind.Unspecified), 6018.1236299438797, 10101.450724729866, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 424, new DateTime(2022, 1, 17, 23, 2, 24, 0, DateTimeKind.Unspecified), 2794.0681662708939, 14664.207345008524, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 427, new DateTime(2022, 1, 18, 1, 55, 12, 0, DateTimeKind.Unspecified), 9684.8090848733136, 7039.0248124144737, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 430, new DateTime(2022, 1, 18, 4, 48, 0, 0, DateTimeKind.Unspecified), 5090.2377051356734, 10896.440219464197, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 433, new DateTime(2022, 1, 18, 7, 40, 48, 0, DateTimeKind.Unspecified), 8302.3953193123307, 7586.8145638615988, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 436, new DateTime(2022, 1, 18, 10, 33, 36, 0, DateTimeKind.Unspecified), 9790.7930993315913, 11088.254163478287, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 439, new DateTime(2022, 1, 18, 13, 26, 24, 0, DateTimeKind.Unspecified), 3941.0596981409658, 17582.247098170526, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 442, new DateTime(2022, 1, 18, 16, 19, 12, 0, DateTimeKind.Unspecified), 2988.8483418871247, 12515.036578510062, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 445, new DateTime(2022, 1, 18, 19, 12, 0, 0, DateTimeKind.Unspecified), 6888.3642649688227, 18256.747340524027, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 448, new DateTime(2022, 1, 18, 22, 4, 48, 0, DateTimeKind.Unspecified), 7491.6097111754561, 16205.901482552445, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 451, new DateTime(2022, 1, 19, 0, 57, 36, 0, DateTimeKind.Unspecified), 8052.3240675981215, 15305.934733193591, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 454, new DateTime(2022, 1, 19, 3, 50, 24, 0, DateTimeKind.Unspecified), 473.98533190340163, 11718.55972380463, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 457, new DateTime(2022, 1, 19, 6, 43, 12, 0, DateTimeKind.Unspecified), 6505.4028935869474, 17429.449389256784, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 460, new DateTime(2022, 1, 19, 9, 36, 0, 0, DateTimeKind.Unspecified), 4443.5680196109734, 469.13177840462498, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 463, new DateTime(2022, 1, 19, 12, 28, 48, 0, DateTimeKind.Unspecified), 9286.2870478482328, 10771.337434404171, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 466, new DateTime(2022, 1, 19, 15, 21, 36, 0, DateTimeKind.Unspecified), 5088.4534896725563, 6613.4965441400809, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 469, new DateTime(2022, 1, 19, 18, 14, 24, 0, DateTimeKind.Unspecified), 5563.705528415956, 6733.2725201676158, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 472, new DateTime(2022, 1, 19, 21, 7, 12, 0, DateTimeKind.Unspecified), 817.707576922562, 6673.5071185161369, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 475, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7008.4969147601332, 12110.271176451255, "24391000-0a63-4bb1-971f-7611dd87d9f6" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 478, new DateTime(2022, 1, 20, 2, 52, 48, 0, DateTimeKind.Unspecified), 8181.3642698555177, 13398.247194563028, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 481, new DateTime(2022, 1, 20, 5, 45, 36, 0, DateTimeKind.Unspecified), 5809.3506150343874, 11701.406229197622, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 484, new DateTime(2022, 1, 20, 8, 38, 24, 0, DateTimeKind.Unspecified), 3636.7999002836395, 461.49365517959421, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 415, new DateTime(2022, 1, 17, 14, 24, 0, 0, DateTimeKind.Unspecified), 692.03544650856406, 9447.0857673526152, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 412, new DateTime(2022, 1, 17, 11, 31, 12, 0, DateTimeKind.Unspecified), 1889.6703525058665, 4082.0883376771544, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 409, new DateTime(2022, 1, 17, 8, 38, 24, 0, DateTimeKind.Unspecified), 836.40144238310768, 11629.216555230711, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 406, new DateTime(2022, 1, 17, 5, 45, 36, 0, DateTimeKind.Unspecified), 4770.7450507242829, 18382.223191791487, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 334, new DateTime(2022, 1, 14, 8, 38, 24, 0, DateTimeKind.Unspecified), 669.02770326298128, 8027.463730080658, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 337, new DateTime(2022, 1, 14, 11, 31, 12, 0, DateTimeKind.Unspecified), 4509.0421518394796, 8350.9885265196535, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 340, new DateTime(2022, 1, 14, 14, 24, 0, 0, DateTimeKind.Unspecified), 3107.3284271021498, 18276.12526653301, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 343, new DateTime(2022, 1, 14, 17, 16, 48, 0, DateTimeKind.Unspecified), 3770.4521676741369, 11466.754092837298, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 346, new DateTime(2022, 1, 14, 20, 9, 36, 0, DateTimeKind.Unspecified), 5929.3604459281687, 10341.162432172017, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 349, new DateTime(2022, 1, 14, 23, 2, 24, 0, DateTimeKind.Unspecified), 7892.1021658164755, 17791.882947295238, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 352, new DateTime(2022, 1, 15, 1, 55, 12, 0, DateTimeKind.Unspecified), 1998.5613851735777, 8516.0941749882786, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 355, new DateTime(2022, 1, 15, 4, 48, 0, 0, DateTimeKind.Unspecified), 5930.6683526613397, 14687.694350613814, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 358, new DateTime(2022, 1, 15, 7, 40, 48, 0, DateTimeKind.Unspecified), 4607.7149805257986, 3190.6620634005176, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 361, new DateTime(2022, 1, 15, 10, 33, 36, 0, DateTimeKind.Unspecified), 833.39575893569076, 13186.135211962812, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 364, new DateTime(2022, 1, 15, 13, 26, 24, 0, DateTimeKind.Unspecified), 5236.5508169236036, 13285.619853832364, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 487, new DateTime(2022, 1, 20, 11, 31, 12, 0, DateTimeKind.Unspecified), 8743.8935093565069, 1810.7986096248333, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 367, new DateTime(2022, 1, 15, 16, 19, 12, 0, DateTimeKind.Unspecified), 7384.8718967722816, 7087.5466690173762, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 373, new DateTime(2022, 1, 15, 22, 4, 48, 0, DateTimeKind.Unspecified), 4996.2789790994457, 18327.621935300107, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 376, new DateTime(2022, 1, 16, 0, 57, 36, 0, DateTimeKind.Unspecified), 7700.6866309391316, 756.94429783466774, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 379, new DateTime(2022, 1, 16, 3, 50, 24, 0, DateTimeKind.Unspecified), 4559.9210156675726, 16387.587543821737, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 382, new DateTime(2022, 1, 16, 6, 43, 12, 0, DateTimeKind.Unspecified), 4448.1171053595299, 6837.9426766906599, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 385, new DateTime(2022, 1, 16, 9, 36, 0, 0, DateTimeKind.Unspecified), 4318.3264719950721, 13945.439930541186, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 388, new DateTime(2022, 1, 16, 12, 28, 48, 0, DateTimeKind.Unspecified), 6675.8373892898235, 18047.924399755513, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 391, new DateTime(2022, 1, 16, 15, 21, 36, 0, DateTimeKind.Unspecified), 8234.4321172969685, 4107.2260510922624, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 394, new DateTime(2022, 1, 16, 18, 14, 24, 0, DateTimeKind.Unspecified), 1718.0097146124053, 14115.879855709054, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 397, new DateTime(2022, 1, 16, 21, 7, 12, 0, DateTimeKind.Unspecified), 7811.0893191077475, 10749.471604619839, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 400, new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6484.9570545465776, 5029.3315076427043, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 403, new DateTime(2022, 1, 17, 2, 52, 48, 0, DateTimeKind.Unspecified), 3527.316339243293, 4179.7771026956852, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 370, new DateTime(2022, 1, 15, 19, 12, 0, 0, DateTimeKind.Unspecified), 5584.1767523085018, 16439.856804008909, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 331, new DateTime(2022, 1, 14, 5, 45, 36, 0, DateTimeKind.Unspecified), 8157.3501396487691, 7118.3554123210552, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 490, new DateTime(2022, 1, 20, 14, 24, 0, 0, DateTimeKind.Unspecified), 212.95079715928068, 14835.349263914632, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 496, new DateTime(2022, 1, 20, 20, 9, 36, 0, DateTimeKind.Unspecified), 5828.288806400541, 16140.000763302482, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 583, new DateTime(2022, 1, 24, 7, 40, 48, 0, DateTimeKind.Unspecified), 5254.225305136918, 8884.4018758990042, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 586, new DateTime(2022, 1, 24, 10, 33, 36, 0, DateTimeKind.Unspecified), 2179.2244647967409, 8871.2974755441901, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 589, new DateTime(2022, 1, 24, 13, 26, 24, 0, DateTimeKind.Unspecified), 999.48263238069626, 701.62406005402977, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 592, new DateTime(2022, 1, 24, 16, 19, 12, 0, DateTimeKind.Unspecified), 4051.8639699398827, 4984.6430345947128, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 595, new DateTime(2022, 1, 24, 19, 12, 0, 0, DateTimeKind.Unspecified), 5992.3129982686041, 5043.660146856274, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 598, new DateTime(2022, 1, 24, 22, 4, 48, 0, DateTimeKind.Unspecified), 1704.5750687697421, 4583.2531720754423, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 601, new DateTime(2022, 1, 25, 0, 57, 36, 0, DateTimeKind.Unspecified), 6117.414585988924, 11611.313319202569, "24391000-0a63-4bb1-971f-7611dd87d9f6" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 604, new DateTime(2022, 1, 25, 3, 50, 24, 0, DateTimeKind.Unspecified), 7517.0092622295415, 15919.461675521943, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 607, new DateTime(2022, 1, 25, 6, 43, 12, 0, DateTimeKind.Unspecified), 6163.2960681463146, 11533.874806321843, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 610, new DateTime(2022, 1, 25, 9, 36, 0, 0, DateTimeKind.Unspecified), 3710.0498273326575, 10550.170512899042, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 613, new DateTime(2022, 1, 25, 12, 28, 48, 0, DateTimeKind.Unspecified), 7849.1530636418856, 19227.333929455359, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 616, new DateTime(2022, 1, 25, 15, 21, 36, 0, DateTimeKind.Unspecified), 6553.3211988337871, 19274.59462315026, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 619, new DateTime(2022, 1, 25, 18, 14, 24, 0, DateTimeKind.Unspecified), 4454.022088764229, 1106.9530446733743, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 622, new DateTime(2022, 1, 25, 21, 7, 12, 0, DateTimeKind.Unspecified), 1165.7064756571594, 11896.542775520073, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 625, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2413.9064956220313, 17566.307848425917, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 628, new DateTime(2022, 1, 26, 2, 52, 48, 0, DateTimeKind.Unspecified), 4570.2627661603483, 3740.5407398959592, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 631, new DateTime(2022, 1, 26, 5, 45, 36, 0, DateTimeKind.Unspecified), 9056.7094013035839, 4156.1000394564453, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 634, new DateTime(2022, 1, 26, 8, 38, 24, 0, DateTimeKind.Unspecified), 8885.5088289940486, 2924.3378411865069, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 637, new DateTime(2022, 1, 26, 11, 31, 12, 0, DateTimeKind.Unspecified), 3937.7870955955827, 8541.1895668507295, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 640, new DateTime(2022, 1, 26, 14, 24, 0, 0, DateTimeKind.Unspecified), 9866.3174685321719, 11104.896332789394, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 643, new DateTime(2022, 1, 26, 17, 16, 48, 0, DateTimeKind.Unspecified), 6393.9005984514879, 17401.989550263348, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 646, new DateTime(2022, 1, 26, 20, 9, 36, 0, DateTimeKind.Unspecified), 4107.1166054117984, 17311.731979724093, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 649, new DateTime(2022, 1, 26, 23, 2, 24, 0, DateTimeKind.Unspecified), 6954.7217380902412, 18195.396643725187, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 580, new DateTime(2022, 1, 24, 4, 48, 0, 0, DateTimeKind.Unspecified), 5594.5668502819099, 17136.354849288789, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 577, new DateTime(2022, 1, 24, 1, 55, 12, 0, DateTimeKind.Unspecified), 4059.8058060961353, 2614.7495423257465, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 574, new DateTime(2022, 1, 23, 23, 2, 24, 0, DateTimeKind.Unspecified), 9786.8181170061616, 1004.3013138175547, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 571, new DateTime(2022, 1, 23, 20, 9, 36, 0, DateTimeKind.Unspecified), 8749.7411299591531, 12464.174596333662, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 499, new DateTime(2022, 1, 20, 23, 2, 24, 0, DateTimeKind.Unspecified), 5998.3335003401562, 12706.5872833838, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 502, new DateTime(2022, 1, 21, 1, 55, 12, 0, DateTimeKind.Unspecified), 5871.8422186589742, 8800.255528715601, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 505, new DateTime(2022, 1, 21, 4, 48, 0, 0, DateTimeKind.Unspecified), 7388.555348251859, 6134.1314308038518, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 508, new DateTime(2022, 1, 21, 7, 40, 48, 0, DateTimeKind.Unspecified), 6765.1325440178862, 12326.638189214449, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 511, new DateTime(2022, 1, 21, 10, 33, 36, 0, DateTimeKind.Unspecified), 2932.7712347138076, 11137.327209549749, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 514, new DateTime(2022, 1, 21, 13, 26, 24, 0, DateTimeKind.Unspecified), 601.17518165770798, 9091.1356127897179, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 517, new DateTime(2022, 1, 21, 16, 19, 12, 0, DateTimeKind.Unspecified), 2110.3493024378822, 1263.3141175694066, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 520, new DateTime(2022, 1, 21, 19, 12, 0, 0, DateTimeKind.Unspecified), 8389.1969044572179, 14913.13299618533, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 523, new DateTime(2022, 1, 21, 22, 4, 48, 0, DateTimeKind.Unspecified), 7857.1148770354239, 120.36057043123682, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 526, new DateTime(2022, 1, 22, 0, 57, 36, 0, DateTimeKind.Unspecified), 6258.8152631683142, 194.37007987634263, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 529, new DateTime(2022, 1, 22, 3, 50, 24, 0, DateTimeKind.Unspecified), 6495.1029899967143, 121.9638669681564, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 493, new DateTime(2022, 1, 20, 17, 16, 48, 0, DateTimeKind.Unspecified), 8719.3346139754158, 4133.5511953875575, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 532, new DateTime(2022, 1, 22, 6, 43, 12, 0, DateTimeKind.Unspecified), 2631.3127093138, 16599.966320695719, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 538, new DateTime(2022, 1, 22, 12, 28, 48, 0, DateTimeKind.Unspecified), 5245.8967021296876, 14353.512766157888, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 541, new DateTime(2022, 1, 22, 15, 21, 36, 0, DateTimeKind.Unspecified), 6124.1430450140178, 6898.487877506017, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 544, new DateTime(2022, 1, 22, 18, 14, 24, 0, DateTimeKind.Unspecified), 7987.2170899241082, 1998.0752186610612, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 547, new DateTime(2022, 1, 22, 21, 7, 12, 0, DateTimeKind.Unspecified), 5719.6558978533285, 483.408980285533, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 550, new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7034.6665107052031, 10505.641852267609, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 553, new DateTime(2022, 1, 23, 2, 52, 48, 0, DateTimeKind.Unspecified), 2379.4222041779226, 19147.781961277436, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 556, new DateTime(2022, 1, 23, 5, 45, 36, 0, DateTimeKind.Unspecified), 671.24347928715042, 6172.0875991042467, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 559, new DateTime(2022, 1, 23, 8, 38, 24, 0, DateTimeKind.Unspecified), 3727.2066305533654, 9079.2698295971277, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 562, new DateTime(2022, 1, 23, 11, 31, 12, 0, DateTimeKind.Unspecified), 1188.802669310707, 10725.094402314757, "24391000-0a63-4bb1-971f-7611dd87d9f6" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 565, new DateTime(2022, 1, 23, 14, 24, 0, 0, DateTimeKind.Unspecified), 5612.7121011283862, 8543.2531945411811, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 568, new DateTime(2022, 1, 23, 17, 16, 48, 0, DateTimeKind.Unspecified), 1271.7634764055381, 19485.273957702662, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 535, new DateTime(2022, 1, 22, 9, 36, 0, 0, DateTimeKind.Unspecified), 8670.0122604653279, 12335.128456223969, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 652, new DateTime(2022, 1, 27, 1, 55, 12, 0, DateTimeKind.Unspecified), 5132.4152610360543, 12310.813058640082, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 328, new DateTime(2022, 1, 14, 2, 52, 48, 0, DateTimeKind.Unspecified), 4042.1644144649122, 10252.027422187246, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 322, new DateTime(2022, 1, 13, 21, 7, 12, 0, DateTimeKind.Unspecified), 7365.3702612256657, 12213.926353555813, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 88, new DateTime(2022, 1, 4, 12, 28, 48, 0, DateTimeKind.Unspecified), 6415.703630998255, 718.18284323074101, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 91, new DateTime(2022, 1, 4, 15, 21, 36, 0, DateTimeKind.Unspecified), 2316.8287962681361, 9000.3049751724884, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 94, new DateTime(2022, 1, 4, 18, 14, 24, 0, DateTimeKind.Unspecified), 9164.2815476013602, 17772.010875920525, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 97, new DateTime(2022, 1, 4, 21, 7, 12, 0, DateTimeKind.Unspecified), 5004.391972297065, 3565.39670612801, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 100, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 557.76597967764769, 11044.538474109075, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 103, new DateTime(2022, 1, 5, 2, 52, 48, 0, DateTimeKind.Unspecified), 5039.2739447571303, 19436.321561756773, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 106, new DateTime(2022, 1, 5, 5, 45, 36, 0, DateTimeKind.Unspecified), 289.33461422814128, 16875.965168054874, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 109, new DateTime(2022, 1, 5, 8, 38, 24, 0, DateTimeKind.Unspecified), 2133.2800695633737, 19620.157003552726, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 112, new DateTime(2022, 1, 5, 11, 31, 12, 0, DateTimeKind.Unspecified), 3186.4397344222721, 18729.953442616745, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 115, new DateTime(2022, 1, 5, 14, 24, 0, 0, DateTimeKind.Unspecified), 4150.1640610780769, 15089.821307220674, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 118, new DateTime(2022, 1, 5, 17, 16, 48, 0, DateTimeKind.Unspecified), 736.3680631672338, 9640.3578477218689, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 121, new DateTime(2022, 1, 5, 20, 9, 36, 0, DateTimeKind.Unspecified), 6605.5024309017572, 14929.734507399937, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 124, new DateTime(2022, 1, 5, 23, 2, 24, 0, DateTimeKind.Unspecified), 8485.9584681366141, 4255.2284306940373, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 127, new DateTime(2022, 1, 6, 1, 55, 12, 0, DateTimeKind.Unspecified), 3143.4476011368774, 8863.2976048376859, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 130, new DateTime(2022, 1, 6, 4, 48, 0, 0, DateTimeKind.Unspecified), 796.4275412424704, 7912.3001432996325, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 133, new DateTime(2022, 1, 6, 7, 40, 48, 0, DateTimeKind.Unspecified), 5092.8022316854704, 2390.009035836063, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 136, new DateTime(2022, 1, 6, 10, 33, 36, 0, DateTimeKind.Unspecified), 9350.3719865098483, 16997.455571331011, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 139, new DateTime(2022, 1, 6, 13, 26, 24, 0, DateTimeKind.Unspecified), 9804.2072068187736, 12804.96091250998, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 142, new DateTime(2022, 1, 6, 16, 19, 12, 0, DateTimeKind.Unspecified), 5652.8053569165777, 8469.9718093313513, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 145, new DateTime(2022, 1, 6, 19, 12, 0, 0, DateTimeKind.Unspecified), 585.5508560365256, 1254.2129802049551, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 148, new DateTime(2022, 1, 6, 22, 4, 48, 0, DateTimeKind.Unspecified), 4885.3271179407084, 15590.021496508927, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 151, new DateTime(2022, 1, 7, 0, 57, 36, 0, DateTimeKind.Unspecified), 1610.5363960525469, 4113.928020405845, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 154, new DateTime(2022, 1, 7, 3, 50, 24, 0, DateTimeKind.Unspecified), 558.94192065426614, 2661.8513212314647, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 85, new DateTime(2022, 1, 4, 9, 36, 0, 0, DateTimeKind.Unspecified), 5825.9612664834913, 1923.0160460457357, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 82, new DateTime(2022, 1, 4, 6, 43, 12, 0, DateTimeKind.Unspecified), 8042.0117388400404, 18947.337227354121, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 79, new DateTime(2022, 1, 4, 3, 50, 24, 0, DateTimeKind.Unspecified), 1953.755715997328, 2596.4397771589402, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 76, new DateTime(2022, 1, 4, 0, 57, 36, 0, DateTimeKind.Unspecified), 7506.4095948621252, 4395.0583724161261, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 4, new DateTime(2022, 1, 1, 3, 50, 24, 0, DateTimeKind.Unspecified), 3096.0341353785766, 11327.470865626567, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 7, new DateTime(2022, 1, 1, 6, 43, 12, 0, DateTimeKind.Unspecified), 4571.0891068731926, 4245.5821411646839, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 10, new DateTime(2022, 1, 1, 9, 36, 0, 0, DateTimeKind.Unspecified), 3787.1349180861898, 12987.029012566025, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 13, new DateTime(2022, 1, 1, 12, 28, 48, 0, DateTimeKind.Unspecified), 9096.8874445411384, 10866.761110537913, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 16, new DateTime(2022, 1, 1, 15, 21, 36, 0, DateTimeKind.Unspecified), 470.49206855833717, 11920.445292111515, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 19, new DateTime(2022, 1, 1, 18, 14, 24, 0, DateTimeKind.Unspecified), 3095.7833806489934, 18457.064297248871, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 22, new DateTime(2022, 1, 1, 21, 7, 12, 0, DateTimeKind.Unspecified), 3353.2287632184575, 2530.3081014047602, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 25, new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4703.1436902996766, 12210.94258031044, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 28, new DateTime(2022, 1, 2, 2, 52, 48, 0, DateTimeKind.Unspecified), 8717.4390860912008, 12618.411892902368, "24391000-0a63-4bb1-971f-7611dd87d9f6" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 31, new DateTime(2022, 1, 2, 5, 45, 36, 0, DateTimeKind.Unspecified), 3123.0970748557033, 14060.133882145585, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 34, new DateTime(2022, 1, 2, 8, 38, 24, 0, DateTimeKind.Unspecified), 7747.9430033823992, 16703.778176195301, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 157, new DateTime(2022, 1, 7, 6, 43, 12, 0, DateTimeKind.Unspecified), 3749.856257233761, 15782.300430706851, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 37, new DateTime(2022, 1, 2, 11, 31, 12, 0, DateTimeKind.Unspecified), 7959.7573041549776, 19024.331186162544, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 43, new DateTime(2022, 1, 2, 17, 16, 48, 0, DateTimeKind.Unspecified), 4438.0465380008654, 13657.420966345295, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 46, new DateTime(2022, 1, 2, 20, 9, 36, 0, DateTimeKind.Unspecified), 3559.4887043128419, 10111.185895936178, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 49, new DateTime(2022, 1, 2, 23, 2, 24, 0, DateTimeKind.Unspecified), 3777.6472711652295, 19680.976008499725, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 52, new DateTime(2022, 1, 3, 1, 55, 12, 0, DateTimeKind.Unspecified), 6204.4375320888093, 4335.8466965163934, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 55, new DateTime(2022, 1, 3, 4, 48, 0, 0, DateTimeKind.Unspecified), 9167.807631865513, 10620.121862166296, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 58, new DateTime(2022, 1, 3, 7, 40, 48, 0, DateTimeKind.Unspecified), 6382.8722770644281, 18298.018985231694, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 61, new DateTime(2022, 1, 3, 10, 33, 36, 0, DateTimeKind.Unspecified), 3300.1788619733898, 4844.4310464465971, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 64, new DateTime(2022, 1, 3, 13, 26, 24, 0, DateTimeKind.Unspecified), 9879.658354766003, 12077.354083611599, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 67, new DateTime(2022, 1, 3, 16, 19, 12, 0, DateTimeKind.Unspecified), 2390.8707931349009, 9417.4616142329432, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 70, new DateTime(2022, 1, 3, 19, 12, 0, 0, DateTimeKind.Unspecified), 3563.0292989851405, 4475.8734610727588, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 73, new DateTime(2022, 1, 3, 22, 4, 48, 0, DateTimeKind.Unspecified), 2725.9020104021988, 296.92914097275548, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 40, new DateTime(2022, 1, 2, 14, 24, 0, 0, DateTimeKind.Unspecified), 9093.4961079924597, 6121.1773758582422, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 325, new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9776.3511866443259, 19229.386196196239, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 160, new DateTime(2022, 1, 7, 9, 36, 0, 0, DateTimeKind.Unspecified), 6821.0103177383826, 18780.725934138944, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 166, new DateTime(2022, 1, 7, 15, 21, 36, 0, DateTimeKind.Unspecified), 7173.7945819222032, 19888.890214911946, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 253, new DateTime(2022, 1, 11, 2, 52, 48, 0, DateTimeKind.Unspecified), 6239.8826081632333, 18374.057823460815, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 256, new DateTime(2022, 1, 11, 5, 45, 36, 0, DateTimeKind.Unspecified), 3184.4142572568785, 15472.934811166777, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 259, new DateTime(2022, 1, 11, 8, 38, 24, 0, DateTimeKind.Unspecified), 2909.1435738201285, 11944.705184236365, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 262, new DateTime(2022, 1, 11, 11, 31, 12, 0, DateTimeKind.Unspecified), 5663.9678083634462, 16548.670571846516, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 265, new DateTime(2022, 1, 11, 14, 24, 0, 0, DateTimeKind.Unspecified), 500.7639469008484, 11759.871979849679, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 268, new DateTime(2022, 1, 11, 17, 16, 48, 0, DateTimeKind.Unspecified), 3125.0677514734075, 12568.12239934151, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 271, new DateTime(2022, 1, 11, 20, 9, 36, 0, DateTimeKind.Unspecified), 2275.3289394175599, 12215.797947876286, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 274, new DateTime(2022, 1, 11, 23, 2, 24, 0, DateTimeKind.Unspecified), 2506.1792662595676, 1996.618771707309, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 277, new DateTime(2022, 1, 12, 1, 55, 12, 0, DateTimeKind.Unspecified), 1396.4720561014924, 7824.8470795035118, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 280, new DateTime(2022, 1, 12, 4, 48, 0, 0, DateTimeKind.Unspecified), 8607.75615152723, 17011.369964652797, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 283, new DateTime(2022, 1, 12, 7, 40, 48, 0, DateTimeKind.Unspecified), 5550.8021231671401, 8802.3401784951584, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 286, new DateTime(2022, 1, 12, 10, 33, 36, 0, DateTimeKind.Unspecified), 5986.1317293382699, 5709.1604639774869, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 289, new DateTime(2022, 1, 12, 13, 26, 24, 0, DateTimeKind.Unspecified), 8999.4926851216842, 5312.7672083575953, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 292, new DateTime(2022, 1, 12, 16, 19, 12, 0, DateTimeKind.Unspecified), 2641.1816562847957, 3810.969208706189, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 295, new DateTime(2022, 1, 12, 19, 12, 0, 0, DateTimeKind.Unspecified), 1050.8960696104268, 19471.782074907482, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 298, new DateTime(2022, 1, 12, 22, 4, 48, 0, DateTimeKind.Unspecified), 2516.7219305773501, 15101.302149124991, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 301, new DateTime(2022, 1, 13, 0, 57, 36, 0, DateTimeKind.Unspecified), 3308.2841090430143, 10284.146358734972, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 304, new DateTime(2022, 1, 13, 3, 50, 24, 0, DateTimeKind.Unspecified), 3711.0120171095127, 16904.463162489476, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 307, new DateTime(2022, 1, 13, 6, 43, 12, 0, DateTimeKind.Unspecified), 5149.6836144147328, 9476.4998547327614, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 310, new DateTime(2022, 1, 13, 9, 36, 0, 0, DateTimeKind.Unspecified), 7802.2301994674071, 5440.6230242483798, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 313, new DateTime(2022, 1, 13, 12, 28, 48, 0, DateTimeKind.Unspecified), 355.05418730205815, 1374.7371944602355, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 316, new DateTime(2022, 1, 13, 15, 21, 36, 0, DateTimeKind.Unspecified), 5671.9363320236207, 19167.43732640208, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 319, new DateTime(2022, 1, 13, 18, 14, 24, 0, DateTimeKind.Unspecified), 5301.4593816490269, 8814.9112223383054, "24391000-0a63-4bb1-971f-7611dd87d9f6" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 250, new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4918.1586268782303, 5165.5733724394095, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 247, new DateTime(2022, 1, 10, 21, 7, 12, 0, DateTimeKind.Unspecified), 6503.4787381938158, 1207.6938215826717, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 244, new DateTime(2022, 1, 10, 18, 14, 24, 0, DateTimeKind.Unspecified), 1810.8267253178403, 9529.7368448440811, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 241, new DateTime(2022, 1, 10, 15, 21, 36, 0, DateTimeKind.Unspecified), 508.71199105077585, 7354.8451562127821, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 169, new DateTime(2022, 1, 7, 18, 14, 24, 0, DateTimeKind.Unspecified), 3942.2478875563947, 18146.984133851194, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 172, new DateTime(2022, 1, 7, 21, 7, 12, 0, DateTimeKind.Unspecified), 985.97869350436622, 15224.88286277573, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 175, new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4043.3127312808115, 14339.583837685957, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 178, new DateTime(2022, 1, 8, 2, 52, 48, 0, DateTimeKind.Unspecified), 6465.7026028675364, 902.01328743703277, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 181, new DateTime(2022, 1, 8, 5, 45, 36, 0, DateTimeKind.Unspecified), 963.78780712185994, 919.18544035004732, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 184, new DateTime(2022, 1, 8, 8, 38, 24, 0, DateTimeKind.Unspecified), 8809.2576861486341, 19869.596269743841, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 187, new DateTime(2022, 1, 8, 11, 31, 12, 0, DateTimeKind.Unspecified), 5960.8884724852933, 17365.440252964749, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 190, new DateTime(2022, 1, 8, 14, 24, 0, 0, DateTimeKind.Unspecified), 507.37998787056392, 10913.136960880773, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 193, new DateTime(2022, 1, 8, 17, 16, 48, 0, DateTimeKind.Unspecified), 535.0025407714146, 15508.732041107858, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 196, new DateTime(2022, 1, 8, 20, 9, 36, 0, DateTimeKind.Unspecified), 2773.2198635252885, 11630.531420616138, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 199, new DateTime(2022, 1, 8, 23, 2, 24, 0, DateTimeKind.Unspecified), 8678.0665745699844, 9961.3522785553723, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 163, new DateTime(2022, 1, 7, 12, 28, 48, 0, DateTimeKind.Unspecified), 4048.3028124724183, 10663.426601251838, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 202, new DateTime(2022, 1, 9, 1, 55, 12, 0, DateTimeKind.Unspecified), 4421.1117290438051, 3655.5125525587509, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 208, new DateTime(2022, 1, 9, 7, 40, 48, 0, DateTimeKind.Unspecified), 4038.7934617614565, 16642.837373177819, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 211, new DateTime(2022, 1, 9, 10, 33, 36, 0, DateTimeKind.Unspecified), 6218.0236779404986, 13439.202959538063, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 214, new DateTime(2022, 1, 9, 13, 26, 24, 0, DateTimeKind.Unspecified), 3157.9622860368686, 5155.9782030419137, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 217, new DateTime(2022, 1, 9, 16, 19, 12, 0, DateTimeKind.Unspecified), 6257.772863244636, 2397.7386960582912, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 220, new DateTime(2022, 1, 9, 19, 12, 0, 0, DateTimeKind.Unspecified), 6021.7396288751434, 17052.210769699159, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 223, new DateTime(2022, 1, 9, 22, 4, 48, 0, DateTimeKind.Unspecified), 4207.5297503389411, 1627.9634821400784, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 226, new DateTime(2022, 1, 10, 0, 57, 36, 0, DateTimeKind.Unspecified), 7681.5196425518297, 13900.314522557177, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 229, new DateTime(2022, 1, 10, 3, 50, 24, 0, DateTimeKind.Unspecified), 4140.3024035959716, 15737.243957329323, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 232, new DateTime(2022, 1, 10, 6, 43, 12, 0, DateTimeKind.Unspecified), 9449.5003494251596, 16605.81925221745, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 235, new DateTime(2022, 1, 10, 9, 36, 0, 0, DateTimeKind.Unspecified), 5926.8687775199705, 15944.476025216785, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 238, new DateTime(2022, 1, 10, 12, 28, 48, 0, DateTimeKind.Unspecified), 7013.646745388427, 18663.484338692815, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 205, new DateTime(2022, 1, 9, 4, 48, 0, 0, DateTimeKind.Unspecified), 3394.4770942960613, 7291.3553887588669, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 440, new DateTime(2022, 1, 18, 14, 24, 0, 0, DateTimeKind.Unspecified), 875.65989343704109, 9105.8047331157941, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 655, new DateTime(2022, 1, 27, 4, 48, 0, 0, DateTimeKind.Unspecified), 6813.2673300487513, 6066.9307265236848, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 661, new DateTime(2022, 1, 27, 10, 33, 36, 0, DateTimeKind.Unspecified), 1819.8317816515603, 179.10194838122601, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 203, new DateTime(2022, 1, 9, 2, 52, 48, 0, DateTimeKind.Unspecified), 3411.3878571260311, 3807.0958228618606, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 206, new DateTime(2022, 1, 9, 5, 45, 36, 0, DateTimeKind.Unspecified), 2225.7777872634424, 9291.7238378393395, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 209, new DateTime(2022, 1, 9, 8, 38, 24, 0, DateTimeKind.Unspecified), 9020.5401936099697, 15130.973149158526, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 212, new DateTime(2022, 1, 9, 11, 31, 12, 0, DateTimeKind.Unspecified), 4346.3829605288638, 5670.9992334234385, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 215, new DateTime(2022, 1, 9, 14, 24, 0, 0, DateTimeKind.Unspecified), 633.84349018765909, 17992.214588540337, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 218, new DateTime(2022, 1, 9, 17, 16, 48, 0, DateTimeKind.Unspecified), 5801.180877136494, 3160.8323016350732, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 221, new DateTime(2022, 1, 9, 20, 9, 36, 0, DateTimeKind.Unspecified), 7233.4560709984344, 6515.0874459395618, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 224, new DateTime(2022, 1, 9, 23, 2, 24, 0, DateTimeKind.Unspecified), 5615.2888901121869, 19654.951297180603, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 227, new DateTime(2022, 1, 10, 1, 55, 12, 0, DateTimeKind.Unspecified), 5349.7339573701229, 7413.2191354440247, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 230, new DateTime(2022, 1, 10, 4, 48, 0, 0, DateTimeKind.Unspecified), 4373.7082970508172, 5662.7355279903277, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 233, new DateTime(2022, 1, 10, 7, 40, 48, 0, DateTimeKind.Unspecified), 9271.1826474366462, 4333.2672101682419, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 236, new DateTime(2022, 1, 10, 10, 33, 36, 0, DateTimeKind.Unspecified), 3148.946425790532, 2301.5551767513116, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 239, new DateTime(2022, 1, 10, 13, 26, 24, 0, DateTimeKind.Unspecified), 7897.9960320778082, 5605.0623977937803, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 242, new DateTime(2022, 1, 10, 16, 19, 12, 0, DateTimeKind.Unspecified), 6416.9167855546566, 10683.743677930599, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 245, new DateTime(2022, 1, 10, 19, 12, 0, 0, DateTimeKind.Unspecified), 4468.5131058238339, 18882.251873324331, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 248, new DateTime(2022, 1, 10, 22, 4, 48, 0, DateTimeKind.Unspecified), 5121.3937900864794, 3395.4536467752223, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 251, new DateTime(2022, 1, 11, 0, 57, 36, 0, DateTimeKind.Unspecified), 671.93193783478046, 11915.474580267864, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 254, new DateTime(2022, 1, 11, 3, 50, 24, 0, DateTimeKind.Unspecified), 9887.9268510720194, 2342.5161118979167, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 257, new DateTime(2022, 1, 11, 6, 43, 12, 0, DateTimeKind.Unspecified), 1935.6387511266564, 15084.847141587907, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 260, new DateTime(2022, 1, 11, 9, 36, 0, 0, DateTimeKind.Unspecified), 8466.8885437853041, 10968.328289464316, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 263, new DateTime(2022, 1, 11, 12, 28, 48, 0, DateTimeKind.Unspecified), 8032.9293569959127, 9649.7501679279158, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 266, new DateTime(2022, 1, 11, 15, 21, 36, 0, DateTimeKind.Unspecified), 793.76876378482905, 6033.7365745916495, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 269, new DateTime(2022, 1, 11, 18, 14, 24, 0, DateTimeKind.Unspecified), 2660.8658680455237, 17388.014816956595, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 200, new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 8775.3559966921384, 10562.548730816281, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 197, new DateTime(2022, 1, 8, 21, 7, 12, 0, DateTimeKind.Unspecified), 9755.0626924503613, 7209.357261268563, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 194, new DateTime(2022, 1, 8, 18, 14, 24, 0, DateTimeKind.Unspecified), 6826.6208337932476, 7457.8251699238299, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 191, new DateTime(2022, 1, 8, 15, 21, 36, 0, DateTimeKind.Unspecified), 8822.2615257737107, 17968.944250137734, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 119, new DateTime(2022, 1, 5, 18, 14, 24, 0, DateTimeKind.Unspecified), 1508.2592492851456, 11429.649960290533, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 122, new DateTime(2022, 1, 5, 21, 7, 12, 0, DateTimeKind.Unspecified), 8719.5434920470907, 7674.8170128302263, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 125, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 9788.0997293707132, 9059.3659568439434, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 128, new DateTime(2022, 1, 6, 2, 52, 48, 0, DateTimeKind.Unspecified), 9117.4481213809649, 8919.8847859176567, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 131, new DateTime(2022, 1, 6, 5, 45, 36, 0, DateTimeKind.Unspecified), 5118.0105828424257, 2328.8306524949994, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 134, new DateTime(2022, 1, 6, 8, 38, 24, 0, DateTimeKind.Unspecified), 1375.7845353128641, 13686.147593027175, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 137, new DateTime(2022, 1, 6, 11, 31, 12, 0, DateTimeKind.Unspecified), 1405.9282657679942, 17839.886833055083, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 140, new DateTime(2022, 1, 6, 14, 24, 0, 0, DateTimeKind.Unspecified), 7828.8303610777311, 10110.857587631657, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 143, new DateTime(2022, 1, 6, 17, 16, 48, 0, DateTimeKind.Unspecified), 2608.0592397261116, 7519.3516591721218, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 146, new DateTime(2022, 1, 6, 20, 9, 36, 0, DateTimeKind.Unspecified), 5204.0040341012636, 19704.669921176948, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 149, new DateTime(2022, 1, 6, 23, 2, 24, 0, DateTimeKind.Unspecified), 1648.1441962285483, 10778.992755451258, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 272, new DateTime(2022, 1, 11, 21, 7, 12, 0, DateTimeKind.Unspecified), 588.2663922467566, 14313.452212803635, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 152, new DateTime(2022, 1, 7, 1, 55, 12, 0, DateTimeKind.Unspecified), 1029.8780150523507, 10414.220379880162, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 158, new DateTime(2022, 1, 7, 7, 40, 48, 0, DateTimeKind.Unspecified), 2323.1639079706133, 19336.732804206698, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 161, new DateTime(2022, 1, 7, 10, 33, 36, 0, DateTimeKind.Unspecified), 3560.6113156662427, 16141.459797489064, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 164, new DateTime(2022, 1, 7, 13, 26, 24, 0, DateTimeKind.Unspecified), 1383.3500167608697, 16059.367878928544, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 167, new DateTime(2022, 1, 7, 16, 19, 12, 0, DateTimeKind.Unspecified), 4121.7413343892222, 13611.498502440149, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 170, new DateTime(2022, 1, 7, 19, 12, 0, 0, DateTimeKind.Unspecified), 8495.5504439608358, 11320.555911947444, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 173, new DateTime(2022, 1, 7, 22, 4, 48, 0, DateTimeKind.Unspecified), 8353.2686830241346, 16943.183961066796, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 176, new DateTime(2022, 1, 8, 0, 57, 36, 0, DateTimeKind.Unspecified), 4224.5964133018078, 14892.306968617677, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 179, new DateTime(2022, 1, 8, 3, 50, 24, 0, DateTimeKind.Unspecified), 7658.2280957304401, 5584.9791387695986, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 182, new DateTime(2022, 1, 8, 6, 43, 12, 0, DateTimeKind.Unspecified), 2446.3699537784833, 4520.839552353742, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 185, new DateTime(2022, 1, 8, 9, 36, 0, 0, DateTimeKind.Unspecified), 7263.4071303700357, 7233.5508247120024, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 188, new DateTime(2022, 1, 8, 12, 28, 48, 0, DateTimeKind.Unspecified), 9127.4551869811148, 529.31895678659828, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 155, new DateTime(2022, 1, 7, 4, 48, 0, 0, DateTimeKind.Unspecified), 3292.6280260860794, 18093.433563567727, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 116, new DateTime(2022, 1, 5, 15, 21, 36, 0, DateTimeKind.Unspecified), 4591.3797599707059, 1410.1170158113673, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 275, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2786.573094661996, 5996.6756874610555, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 281, new DateTime(2022, 1, 12, 5, 45, 36, 0, DateTimeKind.Unspecified), 5664.2725911270445, 14411.119974796884, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 368, new DateTime(2022, 1, 15, 17, 16, 48, 0, DateTimeKind.Unspecified), 3731.253550659188, 17177.280580806168, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 371, new DateTime(2022, 1, 15, 20, 9, 36, 0, DateTimeKind.Unspecified), 7903.9543420466516, 3623.8422537988099, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 374, new DateTime(2022, 1, 15, 23, 2, 24, 0, DateTimeKind.Unspecified), 1224.1182762462122, 4804.5073298414991, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 377, new DateTime(2022, 1, 16, 1, 55, 12, 0, DateTimeKind.Unspecified), 6882.8545733913488, 12606.308536906936, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 380, new DateTime(2022, 1, 16, 4, 48, 0, 0, DateTimeKind.Unspecified), 6680.7347623350306, 19620.149834932818, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 383, new DateTime(2022, 1, 16, 7, 40, 48, 0, DateTimeKind.Unspecified), 5698.1333857082072, 16881.290027450443, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 386, new DateTime(2022, 1, 16, 10, 33, 36, 0, DateTimeKind.Unspecified), 7325.6140281187481, 12952.486114995294, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 389, new DateTime(2022, 1, 16, 13, 26, 24, 0, DateTimeKind.Unspecified), 8997.1279464287418, 12102.069001339662, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 392, new DateTime(2022, 1, 16, 16, 19, 12, 0, DateTimeKind.Unspecified), 9896.4651862562532, 9005.2983997108113, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 395, new DateTime(2022, 1, 16, 19, 12, 0, 0, DateTimeKind.Unspecified), 6965.2898912485134, 16898.800380640139, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 398, new DateTime(2022, 1, 16, 22, 4, 48, 0, DateTimeKind.Unspecified), 3738.8845466753583, 6275.6477860844552, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 401, new DateTime(2022, 1, 17, 0, 57, 36, 0, DateTimeKind.Unspecified), 9786.1609933556992, 3353.1207817607533, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 404, new DateTime(2022, 1, 17, 3, 50, 24, 0, DateTimeKind.Unspecified), 1289.2569912819529, 19661.243186823125, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 407, new DateTime(2022, 1, 17, 6, 43, 12, 0, DateTimeKind.Unspecified), 4723.9387624831452, 19127.699199182603, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 410, new DateTime(2022, 1, 17, 9, 36, 0, 0, DateTimeKind.Unspecified), 2362.8240310622932, 5245.1234436242676, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 413, new DateTime(2022, 1, 17, 12, 28, 48, 0, DateTimeKind.Unspecified), 7055.7109447267449, 776.01464804191892, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 416, new DateTime(2022, 1, 17, 15, 21, 36, 0, DateTimeKind.Unspecified), 9286.5653899202844, 12509.021427966285, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 419, new DateTime(2022, 1, 17, 18, 14, 24, 0, DateTimeKind.Unspecified), 1208.9086102166516, 4113.4698510978924, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 422, new DateTime(2022, 1, 17, 21, 7, 12, 0, DateTimeKind.Unspecified), 7893.4185307352318, 9407.9341650594361, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 425, new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7068.0309938323699, 15714.770492930895, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 428, new DateTime(2022, 1, 18, 2, 52, 48, 0, DateTimeKind.Unspecified), 4407.2144193652302, 2050.0217318781447, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 431, new DateTime(2022, 1, 18, 5, 45, 36, 0, DateTimeKind.Unspecified), 6858.296641398395, 12179.054173365175, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 434, new DateTime(2022, 1, 18, 8, 38, 24, 0, DateTimeKind.Unspecified), 3272.1681277868138, 9569.0023310180677, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 365, new DateTime(2022, 1, 15, 14, 24, 0, 0, DateTimeKind.Unspecified), 1812.8026794802606, 16670.591758497161, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 362, new DateTime(2022, 1, 15, 11, 31, 12, 0, DateTimeKind.Unspecified), 1753.2185576520012, 3708.4321744347831, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 359, new DateTime(2022, 1, 15, 8, 38, 24, 0, DateTimeKind.Unspecified), 8252.6077815259341, 9903.4876380784135, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 356, new DateTime(2022, 1, 15, 5, 45, 36, 0, DateTimeKind.Unspecified), 6961.1442518577451, 5467.1193810814702, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 284, new DateTime(2022, 1, 12, 8, 38, 24, 0, DateTimeKind.Unspecified), 1789.4087116131345, 13533.696301450198, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 287, new DateTime(2022, 1, 12, 11, 31, 12, 0, DateTimeKind.Unspecified), 2730.3239644623918, 5439.1205922388017, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 290, new DateTime(2022, 1, 12, 14, 24, 0, 0, DateTimeKind.Unspecified), 1914.770102280193, 7484.8308517668747, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 293, new DateTime(2022, 1, 12, 17, 16, 48, 0, DateTimeKind.Unspecified), 9116.6029791995134, 13634.813321557698, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 296, new DateTime(2022, 1, 12, 20, 9, 36, 0, DateTimeKind.Unspecified), 2833.6673485234896, 15849.654064364344, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 299, new DateTime(2022, 1, 12, 23, 2, 24, 0, DateTimeKind.Unspecified), 415.67285214244208, 5192.4869008231753, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 302, new DateTime(2022, 1, 13, 1, 55, 12, 0, DateTimeKind.Unspecified), 6145.995516804257, 6091.450330534044, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 305, new DateTime(2022, 1, 13, 4, 48, 0, 0, DateTimeKind.Unspecified), 4794.3773867545142, 2522.182654409266, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 308, new DateTime(2022, 1, 13, 7, 40, 48, 0, DateTimeKind.Unspecified), 385.41189860070585, 7506.3767838867161, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 311, new DateTime(2022, 1, 13, 10, 33, 36, 0, DateTimeKind.Unspecified), 7196.8246432372107, 5448.5211389438427, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 314, new DateTime(2022, 1, 13, 13, 26, 24, 0, DateTimeKind.Unspecified), 1286.3682913166776, 19486.854979095777, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 278, new DateTime(2022, 1, 12, 2, 52, 48, 0, DateTimeKind.Unspecified), 3850.9192136710253, 19066.052457010548, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 317, new DateTime(2022, 1, 13, 16, 19, 12, 0, DateTimeKind.Unspecified), 3808.578672981796, 3031.2696425960607, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 323, new DateTime(2022, 1, 13, 22, 4, 48, 0, DateTimeKind.Unspecified), 635.20595088953462, 7374.5605240754658, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 326, new DateTime(2022, 1, 14, 0, 57, 36, 0, DateTimeKind.Unspecified), 2920.5417315937639, 4736.4459738239821, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 329, new DateTime(2022, 1, 14, 3, 50, 24, 0, DateTimeKind.Unspecified), 5805.0959060482628, 17498.631029276254, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 332, new DateTime(2022, 1, 14, 6, 43, 12, 0, DateTimeKind.Unspecified), 3859.9273711998512, 19305.468852677841, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 335, new DateTime(2022, 1, 14, 9, 36, 0, 0, DateTimeKind.Unspecified), 6586.7780743515859, 15990.026284549756, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 338, new DateTime(2022, 1, 14, 12, 28, 48, 0, DateTimeKind.Unspecified), 2967.0396866311848, 3176.2176936495334, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 341, new DateTime(2022, 1, 14, 15, 21, 36, 0, DateTimeKind.Unspecified), 1701.5737854530691, 11441.98423924475, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 344, new DateTime(2022, 1, 14, 18, 14, 24, 0, DateTimeKind.Unspecified), 9793.8294893769671, 5835.0218235288485, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 347, new DateTime(2022, 1, 14, 21, 7, 12, 0, DateTimeKind.Unspecified), 3757.2702536558868, 19447.715868481377, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 350, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3473.3982540360812, 3006.6118749656825, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 353, new DateTime(2022, 1, 15, 2, 52, 48, 0, DateTimeKind.Unspecified), 7371.5660046200119, 236.28109764559008, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 320, new DateTime(2022, 1, 13, 19, 12, 0, 0, DateTimeKind.Unspecified), 5550.4825376254385, 7809.0636133133139, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 658, new DateTime(2022, 1, 27, 7, 40, 48, 0, DateTimeKind.Unspecified), 9150.5485654580407, 8011.1623251019428, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 113, new DateTime(2022, 1, 5, 12, 28, 48, 0, DateTimeKind.Unspecified), 2836.7575623114139, 17267.190841897213, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 107, new DateTime(2022, 1, 5, 6, 43, 12, 0, DateTimeKind.Unspecified), 9342.9907721667023, 14303.117788539123, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 748, new DateTime(2022, 1, 30, 22, 4, 48, 0, DateTimeKind.Unspecified), 251.75560529626463, 8402.8545150494065, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 751, new DateTime(2022, 1, 31, 0, 57, 36, 0, DateTimeKind.Unspecified), 6593.7419607252968, 2815.9119851758387, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 754, new DateTime(2022, 1, 31, 3, 50, 24, 0, DateTimeKind.Unspecified), 8017.4716481417927, 9264.3132774379374, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 757, new DateTime(2022, 1, 31, 6, 43, 12, 0, DateTimeKind.Unspecified), 3331.3807901833252, 4206.4554888426937, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 760, new DateTime(2022, 1, 31, 9, 36, 0, 0, DateTimeKind.Unspecified), 8317.8118134727047, 1086.8321503188872, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 763, new DateTime(2022, 1, 31, 12, 28, 48, 0, DateTimeKind.Unspecified), 4731.4175651133501, 13586.371342773911, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 766, new DateTime(2022, 1, 31, 15, 21, 36, 0, DateTimeKind.Unspecified), 9408.4667722243867, 17926.282402413923, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 769, new DateTime(2022, 1, 31, 18, 14, 24, 0, DateTimeKind.Unspecified), 1467.762118610159, 8599.0211965466551, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 772, new DateTime(2022, 1, 31, 21, 7, 12, 0, DateTimeKind.Unspecified), 7122.0329832973766, 16686.401065997834, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 775, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2124.1573242930685, 5923.3445375252022, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 778, new DateTime(2022, 2, 1, 2, 52, 48, 0, DateTimeKind.Unspecified), 6172.9886452306855, 5604.5018666662127, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 781, new DateTime(2022, 2, 1, 5, 45, 36, 0, DateTimeKind.Unspecified), 5201.6965501991472, 11441.627015604154, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 784, new DateTime(2022, 2, 1, 8, 38, 24, 0, DateTimeKind.Unspecified), 5498.4652583181742, 13942.314002947409, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 787, new DateTime(2022, 2, 1, 11, 31, 12, 0, DateTimeKind.Unspecified), 3855.4444434506231, 13271.41718018085, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 790, new DateTime(2022, 2, 1, 14, 24, 0, 0, DateTimeKind.Unspecified), 6559.5999116549719, 11984.386666689245, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 793, new DateTime(2022, 2, 1, 17, 16, 48, 0, DateTimeKind.Unspecified), 847.08066749776151, 10210.985444565573, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 796, new DateTime(2022, 2, 1, 20, 9, 36, 0, DateTimeKind.Unspecified), 9205.0215673924813, 13800.794002410294, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 799, new DateTime(2022, 2, 1, 23, 2, 24, 0, DateTimeKind.Unspecified), 5550.3847289909654, 12717.771357732858, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 802, new DateTime(2022, 2, 2, 1, 55, 12, 0, DateTimeKind.Unspecified), 2811.9353341105029, 6244.5543489905986, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 805, new DateTime(2022, 2, 2, 4, 48, 0, 0, DateTimeKind.Unspecified), 748.90767941988702, 4994.9928051102779, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 808, new DateTime(2022, 2, 2, 7, 40, 48, 0, DateTimeKind.Unspecified), 7221.6247643680135, 16170.87615918186, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 811, new DateTime(2022, 2, 2, 10, 33, 36, 0, DateTimeKind.Unspecified), 6920.0728943173299, 18011.70820922952, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 814, new DateTime(2022, 2, 2, 13, 26, 24, 0, DateTimeKind.Unspecified), 9317.7593930364183, 9841.60030183872, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 745, new DateTime(2022, 1, 30, 19, 12, 0, 0, DateTimeKind.Unspecified), 5328.9046549244176, 13186.312934153048, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 742, new DateTime(2022, 1, 30, 16, 19, 12, 0, DateTimeKind.Unspecified), 5538.8561649993817, 4416.4281095917841, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 739, new DateTime(2022, 1, 30, 13, 26, 24, 0, DateTimeKind.Unspecified), 4361.581294367551, 15647.768864665606, "24391000-0a63-4bb1-971f-7611dd87d9f6" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 736, new DateTime(2022, 1, 30, 10, 33, 36, 0, DateTimeKind.Unspecified), 3251.7929028074809, 17961.682612281478, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 664, new DateTime(2022, 1, 27, 13, 26, 24, 0, DateTimeKind.Unspecified), 2935.2725428849667, 10613.468058623001, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 667, new DateTime(2022, 1, 27, 16, 19, 12, 0, DateTimeKind.Unspecified), 8366.3388022819327, 17473.732620497838, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 670, new DateTime(2022, 1, 27, 19, 12, 0, 0, DateTimeKind.Unspecified), 8772.0970082601107, 18552.061596370721, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 673, new DateTime(2022, 1, 27, 22, 4, 48, 0, DateTimeKind.Unspecified), 2700.6391306264313, 4746.9966905008805, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 676, new DateTime(2022, 1, 28, 0, 57, 36, 0, DateTimeKind.Unspecified), 6418.6404098260637, 1972.7971032656542, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 679, new DateTime(2022, 1, 28, 3, 50, 24, 0, DateTimeKind.Unspecified), 9377.7917520984811, 824.0645228978882, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 682, new DateTime(2022, 1, 28, 6, 43, 12, 0, DateTimeKind.Unspecified), 9356.8969709927278, 2370.0031878991613, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 685, new DateTime(2022, 1, 28, 9, 36, 0, 0, DateTimeKind.Unspecified), 8304.6144224032214, 13110.207719535876, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 688, new DateTime(2022, 1, 28, 12, 28, 48, 0, DateTimeKind.Unspecified), 5686.4479917636008, 9321.693306681218, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 691, new DateTime(2022, 1, 28, 15, 21, 36, 0, DateTimeKind.Unspecified), 1935.8681327160602, 11252.637293965099, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 694, new DateTime(2022, 1, 28, 18, 14, 24, 0, DateTimeKind.Unspecified), 909.54925391967242, 11149.299877278096, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 817, new DateTime(2022, 2, 2, 16, 19, 12, 0, DateTimeKind.Unspecified), 7820.0343218783246, 2650.3522770919462, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 697, new DateTime(2022, 1, 28, 21, 7, 12, 0, DateTimeKind.Unspecified), 2224.2480193536694, 15732.765058629888, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 703, new DateTime(2022, 1, 29, 2, 52, 48, 0, DateTimeKind.Unspecified), 6426.7279863928625, 12901.626081142364, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 706, new DateTime(2022, 1, 29, 5, 45, 36, 0, DateTimeKind.Unspecified), 6096.9515482674833, 10407.113572222574, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 709, new DateTime(2022, 1, 29, 8, 38, 24, 0, DateTimeKind.Unspecified), 7637.3127138625514, 6419.4650552017456, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 712, new DateTime(2022, 1, 29, 11, 31, 12, 0, DateTimeKind.Unspecified), 4626.6864145767613, 6167.2220083722668, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 715, new DateTime(2022, 1, 29, 14, 24, 0, 0, DateTimeKind.Unspecified), 5886.3811874247267, 10742.214956564807, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 718, new DateTime(2022, 1, 29, 17, 16, 48, 0, DateTimeKind.Unspecified), 4309.4030236257277, 14916.663591049861, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 721, new DateTime(2022, 1, 29, 20, 9, 36, 0, DateTimeKind.Unspecified), 1587.9079894380457, 5447.7144042151558, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 724, new DateTime(2022, 1, 29, 23, 2, 24, 0, DateTimeKind.Unspecified), 1491.3739552304178, 18702.871470503305, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 727, new DateTime(2022, 1, 30, 1, 55, 12, 0, DateTimeKind.Unspecified), 7576.5807994353836, 3347.4111533881605, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 730, new DateTime(2022, 1, 30, 4, 48, 0, 0, DateTimeKind.Unspecified), 9819.3763803820621, 16775.065384485202, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 733, new DateTime(2022, 1, 30, 7, 40, 48, 0, DateTimeKind.Unspecified), 3243.3670726028181, 4531.2839257091946, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 700, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 6619.9611442406931, 13089.295448779581, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 110, new DateTime(2022, 1, 5, 9, 36, 0, 0, DateTimeKind.Unspecified), 7626.0650301856522, 8802.30936349279, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 820, new DateTime(2022, 2, 2, 19, 12, 0, 0, DateTimeKind.Unspecified), 3764.4743757942283, 18591.275447894706, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 826, new DateTime(2022, 2, 3, 0, 57, 36, 0, DateTimeKind.Unspecified), 3240.7952946711052, 10296.074577551411, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 38, new DateTime(2022, 1, 2, 12, 28, 48, 0, DateTimeKind.Unspecified), 8627.8813442217361, 5206.6340849929638, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 41, new DateTime(2022, 1, 2, 15, 21, 36, 0, DateTimeKind.Unspecified), 4558.1206629848175, 9889.7489204718204, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 44, new DateTime(2022, 1, 2, 18, 14, 24, 0, DateTimeKind.Unspecified), 9103.8672950225791, 14386.643545201263, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 47, new DateTime(2022, 1, 2, 21, 7, 12, 0, DateTimeKind.Unspecified), 8402.2749055329532, 2286.2892778282794, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 50, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5213.2992799547792, 12168.605967758067, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 53, new DateTime(2022, 1, 3, 2, 52, 48, 0, DateTimeKind.Unspecified), 4934.6057896083184, 14399.524761545035, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 56, new DateTime(2022, 1, 3, 5, 45, 36, 0, DateTimeKind.Unspecified), 5447.1177686836827, 19994.51754841995, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 59, new DateTime(2022, 1, 3, 8, 38, 24, 0, DateTimeKind.Unspecified), 3962.565286521412, 19700.037944135045, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 62, new DateTime(2022, 1, 3, 11, 31, 12, 0, DateTimeKind.Unspecified), 7240.4184308461627, 8178.8183965758753, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 65, new DateTime(2022, 1, 3, 14, 24, 0, 0, DateTimeKind.Unspecified), 8700.1025871040074, 17464.894274446815, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 68, new DateTime(2022, 1, 3, 17, 16, 48, 0, DateTimeKind.Unspecified), 4122.3397518546844, 18829.645695614334, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 71, new DateTime(2022, 1, 3, 20, 9, 36, 0, DateTimeKind.Unspecified), 8545.519569220527, 13498.101618060171, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 74, new DateTime(2022, 1, 3, 23, 2, 24, 0, DateTimeKind.Unspecified), 6401.8787339700884, 8163.3752032716602, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" }
                });

            migrationBuilder.InsertData(
                table: "JoggingRecords",
                columns: new[] { "RecordId", "Date", "DistanceInMeters", "DurationInSeconds", "UserId" },
                values: new object[,]
                {
                    { 77, new DateTime(2022, 1, 4, 1, 55, 12, 0, DateTimeKind.Unspecified), 5594.2855040498125, 14652.262950929378, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 80, new DateTime(2022, 1, 4, 4, 48, 0, 0, DateTimeKind.Unspecified), 4951.0259455362993, 5377.57601072542, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 83, new DateTime(2022, 1, 4, 7, 40, 48, 0, DateTimeKind.Unspecified), 8302.7129414736701, 4676.7447456302643, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 86, new DateTime(2022, 1, 4, 10, 33, 36, 0, DateTimeKind.Unspecified), 876.13331401482992, 7969.0742766094008, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 89, new DateTime(2022, 1, 4, 13, 26, 24, 0, DateTimeKind.Unspecified), 2920.9664128232398, 17999.736964536678, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 92, new DateTime(2022, 1, 4, 16, 19, 12, 0, DateTimeKind.Unspecified), 2284.7749607490955, 13575.157338474584, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 95, new DateTime(2022, 1, 4, 19, 12, 0, 0, DateTimeKind.Unspecified), 3481.1237475129128, 3678.1733633826248, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 98, new DateTime(2022, 1, 4, 22, 4, 48, 0, DateTimeKind.Unspecified), 9874.1472000114991, 5139.1378517659505, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 101, new DateTime(2022, 1, 5, 0, 57, 36, 0, DateTimeKind.Unspecified), 3696.5489572776696, 2505.2464136101294, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 104, new DateTime(2022, 1, 5, 3, 50, 24, 0, DateTimeKind.Unspecified), 6917.8750293067706, 601.99012719872599, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 35, new DateTime(2022, 1, 2, 9, 36, 0, 0, DateTimeKind.Unspecified), 8590.9840582645247, 9343.2078416613349, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 32, new DateTime(2022, 1, 2, 6, 43, 12, 0, DateTimeKind.Unspecified), 400.50938941652532, 10172.076180184618, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 29, new DateTime(2022, 1, 2, 3, 50, 24, 0, DateTimeKind.Unspecified), 5475.7300440229274, 2144.9412562370171, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 26, new DateTime(2022, 1, 2, 0, 57, 36, 0, DateTimeKind.Unspecified), 3658.1608484593471, 3328.9196944973796, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 829, new DateTime(2022, 2, 3, 3, 50, 24, 0, DateTimeKind.Unspecified), 9423.4670661340533, 13336.059049877065, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 832, new DateTime(2022, 2, 3, 6, 43, 12, 0, DateTimeKind.Unspecified), 9773.8985276277726, 11426.18413096881, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 835, new DateTime(2022, 2, 3, 9, 36, 0, 0, DateTimeKind.Unspecified), 4652.8590152638581, 5173.0194245121329, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 838, new DateTime(2022, 2, 3, 12, 28, 48, 0, DateTimeKind.Unspecified), 3783.7923140101748, 7403.8647100273456, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 841, new DateTime(2022, 2, 3, 15, 21, 36, 0, DateTimeKind.Unspecified), 383.70599415220732, 9754.3827800769377, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 844, new DateTime(2022, 2, 3, 18, 14, 24, 0, DateTimeKind.Unspecified), 2686.3289356892105, 9341.3772530106762, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 847, new DateTime(2022, 2, 3, 21, 7, 12, 0, DateTimeKind.Unspecified), 5812.2426939342413, 10721.21567202906, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 850, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3099.4873346836798, 9849.3679436846705, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 853, new DateTime(2022, 2, 4, 2, 52, 48, 0, DateTimeKind.Unspecified), 8552.4814862444091, 324.27245989291356, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 856, new DateTime(2022, 2, 4, 5, 45, 36, 0, DateTimeKind.Unspecified), 4155.200904221414, 12996.005120815953, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 859, new DateTime(2022, 2, 4, 8, 38, 24, 0, DateTimeKind.Unspecified), 7492.0879901346352, 11494.482681514326, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 823, new DateTime(2022, 2, 2, 22, 4, 48, 0, DateTimeKind.Unspecified), 4618.9897246133905, 14717.754338390494, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 862, new DateTime(2022, 2, 4, 11, 31, 12, 0, DateTimeKind.Unspecified), 7326.6290425746338, 5443.8304597157039, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 868, new DateTime(2022, 2, 4, 17, 16, 48, 0, DateTimeKind.Unspecified), 422.15049461576893, 4338.51625280384, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 871, new DateTime(2022, 2, 4, 20, 9, 36, 0, DateTimeKind.Unspecified), 6182.4883839389859, 15164.852692753801, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 874, new DateTime(2022, 2, 4, 23, 2, 24, 0, DateTimeKind.Unspecified), 3459.9711745290679, 11618.588718534966, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 2, new DateTime(2022, 1, 1, 1, 55, 12, 0, DateTimeKind.Unspecified), 714.98233985106219, 1719.1816452745343, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 5, new DateTime(2022, 1, 1, 4, 48, 0, 0, DateTimeKind.Unspecified), 2965.9038805358559, 4996.6506389815504, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 8, new DateTime(2022, 1, 1, 7, 40, 48, 0, DateTimeKind.Unspecified), 9350.2259948164156, 17163.597389789793, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 11, new DateTime(2022, 1, 1, 10, 33, 36, 0, DateTimeKind.Unspecified), 5835.496781835267, 8892.7817695832982, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 14, new DateTime(2022, 1, 1, 13, 26, 24, 0, DateTimeKind.Unspecified), 9889.12975920805, 2453.9813247222442, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 17, new DateTime(2022, 1, 1, 16, 19, 12, 0, DateTimeKind.Unspecified), 9641.8553479008951, 2117.7889590584009, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 20, new DateTime(2022, 1, 1, 19, 12, 0, 0, DateTimeKind.Unspecified), 9330.2467719319775, 3424.9333316099974, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 23, new DateTime(2022, 1, 1, 22, 4, 48, 0, DateTimeKind.Unspecified), 6551.5416843081794, 3692.6196693834963, "2f06b0c6-4f7c-44d7-9a92-44c729247f9e" },
                    { 865, new DateTime(2022, 2, 4, 14, 24, 0, 0, DateTimeKind.Unspecified), 3469.7632190544241, 11137.766655960273, "24391000-0a63-4bb1-971f-7611dd87d9f6" },
                    { 1, new DateTime(2022, 1, 1, 0, 57, 36, 0, DateTimeKind.Unspecified), 5901.753404672143, 18698.669479682481, "24391000-0a63-4bb1-971f-7611dd87d9f6" }
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

            migrationBuilder.CreateIndex(
                name: "IX_JoggingRecords_UserId",
                table: "JoggingRecords",
                column: "UserId");
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
                name: "JoggingRecords");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
