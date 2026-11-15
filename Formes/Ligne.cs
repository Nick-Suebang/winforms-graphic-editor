using System.Drawing;

namespace EditeurGraphique.Formes
{
    public sealed class Ligne : Forme
    {
        public Ligne(Point debut, Point fin, Color couleur, int epaisseur)
            : base(debut, fin, couleur, epaisseur)
        {
        }

        public override TypeForme Type => TypeForme.Ligne;

        protected override void Tracer(Graphics graphique, Pen crayon)
        {
            graphique.DrawLine(crayon, Debut, Fin);
        }
    }
}
