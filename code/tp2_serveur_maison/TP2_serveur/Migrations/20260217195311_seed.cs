using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP2_serveur.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "11111111-1111-1111-1111-111111111111", 0, "b93115d3-bdeb-4d8c-9259-fdcbe98d86fb", "a@a.a", false, false, null, "A@A.A", "ABC", "AQAAAAIAAYagAAAAEJVQs20CHtbUiszI3odXrB+4NMQ7US4GqK13knq+OmfSxfhh/5Qys0vOKyXnSkAnnQ==", null, false, "3e889834-e74d-441a-8786-c5da363a6371", false, "abc" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
