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
    public class World
    {
        private List<Area> _worldMap = new List<Area>();
        
        /// <summary>Get or set the Id of the starting area</summary>
        public int StartingArea { get; set; }


        /// <summary>Add a new Area to the World Map</summary>
        /// <param name="area"></param>
        public void AddArea (Area area)
        {
            var item = area ?? throw new ArgumentException(nameof(area));

            var newArea = area.Clone();

            _worldMap.Add(newArea);
        }

        /// <summary>Find the Area by it's Id</summary>
        /// <param name="id"></param>
        /// <returns>The Area that matches the Id</returns>
        public Area FindById (int id)
        {
            return _worldMap.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>Get All of the Areas in the World Map</summary>
        public IEnumerable<Area> GetAll()
        {
            return from x in _worldMap
                   select x.Clone();
        }
    }
}
