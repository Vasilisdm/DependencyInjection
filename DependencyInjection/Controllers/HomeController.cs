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

        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            //IRepository repository = HttpContext.RequestServices.GetService<IRepository>();
            ViewBag.HomeController = _repository.ToString();
            ViewBag.Total = totalizer.Repository.ToString();
            return View(_repository.Products);
        }
    }

}
