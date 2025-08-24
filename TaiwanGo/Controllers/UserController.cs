using Microsoft.AspNetCore.Mvc;
using TaiwanGo.Models.Domain;
using TaiwanGo.Models.Wrap;
using TaiwanGo.ViewModels;

namespace TaiwanGo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult List(CKeywordViewModel p)
        {
            TaiwanGoContext db = new TaiwanGoContext();
            IEnumerable<TUser> datas = null;
            if (string.IsNullOrEmpty(p.txtKeyword))
            {
                datas = from user in db.TUsers
                        select user;
            }
            else
                datas = db.TUsers.Where(user => user.FName.Contains(p.txtKeyword)
                || user.FEmail.Contains(p.txtKeyword)
                || user.FPhone.Contains(p.txtKeyword));
            // 把 TUser 轉成 CStaffWrap
            List<CUserWrap> wraps = datas.Select(u => new CUserWrap(u)).ToList();
            return View(wraps);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TUser user)
        {
            TaiwanGoContext db = new TaiwanGoContext();
            db.TUsers.Add(user);
            db.SaveChanges();//更新資料庫
            return RedirectToAction("List");//RedirectToAction方法會重新導向到指定的動作方法
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                TaiwanGoContext db = new TaiwanGoContext();
                TUser deluser = db.TUsers.FirstOrDefault(user => user.FId == id);
                if (deluser != null)
                {
                    db.TUsers.Remove(deluser);//綠框做刪除
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List"); // 如果id為null，則重定向到List動作
            TaiwanGoContext db = new TaiwanGoContext();
            TUser deluser = db.TUsers.FirstOrDefault(user => user.FId == id);
            if (deluser == null)
                return RedirectToAction("List"); // 如果找不到對應的用戶，返回List
            return View(deluser); // 傳到畫面用強型別          
        }
        [HttpPost]
        public IActionResult Edit(TUser uiUser)
        {
            TaiwanGoContext db = new TaiwanGoContext();
            TUser dbUser = db.TUsers.FirstOrDefault(user => user.FId == uiUser.FId);
            if (dbUser == null)
                return RedirectToAction("List");
            dbUser.FName = uiUser.FName;
            dbUser.FEmail = uiUser.FEmail;
            dbUser.FPassword = uiUser.FPassword;
            dbUser.FPhone = uiUser.FPhone;
            dbUser.FBirthDate = uiUser.FBirthDate;
            db.SaveChanges();
            return RedirectToAction("List");//利用if後結束語句,少寫else{}的精簡寫法
        }
    }
}