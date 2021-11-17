/*
 *  Jett Smith
 *  ITSE 1430 - Fall 2021
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JettSmith.AdventureGame
{
    public class Area
    {
        private string _description;
        private string _itemDescription;

        /// <summary>Get or set description of the Area</summary>
        public string Description
        {
            get => _description ?? "";
            set => _description = value.Trim();
        }

        /// <summary>The additional description of the item, if there is one</summary>
        public string ItemDescription
        {
            get => (_itemDescription != null) ? _itemDescription : "";
            set => _itemDescription = (value != null) ? value.Trim() : null;
        }

        /// <summary>Get or set the item</summary>
        public Item AreaItem { get; set; }

        /// <summary>Get or set id of the Area</summary>
        public int Id { get; set; }

        /// <summary>Get or set the Id of the area to the North (-1 if there is no area north)</summary>
        public int NorthArea { get; set; }

        /// <summary>Get or set the Id of the area to the South (-1 if there is no area north)</summary>
        public int SouthArea { get; set; }

        /// <summary>Get or set the Id of the area to the East (-1 if there is no area north)</summary>
        public int EastArea { get; set; }

        /// <summary>Get or set the Id of the area to the West (-1 if there is no area north)</summary>
        public int WestArea { get; set; }

        public Area Clone () => new Area {
            Description = Description,
            ItemDescription = ItemDescription,
            AreaItem = AreaItem,
            Id = Id,
            NorthArea = NorthArea,
            SouthArea = SouthArea,
            EastArea = EastArea,
            WestArea = WestArea,
        };
    }
}
