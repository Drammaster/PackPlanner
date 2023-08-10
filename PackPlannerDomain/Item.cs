namespace PackPlannerDomain
{
    public class Item
    {
        public int Id { get; set; }
        public int Lenght { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public Item(int id, int length, int quantity, double weight)
        {
            Id = id;
            Lenght = length;
            Quantity = quantity;
            Weight = weight;
        }

        public static double ItemCombinedWeight(Item item)
        {
            return item.Weight * item.Quantity;
        }

        public static List<Item> SortItems(List<Item> items, string order)
        {
            switch (order)
            {
                case "NATURAL":
                    break;
                case "SHORT_TO_LONG":
                    items.Sort((x, y) => x.Lenght.CompareTo(y.Lenght));
                    break;
                case "LONG_TO_SHORT":
                    items.Sort((x, y) => y.Lenght.CompareTo(x.Lenght));
                    break;
                default:
                    break;
            }
            return items;
        }
    }
}