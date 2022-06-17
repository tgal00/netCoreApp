using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShops.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

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
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "CoffeeShops",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpensAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosesAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeShops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoffeeShops_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeShops_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CoffeeShopID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MenuItems_CoffeeShops_CoffeeShopID",
                        column: x => x.CoffeeShopID,
                        principalTable: "CoffeeShops",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Zagreb" },
                    { 2, "Split" },
                    { 3, "Rijeka" },
                    { 4, "Osijek" },
                    { 5, "Zadar" },
                    { 6, "Velika Gorica" },
                    { 7, "Slavonski Brod" },
                    { 8, "Pula" },
                    { 9, "Karlovac" },
                    { 10, "Sisak" },
                    { 11, "Varaždin" },
                    { 12, "Šibenik" },
                    { 13, "Dubrovnik" },
                    { 14, "Bjelovar" },
                    { 15, "Kaštela" },
                    { 16, "Samobor" },
                    { 17, "Vinkovci" },
                    { 18, "Koprivnica" },
                    { 19, "Vukovar" },
                    { 20, "Đakovo" },
                    { 21, "Čakovec" },
                    { 22, "Požega" },
                    { 23, "Zaprešić" },
                    { 24, "Sinj" },
                    { 25, "Petrinja" },
                    { 26, "Solin" },
                    { 27, "Kutina" },
                    { 28, "Virovitica" },
                    { 29, "Križevci" },
                    { 30, "Sveta Nedelja" },
                    { 31, "Dugo Selo" },
                    { 32, "Metković" },
                    { 33, "Poreč" },
                    { 34, "Našice" },
                    { 35, "Sveti Ivan Zelina" },
                    { 36, "Jastrebarsko" },
                    { 37, "Knin" },
                    { 38, "Omiš" },
                    { 39, "Vrbovec" },
                    { 40, "Ivanić-Grad" },
                    { 41, "Rovinj" },
                    { 42, "Nova Gradiška" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 43, "Makarska" },
                    { 44, "Ogulin" },
                    { 45, "Ivanec" },
                    { 46, "Slatina" },
                    { 47, "Umag" },
                    { 48, "Novska" },
                    { 49, "Trogir" },
                    { 50, "Novi Marof" },
                    { 51, "Gospić" },
                    { 52, "Krapina" },
                    { 53, "Županja" },
                    { 54, "Opatija" },
                    { 55, "Labin" },
                    { 56, "Daruvar" },
                    { 57, "Valpovo" },
                    { 58, "Pleternica" },
                    { 59, "Crikvenica" },
                    { 60, "Duga Resa" },
                    { 61, "Benkovac" },
                    { 62, "Imotski" },
                    { 63, "Belišće" },
                    { 64, "Kastav" },
                    { 65, "Garešnica" },
                    { 66, "Ploče" },
                    { 67, "Beli Manastir" },
                    { 68, "Otočac" },
                    { 69, "Donji Miholjac" },
                    { 70, "Trilj" },
                    { 71, "Glina" },
                    { 72, "Zabok" },
                    { 73, "Vodice" },
                    { 74, "Pazin" },
                    { 75, "Pakrac" },
                    { 76, "Ludbreg" },
                    { 77, "Đurđevac" },
                    { 78, "Lepoglava" },
                    { 79, "Bakar" },
                    { 80, "Čazma" },
                    { 81, "Mali Lošinj" },
                    { 82, "Rab" },
                    { 83, "Ozalj" },
                    { 84, "Prelog" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 85, "Drniš" },
                    { 86, "Senj" },
                    { 87, "Ilok" },
                    { 88, "Pregrada" },
                    { 89, "Vrgorac" },
                    { 90, "Grubišno Polje" },
                    { 91, "Varaždinske Toplice" },
                    { 92, "Otok" },
                    { 93, "Mursko Središće" },
                    { 94, "Krk" },
                    { 95, "Lipik" },
                    { 96, "Kutjevo" },
                    { 97, "Vodnjan" },
                    { 98, "Oroslavje" },
                    { 99, "Buzet" },
                    { 100, "Zlatar" },
                    { 101, "Delnice" },
                    { 102, "Donja Stubica" },
                    { 103, "Korčula" },
                    { 104, "Biograd na Moru" },
                    { 105, "Orahovica" },
                    { 106, "Novi Vinodolski" },
                    { 107, "Buje" },
                    { 108, "Slunj" },
                    { 109, "Vrbovsko" },
                    { 110, "Kraljevica" },
                    { 111, "Obrovac" },
                    { 112, "Novigrad" },
                    { 113, "Hvar" },
                    { 114, "Supetar" },
                    { 115, "Pag" },
                    { 116, "Čabar" },
                    { 117, "Skradin" },
                    { 118, "Novalja" },
                    { 119, "Opuzen" },
                    { 120, "Klanjec" },
                    { 121, "Cres" },
                    { 122, "Hrvatska Kostajnica" },
                    { 123, "Nin" },
                    { 124, "Stari Grad" },
                    { 125, "Vrlika" },
                    { 126, "Vis" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "Name" },
                values: new object[] { 127, "Komiža" });

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
                name: "IX_CoffeeShops_AddressID",
                table: "CoffeeShops",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeShops_CityID",
                table: "CoffeeShops",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CoffeeShopID",
                table: "MenuItems",
                column: "CoffeeShopID");
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
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CoffeeShops");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
