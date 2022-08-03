using App.Data;
using App.Models;
using AppMvc.Net.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMvc.Net.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbManageController(AppDbContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteDb()
        {

            return View();
        }

        [TempData]
        public string StatusMessage { get; set; }
        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()
        {
            var success = await dbContext.Database.EnsureDeletedAsync();
            StatusMessage = success ? "Xóa db thành công" : "Không xóa được";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await dbContext.Database.MigrateAsync();
            StatusMessage = "Cập nhật datbabase thành công";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SeedDataAsync()
        {
            var roleNames = typeof(RoleName).GetFields().ToList();

            foreach(var r in roleNames)
            {
                var roleName = r.GetRawConstantValue() as string;
                var rfound = await _roleManager.FindByNameAsync(roleName);

                if(rfound == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var userAdmin = await _userManager.FindByEmailAsync("admin");
            if(userAdmin == null)
            {
                userAdmin = new AppUser()
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                };

                await _userManager.CreateAsync(userAdmin, "admin123");
                await _userManager.AddToRoleAsync(userAdmin, RoleName.Administrator);
            }

            StatusMessage = "Seed Database thành công";

            return RedirectToAction("Index");

        }
    }
}
