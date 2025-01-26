using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();  // Ensure it returns a view (index.cshtml)
    }
}
