namespace PizzaOnLine.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        public int Id { get; set; }
        public List<CartLine> lineCollection { get; set; }
        private SiteContext db = new SiteContext();

        public void AddItem(Pizza product, int quantity)
        {
            if (lineCollection == null)
                lineCollection = new List<CartLine>();

            CartLine line = lineCollection.FirstOrDefault(p => p.PizzaId == product.PizzaId);

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    PizzaId = product.PizzaId,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public decimal ComputeTotalValue()
        {
            decimal totalValue = 0;
            foreach (CartLine line in lineCollection)
                foreach (Pizza pizza in db.Pizzas.Where(e => e.PizzaId == line.PizzaId))
                    totalValue += pizza.Price * line.Quantity;
            return totalValue;
        }
    }
}
