using System.Drawing;

namespace EditeurGraphique.Formes
{
    public sealed class Ellipse : Forme
    {
        public Ellipse(Point debut, Point fin, Color couleur, int epaisseur)
            : base(debut, fin, couleur, epaisseur)
        {
        }

        public override TypeForme Type => TypeForme.Ellipse;

        protected override void Tracer(Graphics graphique, Pen crayon)
        {
            graphique.DrawEllipse(crayon, Limites);
        }
    }
}
