using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiemCong_NguyenvanTuan.Models;

namespace DiemCong_NguyenvanTuan.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext db =new DataClasses1DataContext();
        public ActionResult Index()
        {
            var all_sv = from ss in db.SinhViens select ss;
            return View(all_sv);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ma = (from ss in db.SinhViens select ss).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var ma = collection["MaSV"];
            var ten = collection["HoTen"];
            var sex = collection["GioiTinh"];
            var date = collection["NgaySinh"];
            var hinh = collection["Hinh"];
            ViewBag.ma = (from ss in db.SinhViens select ss).ToList();

            if (string.IsNullOrEmpty(ma))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = ma.ToString();
                s.HoTen = ten.ToString();
                s.GioiTinh = sex;
                s.NgaySinh = DateTime.Parse(date);
                s.Hinh = hinh.ToString();
                db.SinhViens.InsertOnSubmit(s);
                db.SubmitChanges();
                return RedirectToAction("ListSach");
            }
            return this.Create();
        }
        //[HttpGet]
        //public ActionResult DangNhap()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult DangNhap(FormCollection collection)
        //{
        //    string tendangnhap = collection["tendangnhap"];
        //    string matkhau = collection["matkhau"];
        //    KhachHang kh = data.KhachHangs.SingleOrDefault(a => a.tendangnhap == tendangnhap && a.matkhau == matkhau);
        //    if (kh != null)
        //    {
        //        Session["Taikhoan"] = kh;
        //        Session["ten"] = tendangnhap;
        //        ViewBag.ThongBao = "Chúc mừng đăng nhập thành công!";
        //    }
        //    else
        //    {
        //        ViewBag.Thongbao = "Tên Tài Khoản Hoặc Mật Khẩu Không Đúng";
        //    }

        //    return RedirectToAction("Index", "Home");
        //}

        //public ActionResult LogOut()
        //{
        //    Session["Taikhoan"] = null;
        //    return RedirectToAction("DangNhap", "NguoiDung");
        //}
        //public ActionResult CHeanePass()
        //{
        //    Session["Taikhoan"] = null;
        //    return RedirectToAction("DangNhap", "NguoiDung");
        //}
    }
}