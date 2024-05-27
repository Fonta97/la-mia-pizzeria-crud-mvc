using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.EntityFrameworkCore;


namespace la_mia_pizzeria_crud_mvc.Data
{
    //public enum ResultType
    //{
    //    OK,
    //    Exception,
    //    NotFound
    //}
    public class PizzaManager
    {
        public static int CountAllPizzas()
        {

            using PizzaContext db = new PizzaContext();
            return db.Pizzas.Count();
        }
        public static List<Pizza> GetAllPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.ToList();
        }

        public static Pizza GetPizza(int id, bool includeReferences = true)
        {
            using PizzaContext db = new PizzaContext();
            if (includeReferences)
                return db.Pizzas.Where(x => x.Id == id).Include(p => p.Category).Include(p => p.Ingredients).FirstOrDefault();
            return db.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public static List<Ingredient> GetAllIngredients()
        {
            using PizzaContext db = new PizzaContext();
            return db.Ingredients.ToList();
        }



        public static List<Category> GetAllCategories()
        {
            using PizzaContext db = new PizzaContext();
            return db.Categories.ToList();
        }

        public static void InsertPizza(Pizza pizza, List<string> selectedIngredients)
        {
            using PizzaContext db = new PizzaContext();
            pizza.Ingredients = new List<Ingredient>();
            if (selectedIngredients != null)
            {
                foreach (var ingredient in selectedIngredients)
                {
                    int id = int.Parse(ingredient);
                    var ingredientFromDb = db.Ingredients.FirstOrDefault(x => x.Id == id);
                    if (ingredientFromDb != null)
                    {
                        pizza.Ingredients.Add(ingredientFromDb);
                    }
                }
                db.Pizzas.Add(pizza);
                db.SaveChanges();
            }
        }

        //public static ResultType UpdatePizzaWithEnum(int id, Pizza pizza)
        //{
        //    try
        //    {
        //        var pizzaDaModificare = GetPizza(id);

        //        if (pizzaDaModificare == null)
        //            return ResultType.NotFound;

        //        pizzaDaModificare.Name = pizza.Name;
        //        pizzaDaModificare.Description = pizza.Description;
        //        pizzaDaModificare.Price = pizza.Price;

        //        using PizzaContext db = new PizzaContext();
        //        db.SaveChanges();
        //        return ResultType.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResultType.Exception;
        //    }
        //}



        public static bool UpdatePizza(int id, Pizza pizza)
        {
            try
            {
                var pizzaDaModificare = GetPizza(id);

                if (pizzaDaModificare == null)
                    return false;

                pizzaDaModificare.Name = pizza.Name;
                pizzaDaModificare.Description = pizza.Description;
                pizzaDaModificare.Price = pizza.Price;
                pizzaDaModificare.CategoryId = pizza.CategoryId;

                using PizzaContext db = new PizzaContext();
                db.Pizzas.Update(pizzaDaModificare);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeletePizza(int id)
        {
            try
            {
                var pizzaDaCancellare = GetPizza(id, false);

                if (pizzaDaCancellare == null)
                    return false;

                using PizzaContext db = new PizzaContext();
                db.Pizzas.Remove(pizzaDaCancellare);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }








        public static void Seed()
        {
            if (PizzaManager.CountAllPizzas() == 0)
            {
                PizzaManager.InsertPizza(
                    new Pizza("Valtellina", "Rucola, grana, bufala e bresaola", 11.5M),
                    new List<string> { "Rucola", "Grana", "Bufala", "Bresaola" }
                );

                PizzaManager.InsertPizza(
                    new Pizza("Prosciutto e funghi", "La migliore in assoluto", 7.5M),
                    new List<string> { "Prosciutto", "Funghi" }
                );

                PizzaManager.InsertPizza(
                    new Pizza("Marinara", "Pizza sabbiosa", 8M),
                    new List<string> { "Pomodoro", "Aglio", "Origano", "Olio" }
                );

                PizzaManager.InsertPizza(
                    new Pizza("La Pistacchiosa", "Una SIGNORA PIZZA! - Sdrumox", 15.5M),
                    new List<string> { "Pistacchio", "Ingrediente Speciale di Marco Merrino", "Mozzarella", "Salsiccia", "Olio di Pistacchio" }
                );
            }
        }
    }
}
