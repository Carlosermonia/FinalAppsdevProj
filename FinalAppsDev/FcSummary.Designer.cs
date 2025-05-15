namespace finalAppsDevProject
{
    partial class FcSummary
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
            panel1 = new Panel();
            label1 = new Label();
            Bck_btn = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ProductType = new Label();
            UnitSize = new Label();
            Tpctxt = new Label();
            SrpTxt = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Bck_btn).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Bck_btn);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(886, 99);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Copperplate Gothic Bold", 24F);
            label1.Location = new Point(27, 33);
            label1.Name = "label1";
            label1.Size = new Size(334, 44);
            label1.TabIndex = 1;
            label1.Text = "Product Cost";
            label1.Click += label1_Click;
            // 
            // Bck_btn
            // 
            Bck_btn.BackgroundImage = Properties.Resources.backbar;
            Bck_btn.BackgroundImageLayout = ImageLayout.Stretch;
            Bck_btn.Location = new Point(775, 3);
            Bck_btn.Name = "Bck_btn";
            Bck_btn.Size = new Size(99, 46);
            Bck_btn.TabIndex = 0;
            Bck_btn.TabStop = false;
            Bck_btn.Click += Bck_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Copperplate Gothic Bold", 24F);
            label2.Location = new Point(12, 131);
            label2.Name = "label2";
            label2.Size = new Size(338, 44);
            label2.TabIndex = 2;
            label2.Text = "Product Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Copperplate Gothic Bold", 24F);
            label3.Location = new Point(12, 205);
            label3.Name = "label3";
            label3.Size = new Size(230, 44);
            label3.TabIndex = 3;
            label3.Text = "Unit Size:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Copperplate Gothic Bold", 24F);
            label4.Location = new Point(12, 288);
            label4.Name = "label4";
            label4.Size = new Size(486, 44);
            label4.TabIndex = 4;
            label4.Text = "Total Product Cost:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Copperplate Gothic Bold", 24F);
            label5.Location = new Point(12, 374);
            label5.Name = "label5";
            label5.Size = new Size(113, 44);
            label5.TabIndex = 5;
            label5.Text = "Srp:";
            label5.Click += label5_Click;
            // 
            // ProductType
            // 
            ProductType.AutoSize = true;
            ProductType.BackColor = Color.Transparent;
            ProductType.Font = new Font("Copperplate Gothic Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductType.Location = new Point(356, 140);
            ProductType.Name = "ProductType";
            ProductType.Size = new Size(237, 32);
            ProductType.TabIndex = 6;
            ProductType.Text = "Product Type";
            // 
            // UnitSize
            // 
            UnitSize.AutoSize = true;
            UnitSize.BackColor = Color.Transparent;
            UnitSize.Font = new Font("Copperplate Gothic Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UnitSize.Location = new Point(248, 214);
            UnitSize.Name = "UnitSize";
            UnitSize.Size = new Size(156, 32);
            UnitSize.TabIndex = 7;
            UnitSize.Text = "Unit Size";
            // 
            // Tpctxt
            // 
            Tpctxt.AutoSize = true;
            Tpctxt.BackColor = Color.Transparent;
            Tpctxt.Font = new Font("Copperplate Gothic Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tpctxt.Location = new Point(494, 297);
            Tpctxt.Name = "Tpctxt";
            Tpctxt.Size = new Size(81, 32);
            Tpctxt.TabIndex = 8;
            Tpctxt.Text = "TPC";
            // 
            // SrpTxt
            // 
            SrpTxt.AutoSize = true;
            SrpTxt.BackColor = Color.Transparent;
            SrpTxt.Font = new Font("Copperplate Gothic Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SrpTxt.Location = new Point(131, 383);
            SrpTxt.Name = "SrpTxt";
            SrpTxt.Size = new Size(81, 32);
            SrpTxt.TabIndex = 9;
            SrpTxt.Text = "SRP";
            // 
            // FcSummary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._1bckground1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(887, 489);
            Controls.Add(SrpTxt);
            Controls.Add(Tpctxt);
            Controls.Add(UnitSize);
            Controls.Add(ProductType);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FcSummary";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FcSummary";
            Load += FcSummary_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Bck_btn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox Bck_btn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        public Label ProductType;
        public Label UnitSize;
        public Label Tpctxt;
        public Label SrpTxt;
    }
}