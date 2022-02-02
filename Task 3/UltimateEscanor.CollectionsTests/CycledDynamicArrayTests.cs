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
    public class CycledDynamicArrayTests
    {
        [TestMethod()]
        public void Foreach_Test()
        {
            CycledDynamicArray<int> cycled = new CycledDynamicArray<int>();
            cycled.AddRange(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            int elements = 100;

            foreach (var item in cycled)
            {
                Debug.Write(item + " ");

                if (item == 9)
                {
                    Debug.WriteLine("");
                }

                if (--elements <= 0)
                {
                    break;
                }
            }
        }
    }
}