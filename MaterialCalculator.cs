using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Availability_Checker
{
    public static class MaterialCalculator
    {
        public static DataTable Calculate(
            DataTable demandTable,
            DataTable inventoryLotsTable, // 庫存
            DataTable purchaseOrdersTable, // 還在路上的材料
            DataTable productMaterialsTable,
            DataTable materialTable)
        {
            
            DateTime today = DateTime.Today;
            DateTime warningDate = today.AddDays(30); // 警告日期：30天內過期的庫存
            DataTable result = CreateResultTable();


            // 1. BOM 先依 ProductId 分組，之後查 BOM 比較快
            var bomLookup = productMaterialsTable.AsEnumerable()
                .GroupBy(r => r.Field<string>("ProductId")!)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToList()
                );

            // 2. 現有庫存先依 MaterialId 加總
            var onHandLookup = inventoryLotsTable.AsEnumerable()
                .Where(r => r.Field<DateTime>("ExpiryDate") > today)
                .GroupBy(r => r.Field<string>("MaterialId")!)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(r => r.Field<int>("Qty"))
                );


            // 3. 在途量先依 MaterialId 加總，只算未完成
            var onOrderLookup = purchaseOrdersTable.AsEnumerable()
                .Where(r => r.Field<string>("Status") != "已完成")
                .GroupBy(r => r.Field<string>("MaterialId")!)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(r => r.Field<int>("OrderQty"))
                );

            var materialLookup = materialTable.AsEnumerable()
                .ToDictionary(
                    r => r.Field<string>("MaterialId") ?? "",
                    r => r.Field<string>("PartNo") ?? ""
                );

            // 4. 快過期批次先依 MaterialId 整理
            var expiringLookup = inventoryLotsTable.AsEnumerable()
                .Where(r => r.Field<DateTime>("ExpiryDate") >= today)
                .Where(r => r.Field<DateTime>("ExpiryDate") <= warningDate)
                .GroupBy(r => r.Field<string>("MaterialId") ?? "")
                .ToDictionary(
                    g => g.Key,
                    g => string.Join(Environment.NewLine, g.Select(lot =>
                    {
                        string materialId = lot.Field<string>("MaterialId") ?? "";
                        string partNo = materialLookup.TryGetValue(materialId, out var pn) ? pn : "";

                        return $"批號: {lot.Field<string>("LotId") ?? ""}\n" +
                       $"料號: {partNo}\n" +
                       $"數量: {lot.Field<int>("Qty")}\n" +
                       $"到期日: {lot.Field<DateTime>("ExpiryDate").ToShortDateString()}";
                    }))
                );

            var expiringSummaryLookup = inventoryLotsTable.AsEnumerable()
                .Where(r => r.Field<DateTime>("ExpiryDate") >= today)
                .Where(r => r.Field<DateTime>("ExpiryDate") <= warningDate)
                .GroupBy(r => r.Field<string>("MaterialId") ?? "")
                .ToDictionary(
                    g => g.Key,
                    g => string.Join(", ", g.Select(lot =>
                     $"批號: {lot.Field<string>("LotId") ?? ""}數量: {lot.Field<int>("Qty")}"
                    ))
                );

            // 5. 展開 BOM，計算每個 Material 的需求
            var demandByMaterial = new Dictionary<string, int>();

            foreach (DataRow demandRow in demandTable.Rows)
            {
                string productId = demandRow["ProductId"]?.ToString() ?? "";
                int productQty = Convert.ToInt32(demandRow["ProductQty"]);

                if (!bomLookup.TryGetValue(productId, out var bomRows))
                    continue;

                foreach (var bomRow in bomRows)
                {
                    string materialId = bomRow.Field<string>("MaterialId")!;
                    int requiredQty = bomRow.Field<int>("RequiredQty");

                    int totalQty = productQty * requiredQty;

                    if (demandByMaterial.ContainsKey(materialId))
                        demandByMaterial[materialId] += totalQty;
                    else
                        demandByMaterial[materialId] = totalQty;
                }
            }

            // 6. 依 MaterialId 產生結果
            foreach (var item in demandByMaterial)
            {
                string materialId = item.Key;
                int demandQty = item.Value;

                int onHandQty = onHandLookup.TryGetValue(materialId, out int oh) ? oh : 0;
                int inOrderQty = onOrderLookup.TryGetValue(materialId, out int io) ? io : 0;

                int availableQty = onHandQty + inOrderQty;
                int net = availableQty - demandQty;

                string status = GetStatus(net);

                string expiringSummary = "";
                if(expiringSummaryLookup.ContainsKey(materialId))
                {
                    expiringSummary = expiringSummaryLookup[materialId] ?? "";
                }


                string expiringDetail = "";
                if (expiringLookup.ContainsKey(materialId))
                {
                    expiringDetail = expiringLookup[materialId];
                }

                result.Rows.Add(
                    materialId,
                    demandQty,
                    onHandQty,
                    inOrderQty,
                    availableQty,
                    net,
                    status,
                    expiringSummary,
                    expiringDetail
                );
            }

            return result;
        }

        // 根據庫存狀況判斷是否足夠
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
            dt.Columns.Add("快過期明細", typeof(string));
            dt.Columns.Add("快過期Tooltip", typeof(string));

            return dt;
        }
    }
}