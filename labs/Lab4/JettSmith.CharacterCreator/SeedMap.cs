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
    public static class SeedMap
    {
        /// <summary>Seed the World Map</summary>
        public static void Seed ( this World worldmap)
        {
            var areas = new[]
            {
                new Area() {
                    Description = "Past the rocky shore, you see a small cove, with a lovely song coming from it. Seated inside is a mermaid, with a golden key around her neck, emblazoned with a blue music note.",
                    Id = 1,
                    NorthArea = -1,
                    SouthArea = 4,
                    EastArea = 2,
                    WestArea = -1,
                },
                new Area() {
                    Description = "High above the sea, on the edge of a cliff, you spot a large nest, sitting in it is a large griffon, tied to its beak is a golden key, " +
                        "emblazoned with a brown feather.",
                    Id = 2,
                    NorthArea = -1,
                    SouthArea = 5,
                    EastArea = 3,
                    WestArea = 1,
                },
                new Area() {
                    Description = "Built into the mountains is a small shrine, though there seems to no sigh as to who the shrine is for Within a small cage in the shrine " +
                        "is a golden key, emblazoned with a yellow cresent moon.",
                    ItemDescription = "Sitting beside the shrine is a lute. Somebody might have a use for it.",
                    AreaItem = new Item {
                        Name = "Lute",
                        GoldValue = 45,
                        Weight = 3,
                    },
                    Id = 3,
                    NorthArea = -1,
                    SouthArea = 6,
                    EastArea = -1,
                    WestArea = 2,
                },
                new Area() {
                    Description = "You come up to a large grove, within the forest. Sitting there is a beautiful woman that seems to made of plants. The dryad satnds " +
                        "before a massive tree, hanging off a branch is a golden key emblazoned with a green tree.",
                    Id = 4,
                    NorthArea = 1,
                    SouthArea = 7,
                    EastArea = 5,
                    WestArea = -1,
                },
                new Area() {
                    Description = "Standing before you is a large stone, with eight keyholes in a square around a clawed handprint. In order to find those keys, a long " +
                        "journey awaits.",
                    Id = 5,
                    NorthArea = 2,
                    SouthArea = 8,
                    EastArea = 6,
                    WestArea = 4,
                },
                new Area() {
                    Description = "Coming across a large bridge, you hear a roar from below, a hideous troll stands below the bridge, tied to its nose is a golden key " +
                        "emblazoned with a black sun.",
                    ItemDescription = "On the other side of the bridge you can see a brilliant blue gemstone.",
                    AreaItem = new Item {
                        Name = "Sappire",
                        GoldValue = 500,
                        Weight = 1,
                    },
                    Id = 6,
                    NorthArea = 3,
                    SouthArea = 9,
                    EastArea = -1,
                    WestArea = 5,
                },
                new Area() {
                    Description = "A large castle sits on the edge of a cliff. Going inside, you see a king sitting on his throne. Beside him is a pedestal housing a " +
                        "golden key emlazoned with a yellow crown",
                    Id = 7,
                    NorthArea = 4,
                    SouthArea = -1,
                    EastArea = 8,
                    WestArea = -1,
                },
                new Area() {
                    Description = "You come across a massive graveyard, with several undead moving about within. Around the neck of the largest zombie is a golden key " +
                        "emblazoned with a white tombstone.",
                    ItemDescription = "Stuck in the ground is a sword, it may prove useful.",
                    AreaItem = new Item {
                        Name = "Sword",
                        GoldValue = 12,
                        Weight = 3,
                    },
                    Id = 8,
                    NorthArea = 5,
                    SouthArea = -1,
                    EastArea = 9,
                    WestArea = 7,
                },
                new Area() {
                    Description = "Within a large cave you see a massive red dragon, sleeping on a pile of gold and jewels. On a pedestal sets a golden key, " +
                        "emblazoned with a red flame",
                    Id = 9,
                    NorthArea = 6,
                    SouthArea = -1,
                    EastArea = -1,
                    WestArea = 8,
                },
            };

            foreach (var area in areas)
                worldmap.AddArea(area);

            worldmap.StartingArea = 5;
        }
    }
}
