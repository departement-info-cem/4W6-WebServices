using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using labo6_serveur.Models;

namespace labo6_serveur.Data
{
    public class labo6_serveurContext : DbContext
    {
        public labo6_serveurContext (DbContextOptions<labo6_serveurContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Text = "2100 sera-t-elle une année bissextile ?", Answers = { "Oui", "Non" }, Correct = 1 },
                new Question { Id = 2, Text = "2400 sera-t-elle une année bissextile ?", Answers = { "Oui", "Non" }, Correct = 0 },
                new Question { Id = 3, Text = "Quel signe astrologique correspond au 30 avril ?", Answers = { "Taureau", "Balance", "Gémeaux", "Poissons" }, Correct = 0 },
                new Question { Id = 4, Text = "Quel signe astrologique correspond au 22 janvier ?", Answers = { "Capricorne", "Verseau", "Balance", "Poissons" }, Correct = 1 },
                new Question { Id = 5, Text = "Si on mélange de la lumière rouge et verte, quelle couleur obtient-on ?", Answers = { "Marron", "Bleu", "Jaune", "Orange" }, Correct = 2 },
                
                new Question { Id = 6, Text = "Si on mélange de la peinture rouge et verte, quelle couleur obtient-on ?", Answers = { "Marron", "Orange", "Jaune", "Gris" }, Correct = 0 },
                new Question { Id = 7, Text = "En quelle année les femmes ont-elles eu le droit de vote au Québec ?", Answers = { "2001", "1940", "1960", "1920" }, Correct = 1 },
                new Question { Id = 8, Text = "En quelle année les femmes ont-elles obtenu le droit de conduire en Arabie Saoudite ?", Answers = { "Jamais", "2022", "2007", "2018" }, Correct = 3 },
                new Question { Id = 9, Text = "Quelle est la planète la plus chaude du système solaire ?", Answers = { "Mercure", "Vénus", "Mars", "Jupiter" }, Correct = 1 },
                new Question { Id = 10, Text = "Quelle est la planète du système solaire qui est la plus proche de la Terre, en moyenne ?", Answers = { "Mercure", "Vénus", "Mars", "Pluton" }, Correct = 0 },
                
                new Question { Id = 11, Text = "Quel est le plus grand océan du monde ?", Answers = { "Atlantique", "Indien", "Pacifique", "Arctique" }, Correct = 2 },
                new Question { Id = 12, Text = "Quel est le continent avec la plus grande population d'humains ?", Answers = { "Amérique", "Afrique", "Asie", "Europe" }, Correct = 2 },
                new Question { Id = 13, Text = "Quel est l’élément chimique dont le symbole est O ?", Answers = { "Or", "Osmium", "Oxygène", "Ozone" }, Correct = 2 },
                new Question { Id = 14, Text = "Quelle est la capitale de l’Australie ?", Answers = { "Sydney", "Melbourne", "Canberra", "Perth" }, Correct = 2 },
                new Question { Id = 15, Text = "Combien de côtés a un dodécagone ?", Answers = { "10", "11", "12", "13" }, Correct = 2 },

                new Question { Id = 16, Text = "Quel pays a inventé le papier ?", Answers = { "Égypte", "Grèce", "Chine", "Inde" }, Correct = 2 },
                new Question { Id = 17, Text = "Quelle est la langue maternelle la plus parlée au monde ?", Answers = { "Anglais", "Espagnol", "Hindi", "Mandarin" }, Correct = 3 },
                new Question { Id = 18, Text = "Quel organe humain consomme le plus d’énergie au repos ?", Answers = { "Le cœur", "Le foie", "Le cerveau", "Les reins" }, Correct = 2 },
                new Question { Id = 19, Text = "Quel est le plus long fleuve du monde ?", Answers = { "Nil", "Amazone", "Yangtsé", "Mississippi" }, Correct = 1 },
                new Question { Id = 20, Text = "À quelle température l’eau bout-elle au niveau de la mer ?", Answers = { "90°C", "95°C", "100°C", "105°C" }, Correct = 2 },

