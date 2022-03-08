using System;
using AdventureProject.GameEngine;

namespace AdventureProject
{
    /*
     * PROJECT ADVENTURE
     * Created by Argón as yet another way to kinda play around with C#
     * 
     * The purpoe of this is to simulate to a certain point a small adventure in an RPG style.
     * 
     */

    /// <summary>
    /// We're just gonna store the main method here if possible.
    /// </summary>
    class Program
    {
        public static bool Terminate { get; set; } = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Project Arventure!\n" +
                "Created by Argón.\n\n" +
                "This is probably the most rudimentary text-based RPG-like game you've ever seen.");

            while (!Terminate)
            {
                Engine.ReadInput(Console.ReadLine());
            }

        }
    }
}
