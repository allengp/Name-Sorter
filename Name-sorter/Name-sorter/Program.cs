using System;
using System.Configuration;

namespace Name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    /*Input file not supplied*/
                    throw new Exception("Input file not name supplied.");
                }

                /*Get the unsorted file name from command line.*/
                string sourceFileNamme = args[0];

                /*Get the sorted type to be used, now we have only last name based sorter.*/
                string sorterType = ConfigurationManager.AppSettings["SorterType"];
                
                Sorter sorter = NameSorterFactory.GetNameSorter(sorterType);
                sorter.LoadNames(sourceFileNamme);

                /*DO the actual work*/
                sorter.Sort();

                /*Dispaly the result*/
                sorter.PrintToScreen();
               
                /*Write the result in file.*/
                sorter.WriteToFile("sorted-names-list.txt");                
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error" + exp.Message);
            }

            Console.WriteLine("Program completed , hit any key to exit.");
            Console.ReadLine();
        }
    }

   
}
