using Microsoft.VisualBasic.Logging;

namespace ErronkaT3
{
    partial class EsportatuForm
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
            probintziaEtiketa = new Label();
            probintziaCombo = new ComboBox();
            herriaEtiketa = new Label();
            herriaCombo = new ComboBox();
            irteeraKarpeta = new Label();
            irteeraBox = new TextBox();
            arakatuB = new Button();
            esportatuB = new Button();
            karpetaIrekiB = new Button();
            itxiB = new Button();
            egoera = new Label();
            log = new TextBox();
            aurrerapena = new ProgressBar();
            formatuaEtiketa = new Label();
            formatuaCombo = new ComboBox();
            SuspendLayout();
            // 
            // titulua
            // 
            titulua.AutoSize = true;
            titulua.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titulua.Location = new Point(19, 21);
            titulua.Name = "titulua";
            titulua.Size = new Size(211, 29);
            titulua.TabIndex = 0;
            titulua.Text = "Datuak Esportatu";
            // 
            // probintziaEtiketa
            // 
            probintziaEtiketa.AutoSize = true;
            probintziaEtiketa.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            probintziaEtiketa.Location = new Point(23, 123);
            probintziaEtiketa.Name = "probintziaEtiketa";
            probintziaEtiketa.Size = new Size(73, 16);
            probintziaEtiketa.TabIndex = 1;
            probintziaEtiketa.Text = "Probintzia: ";
            // 
            // probintziaCombo
            // 
            probintziaCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            probintziaCombo.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            probintziaCombo.FormattingEnabled = true;
            probintziaCombo.Location = new Point(151, 119);
            probintziaCombo.Name = "probintziaCombo";
            probintziaCombo.Size = new Size(287, 24);
            probintziaCombo.TabIndex = 2;
            // 
            // herriaEtiketa
            // 
            herriaEtiketa.AutoSize = true;
            herriaEtiketa.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            herriaEtiketa.Location = new Point(25, 163);
            herriaEtiketa.Name = "herriaEtiketa";
            herriaEtiketa.Size = new Size(45, 16);
            herriaEtiketa.TabIndex = 3;
            herriaEtiketa.Text = "Herria:";
            // 
            // herriaCombo
            // 
            herriaCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            herriaCombo.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            herriaCombo.FormattingEnabled = true;
            herriaCombo.Location = new Point(151, 159);
            herriaCombo.Name = "herriaCombo";
            herriaCombo.Size = new Size(287, 24);
            herriaCombo.TabIndex = 4;
            // 
            // irteeraKarpeta
            // 
            irteeraKarpeta.AutoSize = true;
            irteeraKarpeta.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            irteeraKarpeta.Location = new Point(24, 204);
            irteeraKarpeta.Name = "irteeraKarpeta";
            irteeraKarpeta.Size = new Size(98, 16);
            irteeraKarpeta.TabIndex = 5;
            irteeraKarpeta.Text = "Irteera karpeta: ";
            // 
            // irteeraBox
            // 
            irteeraBox.Location = new Point(151, 199);
            irteeraBox.Name = "irteeraBox";
            irteeraBox.Size = new Size(287, 23);
            irteeraBox.TabIndex = 6;
            // 
            // arakatuB
            // 
            arakatuB.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            arakatuB.Location = new Point(444, 199);
            arakatuB.Name = "arakatuB";
            arakatuB.Size = new Size(36, 23);
            arakatuB.TabIndex = 7;
            arakatuB.Text = "...";
            arakatuB.UseVisualStyleBackColor = true;
            // 
            // esportatuB
            // 
            esportatuB.BackColor = SystemColors.Highlight;
            esportatuB.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            esportatuB.ForeColor = SystemColors.ControlLightLight;
            esportatuB.Location = new Point(374, 549);
            esportatuB.Name = "esportatuB";
            esportatuB.Size = new Size(113, 38);
            esportatuB.TabIndex = 8;
            esportatuB.Text = "Esportatu";
            esportatuB.UseVisualStyleBackColor = false;
            // 
            // karpetaIrekiB
            // 
            karpetaIrekiB.BackColor = SystemColors.Highlight;
            karpetaIrekiB.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            karpetaIrekiB.ForeColor = SystemColors.ControlLightLight;
            karpetaIrekiB.Location = new Point(252, 549);
            karpetaIrekiB.Name = "karpetaIrekiB";
            karpetaIrekiB.Size = new Size(113, 38);
            karpetaIrekiB.TabIndex = 9;
            karpetaIrekiB.Text = "Karpeta ireki";
            karpetaIrekiB.UseVisualStyleBackColor = false;
            // 
            // itxiB
            // 
            itxiB.BackColor = SystemColors.ButtonShadow;
            itxiB.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itxiB.Location = new Point(131, 549);
            itxiB.Name = "itxiB";
            itxiB.Size = new Size(113, 38);
            itxiB.TabIndex = 10;
            itxiB.Text = "Itzi";
            itxiB.UseVisualStyleBackColor = false;
            // 
            // egoera
            // 
            egoera.AutoSize = true;
            egoera.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            egoera.Location = new Point(22, 72);
            egoera.Name = "egoera";
            egoera.Size = new Size(174, 16);
            egoera.TabIndex = 11;
            egoera.Text = "Aukeratu probintzi eta herria.";
            // 
            // log
            // 
            log.BackColor = SystemColors.ControlLightLight;
            log.Location = new Point(21, 302);
            log.Multiline = true;
            log.Name = "log";
            log.ReadOnly = true;
            log.ScrollBars = ScrollBars.Vertical;
            log.Size = new Size(466, 195);
            log.TabIndex = 12;
            // 
            // aurrerapena
            // 
            aurrerapena.Location = new Point(23, 510);
            aurrerapena.Name = "aurrerapena";
            aurrerapena.Size = new Size(464, 18);
            aurrerapena.Style = ProgressBarStyle.Marquee;
            aurrerapena.TabIndex = 13;
            aurrerapena.Visible = false;
            // 
            // formatuaEtiketa
            // 
            formatuaEtiketa.AutoSize = true;
            formatuaEtiketa.Location = new Point(25, 250);
            formatuaEtiketa.Name = "formatuaEtiketa";
            formatuaEtiketa.Size = new Size(113, 15);
            formatuaEtiketa.TabIndex = 14;
            formatuaEtiketa.Text = "Aukeratu formatua: ";
            // 
            // formatuaCombo
            // 
            formatuaCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            formatuaCombo.FormattingEnabled = true;
            formatuaCombo.Location = new Point(151, 245);
            formatuaCombo.Name = "formatuaCombo";
            formatuaCombo.Size = new Size(287, 23);
            formatuaCombo.TabIndex = 15;
            // 
            // EsportatuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 607);
            Controls.Add(formatuaCombo);
            Controls.Add(formatuaEtiketa);
            Controls.Add(aurrerapena);
            Controls.Add(log);
            Controls.Add(egoera);
            Controls.Add(itxiB);
            Controls.Add(karpetaIrekiB);
            Controls.Add(esportatuB);
            Controls.Add(arakatuB);
            Controls.Add(irteeraBox);
            Controls.Add(irteeraKarpeta);
            Controls.Add(herriaCombo);
            Controls.Add(herriaEtiketa);
            Controls.Add(probintziaCombo);
            Controls.Add(probintziaEtiketa);
            Controls.Add(titulua);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EsportatuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Esportatu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titulua;
        private Label probintziaEtiketa;
        private ComboBox probintziaCombo;
        private Label herriaEtiketa;
        private ComboBox herriaCombo;
        private Label irteeraKarpeta;
        private TextBox irteeraBox;
        private Button arakatuB;
        private Button esportatuB;
        private Button karpetaIrekiB;
        private Button itxiB;
        private Label egoera;
        private TextBox log;
        private ProgressBar aurrerapena;
        private Label formatuaEtiketa;
        private ComboBox formatuaCombo;
    }
}