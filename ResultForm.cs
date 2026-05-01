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
            //dgvResult.CellFormatting += dgvResult_CellFormatting ;
        }

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

        
    }
}