                new Question { Id = 21, Text = "Quel animal est le plus rapide sur terre ?", Answers = { "Guépard", "Lion", "Antilope", "Autruche" }, Correct = 0 },
                new Question { Id = 22, Text = "Quel est le métal le plus léger ?", Answers = { "Aluminium", "Lithium", "Magnésium", "Titane" }, Correct = 1 },
                new Question { Id = 23, Text = "Quel est le symbole chimique du sodium ?", Answers = { "So", "Sd", "Na", "Sn" }, Correct = 2 },
                new Question { Id = 24, Text = "Combien de joueurs y a-t-il sur le terrain par équipe au football ?", Answers = { "9", "10", "11", "12" }, Correct = 2 },
                new Question { Id = 25, Text = "Quel est le plus petit pays du monde ?", Answers = { "Monaco", "Saint-Marin", "Vatican", "Liechtenstein" }, Correct = 2 },

                new Question { Id = 26, Text = "Quelle planète possède les anneaux les plus visibles ?", Answers = { "Jupiter", "Saturne", "Uranus", "Neptune" }, Correct = 1 },
                new Question { Id = 27, Text = "Quel est le nom du plus grand désert chaud du monde ?", Answers = { "Gobi", "Sahara", "Kalahari", "Atacama" }, Correct = 1 },
                new Question { Id = 28, Text = "Quel est l’inventeur du téléphone ?", Answers = { "Thomas Edison", "Nikola Tesla", "Alexander Graham Bell", "Marconi" }, Correct = 2 },
                new Question { Id = 29, Text = "Quel est le nombre de dents chez un adulte en bonne santé ?", Answers = { "28", "30", "32", "34" }, Correct = 2 },
                new Question { Id = 30, Text = "Quel est le gaz le plus présent dans l’atmosphère terrestre ?", Answers = { "Oxygène", "Azote", "Dioxyde de carbone", "Argon" }, Correct = 1 },

                new Question { Id = 31, Text = "Quel est le pays le plus peuplé du monde en 2024 ?", Answers = { "Chine", "Inde", "États-Unis", "Indonésie" }, Correct = 1 },
                new Question { Id = 32, Text = "Quelle est la vitesse approximative de la lumière ?", Answers = { "300 000 km/s", "150 000 km/s", "30 000 km/s", "3 000 km/s" }, Correct = 0 },
                new Question { Id = 33, Text = "Quel est le plus grand mammifère terrestre ?", Answers = { "Éléphant d’Afrique", "Rhinocéros", "Girafe", "Hippopotame" }, Correct = 0 },
                new Question { Id = 34, Text = "Combien de cordes possède un violon ?", Answers = { "4", "5", "6", "7" }, Correct = 0 },
                new Question { Id = 35, Text = "Quel est le nom du satellite naturel de la Terre ?", Answers = { "Lune", "Phobos", "Titan", "Io" }, Correct = 0 },

                new Question { Id = 36, Text = "Quel est le plus haut sommet du monde ?", Answers = { "K2", "Mont Everest", "Kangchenjunga", "Mont Blanc" }, Correct = 1 },
                new Question { Id = 37, Text = "Quelle est la monnaie officielle du Japon ?", Answers = { "Won", "Yen", "Yuan", "Ringgit" }, Correct = 1 },
                new Question { Id = 38, Text = "Quel scientifique a proposé la théorie de la relativité ?", Answers = { "Newton", "Galilée", "Einstein", "Bohr" }, Correct = 2 },
                new Question { Id = 39, Text = "Quel est le plus grand organe du corps humain ?", Answers = { "Le foie", "La peau", "Les poumons", "Le cerveau" }, Correct = 1 },
                new Question { Id = 40, Text = "Combien de minutes y a-t-il dans une journée ?", Answers = { "720", "1440", "2880", "4320" }, Correct = 1 },

