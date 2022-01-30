using Microsoft.VisualStudio.TestTools.UnitTesting;
using UltimateEscanor.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UltimateEscanor.Collections.Tests
{
    [TestClass()]
    public class DynamicArrayTests
    {
        [TestMethod()]
        public void Initialization_16Capacity()
        {
            int expected = 16;

            DynamicArray<int> _array = new DynamicArray<int>(expected);

            Assert.AreEqual(expected, _array.Capacity);
        }

        [TestMethod()]
        public void Initialization_NoParameters()
        {
            int expected = 8;

            DynamicArray<int> _array = new DynamicArray<int>();

            Assert.AreEqual(expected, _array.Capacity);
        }

        [TestMethod()]
        public void Initialization_IEnumerable()
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(array);

            if (array.Length == dynamic.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != dynamic[i])
                        Assert.Fail();
                }
            }
            else Assert.Fail();
        }

        [TestMethod()]
        public void Indexer_PositiveAndNonPositive()
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != dynamic[i] || array[i] != dynamic[i - dynamic.Length])
                {
                    Assert.Fail();
                }
            }
        }
    }
}