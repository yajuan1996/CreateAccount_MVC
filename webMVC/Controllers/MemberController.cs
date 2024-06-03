using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC.Models;

namespace webMVC.Controllers
{
    public class MemberController : Controller
    {
        /// <summary>
        /// 會員資料
        /// </summary>
        private static List<MemberVM> memberList = new List<MemberVM>();

        /// <summary>
        /// 畫面
        /// 若有id為修改，無id則為新增
        /// </summary>
        /// <param name="id">編號</param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {            
            if(id != 0 && id !=null)
            {
                var member = memberList.FirstOrDefault(x => x.Id == id);
                return View(member);
            }
            else
            {                
                return View();
            }
            
        }

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMemberList()
        {            
            return Json(memberList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改or新增帳號
        /// </summary>
        /// <param name="member">會員資料</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(MemberVM member)
        {
            if(memberList.Exists(x => x.Id == member.Id))
            {
                var updateMember = memberList.FirstOrDefault(x => x.Id == member.Id);
                updateMember.Name = member.Name;
                updateMember.Age = member.Age;
                updateMember.Birthday = member.Birthday;
                TempData["Message"] = "修改成功";
            }
            else
            {                
                member.Id = memberList.Count == 0 ? 1 : memberList.Max(x => x.Id) + 1;
                memberList.Add(member);
                TempData["Message"] = "新增成功";
            }            
            
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 刪除帳號
        /// </summary>
        /// <param name="id">編號</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var member = memberList.FirstOrDefault(x => x.Id == id);
            memberList.Remove(member);
            TempData["Message"] = "刪除成功";
            return RedirectToAction("Index");
        }

    }
}