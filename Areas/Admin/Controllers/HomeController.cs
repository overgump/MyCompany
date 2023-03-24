using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        
       // [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
