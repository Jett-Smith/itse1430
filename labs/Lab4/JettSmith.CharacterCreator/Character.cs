/*
 *  Jett Smith
 *  ITSE 1430 - Fall 2021
 */
using System;

namespace JettSmith.AdventureGame
{
    public class Character
    {
        /// <summary>Gets or sets the name</summary>
        public string Name
        {
            get { return (_name != null) ? _name : ""; }
            set { _name = (value != null) ? value.Trim() : null; }
        }

        /// <summary>Gets or sets the class</summary>
        public string Class
        {
            get { return (_class != null) ? _class : ""; }
            set { _class = (value != null) ? value.Trim() : null; }
        }

        /// <summary>Gets or sets the race</summary>
        public string Race
        {
            get { return (_race != null) ? _race : ""; }
            set { _race = (value != null) ? value.Trim() : null; }
        }

        /// <summary>Gets or sets the biography</summary>
        public string Biography
        {
            get { return (_biography != null) ? _biography : ""; }
            set { _biography = (value != null) ? value.Trim() : null; }
        }

        /// <summary>Gets or sets the strength</summary>
        public int Strength { get; set; }
        /// <summary>Gets or sets the intelligence</summary>
        public int Intelligence { get; set; }
        /// <summary>Gets or sets the agility</summary>
        public int Agility { get; set; }
        /// <summary>Gets or sets the constitution</summary>
        public int Constitution { get; set; }
        /// <summary>Gets or sets the charisma</summary>
        public int Charisma { get; set; }

        private string _name;
        private string _class;
        private string _race;
        private string _biography;

        public override string ToString()
        {
            return $"{Name} ({Race} - {Class})";
        }

        /// <summary>Validates the Character</summary>
        /// <returns>An error if there is one</returns>
        public string Validate ()
        {
            if (String.IsNullOrEmpty(Name))
                return "Name is required";
            if (String.IsNullOrEmpty(Class))
                return "Class is required";
            if (String.IsNullOrEmpty(Race))
                return "Race is required";
            if (Strength < 1 || Strength > 100)
                return "Strength must be between 1 and 100";
            if (Intelligence < 1 || Intelligence > 100)
                return "Intelligence must be between 1 and 100";
            if (Agility < 1 || Agility > 100)
                return "Agility must be between 1 and 100";
            if (Constitution < 1 || Constitution > 100)
                return "Constitution must be between 1 and 100";
            if (Charisma < 1 || Charisma > 100)
                return "Charisma must be between 1 and 100";
            return null;
        }
    }
}
