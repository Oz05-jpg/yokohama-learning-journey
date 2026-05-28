using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace YokohamaEF.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //GET: /Admin/Users
        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // GET: /Admin/AssignRole
        public async Task<IActionResult> AssignRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var currentRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            ViewBag.UserId = userId;
            ViewBag.Email = user.Email;
            ViewBag.CurrentRoles = currentRoles;
            ViewBag.AllRoles = allRoles;

            return View();
        }

        // POST: /Admin/AssignRole
        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            // ลบ roles เดิมออกก่อน แล้วใส่ใหม่
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, role);

            return RedirectToAction("Users");
        }

        // GET: /Admin/DeleteUser
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            ViewBag.Email = user.Email;
            ViewBag.UserId = userId;
            return View();
        }

        //POST: /Admin/DeleteUser
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId, bool confirm)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            await _userManager.DeleteAsync(user);
            return RedirectToAction("Users");

        }


    }
}
