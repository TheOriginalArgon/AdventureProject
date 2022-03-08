using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureProject.GameInstances;

namespace AdventureProject.GameEngine
{
    /// <summary>
    /// Command manager is responsible for managing all the interactions that are related to commands.
    /// </summary>
    public static class CommandManager
    {
        private static List<Command> commands = new List<Command>();

        public static Command GetCommand(string name)
        {
            return (from cmd in commands where cmd.ID == name select cmd).FirstOrDefault();
        }

        static CommandManager()
        {
            commands.Add(new Command(
                "newadv",
                Engine.CreateAdventure,
                "Adventure name"));

            commands.Add(new Command(
                "newchar",
                Engine.CreateCharacter,
                new string[]
                {
                    "First name",
                    "Middle name",
                    "Last name"
                }));
            commands.Add(new Command(
                "saveadv",
                Engine.SaveAdventure));
        }
    }
}
