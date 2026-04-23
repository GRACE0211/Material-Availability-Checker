namespace Material_Availability_Checker
{
    partial class InputForm
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
            cmbProduct = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            numDemandQty = new NumericUpDown();
            dgvDemand = new DataGridView();
            btnAdd = new Button();
            btnDeleteSelected = new Button();
            btnImportInventory = new Button();
            btnImportPO = new Button();
            btnAnalyze = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numDemandQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDemand).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // cmbProduct
            // 
            cmbProduct.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(90, 14);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(108, 27);
            cmbProduct.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            label1.Location = new Point(38, 13);
            label1.Name = "label1";
            label1.Size = new Size(43, 19);
            label1.TabIndex = 1;
            label1.Text = "產品:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            label2.Location = new Point(204, 16);
            label2.Name = "label2";
            label2.Size = new Size(43, 19);
            label2.TabIndex = 2;
            label2.Text = "數量:";
            // 
            // numDemandQty
            // 
            numDemandQty.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            numDemandQty.Location = new Point(256, 14);
            numDemandQty.Name = "numDemandQty";
            numDemandQty.Size = new Size(108, 27);
            numDemandQty.TabIndex = 3;
            // 
            // dgvDemand
            // 
            dgvDemand.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDemand.BorderStyle = BorderStyle.Fixed3D;
            dgvDemand.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDemand.Location = new Point(3, 3);
            dgvDemand.Name = "dgvDemand";
            dgvDemand.Size = new Size(631, 167);
            dgvDemand.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnAdd.Location = new Point(370, 13);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(95, 27);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "加入";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnDeleteSelected.Location = new Point(471, 13);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(95, 27);
            btnDeleteSelected.TabIndex = 6;
            btnDeleteSelected.Text = "刪除";
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // btnImportInventory
            // 
            btnImportInventory.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnImportInventory.Location = new Point(52, 14);
            btnImportInventory.Name = "btnImportInventory";
            btnImportInventory.Size = new Size(95, 27);
            btnImportInventory.TabIndex = 7;
            btnImportInventory.Text = "匯入庫存";
            btnImportInventory.UseVisualStyleBackColor = true;
            btnImportInventory.Click += btnImportInventory_Click;
            // 
            // btnImportPO
            // 
            btnImportPO.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnImportPO.Location = new Point(153, 14);
            btnImportPO.Name = "btnImportPO";
            btnImportPO.Size = new Size(114, 27);
            btnImportPO.TabIndex = 8;
            btnImportPO.Text = "匯入採購單";
            btnImportPO.UseVisualStyleBackColor = true;
            btnImportPO.Click += btnImportPO_Click;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnAnalyze.Location = new Point(466, 14);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(114, 27);
            btnAnalyze.TabIndex = 9;
            btnAnalyze.Text = "開始分析";
            btnAnalyze.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微軟正黑體", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label3.Location = new Point(93, 70);
            label3.Name = "label3";
            label3.Size = new Size(95, 22);
            label3.TabIndex = 10;
            label3.Text = "需求輸入區";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微軟正黑體", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label4.Location = new Point(93, 150);
            label4.Name = "label4";
            label4.Size = new Size(82, 22);
            label4.TabIndex = 11;
            label4.Text = "需求清單:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微軟正黑體", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label5.Location = new Point(93, 351);
            label5.Name = "label5";
            label5.Size = new Size(112, 22);
            label5.TabIndex = 12;
            label5.Text = "外部資料匯入";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cmbProduct);
            panel1.Controls.Add(numDemandQty);
            panel1.Controls.Add(btnDeleteSelected);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(93, 95);
            panel1.Name = "panel1";
            panel1.Size = new Size(637, 52);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvDemand);
            panel2.Location = new Point(93, 175);
            panel2.Name = "panel2";
            panel2.Size = new Size(637, 173);
            panel2.TabIndex = 14;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnImportInventory);
            panel3.Controls.Add(btnImportPO);
            panel3.Controls.Add(btnAnalyze);
            panel3.Location = new Point(93, 376);
            panel3.Name = "panel3";
            panel3.Size = new Size(637, 61);
            panel3.TabIndex = 15;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(panel3);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(panel2);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(panel1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(815, 499);
            panel4.TabIndex = 16;
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(815, 499);
            Controls.Add(panel4);
            Name = "InputForm";
            Text = "InputForm";
            Load += InputForm_Load;
            ((System.ComponentModel.ISupportInitialize)numDemandQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDemand).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbProduct;
        private Label label1;
        private Label label2;
        private NumericUpDown numDemandQty;
        private DataGridView dgvDemand;
        private Button btnAdd;
        private Button btnDeleteSelected;
        private Button btnImportInventory;
        private Button btnImportPO;
        private Button btnAnalyze;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}