                new Question { Id = 41, Text = "Quel pays est surnommé le \"Pays du Soleil-Levant\" ?", Answers = { "Chine", "Corée du Sud", "Japon", "Thaïlande" }, Correct = 2 },
                new Question { Id = 42, Text = "Quelle est la formule chimique de l’eau ?", Answers = { "HO", "H2O", "H2O2", "OH2" }, Correct = 1 },
                new Question { Id = 43, Text = "Combien de côtés possède un hexagone ?", Answers = { "5", "6", "7", "8" }, Correct = 1 },
                new Question { Id = 44, Text = "Quel est l’instrument principal pour mesurer la température ?", Answers = { "Baromètre", "Thermomètre", "Hygromètre", "Anémomètre" }, Correct = 1 },
                new Question { Id = 45, Text = "Quel est le plus grand pays du monde par superficie ?", Answers = { "Canada", "Chine", "États-Unis", "Russie" }, Correct = 3 },

                new Question { Id = 46, Text = "Quel est le nom du phénomène qui provoque les marées ?", Answers = { "Le vent", "La rotation de la Terre", "La gravité de la Lune", "La gravité du Soleil" }, Correct = 2 },
                new Question { Id = 47, Text = "Quelle est la couleur complémentaire du bleu ?", Answers = { "Vert", "Jaune", "Orange", "Rouge" }, Correct = 2 },
                new Question { Id = 48, Text = "Quel est le plus ancien jeu de société connu ?", Answers = { "Échecs", "Go", "Mancala", "Backgammon" }, Correct = 2 },
                new Question { Id = 49, Text = "Quel est le nom du plus petit os du corps humain ?", Answers = { "Étrier", "Marteau", "Enclume", "Rotule" }, Correct = 0 },
                new Question { Id = 50, Text = "Quelle planète est surnommée la planète rouge ?", Answers = { "Mercure", "Vénus", "Mars", "Jupiter" }, Correct = 2 },

                new Question { Id = 51, Text = "Quel est le plus grand animal ayant jamais existé ?", Answers = { "Dinosaure", "Éléphant d’Afrique", "Baleine bleue", "Mégalodon" }, Correct = 2 },
                new Question { Id = 52, Text = "Quel est le symbole chimique du fer ?", Answers = { "Fe", "Ir", "Fr", "Fi" }, Correct = 0 },
                new Question { Id = 53, Text = "Combien de jours compte une année bissextile ?", Answers = { "365", "366", "367", "364" }, Correct = 1 },
                new Question { Id = 54, Text = "Quel pays possède la plus grande population en Afrique ?", Answers = { "Égypte", "Éthiopie", "Nigeria", "Afrique du Sud" }, Correct = 2 },
                new Question { Id = 55, Text = "Quelle est la capitale du Brésil ?", Answers = { "Rio de Janeiro", "São Paulo", "Brasília", "Salvador" }, Correct = 2 },

                new Question { Id = 56, Text = "Quel est le nom de la galaxie dans laquelle se trouve la Terre ?", Answers = { "Andromède", "Voie lactée", "Messier 87", "Sombrero" }, Correct = 1 },
                new Question { Id = 57, Text = "Combien de côtés possède un octogone ?", Answers = { "6", "7", "8", "9" }, Correct = 2 },
                new Question { Id = 58, Text = "Quel est le principal gaz responsable de l’effet de serre naturel ?", Answers = { "Oxygène", "Azote", "Dioxyde de carbone", "Vapeur d’eau" }, Correct = 3 },
                new Question { Id = 59, Text = "Quel est le pays d’origine des Jeux olympiques ?", Answers = { "Italie", "Grèce", "France", "Égypte" }, Correct = 1 },
                new Question { Id = 60, Text = "Quel est le sens de rotation de la Terre vue depuis le pôle Nord ?", Answers = { "Horaire", "Antihoraire", "Variable", "Elle ne tourne pas" }, Correct = 1 },

