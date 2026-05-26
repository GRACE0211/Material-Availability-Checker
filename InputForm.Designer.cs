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
            panel4 = new Panel();
            groupBox3 = new GroupBox();
            btnImportDemandSchedule = new Button();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numDemandQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDemand).BeginInit();
            panel4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbProduct
            // 
            cmbProduct.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(58, 62);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(124, 27);
            cmbProduct.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            label1.Location = new Point(9, 66);
            label1.Name = "label1";
            label1.Size = new Size(43, 19);
            label1.TabIndex = 1;
            label1.Text = "產品:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            label2.Location = new Point(188, 66);
            label2.Name = "label2";
            label2.Size = new Size(43, 19);
            label2.TabIndex = 2;
            label2.Text = "數量:";
            // 
            // numDemandQty
            // 
            numDemandQty.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            numDemandQty.Location = new Point(237, 62);
            numDemandQty.Name = "numDemandQty";
            numDemandQty.Size = new Size(139, 27);
            numDemandQty.TabIndex = 3;
            // 
            // dgvDemand
            // 
            dgvDemand.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDemand.BorderStyle = BorderStyle.Fixed3D;
            dgvDemand.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDemand.Location = new Point(6, 28);
            dgvDemand.Name = "dgvDemand";
            dgvDemand.Size = new Size(625, 167);
            dgvDemand.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightSteelBlue;
            btnAdd.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnAdd.Location = new Point(398, 62);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(113, 37);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "加入";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.BackColor = Color.RosyBrown;
            btnDeleteSelected.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnDeleteSelected.Location = new Point(517, 62);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(113, 37);
            btnDeleteSelected.TabIndex = 6;
            btnDeleteSelected.Text = "刪除";
            btnDeleteSelected.UseVisualStyleBackColor = false;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // btnImportInventory
            // 
            btnImportInventory.BackColor = Color.DarkGray;
            btnImportInventory.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnImportInventory.Location = new Point(6, 28);
            btnImportInventory.Name = "btnImportInventory";
            btnImportInventory.Size = new Size(119, 35);
            btnImportInventory.TabIndex = 7;
            btnImportInventory.Text = "匯入庫存";
            btnImportInventory.UseVisualStyleBackColor = false;
            btnImportInventory.Click += btnImportInventory_Click;
            // 
            // btnImportPO
            // 
            btnImportPO.BackColor = Color.DarkGray;
            btnImportPO.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnImportPO.Location = new Point(131, 28);
            btnImportPO.Name = "btnImportPO";
            btnImportPO.Size = new Size(157, 35);
            btnImportPO.TabIndex = 8;
            btnImportPO.Text = "匯入採購單";
            btnImportPO.UseVisualStyleBackColor = false;
            btnImportPO.Click += btnImportPO_Click;
            // 
            // btnAnalyze
            // 
            btnAnalyze.BackColor = Color.YellowGreen;
            btnAnalyze.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnAnalyze.Location = new Point(485, 28);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(146, 35);
            btnAnalyze.TabIndex = 9;
            btnAnalyze.Text = "開始分析";
            btnAnalyze.UseVisualStyleBackColor = false;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Menu;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(groupBox3);
            panel4.Controls.Add(groupBox2);
            panel4.Controls.Add(groupBox1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(850, 573);
            panel4.TabIndex = 16;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Gainsboro;
            groupBox3.Controls.Add(btnImportDemandSchedule);
            groupBox3.Controls.Add(btnImportInventory);
            groupBox3.Controls.Add(btnImportPO);
            groupBox3.Controls.Add(btnAnalyze);
            groupBox3.Font = new Font("微軟正黑體", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            groupBox3.Location = new Point(96, 397);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(637, 71);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "外部資料匯入";
            // 
            // btnImportDemandSchedule
            // 
            btnImportDemandSchedule.BackColor = Color.DarkGray;
            btnImportDemandSchedule.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold);
            btnImportDemandSchedule.Location = new Point(294, 28);
            btnImportDemandSchedule.Name = "btnImportDemandSchedule";
            btnImportDemandSchedule.Size = new Size(157, 35);
            btnImportDemandSchedule.TabIndex = 10;
            btnImportDemandSchedule.Text = "匯入需求排程";
            btnImportDemandSchedule.UseVisualStyleBackColor = false;
            btnImportDemandSchedule.Click += btnImportDemandSchedule_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Gainsboro;
            groupBox2.Controls.Add(dgvDemand);
            groupBox2.Font = new Font("微軟正黑體", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            groupBox2.Location = new Point(96, 184);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(637, 207);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "需求清單";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Gainsboro;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbProduct);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numDemandQty);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnDeleteSelected);
            groupBox1.Font = new Font("微軟正黑體", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            groupBox1.Location = new Point(96, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(637, 105);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "需求輸入區";
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(850, 573);
            Controls.Add(panel4);
            Name = "InputForm";
            Text = "InputForm";
            Load += InputForm_Load;
            ((System.ComponentModel.ISupportInitialize)numDemandQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDemand).EndInit();
            panel4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private Panel panel4;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Button btnImportDemandSchedule;
    }
}
