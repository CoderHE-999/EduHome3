using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeacherController : Controller
    {
        private readonly DataContext _context;

        public TeacherController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Teachers.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Teacher teacher)
        {
            if (teacher.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "IMage is required");
            }

            else if (teacher.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "Max size 2MB");
            }

            else if (teacher.ImageFile.ContentType != "image/jpg" && teacher.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "Format is incorrect!(image.jpg or image.png)");
            }

            if (!ModelState.IsValid) return View();

            return Ok();

        }

        


    }
}
