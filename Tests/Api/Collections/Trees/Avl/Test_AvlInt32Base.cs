using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E01D.Collections.Api.Collections.Trees.Avl;
using NUnit.Framework;

namespace E01D.Collections.Tests.Api.Collections.Trees.Avl
{
    [TestFixture]
    public abstract class Test_AvlInt32_Add : Test_AvlInt32Base
    {
        [Test]
        public void Add_4()
        {
            CreateRoot(4);
        }

        [Test]
        public void Add_4_6()
        {
            var node4 = CreateRoot(4);

            AddRight(node4, 6);
        }

        [Test]
        public void Add_4_2()
        {
            var node4 = CreateRoot(4);

            AddLeft(node4, 2);
        }

        [Test]
        public void Add_4_6_8() // Left Rotation
        {
            AvlIterativeInt32Api api = new AvlIterativeInt32Api();

            var node4 = CreateRoot(4);
            var newRoot4 = AddRight(node4, 6);
            var newRoot6 = AddRightRight(newRoot4, 8);
        }



        [Test]
        public void Add_6_4_2() // Right Rotation
        {


            var node6 = CreateRoot(6);
            var newRoot6 = AddLeft(node6, 4);
            var newRoot4 = AddLeftLeft(newRoot6, 2);


        }

        [Test]
        public void Add_4_6_5() // Double Left or Left-Right Rotation
        {
            var node4 = CreateRoot(4);
            var newRoot4 = AddRight(node4, 6);
            var newRoot5 = AddRightLeft(newRoot4, 5);


        }

        [Test]
        public void Add_6_4_5() // Double Left or Left-Right Rotation
        {
            var node6 = CreateRoot(6);
            var newRoot6 = AddLeft(node6, 4);
            var newRoot5 = AddLeftRight(newRoot6, 5);


        }

        [Test]
        public void Add_6_4_8_2_5_7_10() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var newRoot6 = AddLeft(node6, 4);
            var node8 = CreateNode(8);
            newRoot6 = api.AddNode(newRoot6, node8);
            var newNode8 = newRoot6.Right;

            Assert.IsNotNull(newRoot6);
            Assert.IsNotNull(newRoot6.Left);
            Assert.IsNotNull(newRoot6.Right);
            Assert.AreNotSame(node6, newRoot6);
            Assert.AreSame(node8, newNode8);

            newRoot6 = api.AddNode(newRoot6, CreateNode(2));
            newRoot6 = api.AddNode(newRoot6, CreateNode(5));
            newRoot6 = api.AddNode(newRoot6, CreateNode(7));
            newRoot6 = api.AddNode(newRoot6, CreateNode(10));

            Assert.AreEqual(0, newRoot6.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.Right.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.Right.BalanceFactor);

            Assert.AreEqual(6, newRoot6.Key);
            Assert.AreEqual(4, newRoot6.Left.Key);
            Assert.AreEqual(8, newRoot6.Right.Key);
            Assert.AreEqual(2, newRoot6.Left.Left.Key);
            Assert.AreEqual(5, newRoot6.Left.Right.Key);
            Assert.AreEqual(7, newRoot6.Right.Left.Key);
            Assert.AreEqual(10, newRoot6.Right.Right.Key);
        }

