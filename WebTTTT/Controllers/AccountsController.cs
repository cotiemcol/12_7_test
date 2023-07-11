using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebTTTT.Models;

namespace WebTTTT.Controllers
{
    public class AccountsController : Controller

    {
        private QlyTheThaoEntities db = new QlyTheThaoEntities();
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "taiKhoan,matKhau,hoTenKH,sdtKH,emailKH")] KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(kh.taiKhoan) ||
                    string.IsNullOrWhiteSpace(kh.matKhau) ||
                    string.IsNullOrWhiteSpace(kh.hoTenKH) ||
                    string.IsNullOrWhiteSpace(kh.sdtKH) ||
                    string.IsNullOrWhiteSpace(kh.emailKH))
                {
                    ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin.");
                    return View(kh);
                }
                if (db.KhachHangs.Find(kh.taiKhoan) == null)
                {                   
                    if (kh.matKhau.Length < 6)
                    {
                        ModelState.AddModelError("matKhau", "Mật khẩu phải chứa ít nhất 6 kí tự.");
                        return View(kh);
                    }

                    if (!kh.emailKH.EndsWith("@gmail.com"))
                    {
                        ModelState.AddModelError("emailKH", "Email phải kết thúc bằng '@gmail.com'.");
                        return View(kh);
                    }

                    // kiểm tra số điện thoại phải bắt đầu bằng số 0 và có 10 chữ số từ 0 -> 9
                    if (!Regex.IsMatch(kh.sdtKH, "^0\\d{8,}$"))
                    {
                        ModelState.AddModelError("sdtKH", "Số điện thoại phải bắt đầu bằng số 0 và có ít nhất 9 chữ số.");
                        return View(kh);
                    }

                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    Session["KH"] = kh;
                    return RedirectToAction("Accounts", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản đã được sử dụng !");
                }
            }

            return View(kh);
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}