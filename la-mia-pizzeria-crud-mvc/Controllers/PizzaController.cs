using la_mia_pizzeria_crud_mvc.Data;
using la_mia_pizzeria_crud_mvc.Models;
using la_mia_pizzeria_razor_layout.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_razor_layout.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(PizzaManager.GetAllPizzas());
        }

        [HttpGet]
        public IActionResult GetPizza(int id)
        {
            var pizza = PizzaManager.GetPizza(id);
            if (pizza != null)
                return View(pizza);

            else
                return View("errore");
        }

        [HttpGet]
        public IActionResult Create() //Restituisce form creazione
        {
            Pizza p = new Pizza("Nome di default", "Descrizione base", 66.6M);
            List<Category> categories = PizzaManager.GetAllCategories();
            PizzaFormModel model = new PizzaFormModel(p, categories);
            model.CreateIngredients();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaFormModel pizzaDaInserire)
        {
            if (ModelState.IsValid == false)
            {
                pizzaDaInserire.CreateIngredients();
                return View("Create", pizzaDaInserire); //ritorno form con i dati della pizza precompilati dallo user
            }

            PizzaManager.InsertPizza(pizzaDaInserire.Pizza);
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Update(int id) //update pizza
        {
            var pizza = PizzaManager.GetPizza(id);
            if (pizza == null)
                return NotFound();
            PizzaFormModel model= new PizzaFormModel(pizza, PizzaManager.GetAllCategories());
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaFormModel pizzaDaModificare)
        {
            if (ModelState.IsValid == false)
            {
                return View("Update", pizzaDaModificare); //ritorno form con i dati della pizza precompilati dallo user
            }


            var modified = PizzaManager.UpdatePizza(id, pizzaDaModificare.Pizza);
            if (modified)
            {
                return RedirectToAction("Index");

            }
            else
                return NotFound();

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePizza(int id)
        {
            var deleted = PizzaManager.DeletePizza(id);
            if (deleted)
            {
                return RedirectToAction("Index");

            }
            else
                return NotFound();

        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