        [Test]
        public void Add_6_4_8_2_5() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var root = AddLeft(node6, 4);
            var node8 = CreateNode(8);
            root = api.AddNode(root, node8);
            var newNode8 = root.Right;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Left);
            Assert.IsNotNull(root.Right);
            Assert.AreNotSame(node6, root);
            Assert.AreSame(node8, newNode8);

            root = api.AddNode(root, CreateNode(2));
            root = api.AddNode(root, CreateNode(5));

            Assert.AreEqual(6, root.Key);
            Assert.AreEqual(4, root.Left.Key);
            Assert.AreEqual(8, root.Right.Key);
            Assert.AreEqual(2, root.Left.Left.Key);
            Assert.AreEqual(5, root.Left.Right.Key);

            Assert.AreEqual(1, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.BalanceFactor);
        }

        [Test]
        public void Add_6_4_8_2_5_1() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var root = AddLeft(node6, 4);
            var node8 = CreateNode(8);
            root = api.AddNode(root, node8);
            var newNode8 = root.Right;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Left);
            Assert.IsNotNull(root.Right);
            Assert.AreNotSame(node6, root);
            Assert.AreSame(node8, newNode8);

            root = api.AddNode(root, CreateNode(2));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(1));

            Assert.AreEqual(4, root.Key);
            Assert.AreEqual(2, root.Left.Key);
            Assert.AreEqual(6, root.Right.Key);
            Assert.AreEqual(1, root.Left.Left.Key);
            Assert.AreEqual(5, root.Right.Left.Key);
            Assert.AreEqual(8, root.Right.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(1, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);


        }

        [Test]
        public void Add_6_4_8_2_5_3() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var root = AddLeft(node6, 4);
            var node8 = CreateNode(8);
            root = api.AddNode(root, node8);
            var newNode8 = root.Right;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Left);
            Assert.IsNotNull(root.Right);
            Assert.AreNotSame(node6, root);
            Assert.AreSame(node8, newNode8);

            root = api.AddNode(root, CreateNode(2));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(3));

            Assert.AreEqual(4, root.Key);
            Assert.AreEqual(2, root.Left.Key);
            Assert.AreEqual(6, root.Right.Key);
            Assert.AreEqual(3, root.Left.Right.Key);
            Assert.AreEqual(5, root.Right.Left.Key);
            Assert.AreEqual(8, root.Right.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(-1, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.BalanceFactor);
            Assert.AreEqual(0, root.Right.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);
        }

        [Test]
        public void Add_8_4_10_1_6_5() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(8);
            var root = AddLeft(node6, 4);
            var node8 = CreateNode(10);
            root = api.AddNode(root, node8);
            var newNode8 = root.Right;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Left);
            Assert.IsNotNull(root.Right);
            Assert.AreNotSame(node6, root);
            Assert.AreSame(node8, newNode8);

            root = api.AddNode(root, CreateNode(1));
            root = api.AddNode(root, CreateNode(6));
            root = api.AddNode(root, CreateNode(5));

            Assert.AreEqual(6, root.Key);
            Assert.AreEqual(4, root.Left.Key);
            Assert.AreEqual(8, root.Right.Key);
            Assert.AreEqual(5, root.Left.Right.Key);
            Assert.AreEqual(1, root.Left.Left.Key);
            Assert.AreEqual(10, root.Right.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(-1, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);
        }

        [Test]
        public void Add_8_4_10_1_6_7() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(8);
            var root = AddLeft(node6, 4);
            var node8 = CreateNode(10);
            root = api.AddNode(root, node8);
            var newNode8 = root.Right;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Left);
            Assert.IsNotNull(root.Right);
            Assert.AreNotSame(node6, root);
            Assert.AreSame(node8, newNode8);

            root = api.AddNode(root, CreateNode(1));
            root = api.AddNode(root, CreateNode(6));
            root = api.AddNode(root, CreateNode(7));

            Assert.AreEqual(6, root.Key);
            Assert.AreEqual(4, root.Left.Key);
            Assert.AreEqual(8, root.Right.Key);
            Assert.AreEqual(1, root.Left.Left.Key);
            Assert.AreEqual(7, root.Right.Left.Key);
            Assert.AreEqual(10, root.Right.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(1, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);
        }


        [Test]
        public void Add_6_4_8_2_5_7() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var newRoot6 = AddLeft(node6, 4);
            var node8 = CreateNode(8);
            newRoot6 = api.AddNode(newRoot6, node8);
            var newNode8 = newRoot6.Right;

            Assert.IsNotNull(newRoot6);
            Assert.IsNotNull(newRoot6.Left);
            Assert.IsNotNull(newRoot6.Right);
            Assert.AreNotSame(node6, newRoot6);
            Assert.AreSame(node8, newNode8);

            newRoot6 = api.AddNode(newRoot6, CreateNode(2));
            newRoot6 = api.AddNode(newRoot6, CreateNode(5));
            newRoot6 = api.AddNode(newRoot6, CreateNode(7));


            Assert.AreEqual(0, newRoot6.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.BalanceFactor);
            Assert.AreEqual(1, newRoot6.Right.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.Right.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.Left.BalanceFactor);


            Assert.AreEqual(6, newRoot6.Key);
            Assert.AreEqual(4, newRoot6.Left.Key);
            Assert.AreEqual(8, newRoot6.Right.Key);
            Assert.AreEqual(2, newRoot6.Left.Left.Key);
            Assert.AreEqual(5, newRoot6.Left.Right.Key);
            Assert.AreEqual(7, newRoot6.Right.Left.Key);
        }

        [Test]
        public void Add_6_4_8_2_5_10() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var newRoot6 = AddLeft(node6, 4);
            var node8 = CreateNode(8);
            newRoot6 = api.AddNode(newRoot6, node8);
            var newNode8 = newRoot6.Right;

            Assert.IsNotNull(newRoot6);
            Assert.IsNotNull(newRoot6.Left);
            Assert.IsNotNull(newRoot6.Right);
            Assert.AreNotSame(node6, newRoot6);
            Assert.AreSame(node8, newNode8);

            newRoot6 = api.AddNode(newRoot6, CreateNode(2));
            newRoot6 = api.AddNode(newRoot6, CreateNode(5));
            newRoot6 = api.AddNode(newRoot6, CreateNode(10));


            Assert.AreEqual(0, newRoot6.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.BalanceFactor);
            Assert.AreEqual(-1, newRoot6.Right.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.Right.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.Right.BalanceFactor);


            Assert.AreEqual(6, newRoot6.Key);
            Assert.AreEqual(4, newRoot6.Left.Key);
            Assert.AreEqual(8, newRoot6.Right.Key);
            Assert.AreEqual(2, newRoot6.Left.Left.Key);
            Assert.AreEqual(5, newRoot6.Left.Right.Key);
            Assert.AreEqual(10, newRoot6.Right.Right.Key);
        }

        [Test]
        public void Add_6_4_8_5_7_10() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var newRoot6 = AddLeft(node6, 4);
            var node8 = CreateNode(8);
            newRoot6 = api.AddNode(newRoot6, node8);
            var newNode8 = newRoot6.Right;

            Assert.IsNotNull(newRoot6);
            Assert.IsNotNull(newRoot6.Left);
            Assert.IsNotNull(newRoot6.Right);
            Assert.AreNotSame(node6, newRoot6);
            Assert.AreSame(node8, newNode8);


            newRoot6 = api.AddNode(newRoot6, CreateNode(5));
            newRoot6 = api.AddNode(newRoot6, CreateNode(7));
            newRoot6 = api.AddNode(newRoot6, CreateNode(10));

            Assert.AreEqual(0, newRoot6.BalanceFactor);
            Assert.AreEqual(-1, newRoot6.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.Right.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.Right.BalanceFactor);

            Assert.AreEqual(6, newRoot6.Key);
            Assert.AreEqual(4, newRoot6.Left.Key);
            Assert.AreEqual(8, newRoot6.Right.Key);
            Assert.AreEqual(5, newRoot6.Left.Right.Key);
            Assert.AreEqual(7, newRoot6.Right.Left.Key);
            Assert.AreEqual(10, newRoot6.Right.Right.Key);
        }

        [Test]
        public void Add_6_4_8_2_7_10() // Double Left or Left-Right Rotation
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var newRoot6 = AddLeft(node6, 4);
            var node8 = CreateNode(8);
            newRoot6 = api.AddNode(newRoot6, node8);
            var newNode8 = newRoot6.Right;

            Assert.IsNotNull(newRoot6);
            Assert.IsNotNull(newRoot6.Left);
            Assert.IsNotNull(newRoot6.Right);
            Assert.AreNotSame(node6, newRoot6);
            Assert.AreSame(node8, newNode8);

            newRoot6 = api.AddNode(newRoot6, CreateNode(2));
            newRoot6 = api.AddNode(newRoot6, CreateNode(7));
            newRoot6 = api.AddNode(newRoot6, CreateNode(10));

            Assert.AreEqual(0, newRoot6.BalanceFactor);
            Assert.AreEqual(1, newRoot6.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Left.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.Left.BalanceFactor);
            Assert.AreEqual(0, newRoot6.Right.Right.BalanceFactor);

            Assert.AreEqual(6, newRoot6.Key);
            Assert.AreEqual(4, newRoot6.Left.Key);
            Assert.AreEqual(8, newRoot6.Right.Key);
            Assert.AreEqual(2, newRoot6.Left.Left.Key);
            Assert.AreEqual(7, newRoot6.Right.Left.Key);
            Assert.AreEqual(10, newRoot6.Right.Right.Key);
        }

        [Test]
        public void Add_6_5_20_10_30_8()
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var root = AddLeft(node6, 5);
            var node8 = CreateNode(20);
            root = api.AddNode(root, node8);
            var newNode8 = root.Right;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Left);
            Assert.IsNotNull(root.Right);
            Assert.AreNotSame(node6, root);
            Assert.AreSame(node8, newNode8);

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(30));
            root = api.AddNode(root, CreateNode(8));

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(6, root.Left.Key);
            Assert.AreEqual(20, root.Right.Key);
            Assert.AreEqual(5, root.Left.Left.Key);
            Assert.AreEqual(8, root.Left.Right.Key);
            Assert.AreEqual(30, root.Right.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(-1, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);
        }

        [Test]
        public void Add_6_5_20_10_30_11()
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var root = AddLeft(node6, 5);
            var node8 = CreateNode(20);
            root = api.AddNode(root, node8);
            var newNode8 = root.Right;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Left);
            Assert.IsNotNull(root.Right);
            Assert.AreNotSame(node6, root);
            Assert.AreSame(node8, newNode8);

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(30));
            root = api.AddNode(root, CreateNode(11));

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(6, root.Left.Key);
            Assert.AreEqual(20, root.Right.Key);
            Assert.AreEqual(5, root.Left.Left.Key);
            Assert.AreEqual(11, root.Right.Left.Key);
            Assert.AreEqual(30, root.Right.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(1, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);
        }

        [Test]
        public void Add_6_5_20_10_30_25()
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var root = AddLeft(node6, 5);
            var node8 = CreateNode(20);
            root = api.AddNode(root, node8);
            var newNode8 = root.Right;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Left);
            Assert.IsNotNull(root.Right);
            Assert.AreNotSame(node6, root);
            Assert.AreSame(node8, newNode8);

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(30));
            root = api.AddNode(root, CreateNode(25));

            Assert.AreEqual(20, root.Key);
            Assert.AreEqual(6, root.Left.Key);
            Assert.AreEqual(30, root.Right.Key);
            Assert.AreEqual(5, root.Left.Left.Key);
            Assert.AreEqual(10, root.Left.Right.Key);
            Assert.AreEqual(25, root.Right.Left.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(1, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.BalanceFactor);
            Assert.AreEqual(0, root.Right.Left.BalanceFactor);
        }

        [Test]
        public void Add_6_5_20_10_30_40()
        {
            var api = CreateApi();

            var node6 = CreateRoot(6);
            var root = AddLeft(node6, 5);
            var node8 = CreateNode(20);
            root = api.AddNode(root, node8);
            var newNode8 = root.Right;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Left);
            Assert.IsNotNull(root.Right);
            Assert.AreNotSame(node6, root);
            Assert.AreSame(node8, newNode8);

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(30));
            root = api.AddNode(root, CreateNode(40));

            Assert.AreEqual(20, root.Key);
            Assert.AreEqual(6, root.Left.Key);
            Assert.AreEqual(30, root.Right.Key);
            Assert.AreEqual(5, root.Left.Left.Key);
            Assert.AreEqual(10, root.Left.Right.Key);
            Assert.AreEqual(40, root.Right.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(-1, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);
        }
    }
}
