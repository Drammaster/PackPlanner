using Nancy.Json;
using PackPlannerDomain;

namespace PackPlannerTest
{
    public class ItemTest
    {
        private static readonly string orderNATURAL = "NATURAL";
        private static readonly string orderSHORTTOLONG = "SHORT_TO_LONG";
        private static readonly string orderLONGTOSHORT = "LONG_TO_SHORT";

        private static readonly Item itemGood = new Item(1001, 7000, 30, 3.0);

        private static readonly List<Item> itemsSample = new List<Item>{
            new Item(1001, 6200, 30, 9.653),
            new Item(2001, 7200, 50, 11.21),
            new Item(3001, 6100, 25, 9.655),
            new Item(4001, 3200, 40, 11.24)
        };

        private static readonly List<Item> itemsLongToShort = new List<Item>{
            new Item(2001, 7200, 50, 11.21),
            new Item(1001, 6200, 30, 9.653),
            new Item(3001, 6100, 25, 9.655),
            new Item(4001, 3200, 40, 11.24)
        };

        private static readonly List<Item> itemsShortToLong = new List<Item>{
            new Item(4001, 3200, 40, 11.24),
            new Item(3001, 6100, 25, 9.655),
            new Item(1001, 6200, 30, 9.653),
            new Item(2001, 7200, 50, 11.21)
        };

        [Fact]
        public void ItemCombinedWeight_ReturnsCorrect()
        {
            Assert.Equal(90.0, Item.ItemCombinedWeight(itemGood));
        }

        [Fact]
        public void ItemCombinedWeight_ReturnsIncorrect()
        {
            Assert.NotSame(90, Item.ItemCombinedWeight(itemGood));
            Assert.NotEqual(-90, Item.ItemCombinedWeight(itemGood));
            Assert.NotEqual(91, Item.ItemCombinedWeight(itemGood));
        }

        [Fact]
        public void ItemSort_NATURALorder()
        {
            var serializer = new JavaScriptSerializer();
            var expectedString = serializer.Serialize(itemsSample);
            var notExpectedString = serializer.Serialize(itemsShortToLong);
            var actualString = serializer.Serialize(Item.SortItems(itemsSample, orderNATURAL));

            Assert.Equal(expectedString, actualString);
            Assert.NotEqual(notExpectedString, actualString);
        }

        [Fact]
        public void ItemSort_SHORTTOLONGorder()
        {
            var serializer = new JavaScriptSerializer();
            var expectedString = serializer.Serialize(itemsShortToLong);
            var notExpectedString = serializer.Serialize(itemsLongToShort);
            var actualString = serializer.Serialize(Item.SortItems(itemsSample, orderSHORTTOLONG));

            Assert.Equal(expectedString, actualString);
            Assert.NotEqual(notExpectedString, actualString);
        }

        [Fact]
        public void ItemSort_LONGTOSHORTorder()
        {
            var serializer = new JavaScriptSerializer();
            var expectedString = serializer.Serialize(itemsLongToShort);
            var notExpectedString = serializer.Serialize(itemsShortToLong);
            var actualString = serializer.Serialize(Item.SortItems(itemsSample, orderLONGTOSHORT));

            Assert.Equal(expectedString, actualString);
            Assert.NotEqual(notExpectedString, actualString);
        }
    }
}