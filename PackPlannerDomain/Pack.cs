namespace PackPlannerDomain
{
    public class Pack
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public Pack(int id, List<Item> items)
        {
            Id = id;
            Items = items;
        }

        public static List<Pack> PackItems(List<Item> items, int criteriaItems, double criteriaWeight)
        {
            List<Pack> allPackages = new List<Pack>();
            Pack currentPack = new Pack(1, new List<Item>());

            foreach (Item item in items)
            {
                // while quantity of item is bigger then 0
                while(item.Quantity > 0)
                {
                    int packSpaceRemaining = criteriaItems - PackageQuantity(currentPack);
                    int packWeightQuantityRemaining = (int)((criteriaWeight - PackageWeight(currentPack)) / item.Weight);

                    // check how much item fits into current pack
                    int addableAmount = packSpaceRemaining < packWeightQuantityRemaining ? packSpaceRemaining : packWeightQuantityRemaining;
                    addableAmount = item.Quantity < addableAmount ? item.Quantity : addableAmount;



                    // add amount to current pack and update remaining item quantity
                    if (addableAmount > 0)
                    {
                        currentPack.Items.Add(
                            new Item(
                                item.Id,
                                item.Lenght,
                                addableAmount,
                                item.Weight
                            )
                        );
                    }
                    item.Quantity -= addableAmount;

                    // if there is more item quantity create new pack
                    if (item.Quantity > 0)
                    {
                        allPackages.Add(currentPack);
                        currentPack = new Pack(currentPack.Id + 1, new List<Item>());
                    }
                }
            }

            // If the last package contains items, but it's not full,
            // then add that package to final packages
            if (currentPack.Items.Count > 0)
            {
                allPackages.Add(currentPack);
            }

            return allPackages;
        }

        public static double PackageWeight(Pack pack)
        {
            double weight = 0;
            foreach (Item item in pack.Items)
            {
                weight += item.Weight * item.Quantity;
            }
            return weight;
        }

        public static int PackageQuantity(Pack pack)
        {
            return pack.Items.Sum(item => item.Quantity);
        }

        public static int PackageMaxLenght(Pack pack)
        {
            return pack.Items.Max(item => item.Lenght);
        }
    }
}
