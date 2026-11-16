namespace ErronkaT3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            btnLanaldiaBukatu = new Button();
            button8 = new Button();
            button7 = new Button();
            Datuak = new Label();
            panel3 = new Panel();
            btnLanaldiaHasi = new Button();
            label2 = new Label();
            label1 = new Label();
            Perfil = new PictureBox();
            button5 = new Button();
            button6 = new Button();
            panel2 = new Panel();
            lblBezeroak = new Label();
            dgvBezeroak = new DataGridView();
            label3 = new Label();
            dgvEskaerak = new DataGridView();
            panel4 = new Panel();
            bezeroBerria = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Perfil).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBezeroak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEskaerak).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnLanaldiaBukatu);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(Datuak);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(btnLanaldiaHasi);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Perfil);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 679);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint_2;
            // 
            // btnLanaldiaBukatu
            // 
            btnLanaldiaBukatu.BackColor = Color.LightSalmon;
            btnLanaldiaBukatu.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLanaldiaBukatu.Location = new Point(28, 201);
            btnLanaldiaBukatu.Name = "btnLanaldiaBukatu";
            btnLanaldiaBukatu.Size = new Size(174, 29);
            btnLanaldiaBukatu.TabIndex = 14;
            btnLanaldiaBukatu.Text = "Lanaldia bukatu";
            btnLanaldiaBukatu.TextAlign = ContentAlignment.MiddleLeft;
            btnLanaldiaBukatu.UseVisualStyleBackColor = false;
            btnLanaldiaBukatu.Click += button2_Click;
            // 
            // button8
            // 
            button8.BackColor = SystemColors.ControlDark;
            button8.FlatAppearance.BorderSize = 0;
            button8.Font = new Font("Arial", 12F);
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Location = new Point(45, 399);
            button8.Name = "button8";
            button8.Size = new Size(175, 36);
            button8.TabIndex = 13;
            button8.Text = "Esportatu";
            button8.TextAlign = ContentAlignment.MiddleLeft;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.ControlDark;
            button7.FlatAppearance.BorderSize = 0;
            button7.Font = new Font("Arial", 12F);
            button7.ForeColor = SystemColors.ControlLightLight;
            button7.Location = new Point(45, 350);
            button7.Name = "button7";
            button7.Size = new Size(175, 37);
            button7.TabIndex = 12;
            button7.Text = "Inportatu";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = false;
            // 
            // Datuak
            // 
            Datuak.AutoSize = true;
            Datuak.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Datuak.ForeColor = SystemColors.ControlLightLight;
            Datuak.ImageAlign = ContentAlignment.MiddleLeft;
            Datuak.Location = new Point(23, 301);
            Datuak.Name = "Datuak";
            Datuak.Size = new Size(183, 24);
            Datuak.TabIndex = 11;
            Datuak.Text = "Datuen Kudeaketa";
            Datuak.Click += Datuak_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Location = new Point(14, 283);
            panel3.Name = "panel3";
            panel3.Size = new Size(201, 1);
            panel3.TabIndex = 10;
            // 
            // btnLanaldiaHasi
            // 
            btnLanaldiaHasi.BackColor = Color.YellowGreen;
            btnLanaldiaHasi.FlatAppearance.BorderSize = 0;
            btnLanaldiaHasi.Font = new Font("Arial", 12F);
            btnLanaldiaHasi.ForeColor = SystemColors.ControlText;
            btnLanaldiaHasi.Location = new Point(27, 156);
            btnLanaldiaHasi.Name = "btnLanaldiaHasi";
            btnLanaldiaHasi.Size = new Size(175, 29);
            btnLanaldiaHasi.TabIndex = 14;
            btnLanaldiaHasi.Text = "Lanaldia hasi";
            btnLanaldiaHasi.TextAlign = ContentAlignment.MiddleLeft;
            btnLanaldiaHasi.UseVisualStyleBackColor = false;
            btnLanaldiaHasi.Click += btnLanaldiaHasi_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(41, 106);
            label2.Name = "label2";
            label2.Size = new Size(62, 13);
            label2.TabIndex = 2;
            label2.Text = "Idazkaritza";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(109, 46);
            label1.Name = "label1";
            label1.Size = new Size(92, 24);
            label1.TabIndex = 1;
            label1.Text = "Euskanp";
            label1.Click += label1_Click;
            // 
            // Perfil
            // 
            Perfil.Image = (Image)resources.GetObject("Perfil.Image");
            Perfil.Location = new Point(45, 47);
            Perfil.Name = "Perfil";
            Perfil.Size = new Size(52, 50);
            Perfil.SizeMode = PictureBoxSizeMode.StretchImage;
            Perfil.TabIndex = 0;
            Perfil.TabStop = false;
            Perfil.Click += Perfil_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.DodgerBlue;
            button5.FlatAppearance.BorderSize = 0;
            button5.Font = new Font("Arial", 12F);
            button5.ForeColor = SystemColors.ControlLightLight;
            button5.Location = new Point(241, 34);
            button5.Name = "button5";
            button5.Size = new Size(175, 29);
            button5.TabIndex = 8;
            button5.Text = "Mezuak";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // button6
            // 
            button6.BackColor = Color.Orange;
            button6.FlatAppearance.BorderSize = 0;
            button6.Font = new Font("Arial", 12F);
            button6.ForeColor = SystemColors.ControlLightLight;
            button6.Location = new Point(447, 34);
            button6.Name = "button6";
            button6.Size = new Size(175, 29);
            button6.TabIndex = 9;
            button6.Text = "Bideojokoa";
            button6.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(lblBezeroak);
            panel2.Controls.Add(dgvBezeroak);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dgvEskaerak);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(255, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1072, 679);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // lblBezeroak
            // 
            lblBezeroak.AutoSize = true;
            lblBezeroak.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBezeroak.Location = new Point(715, 98);
            lblBezeroak.Name = "lblBezeroak";
            lblBezeroak.Size = new Size(112, 27);
            lblBezeroak.TabIndex = 11;
            lblBezeroak.Text = "Bezeroak";
            lblBezeroak.Click += label4_Click;
            // 
            // dgvBezeroak
            // 
            dgvBezeroak.AllowUserToAddRows = false;
            dgvBezeroak.AllowUserToResizeColumns = false;
            dgvBezeroak.AllowUserToResizeRows = false;
            dgvBezeroak.BackgroundColor = SystemColors.ControlLightLight;
            dgvBezeroak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBezeroak.Location = new Point(454, 127);
            dgvBezeroak.MultiSelect = false;
            dgvBezeroak.Name = "dgvBezeroak";
            dgvBezeroak.ReadOnly = true;
            dgvBezeroak.ScrollBars = ScrollBars.Vertical;
            dgvBezeroak.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBezeroak.Size = new Size(617, 550);
            dgvBezeroak.TabIndex = 3;
            dgvBezeroak.CellContentClick += dgvBezeroak_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(109, 99);
            label3.Name = "label3";
            label3.Size = new Size(217, 27);
            label3.TabIndex = 10;
            label3.Text = "Bezeroen eskaerak";
            // 
            // dgvEskaerak
            // 
            dgvEskaerak.AllowUserToAddRows = false;
            dgvEskaerak.BackgroundColor = SystemColors.ButtonHighlight;
            dgvEskaerak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEskaerak.GridColor = SystemColors.MenuHighlight;
            dgvEskaerak.Location = new Point(0, 128);
            dgvEskaerak.Name = "dgvEskaerak";
            dgvEskaerak.ReadOnly = true;
            dgvEskaerak.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEskaerak.Size = new Size(439, 550);
            dgvEskaerak.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(bezeroBerria);
            panel4.Controls.Add(button5);
            panel4.Controls.Add(button6);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1083, 82);
            panel4.TabIndex = 0;
            // 
            // bezeroBerria
            // 
            bezeroBerria.BackColor = Color.Azure;
            bezeroBerria.FlatAppearance.BorderSize = 0;
            bezeroBerria.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bezeroBerria.Location = new Point(31, 34);
            bezeroBerria.Name = "bezeroBerria";
            bezeroBerria.Size = new Size(175, 29);
            bezeroBerria.TabIndex = 9;
            bezeroBerria.Text = "Bezero berria";
            bezeroBerria.UseVisualStyleBackColor = false;
            bezeroBerria.Click += button10_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 679);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Idazkaritza";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Perfil).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBezeroak).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEskaerak).EndInit();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox Perfil;
        private Panel panel2;
        private Label label1;
        private Button EskaeraZerrendaB;
        private Label label2;
        private Button btnLanaldiaHasi;
        private Button button6;
        private Button button5;
        private Panel panel3;
        private Button button8;
        private Button button7;
        private Label Datuak;
        private Panel panel4;
        private Button button11;
        private Button bezeroBerria;
        private Button button9;
        private DataGridView dgvEskaerak;
        private Button btnLanaldiaBukatu;
        private Label label3;
        private DataGridView dgvBezeroak;
        private Label lblBezeroak;
    }
}
