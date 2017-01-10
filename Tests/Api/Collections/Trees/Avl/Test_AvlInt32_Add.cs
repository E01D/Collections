using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E01D.Collections.Api.Collections.Trees.Avl;
using E01D.Collections.Models.Collections.Trees.Avl;
using NUnit.Framework;

namespace E01D.Collections.Tests.Api.Collections.Trees.Avl
{
    public abstract class Test_AvlInt32Base
    {
        public abstract AvlApi_I<Int32AvlNode, int> CreateApi();

        [DebuggerStepThrough]
        public Int32AvlNode CreateNode(int i)
        {
            var avlNode = new Int32AvlNode
            {
                Key = i
            };


            return avlNode;
        }

        public Int32AvlNode CreateRoot(int key)
        {
            var api = CreateApi();

            var node4 = CreateNode(key);

            var newNode4 = api.AddNode(node4);

            Assert.IsNotNull(node4);
            Assert.IsNotNull(newNode4);
            Assert.AreSame(node4, newNode4);

            Assert.AreEqual(0, node4.BalanceFactor);
            Assert.AreEqual(0, newNode4.BalanceFactor);

            return newNode4;
        }

        public Int32AvlNode AddRight(Int32AvlNode node4, int i)
        {
            var api = CreateApi();

            var node6 = CreateNode(i);
            var newRoot4 = api.AddNode(node4, node6);
            var newNode6 = newRoot4.Right;

            Assert.IsNotNull(node6);
            Assert.IsNotNull(newRoot4);
            Assert.IsNotNull(newNode6);
            Assert.AreNotSame(node4, newRoot4);
            Assert.AreSame(node6, newNode6);

            Assert.AreEqual(0, node4.BalanceFactor);
            Assert.AreEqual(0, node6.BalanceFactor);
            Assert.AreEqual(0, newNode6.BalanceFactor);
            Assert.AreEqual(-1, newRoot4.BalanceFactor);

            return newRoot4;
        }

        public Int32AvlNode AddLeft(Int32AvlNode node4, int i)
        {
            var api = CreateApi();

            var node2 = CreateNode(i);
            var newRoot4 = api.AddNode(node4, node2);
            var newNode2 = newRoot4.Left;

            Assert.IsNotNull(node2);
            Assert.IsNotNull(newRoot4);
            Assert.IsNotNull(newNode2);
            Assert.AreNotSame(node4, newRoot4);
            Assert.AreSame(node2, newNode2);

            Assert.AreEqual(0, node4.BalanceFactor);
            Assert.AreEqual(0, node2.BalanceFactor);
            Assert.AreEqual(0, newNode2.BalanceFactor);
            Assert.AreEqual(1, newRoot4.BalanceFactor);

            return newRoot4;
        }

        public Int32AvlNode AddLeftLeft(Int32AvlNode orginalRoot, int i)
        {
            var api = CreateApi();

            var oldNode4 = orginalRoot.Left;
            var node2 = CreateNode(2);
            var newRoot4 = api.AddNode(orginalRoot, node2);

            Assert.IsNotNull(newRoot4);
            Assert.IsNotNull(newRoot4.Left);
            Assert.IsNotNull(newRoot4.Right);

            Assert.AreNotSame(newRoot4.Right, orginalRoot);
            Assert.AreNotSame(newRoot4, oldNode4);
            Assert.AreSame(node2, newRoot4.Left);
            Assert.AreEqual(newRoot4.Key, oldNode4.Key);
            Assert.AreEqual(orginalRoot.Key, newRoot4.Right.Key);
            Assert.AreEqual(2, newRoot4.Left.Key);
            Assert.AreEqual(4, newRoot4.Key);
            Assert.AreEqual(6, newRoot4.Right.Key);

            Assert.AreEqual(0, newRoot4.BalanceFactor);
            Assert.AreEqual(0, newRoot4.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot4.Right.BalanceFactor);

            return newRoot4;
        }

        public Int32AvlNode AddRightRight(Int32AvlNode newRoot4, int i)
        {
            var api = CreateApi();

            var oldNode6 = newRoot4.Right;
            var node8 = CreateNode(i);
            var newRoot6 = api.AddNode(newRoot4, node8);

            Assert.IsNotNull(newRoot6);
            Assert.IsNotNull(newRoot6.Left);
            Assert.IsNotNull(newRoot6.Right);
            Assert.AreNotSame(newRoot6.Left, newRoot4);
            Assert.AreNotSame(newRoot6, oldNode6);
            Assert.AreSame(node8, newRoot6.Right);
            Assert.AreEqual(newRoot6.Key, oldNode6.Key);
            Assert.AreEqual(newRoot4.Key, newRoot6.Left.Key);
            Assert.AreEqual(4, newRoot6.Left.Key);
            Assert.AreEqual(6, newRoot6.Key);
            Assert.AreEqual(8, newRoot6.Right.Key);

            Assert.AreEqual(0, newRoot6.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.BalanceFactor);

            return newRoot6;
        }

        public Int32AvlNode AddRightLeft(Int32AvlNode newRoot4, int i)
        {
            var api = CreateApi();

            var oldNode6 = newRoot4.Right;
            var node5 = CreateNode(i);
            var newRoot5 = api.AddNode(newRoot4, node5);

            Assert.IsNotNull(newRoot5);
            Assert.IsNotNull(newRoot5.Left);
            Assert.IsNotNull(newRoot5.Right);
            Assert.AreNotSame(newRoot5, node5);
            Assert.AreNotSame(newRoot5.Left, newRoot4);
            Assert.AreNotSame(newRoot5.Right, oldNode6);
            Assert.AreEqual(newRoot5.Key, node5.Key);
            Assert.AreEqual(newRoot5.Left.Key, newRoot4.Key);
            Assert.AreEqual(newRoot5.Right.Key, oldNode6.Key);

            Assert.AreEqual(0, newRoot5.BalanceFactor);
            Assert.AreEqual(0, newRoot5.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot5.Right.BalanceFactor);

            return newRoot5;
        }

        public Int32AvlNode AddLeftRight(Int32AvlNode newRoot4, int i)
        {
            var api = CreateApi();

            var newNode = CreateNode(i);
            var newRoot5 = api.AddNode(newRoot4, newNode);
            var oldNode6 = newRoot4.Left;

            Assert.IsNotNull(newRoot5);
            Assert.IsNotNull(newRoot5.Right);
            Assert.IsNotNull(newRoot5.Left);
            Assert.AreNotSame(newRoot5, newNode);
            Assert.AreNotSame(newRoot5.Right, newRoot4);
            Assert.AreNotSame(newRoot5.Left, oldNode6);
            Assert.AreEqual(newRoot5.Key, newNode.Key);
            Assert.AreEqual(newRoot5.Right.Key, newRoot4.Key);
            Assert.AreEqual(newRoot5.Left.Key, oldNode6.Key);

            Assert.AreEqual(0, newRoot5.BalanceFactor);
            Assert.AreEqual(0, newRoot5.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot5.Right.BalanceFactor);

            return newRoot5;
        }
    }
}
