# 📦 Material Availability Checker

一個用於提升工作效率的小工具，協助使用者快速判斷產品所需材料是否足夠，並整合庫存與採購資訊進行分析。

---

## 🔧 功能 Features

- 輸入產品與需求數量
- 自動展開 BOM（產品 → 材料）
- 計算材料需求總量
- 整合：
  - 現有庫存（Inventory）
  - 在途採購（Purchase Orders）
- 判斷材料狀態：
  - ✅ 足夠
  - ⚠️ 注意
  - ❌ 不足
- 顯示「快過期材料」
  - 表格顯示摘要（LotId:Qty）
  - Tooltip 顯示完整資訊（批號、料號、數量、到期日）

---

## 🧠 系統邏輯（核心）

### 1. Input（需求與資料來源）

![InputForm](images/InputForm.png)

+ 簡單說明：
    使用者輸入產品需求，並匯入相關庫存與採購資料

+ 範例：

    產品 P001 × 10

+ 資料來源：

 - 手動輸入：
    產品（Product）
    數量（Qty）
 - Excel 匯入：
    現有庫存（InventoryLots）
    採購單（PurchaseOrders）

+ 重點：

    將分散資料整合為後續計算基礎
    支援手動 + 匯入，提高實務彈性

### 2. BOM 展開（產品 → 材料）

+ 簡單說明：
    將產品需求轉換為實際材料需求（依 BOM 結構）

+ 範例：
```
    + P001 × 10
       - M001 × 20
       - M002 × 30
```
+ 重點：

    使用 ProductMaterials 定義 BOM

+ 計算方式：

    材料需求 = 產品數量 × RequiredQty
    
### 3. MaterialCalculator 運算邏輯

+ 簡單說明：

    BOM 展開後，系統會將材料需求、現有庫存與在途採購資料整合，計算每一個材料的可用數量，並判斷材料是否足夠

+ 運算流程：

    1. 依照 `ProductId` 找出對應 BOM
    2. 計算每個材料的需求數量
    3. 將相同 `MaterialId` 的需求進行加總
    4. 查詢現有庫存數量
    5. 查詢在途採購數量
    6. 計算可用數量與 Net
    7. 依照結果判斷狀態

+ 計算方式：

    DemandQty = 產品數量 × RequiredQty

    AvailableQty = InventoryQty + PurchaseQty

    NetQty = AvailableQty - DemandQty


+ 範例：

    ```
    P001 × 10

    BOM：
    M001 × 2
    M002 × 3

    材料需求：
    M001 = 10 × 2 = 20
    M002 = 10 × 3 = 30

    若：
    M001 庫存 15，在途 10
    M002 庫存 20，在途 5

    則：
    M001 Available = 25，Net = 5 → 足夠
    M002 Available = 25，Net = -5 → 不足
    ```

+ 重點：

    - 使用 LINQ 處理資料篩選、分組與加總
    - 使用 Dictionary 快速查詢庫存與採購資料
    - 將計算邏輯集中在 `MaterialCalculator`，讓 UI 與資料運算分開

### 4. 結果判斷與視覺化

![ResultForm](images/ResultForm.jpg)
+ 簡單說明：

    系統會依照 Net 計算結果，將每個材料標示為「足夠 / 注意 / 不足」，並透過顏色顯示在畫面上，讓使用者可以快速判斷料況。

+ 判斷邏輯：

    Net ≥ 0 → 足夠  
    接近 0（或低於安全值）→ 注意  
    Net < 0 → 不足  

+ 範例：

    ```
    M001 Net = 5   → ✅ 足夠
    M002 Net = -5  → ❌ 不足
    ```

+ 重點：

    - 使用 DataGridView 條件格式（顏色標示）
    - 讓使用者不需要看數字就能快速判斷

### 5. 批次資訊與快過期提醒

+ 簡單說明：

    除了材料總量，系統也會顯示每一批（Lot）的資訊，並標示即將到期的材料，協助使用者避免使用過期料。

+ 顯示方式：

    表格欄位：
    ```
    Lot001:10, Lot002:15
    ```

+ Tooltip（滑鼠移上去）：

    ```
    Lot001 / PartNo: M001 / Expiry: 2026-05-30
    Lot002 / PartNo: M001 / Expiry: 2026-06-15
    ```

+ 快過期判斷：

    ExpiryDate - Today ≤ 30 天

+ 重點：

    - 提供 Lot level 細節，而不只是總數
    - UI 保持簡潔，但資訊完整
    - 屬於實務導向功能

---

## 🎯 專案總結

本專案的核心在於：

將「產品需求 → 材料需求 → 庫存與採購資料」整合，  
轉換為可以快速判斷的結果（是否足夠）。

透過簡單的操作與清楚的視覺呈現，  
讓使用者能快速掌握材料是否足夠。

---

## 💡 設計重點

- 使用 LINQ 進行資料轉換與彙總
- 使用 Dictionary 提升查詢效能
- 將計算邏輯集中在 `MaterialCalculator`
- UI 以「快速判斷」為設計目標（顏色 + Tooltip）

---

## 🔧 未來可擴充

- 加入安全庫存邏輯
- 支援 FIFO / 批次優先策略
- 匯出報表（Excel / PDF）
- 擴充顯示欄位（依實務需求調整）