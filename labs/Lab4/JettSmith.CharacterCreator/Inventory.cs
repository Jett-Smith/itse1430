/*
 *  Jett Smith
 *  ITSE 1430 - Fall 2021
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JettSmith.AdventureGame
{
    public class Inventory
    {
        private List<Item> _inventory = new List<Item>();

        /// <summary>Add an item to the inventory</summary>
        /// <param name="item"></param>
        public void Add(Item item)
        {
            var newItem = item ?? throw new ArgumentException(nameof(item));

            var newItem2 = newItem.Clone();

            _inventory.Add(newItem);
        }

        /// <summary>Get the total weight of the inventory</summary>
        /// <returns>The total weight of the inventory</returns>
        public int GetTotalWeight()
        {
            int weight = 0;

            Item[] items = GetAll().ToArray();

            foreach (Item x in items)
                weight += x.Weight;

            return weight;
        }

        public int GetTotalGoldCost()
        {
            int cost = 0;

            Item[] items = GetAll().ToArray();

            foreach (Item x in items)
                cost += x.GoldValue;

            return cost;
        }

        /// <summary>Get all the items in the Inventory</summary>
        /// <returns>All items in Inventory</returns>
        public IEnumerable<Item> GetAll ()
        {
            return from x in _inventory
                   select x.Clone();
        }
    }
}
