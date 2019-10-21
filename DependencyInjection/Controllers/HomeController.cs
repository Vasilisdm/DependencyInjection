using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        private ProductTotalizer _totalizer;

        public HomeController(IRepository repo, ProductTotalizer total)
        {
            _repository = repo;
            _totalizer = total;
        }

        public ViewResult Index()
        {
            ViewBag.Total = _totalizer.Total;
            return View(_repository.Products);
        }
    }

}
