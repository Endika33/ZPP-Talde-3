namespace ErronkaT3
{
    partial class InportatuForm
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
            titulua = new Label();
            azalpena = new Label();
            fitxategiak = new Label();
            inportatuB = new Button();
            itxiB = new Button();
            aurrerapena = new ProgressBar();
            log = new TextBox();
            egoera = new Label();
            SuspendLayout();
            // 
            // titulua
            // 
            titulua.AutoSize = true;
            titulua.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titulua.Location = new Point(17, 35);
            titulua.Name = "titulua";
            titulua.Size = new Size(204, 29);
            titulua.TabIndex = 0;
            titulua.Text = "Datuak Inportatu";
            // 
            // azalpena
            // 
            azalpena.Location = new Point(21, 80);
            azalpena.Name = "azalpena";
            azalpena.Size = new Size(402, 36);
            azalpena.TabIndex = 1;
            azalpena.Text = "Kanpinen eta bezeroen XML fitxategiak Oracle datu-basera inportatuko dira (Java programarekin).";
            // 
            // fitxategiak
            // 
            fitxategiak.Location = new Point(21, 128);
            fitxategiak.Name = "fitxategiak";
            fitxategiak.Size = new Size(410, 83);
            fitxategiak.TabIndex = 2;
            // 
            // inportatuB
            // 
            inportatuB.BackColor = SystemColors.Highlight;
            inportatuB.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inportatuB.ForeColor = Color.White;
            inportatuB.Location = new Point(328, 494);
            inportatuB.Name = "inportatuB";
            inportatuB.Size = new Size(106, 41);
            inportatuB.TabIndex = 3;
            inportatuB.Text = "Inportatu";
            inportatuB.UseVisualStyleBackColor = false;
            // 
            // itxiB
            // 
            itxiB.BackColor = SystemColors.AppWorkspace;
            itxiB.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itxiB.Location = new Point(209, 495);
            itxiB.Name = "itxiB";
            itxiB.Size = new Size(106, 39);
            itxiB.TabIndex = 4;
            itxiB.Text = "Itzi";
            itxiB.UseVisualStyleBackColor = false;
            // 
            // aurrerapena
            // 
            aurrerapena.Location = new Point(21, 455);
            aurrerapena.Name = "aurrerapena";
            aurrerapena.Size = new Size(410, 16);
            aurrerapena.Style = ProgressBarStyle.Marquee;
            aurrerapena.TabIndex = 5;
            aurrerapena.Visible = false;
            // 
            // log
            // 
            log.Location = new Point(21, 227);
            log.Multiline = true;
            log.Name = "log";
            log.Size = new Size(410, 195);
            log.TabIndex = 6;
            // 
            // egoera
            // 
            egoera.AutoSize = true;
            egoera.Location = new Point(25, 431);
            egoera.Name = "egoera";
            egoera.Size = new Size(0, 15);
            egoera.TabIndex = 7;
            // 
            // InportatuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 555);
            Controls.Add(egoera);
            Controls.Add(log);
            Controls.Add(aurrerapena);
            Controls.Add(itxiB);
            Controls.Add(inportatuB);
            Controls.Add(fitxategiak);
            Controls.Add(azalpena);
            Controls.Add(titulua);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InportatuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Datuak inportatu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titulua;
        private Label azalpena;
        private Label fitxategiak;
        private Button inportatuB;
        private Button itxiB;
        private ProgressBar aurrerapena;
        private TextBox log;
        private Label egoera;
    }
}