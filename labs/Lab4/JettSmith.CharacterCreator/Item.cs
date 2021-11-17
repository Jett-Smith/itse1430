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
    public class Item
    {
        private string _name;

        /// <summary>Get or set the name</summary>
        public string Name
        {
            get => (_name != null) ? _name : "";
            set => _name = (value != null) ? value.Trim() : null;
        }

        /// <summary>Get or set the gold value</summary>
        public int GoldValue { get; set; }


        /// <summary>Get or set the weight in pounds</summary>
        public int Weight { get; set; }

        /// <summary>Clones the item</summary>
        /// <returns>A clone of the item</returns>
        public Item Clone() => new Item() {
            Name = Name,
            GoldValue = GoldValue,
            Weight = Weight,
        };

        public override string ToString ()
        {
            return $"{Name}: Worth {GoldValue} gp  {Weight} lbs.";
        }
    }
}
