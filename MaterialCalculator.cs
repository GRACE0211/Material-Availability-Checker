using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Material_Availability_Checker
{
    public static class MaterialCalculator
    {
        public static DataTable Calculate(
            DataTable demandTable,
            DataTable inventoryLotsTable,
            DataTable purchaseOrdersTable,
            DataTable productMaterialsTable,
            DataTable materialTable)
        {
            DataTable result = CreateResultTable();
            var expand = new List<(string MaterialId, int Qty)>();

            // 假資料，之後換成 ProductMaterials/BOM
            //result.Rows.Add("M001", 40, 30, 20, 50, 10, "足夠 ✔️");
            //result.Rows.Add("M002", 50, 20, 25, 45, -5, "注意 ⚠️");
            //result.Rows.Add("M003", 100, 30, 20, 50, -50, "不足 ❌");

            foreach (DataRow demandRow in demandTable.Rows)
            {
                string productId = demandRow["ProductId"]?.ToString() ?? string.Empty;
                int demandQty = Convert.ToInt32(demandRow["DemandQty"]);

                var bomRows = productMaterialsTable.AsEnumerable()
                    .Where(r => r.Field<string>("ProductId") == productId);

                foreach (var bomRow in bomRows)
                {
                    string materialId = bomRow.Field<string>("MaterialId") ?? string.Empty;
                    int requiredQty = bomRow.Field<int>("requiredQty");

                    int totalQty = demandQty * requiredQty;
                    expand.Add((materialId, totalQty));
                }

                var demandByMaterial = expand
                    .GroupBy(x => x.MaterialId)
                    .Select(g => new
                    {
                        MaterialId = g.Key,
                        TotalDemand = g.Sum(x => x.Qty)
                    })
                    .ToList();

                int onHandQty = inventoryLotsTable.AsEnumerable()
                    .Where(r => r.Field<string>("MaterialId") == item.MaterialId)
                    .Sum(r => r.Field<int>("OnHandQty"));

                foreach (var item in demandByMaterial)
                {
                    result.Rows.Add(
                        item.MaterialId,
                        item.TotalDemand,
                        0, // 現有庫存
                        0, // 在途數量
                        0, // 可用庫存
                        0, // 可用庫存 - 需求
                        "待計算" // 是否足夠
                    );
                }
            }

            return result;
        }

        private static DataTable CreateResultTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("料件ID", typeof(string));
            //dt.Columns.Add("材料名稱", typeof(string));
            dt.Columns.Add("需求數量", typeof(int));
            dt.Columns.Add("現有庫存", typeof(int));
            dt.Columns.Add("在途數量", typeof(int));
            dt.Columns.Add("可用庫存", typeof(int));
            dt.Columns.Add("可用庫存 - 需求", typeof(int));
            dt.Columns.Add("是否足夠", typeof(string));

            return dt;
        }
    }
}