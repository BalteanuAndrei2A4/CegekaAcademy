using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGildedRose
{
    public class test
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new AgeBrie ("Aged Brie", 2,  0),
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Sulfuras ("Sulfuras, Hand of Ragnaros",0,80),
                new Sulfuras ("Sulfuras, Hand of Ragnaros", -1,  80),
                new BackStage("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new BackStage(  "Backstage passes to a TAFKAL80ETC concert", 10, 49),
                new BackStage("Backstage passes to a TAFKAL80ETC concert", 5,49),
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            int days = 5;
            if (args.Length > 0)
            {
                days = int.Parse(args[0]) + 1;
            }

            for (var i = 0; i < days; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
