using System.Drawing;
using System.Windows.Forms;
using EditeurGraphique.Formes;

namespace EditeurGraphique.Vues
{
    /// <summary>
    /// Boîte de dialogue de saisie de l'épaisseur du trait. Le champ numérique borné
    /// rend toute saisie invalide impossible.
    /// </summary>
    public sealed class EpaisseurDialog : Form
    {
        private readonly NumericUpDown champEpaisseur;

        public EpaisseurDialog(int epaisseurActuelle)
        {
            Text = "Épaisseur du trait";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(260, 100);

            var libelle = new Label
            {
                Text = "Nouvelle épaisseur (px) :",
                Location = new Point(12, 18),
                AutoSize = true
            };

            champEpaisseur = new NumericUpDown
            {
                Minimum = Forme.EpaisseurMinimale,
                Maximum = Forme.EpaisseurMaximale,
                Value = epaisseurActuelle,
                Location = new Point(180, 15),
                Width = 65
            };

            var boutonOk = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(90, 60),
                Width = 75
            };

            var boutonAnnuler = new Button
            {
                Text = "Annuler",
                DialogResult = DialogResult.Cancel,
                Location = new Point(170, 60),
                Width = 75
            };

            Controls.AddRange(new Control[] { libelle, champEpaisseur, boutonOk, boutonAnnuler });
            AcceptButton = boutonOk;
            CancelButton = boutonAnnuler;
        }

        public int Epaisseur => (int)champEpaisseur.Value;
    }
}
