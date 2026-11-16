namespace ErronkaT3
{
    partial class FormMezua
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
            txtMezua = new TextBox();
            lablCont = new Label();
            btnBidali = new Button();
            btnUtzi = new Button();
            SuspendLayout();
            // 
            // lablIzena
            // 
            lablIzena.AutoSize = true;
            lablIzena.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lablIzena.Location = new Point(26, 33);
            lablIzena.Name = "lablIzena";
            lablIzena.Size = new Size(83, 19);
            lablIzena.TabIndex = 0;
            lablIzena.Text = "Bezeroa: ";
            // 
            // txtMezua
            // 
            txtMezua.Location = new Point(26, 69);
            txtMezua.MaxLength = 1000;
            txtMezua.Multiline = true;
            txtMezua.Name = "txtMezua";
            txtMezua.ScrollBars = ScrollBars.Vertical;
            txtMezua.Size = new Size(402, 127);
            txtMezua.TabIndex = 1;
            txtMezua.TextChanged += txtMezua_TextChanged;
            // 
            // lablCont
            // 
            lablCont.AutoSize = true;
            lablCont.Location = new Point(29, 213);
            lablCont.Name = "lablCont";
            lablCont.Size = new Size(42, 15);
            lablCont.TabIndex = 2;
            lablCont.Text = "0/1000";
            // 
            // btnBidali
            // 
            btnBidali.BackColor = Color.DodgerBlue;
            btnBidali.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBidali.ForeColor = Color.Cornsilk;
            btnBidali.Location = new Point(333, 230);
            btnBidali.Name = "btnBidali";
            btnBidali.Size = new Size(99, 32);
            btnBidali.TabIndex = 3;
            btnBidali.Text = "Bidali";
            btnBidali.UseVisualStyleBackColor = false;
            btnBidali.Click += btnBidali_Click;
            // 
            // btnUtzi
            // 
            btnUtzi.BackColor = Color.Silver;
            btnUtzi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUtzi.ForeColor = Color.Black;
            btnUtzi.Location = new Point(225, 230);
            btnUtzi.Name = "btnUtzi";
            btnUtzi.Size = new Size(99, 32);
            btnUtzi.TabIndex = 4;
            btnUtzi.Text = "Utzi";
            btnUtzi.UseVisualStyleBackColor = false;
            btnUtzi.Click += button2_Click;
            // 
            // FormMezua
            // 
            AcceptButton = btnBidali;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnUtzi;
            ClientSize = new Size(463, 284);
            Controls.Add(btnUtzi);
            Controls.Add(btnBidali);
            Controls.Add(lablCont);
            Controls.Add(txtMezua);
            Controls.Add(lablIzena);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMezua";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mezua bidali ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lablIzena;
        private TextBox txtMezua;
        private Label lablCont;
        private Button btnBidali;
        private Button btnUtzi;
    }
}