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

        public ResultForm(DataTable result)
        {
            InitializeComponent();
            resultTable = result;
        }
        private void ResultForm_Load(object sender, EventArgs e)
        {
            dgvResult.AutoGenerateColumns = true;
            dgvResult.DataSource = resultTable;
            dgvResult.AllowUserToAddRows = false;
            dgvResult.ReadOnly = true;
            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.MultiSelect = false;
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            if(row.Cells["是否足夠"].Value == null)
                return;

            int net = 0;
            if(row.Cells["可用庫存 - 需求"].Value != DBNull.Value)
            {
                net = Convert.ToInt32(row.Cells["可用庫存 - 需求"].Value);
            }

            if (net >= 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else if(net < 0 && net >= -20)
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

    }
}
