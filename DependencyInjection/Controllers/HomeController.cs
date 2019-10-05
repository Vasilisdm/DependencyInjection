using System;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View(new MemoryRepository().Products);
    }

}
