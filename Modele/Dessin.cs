using System.Collections.Generic;
using System.Drawing;
using EditeurGraphique.Formes;

namespace EditeurGraphique.Modele
{
    /// <summary>
    /// Ensemble ordonné des formes qui composent le dessin.
    /// </summary>
    public sealed class Dessin
    {
        private readonly List<Forme> formes = new List<Forme>();

        public IReadOnlyList<Forme> Formes => formes;

        public void Ajouter(Forme forme)
        {
            formes.Add(forme);
        }

        public void Remplacer(IEnumerable<Forme> nouvellesFormes)
        {
            formes.Clear();
            formes.AddRange(nouvellesFormes);
        }

        public void Dessiner(Graphics graphique)
        {
            foreach (var forme in formes)
            {
                forme.Dessiner(graphique);
            }
        }
    }
}
