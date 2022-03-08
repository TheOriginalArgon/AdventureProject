using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureProject.GameInstances;

namespace AdventureProject.GameEngine
{
    /// <summary>
    /// Engine controls the main operations, such as activating the commands, reading user input, managing configuration and creating/deleting instances.
    /// </summary>
    public static class Engine
    {
        /// <summary>
        /// Reads the console input of the user and attempts to execute it as an instruction. If the command is not found the program terminates.
        /// </summary>
        /// <param name="input">What the user inputs through the console.</param>
        public static void ReadInput(string input)
        {
            if (input == "exit" || string.IsNullOrWhiteSpace(input))
            {
                Program.Terminate = true;
            }
            else
            {
                ExecuteCommand(input);
            }
        }

        /// <summary>
        /// Executes a given command from the <see cref="CommandManager"/>.
        /// </summary>
        /// <param name="command">The command ID.</param>
        public static void ExecuteCommand(string command)
        {
            try
            {
                Command cmd = CommandManager.GetCommand(command);
                if (cmd.HasParams)
                {
                    if (cmd.ParamCount == 1)
                    {
                        Console.Write($"{cmd.paramDefinition}: ");
                        cmd.parameter = Console.ReadLine();
                    }
                    else
                    {
                        for (int i = 0; i < cmd.parameters.Length; i++)
                        {
                            Console.Write($"{cmd.paramDefinitions[i]}: ");
                            cmd.parameters[i] = Console.ReadLine();
                        }
                    }
                }
                cmd.Run();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Unknown command \"{command}\"");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid argument");
            }
        }

        // Command-defined methods

        public static void CreateAdventure(object arg)
        {
            Adventure newAdventure = new Adventure(arg.ToString());

            GameManager.LoadAdventure(newAdventure);

            Storage.SerializeObject(newAdventure, newAdventure.Name);

            Console.WriteLine($"Created a new adventure named {newAdventure.Name}.\n" +
                $"Now you can create a main character for it.");
        }

        public static void SaveAdventure()
        {
            if (GameManager.GetLoadedAdventure().IsSaveReady())
            {
                Storage.StoreData(GameManager.GetLoadedAdventure(), GameManager.GetLoadedAdventure().Name);
            }
            else
            {
                Console.WriteLine("Cannot save adventure. Incomplete data.");
            }
        }

        public static void CreateCharacter(object[] args)
        {
            if (GameManager.GetLoadedAdventure() != null)
            {
                Character chr = new Character(new string[] { args[0].ToString(), args[1].ToString(), args[2].ToString() });

                GameManager.GetLoadedAdventure().SetCharacter(chr);

                Console.WriteLine($"Character {chr.FullName()} is now the main character of {GameManager.GetLoadedAdventure().Name}");
            }
            else
            {
                Console.WriteLine($"You need to create an adventure first.");
            }
        }

    }
}
