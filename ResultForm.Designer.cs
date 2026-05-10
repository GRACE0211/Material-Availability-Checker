namespace Material_Availability_Checker
{
    partial class ResultForm
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
            components = new System.ComponentModel.Container();
            dgvResult = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label8 = new Label();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            panel2 = new Panel();
            lblStatus = new Label();
            label7 = new Label();
            lblNetQty = new Label();
            lblAvailableQty = new Label();
            lblPurchaseQty = new Label();
            lblInventoryQty = new Label();
            lblDemandQty = new Label();
            lblMaterialId = new Label();
            dgvLotDetails = new DataGridView();
            label6 = new Label();
            label1 = new Label();
            label5 = new Label();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLotDetails).BeginInit();
            SuspendLayout();
            // 
            // dgvResult
            // 
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Location = new Point(6, 106);
            dgvResult.Name = "dgvResult";
            dgvResult.Size = new Size(911, 357);
            dgvResult.TabIndex = 0;
            dgvResult.CellDoubleClick += dgvResult_CellDoubleClick;
            dgvResult.CellFormatting += dgvResult_CellFormatting;
            dgvResult.CellToolTipTextNeeded += dgvResult_CellToolTipTextNeeded;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("微軟正黑體", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(933, 567);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(dgvResult);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(925, 535);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "材料分析結果";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(8, 83);
            label8.Name = "label8";
            label8.Size = new Size(208, 20);
            label8.TabIndex = 1;
            label8.Text = "*雙擊資料列可查看材料明細";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Font = new Font("微軟正黑體", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(925, 535);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "材料明細頁";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(919, 529);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblStatus);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(lblNetQty);
            panel2.Controls.Add(lblAvailableQty);
            panel2.Controls.Add(lblPurchaseQty);
            panel2.Controls.Add(lblInventoryQty);
            panel2.Controls.Add(lblDemandQty);
            panel2.Controls.Add(lblMaterialId);
            panel2.Controls.Add(dgvLotDetails);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(919, 529);
            panel2.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lblStatus.Location = new Point(133, 255);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(13, 20);
            lblStatus.TabIndex = 15;
            lblStatus.Text = " ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("微軟正黑體", 12F);
            label7.Location = new Point(82, 255);
            label7.Name = "label7";
            label7.Size = new Size(45, 20);
            label7.TabIndex = 14;
            label7.Text = "狀態:";
            // 
            // lblNetQty
            // 
            lblNetQty.AutoSize = true;
            lblNetQty.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lblNetQty.Location = new Point(129, 226);
            lblNetQty.Name = "lblNetQty";
            lblNetQty.Size = new Size(13, 20);
            lblNetQty.TabIndex = 13;
            lblNetQty.Text = " ";
            // 
            // lblAvailableQty
            // 
            lblAvailableQty.AutoSize = true;
            lblAvailableQty.Font = new Font("微軟正黑體", 12F);
            lblAvailableQty.Location = new Point(165, 197);
            lblAvailableQty.Name = "lblAvailableQty";
            lblAvailableQty.Size = new Size(13, 20);
            lblAvailableQty.TabIndex = 12;
            lblAvailableQty.Text = " ";
            // 
            // lblPurchaseQty
            // 
            lblPurchaseQty.AutoSize = true;
            lblPurchaseQty.Font = new Font("微軟正黑體", 12F);
            lblPurchaseQty.Location = new Point(165, 166);
            lblPurchaseQty.Name = "lblPurchaseQty";
            lblPurchaseQty.Size = new Size(13, 20);
            lblPurchaseQty.TabIndex = 11;
            lblPurchaseQty.Text = " ";
            // 
            // lblInventoryQty
            // 
            lblInventoryQty.AutoSize = true;
            lblInventoryQty.Font = new Font("微軟正黑體", 12F);
            lblInventoryQty.Location = new Point(165, 136);
            lblInventoryQty.Name = "lblInventoryQty";
            lblInventoryQty.Size = new Size(13, 20);
            lblInventoryQty.TabIndex = 10;
            lblInventoryQty.Text = " ";
            // 
            // lblDemandQty
            // 
            lblDemandQty.AutoSize = true;
            lblDemandQty.Font = new Font("微軟正黑體", 12F);
            lblDemandQty.Location = new Point(165, 106);
            lblDemandQty.Name = "lblDemandQty";
            lblDemandQty.Size = new Size(13, 20);
            lblDemandQty.TabIndex = 9;
            lblDemandQty.Text = " ";
            // 
            // lblMaterialId
            // 
            lblMaterialId.AutoSize = true;
            lblMaterialId.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lblMaterialId.Location = new Point(133, 77);
            lblMaterialId.Name = "lblMaterialId";
            lblMaterialId.Size = new Size(13, 20);
            lblMaterialId.TabIndex = 8;
            lblMaterialId.Text = " ";
            // 
            // dgvLotDetails
            // 
            dgvLotDetails.BorderStyle = BorderStyle.Fixed3D;
            dgvLotDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLotDetails.Location = new Point(268, 60);
            dgvLotDetails.Name = "dgvLotDetails";
            dgvLotDetails.Size = new Size(558, 230);
            dgvLotDetails.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("微軟正黑體", 12F);
            label6.Location = new Point(82, 226);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 5;
            label6.Text = "Net:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(82, 77);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 0;
            label1.Text = "材料:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微軟正黑體", 12F);
            label5.Location = new Point(82, 197);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 4;
            label5.Text = "可用庫存:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微軟正黑體", 12F);
            label2.Location = new Point(82, 106);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "需求數量:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微軟正黑體", 12F);
            label4.Location = new Point(82, 166);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 3;
            label4.Text = "在途數量:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微軟正黑體", 12F);
            label3.Location = new Point(82, 136);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 2;
            label3.Text = "現有庫存:";
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 567);
            Controls.Add(tabControl1);
            Name = "ResultForm";
            Text = "ResultForm";
            Load += ResultForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLotDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvResult;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolTip toolTip1;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private DataGridView dgvLotDetails;
        private Label label6;
        private Label label5;
        private Label lblMaterialId;
        private Label lblDemandQty;
        private Label lblInventoryQty;
        private Label lblPurchaseQty;
        private Label lblAvailableQty;
        private Label lblStatus;
        private Label label7;
        private Label lblNetQty;
        private Label label8;
    }
}