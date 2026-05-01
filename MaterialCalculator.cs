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

            // 1. BOM展開：根據需求表中的產品，找到對應的BOM，計算每個料件的需求數量
            foreach (DataRow demandRow in demandTable.Rows)
            {
                string productId = demandRow["ProductId"]?.ToString() ?? string.Empty;
                int productQty = Convert.ToInt32(demandRow["ProductQty"]);

                var bomRows = productMaterialsTable.AsEnumerable()
                    .Where(r => r.Field<string>("ProductId") == productId);

                foreach (var bomRow in bomRows)
                {
                    string materialId = bomRow.Field<string>("MaterialId") ?? string.Empty;
                    int requiredQty = bomRow.Field<int>("RequiredQty");

                    int totalQty = productQty * requiredQty;
                    expand.Add((materialId, totalQty));
                }

                // 2. 根據需求表中的產品，找到對應的BOM，計算每個料件的需求數量
                var demandByMaterial = expand
                    .GroupBy(x => x.MaterialId)
                    .Select(g => new
                    {
                        MaterialId = g.Key,
                        TotalDemand = g.Sum(x => x.Qty)
                    })
                    .ToList();


                // 3. 計算每個料件的現有庫存、在途數量、可用庫存，並與需求數量比較，判斷是否足夠
                foreach (var item in demandByMaterial)
                {
                    int onHandQty = inventoryLotsTable.AsEnumerable()
                    .Where(r => r.Field<string>("MaterialId") == item.MaterialId)
                    .Sum(r => r.Field<int>("Qty"));

                    int inOrderQty = purchaseOrdersTable.AsEnumerable()
                        .Where(r => r.Field<string>("MaterialId") == item.MaterialId)
                        .Where(r => r.Field<string>("Status") != "已完成") // 只計算未完成的訂單
                        .Sum(r => r.Field<int>("OrderQty"));

                    int availableQty = onHandQty + inOrderQty;
                    int net = availableQty - item.TotalDemand;

                    string status = GetStatus(net);

                    result.Rows.Add(
                        item.MaterialId,
                        item.TotalDemand,
                        onHandQty,
                        inOrderQty,
                        availableQty,
                        net,
                        status
                    );
                }
            }

            return result;
        }

        private static string GetStatus(int net)
        {
            if (net >= 0)
                return "足夠 ✔️";
            else if (net < 0 && net >= -20)
                return "注意 ⚠️";
            else
                return "不足 ❌";
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