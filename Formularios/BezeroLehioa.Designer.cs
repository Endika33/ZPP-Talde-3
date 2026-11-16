namespace ErronkaT3
{
    partial class BezeroLehioa
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
            lablIzena = new Label();
            lablId = new Label();
            lablMota = new Label();
            btnIzarak = new Button();
            btnEskuoihalak = new Button();
            button3 = new Button();
            btnJatetxea = new Button();
            btnCheckOut = new Button();
            lstMezuak = new ListBox();
            txtboId = new TextBox();
            txtboIzena = new TextBox();
            txtboMota = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lablIzena
            // 
            lablIzena.AutoSize = true;
            lablIzena.Font = new Font("Arial", 9.75F);
            lablIzena.Location = new Point(149, 20);
            lablIzena.Name = "lablIzena";
            lablIzena.Size = new Size(46, 16);
            lablIzena.TabIndex = 0;
            lablIzena.Text = "Izena: ";
            lablIzena.Click += label1_Click;
            // 
            // lablId
            // 
            lablId.AutoSize = true;
            lablId.Font = new Font("Arial", 9.75F);
            lablId.Location = new Point(22, 21);
            lablId.Name = "lablId";
            lablId.Size = new Size(21, 16);
            lablId.TabIndex = 1;
            lablId.Text = "Id:";
            // 
            // lablMota
            // 
            lablMota.AutoSize = true;
            lablMota.Font = new Font("Arial", 9.75F);
            lablMota.Location = new Point(315, 21);
            lablMota.Name = "lablMota";
            lablMota.Size = new Size(40, 16);
            lablMota.TabIndex = 2;
            lablMota.Text = "Mota:";
            // 
            // btnIzarak
            // 
            btnIzarak.BackColor = SystemColors.MenuHighlight;
            btnIzarak.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIzarak.ForeColor = SystemColors.ButtonHighlight;
            btnIzarak.Location = new Point(20, 75);
            btnIzarak.Name = "btnIzarak";
            btnIzarak.Size = new Size(111, 34);
            btnIzarak.TabIndex = 3;
            btnIzarak.Text = "Izarak";
            btnIzarak.UseVisualStyleBackColor = false;
            btnIzarak.Click += btnIzarak_Click;
            // 
            // btnEskuoihalak
            // 
            btnEskuoihalak.BackColor = SystemColors.MenuHighlight;
            btnEskuoihalak.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEskuoihalak.ForeColor = SystemColors.ButtonHighlight;
            btnEskuoihalak.Location = new Point(137, 75);
            btnEskuoihalak.Name = "btnEskuoihalak";
            btnEskuoihalak.Size = new Size(108, 34);
            btnEskuoihalak.TabIndex = 4;
            btnEskuoihalak.Text = "Eskuoihalak";
            btnEskuoihalak.UseVisualStyleBackColor = false;
            btnEskuoihalak.Click += btnEskuoihalak_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.MenuHighlight;
            button3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(365, 75);
            button3.Name = "button3";
            button3.RightToLeft = RightToLeft.No;
            button3.Size = new Size(111, 34);
            button3.TabIndex = 5;
            button3.Text = "Zaborra";
            button3.UseVisualStyleBackColor = false;
        
            // 
            // btnJatetxea
            // 
            btnJatetxea.BackColor = SystemColors.MenuHighlight;
            btnJatetxea.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnJatetxea.ForeColor = SystemColors.ButtonHighlight;
            btnJatetxea.Location = new Point(251, 75);
            btnJatetxea.Name = "btnJatetxea";
            btnJatetxea.Size = new Size(108, 34);
            btnJatetxea.TabIndex = 6;
            btnJatetxea.Text = "Jatetxea";
            btnJatetxea.UseVisualStyleBackColor = false;
            btnJatetxea.Click += btnJatetxea_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = SystemColors.MenuHighlight;
            btnCheckOut.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCheckOut.ForeColor = SystemColors.ButtonHighlight;
            btnCheckOut.Location = new Point(482, 75);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(111, 34);
            btnCheckOut.TabIndex = 7;
            btnCheckOut.Text = "Check-out";
            btnCheckOut.UseVisualStyleBackColor = false;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // lstMezuak
            // 
            lstMezuak.FormattingEnabled = true;
            lstMezuak.Location = new Point(20, 162);
            lstMezuak.Name = "lstMezuak";
            lstMezuak.Size = new Size(573, 169);
            lstMezuak.TabIndex = 8;
            lstMezuak.SelectedIndexChanged += lstMezuak_SelectedIndexChanged;
            // 
            // txtboId
            // 
            txtboId.Location = new Point(46, 17);
            txtboId.Name = "txtboId";
            txtboId.ReadOnly = true;
            txtboId.Size = new Size(82, 23);
            txtboId.TabIndex = 9;
            // 
            // txtboIzena
            // 
            txtboIzena.Location = new Point(193, 16);
            txtboIzena.Name = "txtboIzena";
            txtboIzena.ReadOnly = true;
            txtboIzena.Size = new Size(100, 23);
            txtboIzena.TabIndex = 10;
            // 
            // txtboMota
            // 
            txtboMota.Location = new Point(357, 17);
            txtboMota.Name = "txtboMota";
            txtboMota.ReadOnly = true;
            txtboMota.Size = new Size(116, 23);
            txtboMota.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 131);
            label1.Name = "label1";
            label1.Size = new Size(113, 16);
            label1.TabIndex = 12;
            label1.Text = "Jasotako mezuak:";
            // 
            // BezeroLehioa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 347);
            Controls.Add(label1);
            Controls.Add(txtboMota);
            Controls.Add(txtboIzena);
            Controls.Add(txtboId);
            Controls.Add(lstMezuak);
            Controls.Add(btnCheckOut);
            Controls.Add(btnJatetxea);
            Controls.Add(button3);
            Controls.Add(btnEskuoihalak);
            Controls.Add(btnIzarak);
            Controls.Add(lablMota);
            Controls.Add(lablId);
            Controls.Add(lablIzena);
            Name = "BezeroLehioa";
            Text = "BezeroLehioa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lablIzena;
        private Label lablId;
        private Label lablMota;
        private Button btnIzarak;
        private Button btnEskuoihalak;
        private Button button3;
        private Button btnJatetxea;
        private Button btnCheckOut;
        private ListBox lstMezuak;
        private TextBox txtboId;
        private TextBox txtboIzena;
        private TextBox txtboMota;
        private Label label1;
    }
}