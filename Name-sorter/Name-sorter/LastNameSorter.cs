using System;
using System.Collections.Generic;
using System.Linq;
using Name_sorter.Model;
using System.IO;

namespace Name_sorter
{
    public class LastNameSorter: Sorter
    {
        List<Name> names = null;

        public LastNameSorter()
        {

        }

        /// <summary>
        /// Sort the names
        /// </summary>
        public override void Sort()
        {
            if (names == null)
            {
                throw new Exception("Error, names collection is not initialized.");
            }

            sortedItems = (from name in names orderby name.LastName, name.GivenName ascending select name.GivenName + " " + name.LastName).ToArray<string>();
        }

        /// <summary>
        /// Read the names from the file
        /// </summary>
        /// <param name="fileName">Name of the file (unsorted-names-list.txt)</param>
        public override void LoadNames(string sourceFileName)
        {            
            if (!File.Exists(sourceFileName))
            {
                throw new FileNotFoundException("Input file not found ", sourceFileName);
            }

            var reader = new StreamReader(sourceFileName);
            string line = "";
            names = new List<Name>();

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    /*this is an empty line skip it.*/
                    continue;
                }

                string[] sections = line.Split(' ');

                /*Let us kep the last name in separate field, because sort is based on that .*/
                var newName = new Name
                {
                    LastName = sections[sections.Length - 1],
                    GivenName = string.Join(" ", sections, 0, sections.Length - 1)
                };

                names.Add(newName);
            }
        }

        /// <summary>
        /// Print the names to the screen
        /// </summary>
        public override void PrintToScreen()
        {
            if (sortedItems == null)
            {
                throw new InvalidOperationException("There are no items to display");
            }
            Console.WriteLine(string.Join("\n", sortedItems));
        }

        /// <summary>
        /// Write the sorted names to a file
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public override void WriteToFile(string targetFleName)
        {
            if (sortedItems == null)
            {
                throw new Exception("There are no items to write");
            }

            if (File.Exists(targetFleName))
            {
                /*We should delete if the file already exists.*/
                File.Delete(targetFleName);
            }

            File.WriteAllLines(targetFleName, sortedItems);
        }
    }
}
