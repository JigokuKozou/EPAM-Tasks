using UltimateEscanor.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

namespace UltimateEscanor.Collections.Tests
{
    [TestClass()]
    public class DynamicArrayTests
    {
        [TestMethod()]
        public void InitializationTest_16Capacity()
        {
            int expected = 16;

            DynamicArray<int> _array = new DynamicArray<int>(expected);

            Assert.AreEqual(expected, _array.Capacity);
        }

        [TestMethod()]
        public void InitializationTest_NoParameters()
        {
            int expected = 8;

            DynamicArray<int> _array = new DynamicArray<int>();

            Assert.AreEqual(expected, _array.Capacity);
        }

        [TestMethod()]
        public void InitializationTest_IEnumerable()
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
        public void IndexerTest_PositiveAndNonPositive()
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

        [TestMethod()]
        public void ToArrayTest_WithoutChanging()
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(array);

            int[] actual = dynamic.ToArray();

            if (array.Length != actual.Length)
                Assert.Fail();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != actual[i])
                    Assert.Fail();
            }
        }

        [TestMethod()]
        public void AddTest()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(list);

            int newNumber = 10;
            list.Add(newNumber);
            dynamic.Add(newNumber);

            Assert.IsFalse(list.Except(dynamic).Any());
        }

        [TestMethod()]
        public void AddRangeTest()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(list);

            int[] newNumbers = { 10, 20, 30, 40 };
            list.AddRange(newNumbers);
            dynamic.AddRange(newNumbers);

            var excepted = list.Except(dynamic).ToArray();

            Assert.IsFalse(excepted.Any());
        }

        [TestMethod()]
        public void RemoveTest_ExistingElement()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(list);

            int removable = 4;
            bool isDynamicElementRemoved = dynamic.Remove(removable);
            bool isListElementRemoved = list.Remove(removable);

            var excepted = list.Except(dynamic).ToArray();

            Assert.IsFalse(excepted.Any() && (isDynamicElementRemoved && isListElementRemoved) == true);
        }

        [TestMethod()]
        public void RemoveTest_NonExistingElement()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(list);

            int removable = 999;
            bool isDynamicElementRemoved = dynamic.Remove(removable);
            bool isListElementRemoved = list.Remove(removable);

            var excepted = list.Except(dynamic).ToArray();

            Assert.IsFalse(excepted.Any() && ((isDynamicElementRemoved && isListElementRemoved) == false));
        }

        [TestMethod()]
        public void InsertTest()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(list);

            int[] positions = { 0, (list.Count - 1) / 2, list.Count - 1 };

            int[] values = { 99, 88, 77 };

            for (int i = 0; i < positions.Length; i++)
            {
                list.Insert(positions[i], values[i]);
                dynamic.Insert(positions[i], values[i]);
            }

            var excepted = list.Except(dynamic).ToArray();

            Assert.IsFalse(excepted.Any());
        }

        [TestMethod()]
        public void ImplementationIEnumerableTest()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(list);

            List<int> listNumbers = new();
            List<int> dynamicNumbers = new();

            foreach (var item in dynamic)
            {
                dynamicNumbers.Add(item);
            }

            foreach (var item in list)
            {
                listNumbers.Add(item);
            }

            var excepted = listNumbers.Except(dynamicNumbers).ToArray();

            Assert.IsFalse(excepted.Any());
        }

        [TestMethod()]
        public void CapacityChangeTest()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(list);

            list.Capacity = 10;
            dynamic.Capacity = 10;

            var excepted = list.Except(dynamic).ToArray();

            Assert.IsFalse(excepted.Any() && (list.Capacity == dynamic.Capacity));
        }

        [TestMethod()]
        public void CloneTest()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6 };
            DynamicArray<int> dynamic = new DynamicArray<int>(list);

            var clone = dynamic.Clone() as DynamicArray<int>;

            Assert.IsTrue(!ReferenceEquals(dynamic, clone) && !dynamic.Except(clone).Any());
        }
    }
}