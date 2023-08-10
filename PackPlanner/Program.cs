using PackPlannerDomain;

namespace Program
{
    class Program
    {
        static void Main()
        {
            string criteriaRead = Console.ReadLine();

            List<Item> items = new List<Item>();

            string itemInput = Console.ReadLine();
            while (itemInput != string.Empty)
            {
                // Added Item to list if input doesn't produce an Error
                try
                {
                    Item foundItem = items.Find(item => item.Id == Int32.Parse(itemInput.Split(new char[] { ',' })[0]));
                    if (foundItem != null)
                    {
                        foundItem.Quantity += Int32.Parse(itemInput.Split(new char[] { ',' })[2]);
                    } else
                    {
                        items.Add(
                            new Item(
                                Int32.Parse(itemInput.Split(new char[] { ',' })[0]),
                                Int32.Parse(itemInput.Split(new char[] { ',' })[1]),
                                Int32.Parse(itemInput.Split(new char[] { ',' })[2]),
                                Double.Parse(itemInput.Split(new char[] { ',' })[3])
                            )
                        );
                    }
                } catch
                {
                    Console.WriteLine("INPUT ERROR");
                }

                // Read next input
                itemInput = Console.ReadLine();
            }

            items = Item.SortItems(items, criteriaRead.Split(new char[] { ',' })[0]);

            // Pack items
            List<Pack> packs = Pack.PackItems(
                items,
                Int32.Parse(criteriaRead.Split(new char[] { ',' })[1]),
                Double.Parse(criteriaRead.Split(new char[] { ',' })[2])
            );

            foreach (var pack in packs)
            {
                Console.WriteLine($"Pack Number: {pack.Id}");
                foreach (var item in pack.Items)
                {
                    Console.WriteLine($"{item.Id},{item.Lenght},{item.Quantity},{item.Weight}");
                }
                Console.WriteLine($"Pack Length: {Pack.PackageMaxLenght(pack)}, Pack Weight: {Pack.PackageWeight(pack).ToString("0.#############################")}");
                Console.WriteLine();
            }
        }
    }
}