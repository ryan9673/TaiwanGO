TaiwanGo 後台管理系統
📌 專案簡介

TaiwanGo 是一個基於 ASP.NET Core MVC 的後台管理系統，主要負責管理旅遊平台的基礎資料與訂單紀錄。
資料庫設計涵蓋 員工 (Staff)、會員 (User)、景點分類 (AttractionCategory)、景點 (Attraction)、票券 (Ticket)、訂單 (Booking) 六大核心資料表。

系統的核心目標是：
讓後台人員能夠方便地管理景點與票券資訊。
提供訂單 (Booking) 與會員 (User) 的整合管理，方便查詢誰買了什麼票。
維持資料一致性（透過 Wrap + ViewModel 邏輯串接）。

✅ 我們已經做到的功能(員工會員景點功能開發較完善)
員工管理 CRUD
會員管理 CRUD
景點分類管理
景點管理 CRUD(含圖片上傳/刪除)上傳圖片，會自動刪除舊檔，避免冗餘檔案。 修改功能頁面製作完善能有效更換圖片!
票券管理 CRUD 新增刪除尚未完成
訂單管理 (Booking List 串接多表顯示)CRUD 新增刪除尚未完成

🗄 資料庫設計與欄位說明
1. Staff (員工管理)
FId
FName
FEmail
FPassword
FRole
FPhone
FCreatedAt
FIsActive
👉 用於後台登入與權限管理，確保只有內部人員能操作後台系統。

2. User (會員)
FId
FName
FEmail
FPassword
FPhone
FBirthDate
FGender
FCreatedAt
FIsActive
👉 前台的消費者資料，Booking 訂單會關聯 User。

3. AttractionCategory (景點分類)
FId
FCategoryName
👉 景點的分類，例如「自然景觀」、「文化古蹟」、「主題樂園」。

4. Attraction (景點)
FId
FCategoryId (對應 Category)
FAttractionName
FDescription
FLocation
FImage
👉 景點資料，包含名稱、介紹、地點、圖片，屬於某一個分類。

5. Ticket (票券)
FId
FAttractionId
FTicketName
FPrice
FDescription
FValidDateStart
FValidDateEnd
FIsActive
👉 景點票券資料，屬於某景點，每個票券有售價。

6. Booking (訂單)
FId
FUserId
FTicketId
FBookingDate
FQuantity
FUnitPrice
FTotalAmount
FCreatedAt
👉 使用者購買票券的紀錄，一筆訂單會連結到某位會員 (User) 和某張票券 (Ticket)，而票券又屬於某個景點。

**程式設計方法**
🛠 使用技術
ASP.NET Core MVC：整體架構，分層清晰 (Model, View, Controller)。
Entity Framework Core：ORM，負責存取 SQL Server 資料庫。

**Design Pattern：**
把資料庫實體和 View 要用的資料分離，讓程式更易維護、可擴充、可讀，降低耦合、提升一致性。
Repository-like Wrap Pattern：每個資料表對應一個 Wrap 類別，封裝 Domain Model，方便擴充額外屬性。
ViewModel Pattern：用於整合多張表（例如 CCategoryDetails, CHotelDetails, CBookingWrap）。

Razor語法 (cshtml)：後台頁面 UI 呈現。
依賴注入 (DI)：透過 DbContext 與 _enviro 注入存取 DB 與檔案系統。
檔案處理 (IWebHostEnvironment)：圖片上傳與刪除。

