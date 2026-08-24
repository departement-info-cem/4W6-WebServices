using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vincible.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Superpowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superpowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSuperpower",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    SuperpowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSuperpower", x => new { x.CharactersId, x.SuperpowersId });
                    table.ForeignKey(
                        name: "FK_CharacterSuperpower_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSuperpower_Superpowers_SuperpowersId",
                        column: x => x.SuperpowersId,
                        principalTable: "Superpowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "Img", "IsAlive", "Name" },
                values: new object[,]
                {
                    { 1, 19, "invincible", true, "Invincible" },
                    { 2, 19, "atom_eve", true, "Atom Eve" },
                    { 3, 2000, "omni_man", true, "Omni-Man" },
                    { 4, null, "allen_the_alien", true, "Allen the Alien" },
                    { 5, 10000, "the_immortal", true, "The Immortal" },
                    { 6, null, "dupli_kate", true, "Dupli-Kate" },
                    { 7, null, "rex_splode", true, "Rex Splode" },
                    { 8, 26, "monster_girl", true, "Monster Girl" },
                    { 9, null, "shrinking_rae", true, "Shrinking Rae" },
                    { 10, null, "multi_paul", true, "Multi-Paul" },
                    { 11, null, "powerplex", true, "Powerplex" },
                    { 12, null, "red_rush", false, "Red Rush" },
                    { 13, 12, "robot", true, "Robot" },
                    { 14, null, "shapesmith", true, "Shapesmith" },
                    { 15, null, "war_woman", false, "War Woman" }
                });

            migrationBuilder.InsertData(
                table: "Superpowers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "L'utilisateur peut voler ou léviter.", "Vol" },
                    { 2, "L'utilisateur est significativement résistant contre la majorité des menaces physiques.", "Invulnérabilité" },
                    { 3, "L'utilisateur guérit significativement rapidement de ses blessures.", "Régénération" },
                    { 4, "L'utilisateur peut se déplacer significativement rapidement.", "Vitesse surhumaine" },
                    { 5, "L'utilisateur possède une force physique significativement grande.", "Force surhumaine" },
                    { 6, "L'utilisateur peut manipuler la matière à un niveau moléculaire et atomique.", "Manipulation de la matière" },
                    { 7, "L'utilisateur, même si cliniquement mort, peut se regénérer et reprendre vie.", "Résurrection" },
                    { 8, "L'utilisateur peut dupliquer son corps tout en gardant le contrôle de chacun.", "Réplication" },
                    { 9, "L'utilisateur peut créer de l'énergie cinétique et la transférer sur des objets pour les faire exploser.", "Charge cinétique" },
                    { 10, "L'utilisateur peut se transformer ou se métamorphoser.", "Transformation" },
                    { 11, "L'utilisateur peut réduire et augmenter sa taille sans dépasser sa taille naturelle.", "Réduction de taille" },
                    { 12, "L'utilisateur peut absorber l'énergie cinétique des objets.", "Absorbtion d'énergie" }
                });

            migrationBuilder.InsertData(
                table: "CharacterSuperpower",
                columns: new[] { "CharactersId", "SuperpowersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 7 },
                    { 6, 8 },
                    { 7, 9 },
                    { 8, 3 },
                    { 8, 4 },
                    { 8, 5 },
                    { 8, 10 },
                    { 9, 11 },
                    { 10, 8 },
                    { 11, 2 },
                    { 11, 5 },
                    { 11, 12 },
                    { 12, 4 },
                    { 14, 10 },
                    { 15, 1 },
                    { 15, 2 },
                    { 15, 4 },
                    { 15, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSuperpower_SuperpowersId",
                table: "CharacterSuperpower",
                column: "SuperpowersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSuperpower");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Superpowers");
        }
    }
}