                new Question { Id = 61, Text = "Quelle unité mesure l’intensité du courant électrique ?", Answers = { "Volt", "Watt", "Ampère", "Ohm" }, Correct = 2 },
                new Question { Id = 62, Text = "Quel est le plus grand lac d’eau douce du monde en superficie ?", Answers = { "Lac Victoria", "Lac Baïkal", "Lac Supérieur", "Lac Tanganyika" }, Correct = 2 },
                new Question { Id = 63, Text = "Combien de planètes composent le système solaire ?", Answers = { "7", "8", "9", "10" }, Correct = 1 },
                new Question { Id = 64, Text = "Quel est le pays le plus au nord du monde ?", Answers = { "Canada", "Russie", "Norvège", "Danemark" }, Correct = 1 },
                new Question { Id = 65, Text = "Quel organe permet principalement de filtrer le sang ?", Answers = { "Poumons", "Foie", "Reins", "Pancréas" }, Correct = 2 },

                new Question { Id = 66, Text = "Quel est le nombre minimum de joueurs pour former une équipe de basketball sur le terrain ?", Answers = { "4", "5", "6", "7" }, Correct = 1 },
                new Question { Id = 67, Text = "Quelle est la capitale du Canada ?", Answers = { "Toronto", "Montréal", "Ottawa", "Vancouver" }, Correct = 2 },
                new Question { Id = 68, Text = "Quel métal est liquide à température ambiante ?", Answers = { "Plomb", "Mercure", "Étain", "Zinc" }, Correct = 1 },
                new Question { Id = 69, Text = "Quelle planète a la durée de jour la plus longue ?", Answers = { "Mars", "Vénus", "Jupiter", "Mercure" }, Correct = 1 },
                new Question { Id = 70, Text = "Quelle est la valeur de π (pi) arrondie à deux décimales ?", Answers = { "3.12", "3.14", "3.16", "3.18" }, Correct = 1 },

                new Question { Id = 71, Text = "Quel est le nom du plus grand volcan du système solaire ?", Answers = { "Etna", "Mauna Kea", "Olympus Mons", "Vésuve" }, Correct = 2 },
                new Question { Id = 72, Text = "Quelle est la principale source d’énergie du Soleil ?", Answers = { "Fission", "Combustion", "Fusion nucléaire", "Radioactivité" }, Correct = 2 },
                new Question { Id = 73, Text = "Quel est le pays d’origine de la pizza ?", Answers = { "France", "Espagne", "Italie", "Grèce" }, Correct = 2 },
                new Question { Id = 74, Text = "Quel est le plus petit nombre premier ?", Answers = { "0", "1", "2", "3" }, Correct = 2 },
                new Question { Id = 75, Text = "Quelle mer est la plus salée ?", Answers = { "Mer Rouge", "Mer Morte", "Mer Noire", "Mer Méditerranée" }, Correct = 1 },

                new Question { Id = 76, Text = "Quel est l’os le plus long du corps humain ?", Answers = { "Tibia", "Fémur", "Humérus", "Radius" }, Correct = 1 },
                new Question { Id = 77, Text = "Quelle est la capitale de l’Islande ?", Answers = { "Oslo", "Helsinki", "Reykjavík", "Stockholm" }, Correct = 2 },
                new Question { Id = 78, Text = "Combien de faces possède un cube ?", Answers = { "4", "5", "6", "8" }, Correct = 2 },
                new Question { Id = 79, Text = "Quel est le principal constituant du verre ?", Answers = { "Calcium", "Silicium", "Sable", "Carbone" }, Correct = 2 },
                new Question { Id = 80, Text = "Quel est le pays le plus visité au monde ?", Answers = { "États-Unis", "Espagne", "Italie", "France" }, Correct = 3 },

