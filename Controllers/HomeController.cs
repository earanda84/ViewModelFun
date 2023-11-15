using System.Diagnostics;
using FirstMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        string message = "Here is a Message!";
        return View("Index", message);
    }

    [HttpGet("numbers")]
    public IActionResult Numbers()
    {
        // Se define una viewModel dynamic, que contiene una matriz de números y un string
        var ViewModel = new
        {
            MyArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            MyString = "Here are some numbers!"
        };

        return View(ViewModel);
    }

    [HttpGet("users")]
    public IActionResult Users()
    {
        // Modelo Usuarios
        List<User> usuarios = new List<User>();

        // Lista de nombres
        List<string> names = new List<string> { "Jhon", "Peter", "Delia", "Francis", "Cynthia" };

        // Lista de Apellidos
        List<string> lastnames = new List<string>() { "Kuveit", "McManaman", "Wallace", "Van Vholt", "Kucevic" };

        // Bucle recorrer lista de nombres y apellidos
        for (int i = 0; i < names.Count && i < lastnames.Count; i++)
        {
            // Modelo usuario se agregan múltiples nombres y apellidos
            usuarios.Add(new User { Name = names[i], LastName = lastnames[i] });
        }

        // Se crea un model view para pasarlo a la vista, contiene varios usuarios que a su vez son una lista de modelo usuario
        // Se agrega además un titulo pasado a la vista
        var modelView = new
        {
            Usuarios = usuarios,
            Title = "Here some users!"
        };

        // se pasa a la vista el view model
        return View(modelView);
    }

    [HttpGet("user")]
    public IActionResult UserPage(string fullName)
    {
        // Declaración de ViewModel con un string y los parametros pasado por el redireccionamiento de anchor frontend
        var user = new
        {
            title = "Here is a User!",
            fullName
        };
        
        return View(user);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
