using System;
using System.Drawing;
using RectangleDessin = System.Drawing.Rectangle;

namespace EditeurGraphique.Formes
{
    /// <summary>
    /// Forme géométrique définie par deux points, une couleur et une épaisseur de trait.
    /// </summary>
    public abstract class Forme
    {
        public const int EpaisseurMinimale = 1;
        public const int EpaisseurMaximale = 100;

        protected Forme(Point debut, Point fin, Color couleur, int epaisseur)
        {
            if (epaisseur < EpaisseurMinimale || epaisseur > EpaisseurMaximale)
            {
                throw new ArgumentOutOfRangeException(nameof(epaisseur), epaisseur,
                    $"L'épaisseur doit être comprise entre {EpaisseurMinimale} et {EpaisseurMaximale}.");
            }

            Debut = debut;
            Fin = fin;
            Couleur = couleur;
            Epaisseur = epaisseur;
        }

        public abstract TypeForme Type { get; }

        public Point Debut { get; }

        public Point Fin { get; private set; }

        public Color Couleur { get; }

        public int Epaisseur { get; }

        /// <summary>
        /// Vrai si la forme n'a aucune étendue (simple clic sans déplacement).
        /// </summary>
        public bool EstVide => Debut == Fin;

        /// <summary>
        /// Rectangle englobant normalisé, quel que soit le sens du tracé.
        /// </summary>
        protected RectangleDessin Limites => RectangleDessin.FromLTRB(
            Math.Min(Debut.X, Fin.X),
            Math.Min(Debut.Y, Fin.Y),
            Math.Max(Debut.X, Fin.X),
            Math.Max(Debut.Y, Fin.Y));

        public void DeplacerFin(Point fin)
        {
            Fin = fin;
        }

        public void Dessiner(Graphics graphique)
        {
            using (var crayon = new Pen(Couleur, Epaisseur))
            {
                Tracer(graphique, crayon);
            }
        }

        /// <summary>
        /// Trace la forme avec un crayon déjà configuré (couleur et épaisseur).
        /// </summary>
        protected abstract void Tracer(Graphics graphique, Pen crayon);
    }
}
