using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Availability_Checker
{
    public partial class ResultForm : Form
    {

        private DataTable resultTable;
        private DataTable inventoryLotsTable;
        private DataTable materialTable;

        public ResultForm(DataTable result, DataTable inventoryLotsTable, DataTable materialTable)
        {
            InitializeComponent();
            resultTable = result;
            this.inventoryLotsTable = inventoryLotsTable;
            this.materialTable = materialTable;
        }
        private void ResultForm_Load(object sender, EventArgs e)
        {
            dgvResult.AutoGenerateColumns = true;
            dgvResult.DataSource = resultTable;
            dgvResult.AllowUserToAddRows = false;
            dgvResult.ReadOnly = true;
            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.MultiSelect = false;
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.Columns["快過期明細"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgvResult.CellToolTipTextNeeded += dgvResult_CellToolTipTextNeeded;
            dgvResult.ShowCellToolTips = true;
            if (dgvResult.Columns.Contains("快過期Tooltip"))
            {
                dgvResult.Columns["快過期Tooltip"].Visible = false;
            }
            //dgvResult.CellFormatting += dgvResult_CellFormatting ;
        }

        // 根據 "是否足夠" 欄位的值來設定行的背景顏色
        private void dgvResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = dgvResult.Rows[e.RowIndex];
            if (row.Cells["是否足夠"].Value == null)
                return;

            int net = 0;
            if (row.Cells["可用庫存 - 需求"].Value != DBNull.Value)
            {
                net = Convert.ToInt32(row.Cells["可用庫存 - 需求"].Value);
            }

            if (net >= 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else if (net < 0 && net >= -20)
            {
                row.DefaultCellStyle.BackColor = Color.LightYellow;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral;
            }

        }

        private void dgvResult_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvResult.Columns[e.ColumnIndex].Name != "快過期明細")
                return;

            var value = dgvResult.Rows[e.RowIndex].Cells["快過期Tooltip"].Value;

            if (value == null || value == DBNull.Value)
                return;

            string text = value.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(text))
                return;

            e.ToolTipText = text;
        }



        private void LoadLotDetails(string materialId)
        {
            if (string.IsNullOrEmpty(materialId))
                return;

            var detailTable = new DataTable();
            detailTable.Columns.Add("LotId");
            detailTable.Columns.Add("PartNo");
            detailTable.Columns.Add("Qty", typeof(int));
            detailTable.Columns.Add("ExpiryDate", typeof(DateTime));
            detailTable.Columns.Add("剩餘天數", typeof(int));

            var rows = inventoryLotsTable.AsEnumerable()
                .Where(r => r.Field<string>("MaterialId") == materialId);
            var materialLookUp = materialTable.AsEnumerable()
                .ToDictionary(
                    r => r.Field<string>("MaterialId") ?? "",
                    r => r.Field<string>("PartNo") ?? ""
                );
            string partNo = materialLookUp.TryGetValue(materialId, out var pn) ? pn : "";

            foreach (var r in rows)
            {
                DateTime expiryDate = r.Field<DateTime>("ExpiryDate");
                int remainingDays = (expiryDate.Date - DateTime.Today).Days;

                detailTable.Rows.Add(
                    r.Field<string>("LotId"),
                    partNo,
                    r.Field<int>("Qty"),
                    expiryDate,
                    remainingDays
                );
            }

            dgvLotDetails.DataSource = detailTable;
            dgvLotDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var row = dgvResult.Rows[e.RowIndex];
            lblMaterialId.Text = row.Cells["料件ID"].Value?.ToString();
            lblDemandQty.Text = row.Cells["需求數量"].Value?.ToString();
            lblInventoryQty.Text = row.Cells["現有庫存"].Value?.ToString();
            lblPurchaseQty.Text = row.Cells["在途數量"].Value?.ToString();
            lblAvailableQty.Text = row.Cells["可用庫存"].Value?.ToString();
            lblNetQty.Text = row.Cells["可用庫存 - 需求"].Value?.ToString();
            lblStatus.Text = row.Cells["是否足夠"].Value?.ToString();
            var materialId = row.Cells["料件ID"].Value?.ToString();
            if (string.IsNullOrEmpty(materialId))
                return;
            // 載入明細
            LoadLotDetails(materialId);

            //切換到tabPage2
            tabControl1.SelectedTab = tabPage2;
        }
    }
}
