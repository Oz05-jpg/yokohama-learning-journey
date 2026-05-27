using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YokohamaEF.Data;
using YokohamaEF.Models;

namespace YokohamaEF.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _db;

        public DepartmentController(AppDbContext db)
        {
            _db = db;

        }

        //GET : แสดง Department ทั้งหมด
        public IActionResult Index()
        {
            var departments = _db.Departments
                .Include(d => d.Employees)
                .ToList();
            return View(departments);
        }

        //GET : หน้าเพิ่ม Department 
        public IActionResult Create()
        {
            return View();
        }

        //POST : บันทึก Department ใหม่
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
                return View(department);
            _db.Departments.Add(department);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
