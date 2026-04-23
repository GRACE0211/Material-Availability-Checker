using System.Data;
using ClosedXML.Excel;

namespace Material_Availability_Checker
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private DataTable productTable = new DataTable();
        private DataTable demandTable = new DataTable();
        private DataTable inventoryLotsTable = new DataTable();
        private DataTable purchaseOrdersTable = new DataTable();

        private void InputForm_Load(object sender, EventArgs e)
        {
            // 1. 產品清單（給 ComboBox 用）
            productTable.Columns.Add("ProductId", typeof(string));
            productTable.Columns.Add("ProductName", typeof(string));

            // 假資料，到時候改成 SQL
            productTable.Rows.Add("P001", "產品A");
            productTable.Rows.Add("P002", "產品B");
            productTable.Rows.Add("P003", "產品C");
            productTable.Rows.Add("P004", "產品D");
            productTable.Rows.Add("P005", "產品E");

            cmbProduct.DataSource = productTable;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductId";
            cmbProduct.SelectedIndex = 0;

            // 2. 需求清單（給 DataGridView 用）
            demandTable.Columns.Add("ProductId", typeof(string));
            demandTable.Columns.Add("ProductName", typeof(string));
            demandTable.Columns.Add("ProductQty", typeof(int));

            dgvDemand.AutoGenerateColumns = true;
            dgvDemand.DataSource = demandTable;

            dgvDemand.AllowUserToAddRows = false;
            dgvDemand.ReadOnly = true;
            dgvDemand.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDemand.MultiSelect = false;

            // 3. 庫存批次清單（給 DataTable 用）
            InitInventoryLotsTable();
            InitPurchaseOrdersTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex == -1 || cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("請先選擇產品");
                return;
            }

            int demandQty = (int)numDemandQty.Value;

            if (demandQty <= 0)
            {
                MessageBox.Show("需求數量必須大於 0");
                return;
            }

            string productId = cmbProduct.SelectedValue.ToString()!;
            string productName = cmbProduct.Text;

            // 檢查是否已存在同產品
            DataRow? existingRow = demandTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("ProductId") == productId);

            if (existingRow != null)
            {
                existingRow["ProductQty"] = Convert.ToInt32(existingRow["ProductQty"]) + demandQty;
            }
            else
            {
                demandTable.Rows.Add(productId, productName, demandQty);
            }

            numDemandQty.Value = 0;
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgvDemand.CurrentRow == null)
            {
                MessageBox.Show("請先選擇要刪除的資料列");
                return;
            }

            dgvDemand.Rows.Remove(dgvDemand.CurrentRow);
        }
        // 3. 庫存批次清單（給 DataTable 用）
        private void InitInventoryLotsTable()
        {
            inventoryLotsTable.Columns.Clear();

            inventoryLotsTable.Columns.Add("LotId", typeof(string));
            inventoryLotsTable.Columns.Add("MaterialId", typeof(string));
            inventoryLotsTable.Columns.Add("Qty", typeof(int));
            inventoryLotsTable.Columns.Add("ExpiryDate", typeof(DateTime));
            inventoryLotsTable.Columns.Add("ReceivedDate", typeof(DateTime));
        }
        // 4. 採購訂單清單（給 DataTable 用）     
        private void InitPurchaseOrdersTable()
        {
            purchaseOrdersTable.Columns.Clear();

            purchaseOrdersTable.Columns.Add("POId", typeof(string));
            purchaseOrdersTable.Columns.Add("MaterialId", typeof(string));
            purchaseOrdersTable.Columns.Add("OrderQty", typeof(int));
            purchaseOrdersTable.Columns.Add("Status", typeof(string));
            purchaseOrdersTable.Columns.Add("ExpectedDate", typeof(DateTime));
        }
        // 5. 從 Excel 匯入庫存
        private void btnImportInventory_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                ImportInventoryLotsFromExcel(ofd.FileName);
                MessageBox.Show($"庫存批次匯入完成，共 {inventoryLotsTable.Rows.Count} 筆");
            }
            catch (Exception ex)
            {
                MessageBox.Show("匯入庫存失敗：" + ex.Message);
            }
        }
        // 從 Excel 匯入庫存
        private void ImportInventoryLotsFromExcel(string filePath)
        {
            inventoryLotsTable.Rows.Clear();

            using var workbook = new XLWorkbook(filePath);
            var ws = workbook.Worksheet(1);

            var lastRow = ws.LastRowUsed();
            if (lastRow == null)
                return;

            int lastRowNumber = lastRow.RowNumber();

            for (int row = 2; row <= lastRowNumber; row++) // 第1列是標題
            {
                string lotId = ws.Cell(row, 1).GetString().Trim();
                string materialId = ws.Cell(row, 2).GetString().Trim();

                if (string.IsNullOrWhiteSpace(materialId))
                    continue;

                int qty = 0;
                int.TryParse(ws.Cell(row, 3).GetString().Trim(), out qty);

                DateTime expiryDate;
                if (!DateTime.TryParse(ws.Cell(row, 4).GetString().Trim(), out expiryDate))
                {
                    expiryDate = DateTime.MaxValue;
                }

                DateTime receivedDate;
                if (!DateTime.TryParse(ws.Cell(row, 5).GetString().Trim(), out receivedDate))
                {
                    receivedDate = DateTime.MinValue;
                }

                inventoryLotsTable.Rows.Add(lotId, materialId, qty, expiryDate, receivedDate);
            }
        }

        private void btnImportPO_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                ImportPurchaseOrdersFromExcel(ofd.FileName);
                MessageBox.Show($"採購單匯入完成，共 {purchaseOrdersTable.Rows.Count} 筆");
            }
            catch (Exception ex)
            {
                MessageBox.Show("匯入採購單失敗：" + ex.Message);
            }
        }
        private void ImportPurchaseOrdersFromExcel(string filePath)
        {
            purchaseOrdersTable.Rows.Clear();

            using var workbook = new XLWorkbook(filePath);
            var ws = workbook.Worksheet(1);

            var lastRow = ws.LastRowUsed();
            if (lastRow == null)
                return;

            int lastRowNumber = lastRow.RowNumber();

            for (int row = 2; row <= lastRowNumber; row++)
            {
                string poId = ws.Cell(row, 1).GetString().Trim();
                string materialId = ws.Cell(row, 2).GetString().Trim();

                if (string.IsNullOrWhiteSpace(materialId))
                    continue;

                int orderQty = 0;
                int.TryParse(ws.Cell(row, 3).GetString().Trim(), out orderQty);

                string status = ws.Cell(row, 4).GetString().Trim();

                DateTime expectedDate;
                if (!DateTime.TryParse(ws.Cell(row, 5).GetString().Trim(), out expectedDate))
                {
                    expectedDate = DateTime.MinValue;
                }

                purchaseOrdersTable.Rows.Add(poId, materialId, orderQty, status, expectedDate);
            }
        }
    }
}
