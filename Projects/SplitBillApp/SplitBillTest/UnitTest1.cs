using System;  
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SplitBill;  

namespace SplitBillTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_CalculationMethod()
        {
            decimal totalExpense = 30;
            decimal[] expenses = { 12, 10, 8 };
            decimal[] result = new decimal[3];
            result = Program.Calculation(totalExpense, expenses);
            decimal[] expectedResult = { -2, 0, 2 };
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Test_LoggingData()
        {
            decimal[] output = { -2, 0, 2 };
            string pathRoot = Directory.GetCurrentDirectory();
            string path = pathRoot + "/Test_output.txt";
            File.WriteAllText(path, "");
            Program.LoggingData(output, path);
            using (StreamReader sr = new StreamReader(path))
            {
                Assert.AreEqual("(2)", sr.ReadLine());
                Assert.AreEqual("0", sr.ReadLine());
                Assert.AreEqual("2", sr.ReadLine());
                Assert.AreEqual("", sr.ReadLine());
                sr.Close();
            }

        }

    }
}
