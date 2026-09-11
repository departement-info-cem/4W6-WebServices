using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP2_serveur.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "http://localhost:5143/api/Artists/GetPicture/1", "Hans Zimmer" },
                    { 2, "http://localhost:5143/api/Artists/GetPicture/2", "The Weeknd" },
                    { 3, "http://localhost:5143/api/Artists/GetPicture/3", "Drake" },
                    { 4, "http://localhost:5143/api/Artists/GetPicture/4", "Lady Gaga" },
                    { 5, "http://localhost:5143/api/Artists/GetPicture/5", "Beyoncé" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111111-1111-1111-1111-111111111111", 0, "b1e01a19-da8e-45ac-8f93-f2bff75cec2c", "a@a.a", false, false, null, "A@A.A", "ABC", "AQAAAAIAAYagAAAAEBiUO0zV5/ysu+vGzff4kztWAehBc0rUduTCnJQQot+8doJmM2Ydqv2ItNm4XpfWpQ==", null, false, "e8225142-eb6e-4c14-a0e2-4c02bd0408d0", false, "abc" });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "Id", "ArtistId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 1, "http://localhost:5143/api/Albums/GetPicture/1", "Interstellar" },
                    { 2, 1, "http://localhost:5143/api/Albums/GetPicture/2", "Inception" },
                    { 3, 1, "http://localhost:5143/api/Albums/GetPicture/3", "Dune" },
                    { 4, 1, "http://localhost:5143/api/Albums/GetPicture/4", "Twilight of the Gods" },
                    { 5, 2, "http://localhost:5143/api/Albums/GetPicture/5", "Starboy" },
                    { 6, 2, "http://localhost:5143/api/Albums/GetPicture/6", "After Hours" },
                    { 7, 2, "http://localhost:5143/api/Albums/GetPicture/7", "Hurry Up Tomorrow" },
                    { 8, 2, "http://localhost:5143/api/Albums/GetPicture/8", "Dawn FM" },
                    { 9, 3, "http://localhost:5143/api/Albums/GetPicture/9", "Views" },
                    { 10, 3, "http://localhost:5143/api/Albums/GetPicture/10", "Certified Lover Boy" },
                    { 11, 3, "http://localhost:5143/api/Albums/GetPicture/11", "Scorpion" },
                    { 12, 3, "http://localhost:5143/api/Albums/GetPicture/12", "For All the Dogs" },
                    { 13, 4, "http://localhost:5143/api/Albums/GetPicture/13", "Mayhem" },
                    { 14, 4, "http://localhost:5143/api/Albums/GetPicture/14", "The Fame" },
                    { 15, 4, "http://localhost:5143/api/Albums/GetPicture/15", "Artpop" },
                    { 16, 4, "http://localhost:5143/api/Albums/GetPicture/16", "Chromatica" },
                    { 17, 5, "http://localhost:5143/api/Albums/GetPicture/17", "Cowboy Carter" },
                    { 18, 5, "http://localhost:5143/api/Albums/GetPicture/18", "Lemonade" },
                    { 19, 5, "http://localhost:5143/api/Albums/GetPicture/19", "4" },
                    { 20, 5, "http://localhost:5143/api/Albums/GetPicture/20", "B'Day" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "AlbumId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Cornfield Chase" },
                    { 2, 1, "Mountains" },
                    { 3, 1, "Afraid of Time" },
                    { 4, 2, "Old Souls" },
                    { 5, 2, "Dream Within a Dream" },
                    { 6, 2, "Mombasa" },
                    { 7, 3, "Dream of Arrakis" },
                    { 8, 3, "House Atreides" },
                    { 9, 3, "Leaving Caladan" },
                    { 10, 4, "Valhalla" },
                    { 11, 4, "Open Hands" },
                    { 12, 4, "Tricky Lover" },
                    { 13, 5, "Starboy" },
                    { 14, 5, "Party Monster" },
                    { 15, 5, "Secrets" },
                    { 16, 6, "Alone Again" },
                    { 17, 6, "Too Late" },
                    { 18, 6, "Faith" },
                    { 19, 7, "Cry for Me" },
                    { 20, 7, "Timeless" },
                    { 21, 7, "Without a Warning" },
                    { 22, 8, "Gasoline" },
                    { 23, 8, "Sacrifice" },
                    { 24, 8, "Out of Time" },
                    { 25, 9, "9" },
                    { 26, 9, "Hype" },
                    { 27, 9, "With You" },
                    { 28, 10, "Champagne Poetry" },
                    { 29, 10, "Love All" },
                    { 30, 10, "Fair Trade" },
                    { 31, 11, "Nonstop" },
                    { 32, 11, "Elevate" },
                    { 33, 11, "Emotionless" },
                    { 34, 12, "Virginia Beach" },
                    { 35, 12, "Daylight" },
                    { 36, 12, "Slime You Out" },
                    { 37, 13, "Abracadabra" },
                    { 38, 13, "Disease" },
                    { 39, 13, "Garden of Eden" },
                    { 40, 14, "Just Dance" },
                    { 41, 14, "Paparazzi" },
                    { 42, 14, "Poker Face" },
                    { 43, 15, "Venus" },
                    { 44, 15, "G.U.Y." },
                    { 45, 15, "Applause" },
                    { 46, 16, "Stupid Love" },
                    { 47, 16, "Alice" },
                    { 48, 16, "Enigma" },
                    { 49, 17, "BLACKBIRD" },
                    { 50, 17, "BODYGUARD" },
                    { 51, 17, "DAUGHTER" },
                    { 52, 18, "Hold Up" },
                    { 53, 18, "Sorry" },
                    { 54, 18, "Sandcastles" },
                    { 55, 19, "I Care" },
                    { 56, 19, "1+1" },
                    { 57, 19, "Party" },
                    { 58, 20, "Deja Vu" },
                    { 59, 20, "Ring the Alarm" },
                    { 60, 20, "Green Light" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumId",
                table: "Song",
                column: "AlbumId");
        }

        /// <inheritdoc />
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
                name: "Song");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
