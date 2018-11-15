using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Name_sorter;
using System.IO;

namespace SorterTest
{
    [TestClass]
    public class UnitTestLastNameSorter
    {
        #region TestInputFileValidation

        /// <summary>
        /// make sure Input file validation is working good
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestInputFileValidation()
        {
            var inputFileName = "TestInputFileValidation.txt";

            if (File.Exists(inputFileName))
            {
                File.Delete(inputFileName);
            }

            var lastNameSorter = new LastNameSorter();
            lastNameSorter.LoadNames(inputFileName);
        }

        #endregion

        #region TestWriteToFile_FileCreation
       
        [TestMethod]
        public void TestWriteToFile_FileCreation()
        {
            var inputFileName = "InTestOutFileCreation.txt";
            var outputFileName = "OutTestOutFileCreation.txt";

            if (File.Exists(inputFileName))
            {
                File.Delete(inputFileName);
            }

            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }

            File.WriteAllText(inputFileName, "");

            var lastNameSorter = new LastNameSorter();
            lastNameSorter.LoadNames(inputFileName);
            lastNameSorter.Sort();

            lastNameSorter.WriteToFile(outputFileName);

            var fileCreated = File.Exists(outputFileName);

            Assert.AreEqual(true, fileCreated);
        }

        #endregion

        #region TestSortResult
        
        /// <summary>
        /// Valid Sort verification
        /// </summary>
        [TestMethod]
        public void TestSortResult()
        {
            var unSortedNames = new string[] { "Janet Parsons", "Vaughn Lewis" };
            var inputFileName = "InTestSortResult.txt";
            var outputFileName = "OutTestSortResult.txt";

            if (File.Exists(inputFileName))
            {
                File.Delete(inputFileName);
            }

            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }

            File.WriteAllLines(inputFileName, unSortedNames);

            var lastNameSorter = new LastNameSorter();
            lastNameSorter.LoadNames(inputFileName);
            lastNameSorter.Sort();

            lastNameSorter.WriteToFile(outputFileName);

            var data = File.ReadAllLines(outputFileName);

            var result = string.Join(",", data);

            Assert.AreEqual("Vaughn Lewis,Janet Parsons", result);
        }

        #endregion

        #region TestSortResultThreeGivenName
        
        /// <summary>
        /// Valid Sort verification
        /// </summary>
        [TestMethod]
        public void TestSortResultThreeGivenName()
        {
            var unSortedNames = new string[] { "Hunter Uriah Mathew Clarke", "Hunter Uriah Mathew Andrew", "Hunter Uriah Nathan Andrew" };
            var inputFileName = "InTestSortResultThreeGivenName.txt";
            var outputFileName = "OutTestSortResultThreeGivenName.txt";

            if (File.Exists(inputFileName))
            {
                File.Delete(inputFileName);
            }

            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }

            File.WriteAllLines(inputFileName, unSortedNames);

            var lastNameSorter = new LastNameSorter();
            lastNameSorter.LoadNames(inputFileName);
            lastNameSorter.Sort();

            lastNameSorter.WriteToFile(outputFileName);

            var data = File.ReadAllLines(outputFileName);

            var result = string.Join(",", data);

            Assert.AreEqual("Hunter Uriah Mathew Andrew,Hunter Uriah Nathan Andrew,Hunter Uriah Mathew Clarke", result);
        }

        #endregion

        #region TestPrintToScreen
        
        [TestMethod]
        public void TestPrintToScreen()
        {
            var unSortedNames = new string[] { "Janet Parsons", "Vaughn Lewis" };
            var inputFileName = "InTestPrintToScreen.txt";
            
            if (File.Exists(inputFileName))
            {
                File.Delete(inputFileName);
            }
           
            File.WriteAllLines(inputFileName, unSortedNames);

            var lastNameSorter = new LastNameSorter();
            lastNameSorter.LoadNames(inputFileName);
            lastNameSorter.Sort();
            lastNameSorter.PrintToScreen(); 
        }

        #endregion

        #region TestPrintToScreen

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPrintToScreenValidation()
        {        
            var lastNameSorter = new LastNameSorter();           
            lastNameSorter.PrintToScreen();
        }

        #endregion
    }
}
