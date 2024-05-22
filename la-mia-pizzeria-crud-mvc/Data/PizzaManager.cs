namespace la_mia_pizzeria_crud_mvc.Data
{
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

        public static Pizza GetPizza(int id)
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public static void InsertPizza(Pizza pizza)
        {
            using PizzaContext db = new PizzaContext();
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }

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

                using PizzaContext db = new PizzaContext();
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

                PizzaManager.InsertPizza(new Pizza("Valtellina", "Rucola, grana, bufala e bresaola", 11.5M));
                PizzaManager.InsertPizza(new Pizza("Prosciutto e funghi", "La migliore in assoluto", 7.5M));
                PizzaManager.InsertPizza(new Pizza("Marinara", "Pizza sabbiosa", 8M));
                PizzaManager.InsertPizza(new Pizza("La Pistacchiosa", "Una SIGNORA PIZZA! - Sdrumox", 15.5M));
            }
        }
    }
}
