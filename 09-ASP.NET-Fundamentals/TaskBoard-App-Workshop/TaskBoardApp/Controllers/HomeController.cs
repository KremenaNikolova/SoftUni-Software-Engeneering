﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardApp.ViewModels;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}