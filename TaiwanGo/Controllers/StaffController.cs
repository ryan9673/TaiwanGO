using Microsoft.AspNetCore.Mvc;
using TaiwanGo.Models.Domain;
using TaiwanGo.Models.Wrap;
using TaiwanGo.ViewModels;

namespace TaiwanGo.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult List(CKeywordViewModel p)
        {
            TaiwanGoContext db = new TaiwanGoContext();
            IEnumerable<TStaff> datas = null;
            if (string.IsNullOrEmpty(p.txtKeyword))
            {
                datas = from s in db.TStaffs
                        select s;
            }
            else
                datas = db.TStaffs.Where(staff => staff.FName.Contains(p.txtKeyword)
                || staff.FEmail.Contains(p.txtKeyword)
                || staff.FPhone.Contains(p.txtKeyword)
                || staff.FRole.Contains(p.txtKeyword));
            // 把 TStaff 轉成 CStaffWrap
            List<CStaffWrap> wraps = datas.Select(s => new CStaffWrap(s)).ToList();
            return View(wraps);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TStaff s)
        {
            TaiwanGoContext db = new TaiwanGoContext();
            db.TStaffs.Add(s);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                TaiwanGoContext db = new TaiwanGoContext();
                TStaff delStaff = db.TStaffs.FirstOrDefault(staff => staff.FId == id);
                if (delStaff != null)
                {
                    db.TStaffs.Remove(delStaff);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List"); 
            TaiwanGoContext db = new TaiwanGoContext();
            TStaff delstaff = db.TStaffs.FirstOrDefault(staff => staff.FId == id);
            if (delstaff == null)
                return RedirectToAction("List"); 
            return View(delstaff); 
        }
        [HttpPost]
        public IActionResult Edit(TStaff uiStaff)
        {
            TaiwanGoContext db = new TaiwanGoContext();
            TStaff dbStaff = db.TStaffs.FirstOrDefault(staff => staff.FId == uiStaff.FId);
            if (dbStaff == null)
                return RedirectToAction("List");
            dbStaff.FName = uiStaff.FName;
            dbStaff.FEmail = uiStaff.FEmail;
            dbStaff.FPassword = uiStaff.FPassword;
            dbStaff.FPhone = uiStaff.FPhone;
            dbStaff.FRole = uiStaff.FRole;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}