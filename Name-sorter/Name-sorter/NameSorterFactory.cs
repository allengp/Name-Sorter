using System;

namespace Name_sorter
{
    public class NameSorterFactory
    {
        public static Sorter GetNameSorter(string sorterType)
        {
            Sorter sorter = null;

            switch (sorterType)
            {
                case "LastNameBasedSorter":
                    sorter = new LastNameSorter();
                    break;
                default:
                    throw new Exception("Sorting Not implemented");

            }

            return sorter;
        }
    }
}
