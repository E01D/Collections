using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E01D.Collections.Api.Collections.Trees.Avl;
using E01D.Collections.Models.Collections.Trees.Avl;
using NUnit.Framework;

namespace E01D.Collections.Tests.Api.Collections.Trees.Avl
{
    [TestFixture]
    public class Test_AvlIterative2Int32Api_Add : Test_AvlInt32_Add
    {
        public override AvlApi_I<Int32AvlNode, int> CreateApi()
        {
            return new AvlIterativeInt32Api();
        }

        [Test]
        public void TestRotateRight_4_2_1()
        {
            var api = CreateApi();

            var root = api.AddNode(null, CreateNode(4));
            root = api.AddNode(root, CreateNode(2));
            root = api.AddNode(root, CreateNode(1));

            Assert.AreEqual(2, root.Key);
            Assert.AreEqual(1, root.Left.Key);
            Assert.AreEqual(4, root.Right.Key);
        }
    }
}
