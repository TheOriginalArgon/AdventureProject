using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureProject.Functionality;

namespace AdventureProject.GameInstances
{
    // An adventure is the major environment where characters interact with other objects, places and entities.
    [Serializable]
    public class Adventure : ISaveable
    {
        // Basic properties
        public int ID { get; private set; }
        public string Name { get; private set; }
        public Character MainCharacter { get; private set; }

        public Adventure()
        {
            ID = 0;
        }
        public Adventure(string name = "unnamed adventure")
        {
            ID = 0;
            Name = name;
        }
        public bool IsSaveReady()
        {
            if (MainCharacter != null &&
                Name != null)
            {
                return true;
            }
            return false;
        }

        public void SetCharacter(Character chr)
        {
            MainCharacter = chr;
        }

    }
}
