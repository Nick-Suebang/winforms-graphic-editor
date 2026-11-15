using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EditeurGraphique.Formes;
using EditeurGraphique.Modele;
using EditeurGraphique.Persistance;

namespace EditeurGraphique.Vues
{
    public partial class FenetrePrincipale : Form
    {
        private const string FiltreFichiers = "Fichiers texte (*.txt)|*.txt";
        private const int EpaisseurParDefaut = 2;

        private readonly Dessin dessin = new Dessin();
        private Forme formeEnCours;
        private TypeForme outilCourant = TypeForme.Ligne;
        private Color couleurCourante = Color.Black;
        private int epaisseurCourante = EpaisseurParDefaut;

        public FenetrePrincipale()
        {
            InitializeComponent();

            ligneMenuItem.Tag = TypeForme.Ligne;
            rectangleMenuItem.Tag = TypeForme.Rectangle;
            ellipseMenuItem.Tag = TypeForme.Ellipse;

            MettreAJourEtat();
        }

        private void MettreAJourEtat()
        {
            etatLabel.Text = $"Outil : {outilCourant} | Couleur : {couleurCourante.Name} | Épaisseur : {epaisseurCourante} px";

            ligneMenuItem.Checked = outilCourant == TypeForme.Ligne;
            rectangleMenuItem.Checked = outilCourant == TypeForme.Rectangle;
            ellipseMenuItem.Checked = outilCourant == TypeForme.Ellipse;

            augmenterTraitMenuItem.Enabled = epaisseurCourante < Forme.EpaisseurMaximale;
            diminuerTraitMenuItem.Enabled = epaisseurCourante > Forme.EpaisseurMinimale;
        }

        private void ChangerEpaisseur(int epaisseur)
        {
            epaisseurCourante = Math.Max(Forme.EpaisseurMinimale, Math.Min(Forme.EpaisseurMaximale, epaisseur));
            MettreAJourEtat();
        }

        private static void AfficherErreur(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Dessin à la souris

        private void ZoneDessin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                formeEnCours = FabriqueFormes.Creer(outilCourant, e.Location, e.Location, couleurCourante, epaisseurCourante);
            }
        }

        private void ZoneDessin_MouseMove(object sender, MouseEventArgs e)
        {
            if (formeEnCours != null)
            {
                formeEnCours.DeplacerFin(e.Location);
                zoneDessin.Invalidate();
            }
        }

        private void ZoneDessin_MouseUp(object sender, MouseEventArgs e)
        {
            if (formeEnCours == null || e.Button != MouseButtons.Left)
            {
                return;
            }

            formeEnCours.DeplacerFin(e.Location);
            if (!formeEnCours.EstVide)
            {
                dessin.Ajouter(formeEnCours);
            }

            formeEnCours = null;
            zoneDessin.Invalidate();
        }

        private void ZoneDessin_Paint(object sender, PaintEventArgs e)
        {
            dessin.Dessiner(e.Graphics);
            formeEnCours?.Dessiner(e.Graphics);
        }

        #endregion

        #region Menu Fichier

        private void OuvrirMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialogue = new OpenFileDialog { Filter = FiltreFichiers })
            {
                if (dialogue.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    dessin.Remplacer(SerialiseurDessin.Charger(dialogue.FileName));
                    zoneDessin.Invalidate();
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is FormatException)
                {
                    AfficherErreur($"Impossible de charger le dessin.\n\n{ex.Message}");
                }
            }
        }

        private void EnregistrerMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialogue = new SaveFileDialog { Filter = FiltreFichiers })
            {
                if (dialogue.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    SerialiseurDessin.Enregistrer(dialogue.FileName, dessin.Formes);
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    AfficherErreur($"Impossible d'enregistrer le dessin.\n\n{ex.Message}");
                }
            }
        }

        #endregion

        #region Menu Outils et menu contextuel

        private void OutilMenuItem_Click(object sender, EventArgs e)
        {
            outilCourant = (TypeForme)((ToolStripMenuItem)sender).Tag;
            MettreAJourEtat();
        }

        private void EpaisseurMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialogue = new EpaisseurDialog(epaisseurCourante))
            {
                if (dialogue.ShowDialog(this) == DialogResult.OK)
                {
                    ChangerEpaisseur(dialogue.Epaisseur);
                }
            }
        }

        private void CouleurMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialogue = new ColorDialog { Color = couleurCourante })
            {
                if (dialogue.ShowDialog(this) == DialogResult.OK)
                {
                    couleurCourante = dialogue.Color;
                    MettreAJourEtat();
                }
            }
        }

        private void AugmenterTraitMenuItem_Click(object sender, EventArgs e)
        {
            ChangerEpaisseur(epaisseurCourante + 1);
        }

        private void DiminuerTraitMenuItem_Click(object sender, EventArgs e)
        {
            ChangerEpaisseur(epaisseurCourante - 1);
        }

        #endregion
    }
}
