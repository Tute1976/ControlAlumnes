﻿namespace ControlAlumnes.Control
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.llista = new System.Windows.Forms.ListView();
            this.cEstacio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cNom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cAdreca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTemps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imatges = new System.Windows.Forms.ImageList(this.components);
            this.barraEstat = new System.Windows.Forms.StatusStrip();
            this.barraBotons = new System.Windows.Forms.ToolStrip();
            this.botoTancar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.botoIniciarAturar = new System.Windows.Forms.ToolStripButton();
            this.lCodi = new System.Windows.Forms.ToolStripLabel();
            this.cbCodi = new System.Windows.Forms.ToolStripComboBox();
            this.split = new System.Windows.Forms.SplitContainer();
            this.events = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barraBotons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.SuspendLayout();
            // 
            // llista
            // 
            this.llista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cEstacio,
            this.cNom,
            this.cAdreca,
            this.cTemps});
            this.llista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llista.HideSelection = false;
            this.llista.LargeImageList = this.imatges;
            this.llista.Location = new System.Drawing.Point(0, 0);
            this.llista.Margin = new System.Windows.Forms.Padding(6);
            this.llista.Name = "llista";
            this.llista.Size = new System.Drawing.Size(600, 477);
            this.llista.SmallImageList = this.imatges;
            this.llista.TabIndex = 0;
            this.llista.UseCompatibleStateImageBehavior = false;
            this.llista.View = System.Windows.Forms.View.Details;
            // 
            // cEstacio
            // 
            this.cEstacio.Text = "Estació";
            this.cEstacio.Width = 100;
            // 
            // cNom
            // 
            this.cNom.Text = "Nom";
            this.cNom.Width = 150;
            // 
            // cAdreca
            // 
            this.cAdreca.Text = "Adreça";
            this.cAdreca.Width = 100;
            // 
            // cTemps
            // 
            this.cTemps.Text = "Temps";
            this.cTemps.Width = 150;
            // 
            // imatges
            // 
            this.imatges.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imatges.ImageStream")));
            this.imatges.TransparentColor = System.Drawing.Color.Transparent;
            this.imatges.Images.SetKeyName(0, "Estacio_Blau.png");
            this.imatges.Images.SetKeyName(1, "Estacio_Verd.png");
            this.imatges.Images.SetKeyName(2, "Estacio_Buida.png");
            this.imatges.Images.SetKeyName(3, "Estacio_Vermell.png");
            // 
            // barraEstat
            // 
            this.barraEstat.GripMargin = new System.Windows.Forms.Padding(5);
            this.barraEstat.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.barraEstat.Location = new System.Drawing.Point(0, 518);
            this.barraEstat.Name = "barraEstat";
            this.barraEstat.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.barraEstat.Size = new System.Drawing.Size(904, 22);
            this.barraEstat.SizingGrip = false;
            this.barraEstat.TabIndex = 1;
            this.barraEstat.Text = "statusStrip1";
            // 
            // barraBotons
            // 
            this.barraBotons.GripMargin = new System.Windows.Forms.Padding(5);
            this.barraBotons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.barraBotons.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.barraBotons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botoTancar,
            this.toolStripSeparator1,
            this.botoIniciarAturar,
            this.lCodi,
            this.cbCodi});
            this.barraBotons.Location = new System.Drawing.Point(0, 0);
            this.barraBotons.Name = "barraBotons";
            this.barraBotons.Size = new System.Drawing.Size(904, 41);
            this.barraBotons.TabIndex = 2;
            this.barraBotons.Text = "toolStrip1";
            // 
            // botoTancar
            // 
            this.botoTancar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botoTancar.Image = global::ControlAlumnes.Control.Properties.Resources.Logout;
            this.botoTancar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botoTancar.Name = "botoTancar";
            this.botoTancar.Size = new System.Drawing.Size(36, 36);
            this.botoTancar.Text = "Tancar";
            this.botoTancar.Click += new System.EventHandler(this.BotoTancar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // botoIniciarAturar
            // 
            this.botoIniciarAturar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botoIniciarAturar.Enabled = false;
            this.botoIniciarAturar.Image = global::ControlAlumnes.Control.Properties.Resources.Media_Play;
            this.botoIniciarAturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botoIniciarAturar.Name = "botoIniciarAturar";
            this.botoIniciarAturar.Size = new System.Drawing.Size(36, 36);
            this.botoIniciarAturar.Tag = false;
            this.botoIniciarAturar.Text = "Iniciar";
            this.botoIniciarAturar.Click += new System.EventHandler(this.BotoIniciarAturar_Click);
            // 
            // lCodi
            // 
            this.lCodi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lCodi.AutoSize = false;
            this.lCodi.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCodi.Margin = new System.Windows.Forms.Padding(20, 2, 0, 3);
            this.lCodi.Name = "lCodi";
            this.lCodi.Size = new System.Drawing.Size(100, 36);
            this.lCodi.Text = "???";
            // 
            // cbCodi
            // 
            this.cbCodi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbCodi.DropDownWidth = 300;
            this.cbCodi.Name = "cbCodi";
            this.cbCodi.Size = new System.Drawing.Size(300, 41);
            this.cbCodi.Sorted = true;
            this.cbCodi.ToolTipText = "Codi de connexió";
            this.cbCodi.TextChanged += new System.EventHandler(this.CbCodi_TextChanged);
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 41);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.llista);
            this.split.Panel1MinSize = 600;
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.events);
            this.split.Panel2MinSize = 300;
            this.split.Size = new System.Drawing.Size(904, 477);
            this.split.SplitterDistance = 600;
            this.split.TabIndex = 3;
            // 
            // events
            // 
            this.events.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.events.Dock = System.Windows.Forms.DockStyle.Fill;
            this.events.HideSelection = false;
            this.events.LargeImageList = this.imatges;
            this.events.Location = new System.Drawing.Point(0, 0);
            this.events.Name = "events";
            this.events.Size = new System.Drawing.Size(300, 477);
            this.events.SmallImageList = this.imatges;
            this.events.TabIndex = 0;
            this.events.UseCompatibleStateImageBehavior = false;
            this.events.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Estació";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Temps";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 200;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Estacio_Blau.png");
            this.imageList1.Images.SetKeyName(1, "Estacio_Verd.png");
            this.imageList1.Images.SetKeyName(2, "Estacio_Buida.png");
            this.imageList1.Images.SetKeyName(3, "Estacio_Vermell.png");
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 540);
            this.Controls.Add(this.split);
            this.Controls.Add(this.barraBotons);
            this.Controls.Add(this.barraEstat);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPrincipal";
            this.Text = "Control de connexions";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.barraBotons.ResumeLayout(false);
            this.barraBotons.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView llista;
        private System.Windows.Forms.ColumnHeader cEstacio;
        private System.Windows.Forms.ColumnHeader cAdreca;
        private System.Windows.Forms.ColumnHeader cTemps;
        private System.Windows.Forms.ImageList imatges;
        private System.Windows.Forms.StatusStrip barraEstat;
        private System.Windows.Forms.ToolStrip barraBotons;
        private System.Windows.Forms.ToolStripButton botoTancar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton botoIniciarAturar;
        private System.Windows.Forms.ColumnHeader cNom;
        private System.Windows.Forms.ToolStripComboBox cbCodi;
        private System.Windows.Forms.ToolStripLabel lCodi;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.ListView events;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
    }
}

