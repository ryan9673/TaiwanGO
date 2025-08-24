using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaiwanGo.Models.Domain;
using TaiwanGo.Models.Wrap;
using TaiwanGo.ViewModels;

namespace TaiwanGo.Controllers
{
    public class AttractionController : Controller
    {
        private IWebHostEnvironment _enviro = null;
        public AttractionController(IWebHostEnvironment p)
        {
            _enviro = p;
        }
        public IActionResult List(CCategoryDetails a)
        {
            TaiwanGoContext db = new TaiwanGoContext();
            //查詢所有分類
            var categories = db.TAttractionCategories.ToList();
            //建立viewmodel空清單
            var categoryDetailsList = new List<CCategoryDetails>();
            //對每個分類進行處理
            //從 categories（一整個集合）裡，依序取出每一筆資料，放進 category（單一變數），執行迴圈內容。
            foreach (var category in categories)
            {               
                var detail = new CCategoryDetails
                {
                    //將分類資料包裝成 CAttractionCategoryWrap
                    Category = new CAttractionCategoryWrap(category),
                    AttractionsList = db.TAttractions
                        .Where(a => a.FCategoryId == category.FId)  //依分類 Id 找景點
                        .Select(a => new CAttractionWrap(a))
                        .ToList()
                };
                categoryDetailsList.Add(detail);
            }
            return View(categoryDetailsList);
        }
        public IActionResult Create()
        {
            TaiwanGoContext db = new TaiwanGoContext();

            var categories = db.TAttractionCategories.ToList();
            // 建立下拉選單用的 SelectList 
            ViewBag.Categories = new SelectList(categories, "FId", "FCategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
    public IActionResult Create(CAttractionWrap attraction)
    {
            TaiwanGoContext db = new TaiwanGoContext();

            //處理圖片上傳
            if (attraction.FImage != null)
            { // 產生唯一檔名
                string photoName = Guid.NewGuid().ToString() + Path.GetExtension(attraction.Photo.FileName);
                // 儲存路徑
                string filePath = Path.Combine(_enviro.WebRootPath, "images", photoName);
                // 寫入檔案
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    attraction.Photo.CopyTo(fileStream);
                }
                // 將檔名存回資料庫欄位
                attraction.FImage = photoName;
            }

            // 包成 Entity 寫進資料庫
            var entity = new TAttraction
            {
                FCategoryId = attraction.FCategoryId, // 使用者選的分類
                AttractionName = attraction.AttractionName,
                FDescription = attraction.FDescription,
                FLocation = attraction.FLocation,
                FImage = attraction.FImage
            };

            db.TAttractions.Add(entity);
            db.SaveChanges();
            return RedirectToAction("List");    
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                TaiwanGoContext db = new TaiwanGoContext();
                TAttraction d = db.TAttractions.FirstOrDefault(p => p.FId == id);
                if (d != null)
                {
                    db.TAttractions.Remove(d);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            TaiwanGoContext db = new TaiwanGoContext();
            TAttraction d = db.TAttractions.FirstOrDefault(p => p.FId == id);
            if (d == null)
            {
                return RedirectToAction("List");
            }
            //建立下拉選單用的 SelectList
            ViewBag.Categories = new SelectList(db.TAttractionCategories, "FId", "FCategoryName", d.FCategoryId);
            // 把 TAttraction 包裝成 ViewModel
            return View(new CAttractionWrap(d));
        }
        [HttpPost]
        public IActionResult Edit(CAttractionWrap uiAttraction)
        {
            TaiwanGoContext db = new TaiwanGoContext();
            // 找到 DB 景點
            TAttraction dbAttraction = db.TAttractions.FirstOrDefault(p => p.FId == uiAttraction.FId);
            if (dbAttraction == null)
                return RedirectToAction("List");

            // 更新基本資料
            dbAttraction.AttractionName = uiAttraction.AttractionName;
            dbAttraction.FDescription = uiAttraction.FDescription;
            dbAttraction.FLocation = uiAttraction.FLocation;
            dbAttraction.FCategoryId = uiAttraction.FCategoryId;  dbAttraction.FId = uiAttraction.FId;

            
            if (uiAttraction.Photo != null && uiAttraction.Photo.Length > 0)
            {
                // 刪除舊圖片
                if (!string.IsNullOrEmpty(dbAttraction.FImage))
                {
                    string oldPath = Path.Combine(_enviro.WebRootPath, "images", dbAttraction.FImage);
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                // 儲存新圖片
                string photoName = Guid.NewGuid().ToString() + Path.GetExtension(uiAttraction.Photo.FileName);
                string path = Path.Combine(_enviro.WebRootPath, "images", photoName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    uiAttraction.Photo.CopyTo(stream);
                }
                dbAttraction.FImage = photoName;
            }
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}

