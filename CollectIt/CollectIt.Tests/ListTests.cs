using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CollectIt.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void A_List_Can_Insert()
        {
            List<int> integers = new List<int> { 1, 2, 3 };
            integers.Insert(1, 6);
            
            Assert.AreEqual(6, integers[1]);
        }

        [TestMethod]
        public void A_List_Can_Remove()
        {
            List<int> integers = new List<int> { 1, 2, 3 };
            integers.Remove(2);

            Assert.IsTrue(integers.SequenceEqual(new [] { 1,3 }));
        }

        [TestMethod]
        public void A_List_Can_Find_Things()
        {
            List<int> integers = new List<int> { 1, 2, 3 };

            Assert.AreEqual(integers.IndexOf(3), 2);
        }
    }
}
