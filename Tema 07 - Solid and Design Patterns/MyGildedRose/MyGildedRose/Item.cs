using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGildedRose
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public Item() { }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void ChangeDay()
        {
            SellIn--;
        }

        public virtual void updateQuality()
        {
            if (SellIn < 0)
                Quality -= 2;
            else
            {
                Quality--;
            }
        }
    }

    public class AgeBrie : Item
    {
        public AgeBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        
        }

        public override void updateQuality()
        {
           
            if (Quality >= 50)
            {
                return;
            }
            
            Quality += 1;
        }
    }

    public class BackStage : Item
    {
        public BackStage(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {

          if(Quality > 50)
          {
                return;
          }
          if (SellIn <= 0)
          {
                Quality = 0;
          }
          else if(SellIn < 6 && SellIn >0)
          {
                Quality += 3;
          }
          else if (SellIn >=6 && SellIn <11)
          {
                Quality += 2;
          }
          else
          {
                Quality += 1;
          }

            if (Quality > 50)
                Quality = 50;


        }
    }

    public class Conjured : Item
    {
        public Conjured(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {

        }
        public override void updateQuality()
        {
            if (Quality <= 0)
            {
                return;
            }
            if (SellIn <= 0)
                Quality -= 2;

            Quality -= 2;
        }
    }

    public class Sulfuras : Item
    {
        public Sulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {

        }
        public override void updateQuality()
        {
            
        }
    }
}
