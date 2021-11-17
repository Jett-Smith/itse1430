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
    public class Player
    {
        private Character _playerCharacter;

        public Inventory inventory = new Inventory();
        
        /// <summary>Get or set the character</summary>
        public Character PlayerCharacter
        {
            get => (_playerCharacter != null) ? _playerCharacter : new Character();
            set => _playerCharacter = (value != null) ? value : null;
        }

        /// <summary>Get or set the current location of the player</summary>
        public int CurrentArea { get; set; }

    }
}
