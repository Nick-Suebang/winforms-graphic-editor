using System.Drawing;

namespace EditeurGraphique.Formes
{
    public sealed class Rectangle : Forme
    {
        public Rectangle(Point debut, Point fin, Color couleur, int epaisseur)
            : base(debut, fin, couleur, epaisseur)
        {
        }

        public override TypeForme Type => TypeForme.Rectangle;

        protected override void Tracer(Graphics graphique, Pen crayon)
        {
            graphique.DrawRectangle(crayon, Limites);
        }
    }
}