                new Question { Id = 81, Text = "Quel est le nom de la couche externe de la Terre ?", Answers = { "Manteau", "Noyau", "Croûte", "Lithosphère" }, Correct = 2 },
                new Question { Id = 82, Text = "Quel est le nombre de lettres dans l’alphabet grec ?", Answers = { "22", "24", "26", "28" }, Correct = 1 },
                new Question { Id = 83, Text = "Quelle planète possède le plus de lunes connues ?", Answers = { "Jupiter", "Saturne", "Uranus", "Neptune" }, Correct = 1 },
                new Question { Id = 84, Text = "Quel est le principal pigment vert des plantes ?", Answers = { "Carotène", "Chlorophylle", "Mélanine", "Xanthophylle" }, Correct = 1 },
                new Question { Id = 85, Text = "Quel est le plus petit pays d’Afrique ?", Answers = { "Gambie", "Seychelles", "Comores", "Lesotho" }, Correct = 1 },

                new Question { Id = 86, Text = "Quelle est la capitale de la Nouvelle-Zélande ?", Answers = { "Auckland", "Christchurch", "Wellington", "Hamilton" }, Correct = 2 },
                new Question { Id = 87, Text = "Quel est le symbole chimique de l’or ?", Answers = { "Ag", "Au", "Or", "Go" }, Correct = 1 },
                new Question { Id = 88, Text = "Quelle est la durée approximative de rotation de la Terre sur elle-même ?", Answers = { "12 heures", "24 heures", "36 heures", "48 heures" }, Correct = 1 },
                new Question { Id = 89, Text = "Quel est le nom du plus grand récif corallien du monde ?", Answers = { "Récif de Belize", "Grande barrière de corail", "Récif des Maldives", "Récif des Caraïbes" }, Correct = 1 },
                new Question { Id = 90, Text = "Quel est le plus petit continent ?", Answers = { "Europe", "Antarctique", "Océanie", "Amérique du Sud" }, Correct = 2 },

                new Question { Id = 91, Text = "Quel est l’auteur de \"Le Petit Prince\" ?", Answers = { "Victor Hugo", "Antoine de Saint-Exupéry", "Jules Verne", "Albert Camus" }, Correct = 1 },
                new Question { Id = 92, Text = "Quelle est la langue officielle du Brésil ?", Answers = { "Espagnol", "Portugais", "Français", "Anglais" }, Correct = 1 },
                new Question { Id = 93, Text = "Quel est le plus grand désert froid du monde ?", Answers = { "Gobi", "Antarctique", "Arctique", "Sibérien" }, Correct = 1 },
                new Question { Id = 94, Text = "Quelle est la plus petite planète du système solaire ?", Answers = { "Mercure", "Mars", "Vénus", "Pluton" }, Correct = 0 },
                new Question { Id = 95, Text = "Quel est le nombre maximum de points dans un strike au bowling ?", Answers = { "200", "250", "300", "350" }, Correct = 2 },

                new Question { Id = 96, Text = "Quel est le nom de l’échelle qui mesure les tremblements de terre ?", Answers = { "Fujita", "Mercalli", "Richter", "Beaufort" }, Correct = 2 },
                new Question { Id = 97, Text = "Quelle vitamine est principalement produite grâce au soleil ?", Answers = { "Vitamine A", "Vitamine B12", "Vitamine C", "Vitamine D" }, Correct = 3 },
                new Question { Id = 98, Text = "Quel est le plus grand pays d’Amérique du Sud ?", Answers = { "Argentine", "Colombie", "Pérou", "Brésil" }, Correct = 3 },
                new Question { Id = 99, Text = "Quel est le principal os de l’avant-bras ?", Answers = { "Humérus", "Cubitus", "Fémur", "Omoplate" }, Correct = 1 },
                new Question { Id = 100, Text = "Quel est le seul mammifère capable de voler ?", Answers = { "Écureuil volant", "Chauve-souris", "Colibri", "Planeur" }, Correct = 1 }

            );
        }

        public DbSet<labo6_serveur.Models.Question> Question { get; set; } = default!;
    }
}
