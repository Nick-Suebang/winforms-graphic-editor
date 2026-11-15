namespace EditeurGraphique.Vues
{
    partial class FenetrePrincipale
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zoneDessin = new System.Windows.Forms.PictureBox();
            this.menuContextuel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.couleurMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.augmenterTraitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diminuerTraitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barreEtat = new System.Windows.Forms.StatusStrip();
            this.etatLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.fichierMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outilsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ligneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.epaisseurMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.zoneDessin)).BeginInit();
            this.menuContextuel.SuspendLayout();
            this.barreEtat.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoneDessin
            // 
            this.zoneDessin.ContextMenuStrip = this.menuContextuel;
            this.zoneDessin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoneDessin.Location = new System.Drawing.Point(0, 30);
            this.zoneDessin.Name = "zoneDessin";
            this.zoneDessin.Size = new System.Drawing.Size(1204, 596);
            this.zoneDessin.TabIndex = 0;
            this.zoneDessin.TabStop = false;
            this.zoneDessin.Paint += new System.Windows.Forms.PaintEventHandler(this.ZoneDessin_Paint);
            this.zoneDessin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZoneDessin_MouseDown);
            this.zoneDessin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ZoneDessin_MouseMove);
            this.zoneDessin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZoneDessin_MouseUp);
            // 
            // menuContextuel
            // 
            this.menuContextuel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuContextuel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.couleurMenuItem,
            this.augmenterTraitMenuItem,
            this.diminuerTraitMenuItem});
            this.menuContextuel.Name = "menuContextuel";
            this.menuContextuel.Size = new System.Drawing.Size(184, 76);
            // 
            // couleurMenuItem
            // 
            this.couleurMenuItem.Name = "couleurMenuItem";
            this.couleurMenuItem.Size = new System.Drawing.Size(183, 24);
            this.couleurMenuItem.Text = "Couleur";
            this.couleurMenuItem.Click += new System.EventHandler(this.CouleurMenuItem_Click);
            // 
            // augmenterTraitMenuItem
            // 
            this.augmenterTraitMenuItem.Name = "augmenterTraitMenuItem";
            this.augmenterTraitMenuItem.Size = new System.Drawing.Size(183, 24);
            this.augmenterTraitMenuItem.Text = "Augmenter trait";
            this.augmenterTraitMenuItem.Click += new System.EventHandler(this.AugmenterTraitMenuItem_Click);
            // 
            // diminuerTraitMenuItem
            // 
            this.diminuerTraitMenuItem.Name = "diminuerTraitMenuItem";
            this.diminuerTraitMenuItem.Size = new System.Drawing.Size(183, 24);
            this.diminuerTraitMenuItem.Text = "Diminuer trait";
            this.diminuerTraitMenuItem.Click += new System.EventHandler(this.DiminuerTraitMenuItem_Click);
            // 
            // barreEtat
            // 
            this.barreEtat.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.barreEtat.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.barreEtat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.etatLabel});
            this.barreEtat.Location = new System.Drawing.Point(0, 600);
            this.barreEtat.Name = "barreEtat";
            this.barreEtat.Size = new System.Drawing.Size(1204, 26);
            this.barreEtat.TabIndex = 2;
            this.barreEtat.Text = "barreEtat";
            // 
            // etatLabel
            // 
            this.etatLabel.Name = "etatLabel";
            this.etatLabel.Size = new System.Drawing.Size(151, 20);
            this.etatLabel.Text = "etatLabel";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierMenu,
            this.outilsMenu});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1204, 30);
            this.menuPrincipal.TabIndex = 1;
            this.menuPrincipal.Text = "menuPrincipal";
            // 
            // fichierMenu
            // 
            this.fichierMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirMenuItem,
            this.enregistrerMenuItem});
            this.fichierMenu.Name = "fichierMenu";
            this.fichierMenu.Size = new System.Drawing.Size(66, 26);
            this.fichierMenu.Text = "Fichier";
            // 
            // ouvrirMenuItem
            // 
            this.ouvrirMenuItem.Name = "ouvrirMenuItem";
            this.ouvrirMenuItem.Size = new System.Drawing.Size(172, 26);
            this.ouvrirMenuItem.Text = "Ouvrir...";
            this.ouvrirMenuItem.Click += new System.EventHandler(this.OuvrirMenuItem_Click);
            // 
            // enregistrerMenuItem
            // 
            this.enregistrerMenuItem.Name = "enregistrerMenuItem";
            this.enregistrerMenuItem.Size = new System.Drawing.Size(172, 26);
            this.enregistrerMenuItem.Text = "Enregistrer...";
            this.enregistrerMenuItem.Click += new System.EventHandler(this.EnregistrerMenuItem_Click);
            // 
            // outilsMenu
            // 
            this.outilsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ligneMenuItem,
            this.rectangleMenuItem,
            this.ellipseMenuItem,
            this.epaisseurMenuItem});
            this.outilsMenu.Name = "outilsMenu";
            this.outilsMenu.Size = new System.Drawing.Size(61, 26);
            this.outilsMenu.Text = "Outils";
            // 
            // ligneMenuItem
            // 
            this.ligneMenuItem.Name = "ligneMenuItem";
            this.ligneMenuItem.Size = new System.Drawing.Size(215, 26);
            this.ligneMenuItem.Text = "Ligne";
            this.ligneMenuItem.Click += new System.EventHandler(this.OutilMenuItem_Click);
            // 
            // rectangleMenuItem
            // 
            this.rectangleMenuItem.Name = "rectangleMenuItem";
            this.rectangleMenuItem.Size = new System.Drawing.Size(215, 26);
            this.rectangleMenuItem.Text = "Rectangle";
            this.rectangleMenuItem.Click += new System.EventHandler(this.OutilMenuItem_Click);
            // 
            // ellipseMenuItem
            // 
            this.ellipseMenuItem.Name = "ellipseMenuItem";
            this.ellipseMenuItem.Size = new System.Drawing.Size(215, 26);
            this.ellipseMenuItem.Text = "Ellipse";
            this.ellipseMenuItem.Click += new System.EventHandler(this.OutilMenuItem_Click);
            // 
            // epaisseurMenuItem
            // 
            this.epaisseurMenuItem.Name = "epaisseurMenuItem";
            this.epaisseurMenuItem.Size = new System.Drawing.Size(215, 26);
            this.epaisseurMenuItem.Text = "Épaisseur du trait...";
            this.epaisseurMenuItem.Click += new System.EventHandler(this.EpaisseurMenuItem_Click);
            // 
            // FenetrePrincipale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 626);
            this.Controls.Add(this.barreEtat);
            this.Controls.Add(this.zoneDessin);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FenetrePrincipale";
            this.Text = "Dessinateur";
            ((System.ComponentModel.ISupportInitialize)(this.zoneDessin)).EndInit();
            this.menuContextuel.ResumeLayout(false);
            this.barreEtat.ResumeLayout(false);
            this.barreEtat.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox zoneDessin;
        private System.Windows.Forms.StatusStrip barreEtat;
        private System.Windows.Forms.ContextMenuStrip menuContextuel;
        private System.Windows.Forms.ToolStripMenuItem couleurMenuItem;
        private System.Windows.Forms.ToolStripMenuItem augmenterTraitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diminuerTraitMenuItem;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem fichierMenu;
        private System.Windows.Forms.ToolStripMenuItem ouvrirMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outilsMenu;
        private System.Windows.Forms.ToolStripMenuItem ligneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem epaisseurMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel etatLabel;
    }
}

