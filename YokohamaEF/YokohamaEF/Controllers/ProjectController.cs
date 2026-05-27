using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YokohamaEF.Data;
using YokohamaEF.Models;
namespace YokohamaEF.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly AppDbContext _db;

        public ProjectController(AppDbContext db)
        {
            _db = db;
        }

        //index
        public IActionResult Index()
        {
            var projects = _db.Projects
                .Include(p => p.Employees)
                .ToList();
            return View(projects);
        }

        //create
        public IActionResult Create(Project project)
        {
            if (!ModelState.IsValid)
                return View(project);
            _db.Projects.Add(project);
            _db.SaveChanges();
            return RedirectToAction("Index");//ส่งค่ากลับมาหน้าแรก
        }

        // GET: เปิดหน้า Assign — รับ project id มา
        public IActionResult Assign(int id)
        {
            // ดึง project + employees ที่อยู่ใน project นี้อยู่แล้ว
            var project = _db.Projects
                .Include(p => p.Employees) // Eager Load — ดึง Employees มาด้วยเลย
                .FirstOrDefault(p => p.Id == id);
            if (project == null) return NotFound();

            // ส่ง employees ทั้งหมดไปให้ View เลือก (เพื่อทำ checkbox)
            ViewBag.AllEmployees = _db.Employees.ToList();
            return View(project);
        }

        //POST: รับ checkbox ที่โอเลือกมา → บันทึก
        [HttpPost]
        public IActionResult Assign(int id, List<int> employeeIds)
        {
            // ดึง project พร้อม employees ที่ assign อยู่ตอนนี้
            var project = _db.Projects
                .Include(p => p.Employees)
                .FirstOrDefault(p => p.Id == id);

            if (project == null) return NotFound();

            // ล้าง employees เดิมออกทั้งหมดก่อน (EF จัดการ Junction Table ให้)
            project.Employees.Clear();

            // หา Employee objects จาก id ที่เลือกมา
            var selected = _db.Employees
                .Where(e => employeeIds.Contains(e.Id))
                .ToList();

            // เพิ่มทีละคนเข้า project (EF เขียน Junction Table ให้อัตโนมัติ)
            foreach (var emp in selected)
                project.Employees.Add(emp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
