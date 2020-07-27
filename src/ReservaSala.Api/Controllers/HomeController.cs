using Microsoft.AspNetCore.Mvc;

namespace ReservaSala.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public string Index()
        {
            return "Api Running...";
        }
    }
}