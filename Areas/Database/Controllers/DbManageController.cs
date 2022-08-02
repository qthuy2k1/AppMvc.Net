using AppMvc.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMvc.Net.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext dbContext;

        public DbManageController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
