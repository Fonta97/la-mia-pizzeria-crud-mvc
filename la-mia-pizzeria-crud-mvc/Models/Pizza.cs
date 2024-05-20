namespace la_mia_pizzeria_razor_layout.Models
{
    public class Pizza
    {
        public string name { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public decimal price { get; set; }

        public Pizza(string name, string description, string img, decimal price)
        {
            this.name = name;
            this.description = description;
            this.img = img;
            this.price = price;
        }
    }
}

