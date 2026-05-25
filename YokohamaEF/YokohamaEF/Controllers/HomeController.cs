using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YokohamaEF.Data;
using YokohamaEF.Models;

namespace YokohamaEF.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //ดึง Migrations
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        //GET : แสดงรายชื่อพนักงานทั้งหมด
       public IActionResult Employees()
        {
            var employees = _db.Employees.ToList();
            return View(employees);
        }

        // GET: หน้าฟอร์มเพิ่มพนักงาน
        public IActionResult Create()
        {
            return View();
        }

        // POST: บันทึกพนักงานใหม่
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Employees");
        }

        // GET: หน้าฟอร์มแก้ไข
        public IActionResult Edit(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        // POST: บันทึกการแก้ไข
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            _db.Employees.Update(employee);
            _db.SaveChanges();
            return RedirectToAction("Employees");
        }

        // POST: ลบพนักงาน
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null) return NotFound();

            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Employees");
        }
    }
}
