using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    public class ProductTest
    {
        static List<Product> products = new List<Product> {
                new Product("Electric sander", Type.M, new List<int> {99, 82, 81, 79}, 157.98m),
                new Product("Power saw", Type.M, new List<int> {99, 86, 90, 94}, 99.99m),
                new Product("Sledge hammer", Type.F, new List<int> {93, 92, 80, 87}, 21.50m),
                new Product("Hammer", Type.M, new List<int> {97, 89, 85, 82}, 11.99m),
                new Product("Lawn mower", Type.F, new List<int> {35, 72, 91, 70}, 139.50m),
                new Product("Screwdriver", Type.F, new List<int> {88, 94, 65, 91}, 56.99m),
                new Product("Jig saw", Type.M, new List<int> {75, 84, 91, 39}, 11.00m),
                new Product("Wrench", Type.F, new List<int> {97, 92, 81, 60}, 17.50m),
                new Product("Sledge hammer", Type.M, new List<int> {75, 84, 91, 39}, 21.50m),
                new Product("Hammer", Type.F, new List<int> {94, 92, 91, 91}, 11.99m),
                new Product("Lawn mower", Type.M, new List<int> {96, 85, 91, 60}, 179.50m),
                new Product("Screwdriver", Type.M, new List<int> {96, 85, 51, 30}, 66.99m)
            };

        public static void GroupByCategoryCountDescending() 
        {
            foreach (var item in products.GroupBy(info => info.Category)
                         .Select(group => new {
                             Metric = group.Key,
                             Count = group.Count()
                         })
                         .OrderBy(x => x.Metric))
            {
                Console.WriteLine($"Category group: {item.Metric}\n                " +
                    $"Number of products of Type {item.Metric} in this group: {item.Count}");
            }

        }

        public static void GroupByQtrAndProductPriceAvg() 
        {
            foreach (var item in products.GroupBy(info => info.Quarter)
                            .Select(group => new
                            {
                                Metric = group.Key,
                                Price = group.Average(p => p.Price)
                            })
                            .OrderBy(x => x.Metric))
            {
                Console.WriteLine($"Quarter group: {item.Metric}\n        " +
                    $"Average price per Quarter {item.Metric} in this group: ${item.Price}");
            }
        }

        public static void GroupByQtrCategoryWeeklySum() 
        {
            foreach (var item in products.GroupBy(c => new { Quarter = c.Quarter, Category = c.Category })
                               .Select(group => new
                               {
                                   Description = group.,
                                   Price = group.Average(p => p.Price)
                               })
                               .OrderBy(x => x.Metric))
            {
                Console.WriteLine($"Quarter group: {item.Metric}\n        " +
                    $"Average price per Quarter {item.Metric} in this group: ${item.Price}");
            }

        }

        static void Main(string[] args)
        {
            GroupByCategoryCountDescending(); Console.WriteLine("\n\n");
            GroupByQtrAndProductPriceAvg();

        }
    }
}
