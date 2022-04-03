using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGildedRose
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            //aplicati Factory Pattern on init
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.ChangeDay();
                item.updateQuality();
            }
        }
    }
}
