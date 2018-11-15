using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name_sorter
{
    public abstract class Sorter
    {
        protected string[] sortedItems = null;
               
        /// <summary>
        /// Read the names from the file
        /// </summary>
        /// <param name="fileName">Name of the file (unsorted-names-list.txt)</param>
        public abstract void LoadNames(string fileName);

        /// <summary>
        /// Sort the names
        /// </summary>
        public abstract void Sort();

        /// <summary>
        /// Print the names to the screen
        /// </summary>
        public abstract void PrintToScreen();

        /// <summary>
        /// Write the sorted names to a file
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public abstract void WriteToFile(string fileName);
    }
}
