using Nancy.Json;
using PackPlannerDomain;

namespace PackPlannerTest
{
    public class PackTest
    {
        private static readonly List<Pack> expected = new List<Pack>{
                new Pack(1, new List<Item>{
                        new Item(1001,6200,10,9.653)
                    }
                ),
                new Pack(2, new List<Item>{
                        new Item(1001,6200,10,9.653),
                    }
                ),
                new Pack(3, new List<Item>{
                        new Item(1001,6200,10,9.653),
                    }
                ),
                new Pack(4, new List<Item>{
                        new Item(2001,7200,8,11.21)
                    }
                ),
                new Pack(5, new List<Item>{
                        new Item(2001,7200,2,11.21)
                    }
                )
            };

        private static readonly List<Pack> notExpected = new List<Pack>{
                new Pack(1, new List<Item>{
                        new Item(1001,6200,30,9.653)
                    }
                ),
                new Pack(2, new List<Item>{
                        new Item(2001,7200,10,11.21)
                    }
                )
            };

        private static readonly List<Item> itemsSampleOne = new List<Item>{
                new Item(1001,6200,30,9.653),
                new Item(2001,7200,10,11.21)
            };

        [Fact]
        public static void PackageWeight_ReturnCorrect()
        {
            Assert.Equal(96.53, Pack.PackageWeight(expected[0]));
            Assert.NotEqual(96, Pack.PackageWeight(expected[0]));
            Assert.NotEqual(96.54, Pack.PackageWeight(expected[0]));
            Assert.NotEqual(96.52, Pack.PackageWeight(expected[0]));
        }

        [Fact]
        public static void PackageQauntity_ReturnCorrect()
        {
            Assert.Equal(10, Pack.PackageQuantity(expected[0]));
            Assert.NotEqual(9, Pack.PackageQuantity(expected[0]));
            Assert.NotEqual(11, Pack.PackageQuantity(expected[0]));
        }

        [Fact]
        public static void PackageMaxLenght_ReturnCorrect()
        {
            Assert.Equal(6200, Pack.PackageMaxLenght(expected[0]));
        }

        [Fact]
        public static void PackItems_ReturnsCorrect()
        {
            List<Pack> actual = Pack.PackItems(itemsSampleOne, 80, 100.0);

            var serializer = new JavaScriptSerializer();
            var expectedString = serializer.Serialize(expected);
            var notExpectedString = serializer.Serialize(notExpected);
            var actualString = serializer.Serialize(actual);

            Assert.Equal(expectedString, actualString);
            Assert.NotEqual(notExpectedString, actualString);
        }
    }
}
