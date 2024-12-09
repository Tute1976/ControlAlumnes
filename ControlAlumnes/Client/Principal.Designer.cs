namespace ControlAlumnes.Client
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
            this.taula = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodi = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.bConnectar = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.iconaBarra = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerBatex = new System.Windows.Forms.Timer(this.components);
            this.taula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // taula
            // 
            this.taula.ColumnCount = 5;
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.taula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.taula.Controls.Add(this.label1, 2, 1);
            this.taula.Controls.Add(this.label2, 2, 2);
            this.taula.Controls.Add(this.txtCodi, 3, 1);
            this.taula.Controls.Add(this.txtNom, 2, 3);
            this.taula.Controls.Add(this.bConnectar, 2, 5);
            this.taula.Controls.Add(this.pbLogo, 0, 0);
            this.taula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taula.Location = new System.Drawing.Point(10, 10);
            this.taula.Name = "taula";
            this.taula.RowCount = 7;
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.taula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.taula.Size = new System.Drawing.Size(692, 268);
            this.taula.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(129, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(129, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom";
            // 
            // txtCodi
            // 
            this.txtCodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodi.Location = new System.Drawing.Point(223, 35);
            this.txtCodi.Name = "txtCodi";
            this.txtCodi.Size = new System.Drawing.Size(402, 26);
            this.txtCodi.TabIndex = 2;
            this.txtCodi.TextChanged += new System.EventHandler(this.Textes_TextChanged);
            // 
            // txtNom
            // 
            this.taula.SetColumnSpan(this.txtNom, 2);
            this.txtNom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNom.Location = new System.Drawing.Point(129, 99);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(496, 26);
            this.txtNom.TabIndex = 3;
            this.txtNom.TextChanged += new System.EventHandler(this.Textes_TextChanged);
            // 
            // bConnectar
            // 
            this.taula.SetColumnSpan(this.bConnectar, 2);
            this.bConnectar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bConnectar.Enabled = false;
            this.bConnectar.Location = new System.Drawing.Point(129, 151);
            this.bConnectar.Name = "bConnectar";
            this.bConnectar.Size = new System.Drawing.Size(496, 42);
            this.bConnectar.TabIndex = 4;
            this.bConnectar.Text = "Connectar";
            this.bConnectar.UseVisualStyleBackColor = true;
            this.bConnectar.Click += new System.EventHandler(this.BConnectar_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = global::ControlAlumnes.Client.Properties.Resources.Logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pbLogo.Name = "pbLogo";
            this.taula.SetRowSpan(this.pbLogo, 2);
            this.pbLogo.Size = new System.Drawing.Size(43, 43);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 5;
            this.pbLogo.TabStop = false;
            // 
            // iconaBarra
            // 
            this.iconaBarra.Icon = ((System.Drawing.Icon)(resources.GetObject("iconaBarra.Icon")));
            this.iconaBarra.Text = "Connectat";
            this.iconaBarra.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IconaBarra_MouseDoubleClick);
            // 
            // timerBatex
            // 
            this.timerBatex.Interval = 30000;
            this.timerBatex.Tick += new System.EventHandler(this.TimerBatex_Tick);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 288);
            this.Controls.Add(this.taula);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control d\'alumnes";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.taula.ResumeLayout(false);
            this.taula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel taula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodi;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Button bConnectar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.NotifyIcon iconaBarra;
        private System.Windows.Forms.Timer timerBatex;
    }
}

