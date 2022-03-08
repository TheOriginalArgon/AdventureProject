using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureProject.Functionality;

namespace AdventureProject.GameInstances
{
    /// <summary>
    /// A character is a living being that is able to participate in events and execute complex actions.
    /// </summary>

    [Serializable]
    public class Character : ISaveable
    {
        // Basic properties
        private string ID { get; set; }
        private string FirstName { get; set; }
        private string MidName { get; set; }
        private string LastName { get; set; }
        private bool IsPlayable { get; set; }

        public bool IsSaveReady()
        {
            return true;
        }

        public Character()
        {

        }
        public Character(string[] name, bool playable = false)
        {
            FirstName = name[0];
            MidName = name[1];
            LastName = name[2];
        }

        public string FullName()
        {
            string fullName = $"{FirstName} {MidName} {LastName}";
            return fullName;
        }

    }
}
