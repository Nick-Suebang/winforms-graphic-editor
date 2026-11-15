using System;
using System.Drawing;

namespace EditeurGraphique.Formes
{
    /// <summary>
    /// Point unique de création des formes : ajouter une forme ne demande de modifier que cette classe
    /// et l'énumération <see cref="TypeForme"/>.
    /// </summary>
    public static class FabriqueFormes
    {
        public static Forme Creer(TypeForme type, Point debut, Point fin, Color couleur, int epaisseur)
        {
            switch (type)
            {
                case TypeForme.Ligne:
                    return new Ligne(debut, fin, couleur, epaisseur);
                case TypeForme.Rectangle:
                    return new Rectangle(debut, fin, couleur, epaisseur);
                case TypeForme.Ellipse:
                    return new Ellipse(debut, fin, couleur, epaisseur);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Type de forme inconnu.");
            }
        }
    }
}
