using Microsoft.AspNetCore.Mvc.Rendering;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class PizzaFormModel
    {
        public Pizza Pizza { get; set; }
        public List<Category>? Categories { get; set; }

        public List<SelectListItem>? Ingredients { get; set; }
        public List<string> SelectedIngredients { get; set; }
        public PizzaFormModel() { }

        public PizzaFormModel(Pizza pizza, List<Category>? categories)
        {

            Pizza = pizza;
            Categories = categories;
        }

        public void CreateIngredients()
        {
            this.Ingredients = new List<SelectListItem>();
            this.SelectedIngredients = new List<string>();
            var ingredientsFromDB = PizzaManager.GetAllIngredients();
            foreach (var ingredient in ingredientsFromDB)
            {
                bool isSelected = this.Pizza.Ingredients?.Any(t => t.Id == ingredient.Id) == true;
                this.Ingredients.Add(new SelectListItem()
                {
                    Text = ingredient.Name,
                    Value = ingredient.Id.ToString(),
                    Selected = isSelected
                });
                if (isSelected)
                {
                    this.SelectedIngredients.Add(ingredient.Id.Tostring());
                }

            }
        }
    }
}