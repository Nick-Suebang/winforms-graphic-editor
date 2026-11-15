using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using EditeurGraphique.Formes;

namespace EditeurGraphique.Persistance
{
    /// <summary>
    /// Lit et écrit un dessin au format texte, une forme par ligne :
    /// <c>Type;X1;Y1;X2;Y2;R;G;B;Epaisseur</c>.
    /// </summary>
    public static class SerialiseurDessin
    {
        private const char Separateur = ';';
        private const int NombreDeChamps = 9;

        public static void Enregistrer(string chemin, IEnumerable<Forme> formes)
        {
            File.WriteAllLines(chemin, formes.Select(VersLigne));
        }

        /// <summary>
        /// Charge toutes les formes du fichier. Le fichier est lu entièrement avant d'être accepté :
        /// la moindre ligne invalide lève une <see cref="FormatException"/> qui indique son numéro.
        /// </summary>
        public static IReadOnlyList<Forme> Charger(string chemin)
        {
            var formes = new List<Forme>();
            string[] lignes = File.ReadAllLines(chemin);

            for (int i = 0; i < lignes.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lignes[i]))
                {
                    continue;
                }

                try
                {
                    formes.Add(DepuisLigne(lignes[i]));
                }
                catch (FormatException ex)
                {
                    throw new FormatException($"Ligne {i + 1} : {ex.Message}", ex);
                }
            }

            return formes;
        }

        private static string VersLigne(Forme forme)
        {
            object[] champs =
            {
                forme.Type,
                forme.Debut.X, forme.Debut.Y,
                forme.Fin.X, forme.Fin.Y,
                forme.Couleur.R, forme.Couleur.G, forme.Couleur.B,
                forme.Epaisseur
            };

            return string.Join(Separateur.ToString(), champs.Select(c => Convert.ToString(c, CultureInfo.InvariantCulture)));
        }

        private static Forme DepuisLigne(string ligne)
        {
            string[] champs = ligne.Split(Separateur);
            if (champs.Length != NombreDeChamps)
            {
                throw new FormatException($"{NombreDeChamps} champs attendus, {champs.Length} trouvés.");
            }

            if (!Enum.GetNames(typeof(TypeForme)).Contains(champs[0]))
            {
                throw new FormatException($"type de forme inconnu « {champs[0]} ».");
            }

            var type = (TypeForme)Enum.Parse(typeof(TypeForme), champs[0]);

            var debut = new Point(LireEntier(champs[1]), LireEntier(champs[2]));
            var fin = new Point(LireEntier(champs[3]), LireEntier(champs[4]));
            var couleur = Color.FromArgb(LireComposante(champs[5]), LireComposante(champs[6]), LireComposante(champs[7]));
            int epaisseur = LireEntier(champs[8]);

            if (epaisseur < Forme.EpaisseurMinimale || epaisseur > Forme.EpaisseurMaximale)
            {
                throw new FormatException(
                    $"épaisseur {epaisseur} hors de l'intervalle {Forme.EpaisseurMinimale}-{Forme.EpaisseurMaximale}.");
            }

            return FabriqueFormes.Creer(type, debut, fin, couleur, epaisseur);
        }

        private static int LireEntier(string texte)
        {
            if (!int.TryParse(texte, NumberStyles.Integer, CultureInfo.InvariantCulture, out int valeur))
            {
                throw new FormatException($"« {texte} » n'est pas un nombre entier.");
            }

            return valeur;
        }

        private static int LireComposante(string texte)
        {
            int valeur = LireEntier(texte);
            if (valeur < 0 || valeur > 255)
            {
                throw new FormatException($"composante de couleur {valeur} hors de l'intervalle 0-255.");
            }

            return valeur;
        }
    }
}
