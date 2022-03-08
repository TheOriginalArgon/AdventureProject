using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureProject.GameInstances;

namespace AdventureProject.GameEngine
{
    /// <summary>
    /// Game manager manages all the interactions of the objects within the game.
    /// </summary>
    public static class GameManager
    {
        private static Adventure loadedAdventure;


        public static Adventure GetLoadedAdventure()
        {
            return loadedAdventure;
        }
        public static void LoadAdventure(Adventure adv)
        {
            loadedAdventure = adv;
        }


    }
}
