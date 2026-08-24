using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace labo6_serveur.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correct = table.Column<int>(type: "int", nullable: false),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Answers", "Correct", "Text" },
                values: new object[,]
                {
                    { 1, "[\"Oui\",\"Non\"]", 1, "2100 sera-t-elle une année bissextile ?" },
                    { 2, "[\"Oui\",\"Non\"]", 0, "2400 sera-t-elle une année bissextile ?" },
                    { 3, "[\"Taureau\",\"Balance\",\"G\\u00E9meaux\",\"Poissons\"]", 0, "Quel signe astrologique correspond au 30 avril ?" },
                    { 4, "[\"Capricorne\",\"Verseau\",\"Balance\",\"Poissons\"]", 1, "Quel signe astrologique correspond au 22 janvier ?" },
                    { 5, "[\"Marron\",\"Bleu\",\"Jaune\",\"Orange\"]", 2, "Si on mélange de la lumière rouge et verte, quelle couleur obtient-on ?" },
                    { 6, "[\"Marron\",\"Orange\",\"Jaune\",\"Gris\"]", 0, "Si on mélange de la peinture rouge et verte, quelle couleur obtient-on ?" },
                    { 7, "[\"2001\",\"1940\",\"1960\",\"1920\"]", 1, "En quelle année les femmes ont-elles eu le droit de vote au Québec ?" },
                    { 8, "[\"Jamais\",\"2022\",\"2007\",\"2018\"]", 3, "En quelle année les femmes ont-elles obtenu le droit de conduire en Arabie Saoudite ?" },
                    { 9, "[\"Mercure\",\"V\\u00E9nus\",\"Mars\",\"Jupiter\"]", 1, "Quelle est la planète la plus chaude du système solaire ?" },
                    { 10, "[\"Mercure\",\"V\\u00E9nus\",\"Mars\",\"Pluton\"]", 0, "Quelle est la planète du système solaire qui est la plus proche de la Terre, en moyenne ?" },
                    { 11, "[\"Atlantique\",\"Indien\",\"Pacifique\",\"Arctique\"]", 2, "Quel est le plus grand océan du monde ?" },
                    { 12, "[\"Am\\u00E9rique\",\"Afrique\",\"Asie\",\"Europe\"]", 2, "Quel est le continent avec la plus grande population d'humains ?" },
                    { 13, "[\"Or\",\"Osmium\",\"Oxyg\\u00E8ne\",\"Ozone\"]", 2, "Quel est l’élément chimique dont le symbole est O ?" },
                    { 14, "[\"Sydney\",\"Melbourne\",\"Canberra\",\"Perth\"]", 2, "Quelle est la capitale de l’Australie ?" },
                    { 15, "[\"10\",\"11\",\"12\",\"13\"]", 2, "Combien de côtés a un dodécagone ?" },
                    { 16, "[\"\\u00C9gypte\",\"Gr\\u00E8ce\",\"Chine\",\"Inde\"]", 2, "Quel pays a inventé le papier ?" },
                    { 17, "[\"Anglais\",\"Espagnol\",\"Hindi\",\"Mandarin\"]", 3, "Quelle est la langue maternelle la plus parlée au monde ?" },
                    { 18, "[\"Le c\\u0153ur\",\"Le foie\",\"Le cerveau\",\"Les reins\"]", 2, "Quel organe humain consomme le plus d’énergie au repos ?" },
                    { 19, "[\"Nil\",\"Amazone\",\"Yangts\\u00E9\",\"Mississippi\"]", 1, "Quel est le plus long fleuve du monde ?" },
                    { 20, "[\"90\\u00B0C\",\"95\\u00B0C\",\"100\\u00B0C\",\"105\\u00B0C\"]", 2, "À quelle température l’eau bout-elle au niveau de la mer ?" },
                    { 21, "[\"Gu\\u00E9pard\",\"Lion\",\"Antilope\",\"Autruche\"]", 0, "Quel animal est le plus rapide sur terre ?" },
                    { 22, "[\"Aluminium\",\"Lithium\",\"Magn\\u00E9sium\",\"Titane\"]", 1, "Quel est le métal le plus léger ?" },
                    { 23, "[\"So\",\"Sd\",\"Na\",\"Sn\"]", 2, "Quel est le symbole chimique du sodium ?" },
                    { 24, "[\"9\",\"10\",\"11\",\"12\"]", 2, "Combien de joueurs y a-t-il sur le terrain par équipe au football ?" },
                    { 25, "[\"Monaco\",\"Saint-Marin\",\"Vatican\",\"Liechtenstein\"]", 2, "Quel est le plus petit pays du monde ?" },
                    { 26, "[\"Jupiter\",\"Saturne\",\"Uranus\",\"Neptune\"]", 1, "Quelle planète possède les anneaux les plus visibles ?" },
                    { 27, "[\"Gobi\",\"Sahara\",\"Kalahari\",\"Atacama\"]", 1, "Quel est le nom du plus grand désert chaud du monde ?" },
                    { 28, "[\"Thomas Edison\",\"Nikola Tesla\",\"Alexander Graham Bell\",\"Marconi\"]", 2, "Quel est l’inventeur du téléphone ?" },
                    { 29, "[\"28\",\"30\",\"32\",\"34\"]", 2, "Quel est le nombre de dents chez un adulte en bonne santé ?" },
                    { 30, "[\"Oxyg\\u00E8ne\",\"Azote\",\"Dioxyde de carbone\",\"Argon\"]", 1, "Quel est le gaz le plus présent dans l’atmosphère terrestre ?" },
                    { 31, "[\"Chine\",\"Inde\",\"\\u00C9tats-Unis\",\"Indon\\u00E9sie\"]", 1, "Quel est le pays le plus peuplé du monde en 2024 ?" },
                    { 32, "[\"300 000 km/s\",\"150 000 km/s\",\"30 000 km/s\",\"3 000 km/s\"]", 0, "Quelle est la vitesse approximative de la lumière ?" },
                    { 33, "[\"\\u00C9l\\u00E9phant d\\u2019Afrique\",\"Rhinoc\\u00E9ros\",\"Girafe\",\"Hippopotame\"]", 0, "Quel est le plus grand mammifère terrestre ?" },
                    { 34, "[\"4\",\"5\",\"6\",\"7\"]", 0, "Combien de cordes possède un violon ?" },
                    { 35, "[\"Lune\",\"Phobos\",\"Titan\",\"Io\"]", 0, "Quel est le nom du satellite naturel de la Terre ?" },
                    { 36, "[\"K2\",\"Mont Everest\",\"Kangchenjunga\",\"Mont Blanc\"]", 1, "Quel est le plus haut sommet du monde ?" },
                    { 37, "[\"Won\",\"Yen\",\"Yuan\",\"Ringgit\"]", 1, "Quelle est la monnaie officielle du Japon ?" },
                    { 38, "[\"Newton\",\"Galil\\u00E9e\",\"Einstein\",\"Bohr\"]", 2, "Quel scientifique a proposé la théorie de la relativité ?" },
                    { 39, "[\"Le foie\",\"La peau\",\"Les poumons\",\"Le cerveau\"]", 1, "Quel est le plus grand organe du corps humain ?" },
                    { 40, "[\"720\",\"1440\",\"2880\",\"4320\"]", 1, "Combien de minutes y a-t-il dans une journée ?" },
                    { 41, "[\"Chine\",\"Cor\\u00E9e du Sud\",\"Japon\",\"Tha\\u00EFlande\"]", 2, "Quel pays est surnommé le \"Pays du Soleil-Levant\" ?" },
                    { 42, "[\"HO\",\"H2O\",\"H2O2\",\"OH2\"]", 1, "Quelle est la formule chimique de l’eau ?" },
                    { 43, "[\"5\",\"6\",\"7\",\"8\"]", 1, "Combien de côtés possède un hexagone ?" },
                    { 44, "[\"Barom\\u00E8tre\",\"Thermom\\u00E8tre\",\"Hygrom\\u00E8tre\",\"An\\u00E9mom\\u00E8tre\"]", 1, "Quel est l’instrument principal pour mesurer la température ?" },
                    { 45, "[\"Canada\",\"Chine\",\"\\u00C9tats-Unis\",\"Russie\"]", 3, "Quel est le plus grand pays du monde par superficie ?" },
                    { 46, "[\"Le vent\",\"La rotation de la Terre\",\"La gravit\\u00E9 de la Lune\",\"La gravit\\u00E9 du Soleil\"]", 2, "Quel est le nom du phénomène qui provoque les marées ?" },
                    { 47, "[\"Vert\",\"Jaune\",\"Orange\",\"Rouge\"]", 2, "Quelle est la couleur complémentaire du bleu ?" },
                    { 48, "[\"\\u00C9checs\",\"Go\",\"Mancala\",\"Backgammon\"]", 2, "Quel est le plus ancien jeu de société connu ?" },
                    { 49, "[\"\\u00C9trier\",\"Marteau\",\"Enclume\",\"Rotule\"]", 0, "Quel est le nom du plus petit os du corps humain ?" },
                    { 50, "[\"Mercure\",\"V\\u00E9nus\",\"Mars\",\"Jupiter\"]", 2, "Quelle planète est surnommée la planète rouge ?" },
                    { 51, "[\"Dinosaure\",\"\\u00C9l\\u00E9phant d\\u2019Afrique\",\"Baleine bleue\",\"M\\u00E9galodon\"]", 2, "Quel est le plus grand animal ayant jamais existé ?" },
                    { 52, "[\"Fe\",\"Ir\",\"Fr\",\"Fi\"]", 0, "Quel est le symbole chimique du fer ?" },
                    { 53, "[\"365\",\"366\",\"367\",\"364\"]", 1, "Combien de jours compte une année bissextile ?" },
                    { 54, "[\"\\u00C9gypte\",\"\\u00C9thiopie\",\"Nigeria\",\"Afrique du Sud\"]", 2, "Quel pays possède la plus grande population en Afrique ?" },
                    { 55, "[\"Rio de Janeiro\",\"S\\u00E3o Paulo\",\"Bras\\u00EDlia\",\"Salvador\"]", 2, "Quelle est la capitale du Brésil ?" },
                    { 56, "[\"Androm\\u00E8de\",\"Voie lact\\u00E9e\",\"Messier 87\",\"Sombrero\"]", 1, "Quel est le nom de la galaxie dans laquelle se trouve la Terre ?" },
                    { 57, "[\"6\",\"7\",\"8\",\"9\"]", 2, "Combien de côtés possède un octogone ?" },
                    { 58, "[\"Oxyg\\u00E8ne\",\"Azote\",\"Dioxyde de carbone\",\"Vapeur d\\u2019eau\"]", 3, "Quel est le principal gaz responsable de l’effet de serre naturel ?" },
                    { 59, "[\"Italie\",\"Gr\\u00E8ce\",\"France\",\"\\u00C9gypte\"]", 1, "Quel est le pays d’origine des Jeux olympiques ?" },
                    { 60, "[\"Horaire\",\"Antihoraire\",\"Variable\",\"Elle ne tourne pas\"]", 1, "Quel est le sens de rotation de la Terre vue depuis le pôle Nord ?" },
                    { 61, "[\"Volt\",\"Watt\",\"Amp\\u00E8re\",\"Ohm\"]", 2, "Quelle unité mesure l’intensité du courant électrique ?" },
                    { 62, "[\"Lac Victoria\",\"Lac Ba\\u00EFkal\",\"Lac Sup\\u00E9rieur\",\"Lac Tanganyika\"]", 2, "Quel est le plus grand lac d’eau douce du monde en superficie ?" },
                    { 63, "[\"7\",\"8\",\"9\",\"10\"]", 1, "Combien de planètes composent le système solaire ?" },
                    { 64, "[\"Canada\",\"Russie\",\"Norv\\u00E8ge\",\"Danemark\"]", 1, "Quel est le pays le plus au nord du monde ?" },
                    { 65, "[\"Poumons\",\"Foie\",\"Reins\",\"Pancr\\u00E9as\"]", 2, "Quel organe permet principalement de filtrer le sang ?" },
                    { 66, "[\"4\",\"5\",\"6\",\"7\"]", 1, "Quel est le nombre minimum de joueurs pour former une équipe de basketball sur le terrain ?" },
                    { 67, "[\"Toronto\",\"Montr\\u00E9al\",\"Ottawa\",\"Vancouver\"]", 2, "Quelle est la capitale du Canada ?" },
                    { 68, "[\"Plomb\",\"Mercure\",\"\\u00C9tain\",\"Zinc\"]", 1, "Quel métal est liquide à température ambiante ?" },
                    { 69, "[\"Mars\",\"V\\u00E9nus\",\"Jupiter\",\"Mercure\"]", 1, "Quelle planète a la durée de jour la plus longue ?" },
                    { 70, "[\"3.12\",\"3.14\",\"3.16\",\"3.18\"]", 1, "Quelle est la valeur de π (pi) arrondie à deux décimales ?" },
                    { 71, "[\"Etna\",\"Mauna Kea\",\"Olympus Mons\",\"V\\u00E9suve\"]", 2, "Quel est le nom du plus grand volcan du système solaire ?" },
                    { 72, "[\"Fission\",\"Combustion\",\"Fusion nucl\\u00E9aire\",\"Radioactivit\\u00E9\"]", 2, "Quelle est la principale source d’énergie du Soleil ?" },
                    { 73, "[\"France\",\"Espagne\",\"Italie\",\"Gr\\u00E8ce\"]", 2, "Quel est le pays d’origine de la pizza ?" },
                    { 74, "[\"0\",\"1\",\"2\",\"3\"]", 2, "Quel est le plus petit nombre premier ?" },
                    { 75, "[\"Mer Rouge\",\"Mer Morte\",\"Mer Noire\",\"Mer M\\u00E9diterran\\u00E9e\"]", 1, "Quelle mer est la plus salée ?" },
                    { 76, "[\"Tibia\",\"F\\u00E9mur\",\"Hum\\u00E9rus\",\"Radius\"]", 1, "Quel est l’os le plus long du corps humain ?" },
                    { 77, "[\"Oslo\",\"Helsinki\",\"Reykjav\\u00EDk\",\"Stockholm\"]", 2, "Quelle est la capitale de l’Islande ?" },
                    { 78, "[\"4\",\"5\",\"6\",\"8\"]", 2, "Combien de faces possède un cube ?" },
                    { 79, "[\"Calcium\",\"Silicium\",\"Sable\",\"Carbone\"]", 2, "Quel est le principal constituant du verre ?" },
                    { 80, "[\"\\u00C9tats-Unis\",\"Espagne\",\"Italie\",\"France\"]", 3, "Quel est le pays le plus visité au monde ?" },
                    { 81, "[\"Manteau\",\"Noyau\",\"Cro\\u00FBte\",\"Lithosph\\u00E8re\"]", 2, "Quel est le nom de la couche externe de la Terre ?" },
                    { 82, "[\"22\",\"24\",\"26\",\"28\"]", 1, "Quel est le nombre de lettres dans l’alphabet grec ?" },
                    { 83, "[\"Jupiter\",\"Saturne\",\"Uranus\",\"Neptune\"]", 1, "Quelle planète possède le plus de lunes connues ?" },
                    { 84, "[\"Carot\\u00E8ne\",\"Chlorophylle\",\"M\\u00E9lanine\",\"Xanthophylle\"]", 1, "Quel est le principal pigment vert des plantes ?" },
                    { 85, "[\"Gambie\",\"Seychelles\",\"Comores\",\"Lesotho\"]", 1, "Quel est le plus petit pays d’Afrique ?" },
                    { 86, "[\"Auckland\",\"Christchurch\",\"Wellington\",\"Hamilton\"]", 2, "Quelle est la capitale de la Nouvelle-Zélande ?" },
                    { 87, "[\"Ag\",\"Au\",\"Or\",\"Go\"]", 1, "Quel est le symbole chimique de l’or ?" },
                    { 88, "[\"12 heures\",\"24 heures\",\"36 heures\",\"48 heures\"]", 1, "Quelle est la durée approximative de rotation de la Terre sur elle-même ?" },
                    { 89, "[\"R\\u00E9cif de Belize\",\"Grande barri\\u00E8re de corail\",\"R\\u00E9cif des Maldives\",\"R\\u00E9cif des Cara\\u00EFbes\"]", 1, "Quel est le nom du plus grand récif corallien du monde ?" },
                    { 90, "[\"Europe\",\"Antarctique\",\"Oc\\u00E9anie\",\"Am\\u00E9rique du Sud\"]", 2, "Quel est le plus petit continent ?" },
                    { 91, "[\"Victor Hugo\",\"Antoine de Saint-Exup\\u00E9ry\",\"Jules Verne\",\"Albert Camus\"]", 1, "Quel est l’auteur de \"Le Petit Prince\" ?" },
                    { 92, "[\"Espagnol\",\"Portugais\",\"Fran\\u00E7ais\",\"Anglais\"]", 1, "Quelle est la langue officielle du Brésil ?" },
                    { 93, "[\"Gobi\",\"Antarctique\",\"Arctique\",\"Sib\\u00E9rien\"]", 1, "Quel est le plus grand désert froid du monde ?" },
                    { 94, "[\"Mercure\",\"Mars\",\"V\\u00E9nus\",\"Pluton\"]", 0, "Quelle est la plus petite planète du système solaire ?" },
                    { 95, "[\"200\",\"250\",\"300\",\"350\"]", 2, "Quel est le nombre maximum de points dans un strike au bowling ?" },
                    { 96, "[\"Fujita\",\"Mercalli\",\"Richter\",\"Beaufort\"]", 2, "Quel est le nom de l’échelle qui mesure les tremblements de terre ?" },
                    { 97, "[\"Vitamine A\",\"Vitamine B12\",\"Vitamine C\",\"Vitamine D\"]", 3, "Quelle vitamine est principalement produite grâce au soleil ?" },
                    { 98, "[\"Argentine\",\"Colombie\",\"P\\u00E9rou\",\"Br\\u00E9sil\"]", 3, "Quel est le plus grand pays d’Amérique du Sud ?" },
                    { 99, "[\"Hum\\u00E9rus\",\"Cubitus\",\"F\\u00E9mur\",\"Omoplate\"]", 1, "Quel est le principal os de l’avant-bras ?" },
                    { 100, "[\"\\u00C9cureuil volant\",\"Chauve-souris\",\"Colibri\",\"Planeur\"]", 1, "Quel est le seul mammifère capable de voler ?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
