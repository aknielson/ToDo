using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Mvc.Controllers
{
    public class ToDoController : Controller
    {
        public ToDoController()
        {
            
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "ToDo Zim";
            return View();
        }
    }
}