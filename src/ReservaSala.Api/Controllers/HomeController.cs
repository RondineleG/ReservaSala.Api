using Microsoft.AspNetCore.Mvc;

namespace ReservaSala.Api.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "API Running...";
        }
    }
}