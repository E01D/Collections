using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E01D.Collections.Models.Collections.Trees.Avl;
using NUnit.Framework;

namespace E01D.Collections.Tests.Api.Collections.Trees.Avl
{
    [TestFixture]
    public abstract class Test_AvlInt32Base_Delete : Test_AvlInt32Base
    {
        readonly int a = 1;
        readonly int b = 2;
        readonly int c = 3;
        readonly int d = 4;
        readonly int e = 5;
        readonly int f = 6;
        readonly int g = 7;
        readonly int h = 8;
        readonly int i = 9;
        readonly int j = 10;
        readonly int k = 11;
        readonly int l = 12;

        [Test]
        public void Case_OnlyRootPresent() // Case 1.1
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(2));

            root = api.Remove(root, 2);

            Assert.IsNull(root);
        }

        [Test]
        public void Case_RootAndRightChild_DeleteChild() // Case 1.2b
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(2));
            root = api.AddNode(root, CreateNode(3));

            root = api.Remove(root, 3);

            Assert.AreEqual(2, root.Key);
            Assert.AreEqual(0, root.BalanceFactor);
        }

        [Test]
        public void Case_RootAndLeftChild_DeleteChild() // Case 1.2a
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(2));
            root = api.AddNode(root, CreateNode(1));

            root = api.Remove(root, 1);

            Assert.AreEqual(2, root.Key);
            Assert.AreEqual(0, root.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_10_5_20_1_6_DeleteLeaf_6() // Case 1.2x
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(20));
            root = api.AddNode(root, CreateNode(1));
            root = api.AddNode(root, CreateNode(6));

            root = api.Remove(root, 6);

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(1, root.BalanceFactor);
            Assert.AreEqual(1, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_10_5_20_1_6_DeleteLeaf_1() // Case 1.2x
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(20));
            root = api.AddNode(root, CreateNode(1));
            root = api.AddNode(root, CreateNode(6));

            root = api.Remove(root, 1);

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(1, root.BalanceFactor);
            Assert.AreEqual(-1, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_10_5_20_15_30_DeleteLeaf_15() // Case 1.2x
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(20));
            root = api.AddNode(root, CreateNode(15));
            root = api.AddNode(root, CreateNode(30));

            root = api.Remove(root, 15);

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(-1, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(-1, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_10_5_20_15_30_DeleteLeaf_30() // Case 1.2x
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(20));
            root = api.AddNode(root, CreateNode(15));
            root = api.AddNode(root, CreateNode(30));

            root = api.Remove(root, 30);

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(-1, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(1, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Right.Left.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_10_5_20_30_DeleteNode_20() // Case 2a
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(20));
            root = api.AddNode(root, CreateNode(30));

            root = api.Remove(root, 20);

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(5, root.Left.Key);
            Assert.AreEqual(30, root.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_10_5_20_15_DeleteNode_20() // Case 2b
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(20));
            root = api.AddNode(root, CreateNode(15));

            root = api.Remove(root, 20);

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(5, root.Left.Key);
            Assert.AreEqual(15, root.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_10_5_20_6_DeleteNode_20() // Case 2a
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(20));
            root = api.AddNode(root, CreateNode(6));

            root = api.Remove(root, 5);

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(6, root.Left.Key);
            Assert.AreEqual(20, root.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_10_5_20_1_DeleteNode_5() // Case 2b
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(20));
            root = api.AddNode(root, CreateNode(1));

            root = api.Remove(root, 5);

            Assert.AreEqual(10, root.Key);
            Assert.AreEqual(1, root.Left.Key);
            Assert.AreEqual(20, root.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_10_5_20_1_DeleteNode_20() // Case 2b
        {
            var api = CreateApi();

            Int32AvlNode root = null;

            root = api.AddNode(root, CreateNode(10));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(20));
            root = api.AddNode(root, CreateNode(1));

            root = api.Remove(root, 20);

            Assert.AreEqual(5, root.Key);
            Assert.AreEqual(1, root.Left.Key);
            Assert.AreEqual(10, root.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [Test]
        public void Case_RootAndFour_DeleteNode_2000() // Case 3
        {
            var api = CreateApi();

            Int32AvlNode root;

            root = api.AddNode(null, CreateNode(1000));

            root = api.AddNode(root, CreateNode(500));
            root = api.AddNode(root, CreateNode(2000));

            root = api.AddNode(root, CreateNode(300));
            root = api.AddNode(root, CreateNode(700));
            root = api.AddNode(root, CreateNode(1500));
            root = api.AddNode(root, CreateNode(3000));

            root = api.AddNode(root, CreateNode(200));
            root = api.AddNode(root, CreateNode(400));
            root = api.AddNode(root, CreateNode(600));
            root = api.AddNode(root, CreateNode(800));
            root = api.AddNode(root, CreateNode(1300));
            root = api.AddNode(root, CreateNode(1700));
            root = api.AddNode(root, CreateNode(2500));
            root = api.AddNode(root, CreateNode(4000));

            root = api.AddNode(root, CreateNode(150));
            root = api.AddNode(root, CreateNode(250));
            root = api.AddNode(root, CreateNode(350));
            root = api.AddNode(root, CreateNode(450));
            root = api.AddNode(root, CreateNode(550));
            root = api.AddNode(root, CreateNode(650));
            root = api.AddNode(root, CreateNode(750));
            root = api.AddNode(root, CreateNode(850));
            root = api.AddNode(root, CreateNode(1200));
            root = api.AddNode(root, CreateNode(1350));
            root = api.AddNode(root, CreateNode(1600));
            root = api.AddNode(root, CreateNode(1800));
            root = api.AddNode(root, CreateNode(2400));
            root = api.AddNode(root, CreateNode(2700));
            root = api.AddNode(root, CreateNode(3500));
            root = api.AddNode(root, CreateNode(5000));

            root = api.Remove(root, 2000);

            Assert.AreEqual(1000, root.Key);

            Assert.AreEqual(500, root.Left.Key);
            Assert.AreEqual(2400, root.Right.Key);

            Assert.AreEqual(300, root.Left.Left.Key);
            Assert.AreEqual(700, root.Left.Right.Key);
            Assert.AreEqual(1500, root.Right.Left.Key);
            Assert.AreEqual(3000, root.Right.Right.Key);

            Assert.AreEqual(200, root.Left.Left.Left.Key);
            Assert.AreEqual(400, root.Left.Left.Right.Key);
            Assert.AreEqual(600, root.Left.Right.Left.Key);
            Assert.AreEqual(800, root.Left.Right.Right.Key);
            Assert.AreEqual(1300, root.Right.Left.Left.Key);
            Assert.AreEqual(1700, root.Right.Left.Right.Key);
            Assert.AreEqual(2500, root.Right.Right.Left.Key);
            Assert.AreEqual(4000, root.Right.Right.Right.Key);

            Assert.AreEqual(150, root.Left.Left.Left.Left.Key);
            Assert.AreEqual(250, root.Left.Left.Left.Right.Key);
            Assert.AreEqual(350, root.Left.Left.Right.Left.Key);
            Assert.AreEqual(450, root.Left.Left.Right.Right.Key);
            Assert.AreEqual(550, root.Left.Right.Left.Left.Key);
            Assert.AreEqual(650, root.Left.Right.Left.Right.Key);
            Assert.AreEqual(750, root.Left.Right.Right.Left.Key);
            Assert.AreEqual(850, root.Left.Right.Right.Right.Key);
            Assert.AreEqual(1200, root.Right.Left.Left.Left.Key);
            Assert.AreEqual(1350, root.Right.Left.Left.Right.Key);
            Assert.AreEqual(1600, root.Right.Left.Right.Left.Key);
            Assert.AreEqual(1800, root.Right.Left.Right.Right.Key);
            //Assert.AreEqual(2400, root.Right.Right.Left.Left.Key);  -- took the spot of the deleted node
            Assert.AreEqual(2700, root.Right.Right.Left.Right.Key);
            Assert.AreEqual(3500, root.Right.Right.Right.Left.Key);
            Assert.AreEqual(5000, root.Right.Right.Right.Right.Key);

            //Assert.AreEqual(0, root.BalanceFactor);
            //Assert.AreEqual(0, root.Left.BalanceFactor);
            //Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [TestCase]
        public void Case_1L_2_1_3_4()
        {
            var api = CreateApi();

            Int32AvlNode root;

            root = api.AddNode(null, CreateNode(2));
            root = api.AddNode(root, CreateNode(1));
            root = api.AddNode(root, CreateNode(3));
            root = api.AddNode(root, CreateNode(4));

            root = api.Remove(root, 1);

            Assert.AreEqual(3, root.Key);
            Assert.AreEqual(2, root.Left.Key);
            Assert.AreEqual(4, root.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [TestCase]
        public void Case_1R_3_2_4_1()
        {
            var api = CreateApi();

            Int32AvlNode root;

            root = api.AddNode(null, CreateNode(3));
            root = api.AddNode(root, CreateNode(2));
            root = api.AddNode(root, CreateNode(4));
            root = api.AddNode(root, CreateNode(1));

            root = api.Remove(root, 4);

            Assert.AreEqual(2, root.Key);
            Assert.AreEqual(1, root.Left.Key);
            Assert.AreEqual(3, root.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [TestCase]
        public void Case_1RL_2_1_4_3()
        {
            var api = CreateApi();

            Int32AvlNode root;

            root = api.AddNode(null, CreateNode(2));
            root = api.AddNode(root, CreateNode(1));
            root = api.AddNode(root, CreateNode(4));
            root = api.AddNode(root, CreateNode(3));

            root = api.Remove(root, 1);

            Assert.AreEqual(3, root.Key);
            Assert.AreEqual(2, root.Left.Key);
            Assert.AreEqual(4, root.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [TestCase]
        public void Case_1LR_3_1_4_2()
        {
            var api = CreateApi();

            Int32AvlNode root;

            root = api.AddNode(null, CreateNode(3));
            root = api.AddNode(root, CreateNode(1));
            root = api.AddNode(root, CreateNode(4));
            root = api.AddNode(root, CreateNode(2));

            root = api.Remove(root, 4);

            Assert.AreEqual(2, root.Key);
            Assert.AreEqual(1, root.Left.Key);
            Assert.AreEqual(3, root.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
        }

        [TestCase]
        public void Case_1L_3_2_5_1_4_6_7()
        {
            var api = CreateApi();

            Int32AvlNode root;

            root = api.AddNode(null, CreateNode(3));
            root = api.AddNode(root, CreateNode(2));
            root = api.AddNode(root, CreateNode(5));
            root = api.AddNode(root, CreateNode(1));
            root = api.AddNode(root, CreateNode(4));
            root = api.AddNode(root, CreateNode(6));
            root = api.AddNode(root, CreateNode(7));

            root = api.Remove(root, 1);

            Assert.AreEqual(5, root.Key);
            Assert.AreEqual(3, root.Left.Key);
            Assert.AreEqual(6, root.Right.Key);
            Assert.AreEqual(2, root.Left.Left.Key);
            Assert.AreEqual(4, root.Left.Right.Key);
            Assert.AreEqual(7, root.Right.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(-1, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);
        }

        [TestCase]
        public void Case_1R_5_3_6_2_4_7_1()
        {
            var api = CreateApi();

            Int32AvlNode root;

            root = api.AddNode(null, CreateNode(5));
            root = api.AddNode(root, CreateNode(3));
            root = api.AddNode(root, CreateNode(6));
            root = api.AddNode(root, CreateNode(2));
            root = api.AddNode(root, CreateNode(4));
            root = api.AddNode(root, CreateNode(7));
            root = api.AddNode(root, CreateNode(1));

            root = api.Remove(root, 7);

            Assert.AreEqual(3, root.Key);
            Assert.AreEqual(2, root.Left.Key);
            Assert.AreEqual(5, root.Right.Key);
            Assert.AreEqual(1, root.Left.Left.Key);
            Assert.AreEqual(4, root.Right.Left.Key);
            Assert.AreEqual(6, root.Right.Right.Key);

            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(1, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);
        }

        [TestCase]
        public void Case_1RL_e_c_j_a_d_h_k_b_g_i_l_f()
        {
            http://stackoverflow.com/questions/3955680/how-to-check-if-my-avl-tree-implementation-is-correct

            //    - e -                       —- h —-
            //   /     \                     /       \
            //  c       j                   - e-      j
            // / \     / \   == 2L ==>     /    \    / \
            //a   d   h   k               c      g  i   k
            // x     / \   \             / \    /        \
            //  b   g   i   l           a   d  f          l
            //     /
            //    f

            var api = CreateApi();

            Int32AvlNode root;

            root = api.AddNode(null, CreateNode(e));
            root = api.AddNode(root, CreateNode(c));
            root = api.AddNode(root, CreateNode(j));
            root = api.AddNode(root, CreateNode(a));
            root = api.AddNode(root, CreateNode(d));
            root = api.AddNode(root, CreateNode(h));
            root = api.AddNode(root, CreateNode(k));
            root = api.AddNode(root, CreateNode(b));
            root = api.AddNode(root, CreateNode(g));
            root = api.AddNode(root, CreateNode(i));
            root = api.AddNode(root, CreateNode(l));
            root = api.AddNode(root, CreateNode(f));

            root = api.Remove(root, b);

            Assert.AreEqual(h, root.Key);
            Assert.AreEqual(e, root.Left.Key);
            Assert.AreEqual(j, root.Right.Key);
            Assert.AreEqual(c, root.Left.Left.Key);
            Assert.AreEqual(g, root.Left.Right.Key);
            Assert.AreEqual(i, root.Right.Left.Key);
            Assert.AreEqual(k, root.Right.Right.Key);

            Assert.AreEqual(a, root.Left.Left.Left.Key);
            Assert.AreEqual(d, root.Left.Left.Right.Key);
            Assert.AreEqual(f, root.Left.Right.Left.Key);
            //Assert.AreEqual(800, root.Left.Right.Right.Key);
            //Assert.AreEqual(1300, root.Right.Left.Left.Key);
            //Assert.AreEqual(1700, root.Right.Left.Right.Key);
            //Assert.AreEqual(2500, root.Right.Right.Left.Key);
            Assert.AreEqual(l, root.Right.Right.Right.Key);



            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(0, root.Left.BalanceFactor);
            Assert.AreEqual(-1, root.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.BalanceFactor);
            Assert.AreEqual(1, root.Left.Right.BalanceFactor);
            Assert.AreEqual(0, root.Right.Left.BalanceFactor);
            Assert.AreEqual(-1, root.Right.Right.BalanceFactor);

            Assert.AreEqual(0, root.Left.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Left.Left.Right.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.Left.BalanceFactor);
            //Assert.AreEqual(800, root.Left.Right.Right.BalanceFactor);
            //Assert.AreEqual(1300, root.Right.Left.Left.BalanceFactor);
            //Assert.AreEqual(1700, root.Right.Left.Right.BalanceFactor);
            //Assert.AreEqual(2500, root.Right.Right.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.Right.BalanceFactor);
        }

        [TestCase]
        public void Case_1LR_h_c_k_b_e_i_l_a_d_f_j_g()
        {
            // http://stackoverflow.com/questions/3955680/how-to-check-if-my-avl-tree-implementation-is-correct

            //      - h -                    - e -
            //     /     \                  /     \
            //    c       k                c       - h -
            //   / \     / \  == 2R ==>   / \     /     \
            //  b   e   i   l            b   d   f       k
            // /   / \   x              /         \     / \
            //a   d   f   j            a           g   i   l
            //         \
            //          g

            var api = CreateApi();

            Int32AvlNode root;

            root = api.AddNode(null, CreateNode(h));
            root = api.AddNode(root, CreateNode(c));
            root = api.AddNode(root, CreateNode(k));
            root = api.AddNode(root, CreateNode(b));
            root = api.AddNode(root, CreateNode(e));
            root = api.AddNode(root, CreateNode(i));
            root = api.AddNode(root, CreateNode(l));
            root = api.AddNode(root, CreateNode(a));
            root = api.AddNode(root, CreateNode(d));
            root = api.AddNode(root, CreateNode(f));
            root = api.AddNode(root, CreateNode(j));
            root = api.AddNode(root, CreateNode(g));

            root = api.Remove(root, j);

            Assert.AreEqual(e, root.Key);
            Assert.AreEqual(c, root.Left.Key);
            Assert.AreEqual(h, root.Right.Key);
            Assert.AreEqual(b, root.Left.Left.Key);
            Assert.AreEqual(d, root.Left.Right.Key);
            Assert.AreEqual(f, root.Right.Left.Key);
            Assert.AreEqual(k, root.Right.Right.Key);

            Assert.AreEqual(a, root.Left.Left.Left.Key);
            //Assert.AreEqual(d, root.Left.Left.Right.Key);
            //Assert.AreEqual(f, root.Left.Right.Left.Key);
            //Assert.AreEqual(800, root.Left.Right.Right.Key);
            //Assert.AreEqual(1300, root.Right.Left.Left.Key);
            Assert.AreEqual(g, root.Right.Left.Right.Key);
            Assert.AreEqual(i, root.Right.Right.Left.Key);
            Assert.AreEqual(l, root.Right.Right.Right.Key);



            Assert.AreEqual(0, root.BalanceFactor);
            Assert.AreEqual(1, root.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.BalanceFactor);

            Assert.AreEqual(1, root.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Left.Right.BalanceFactor);
            Assert.AreEqual(-1, root.Right.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.BalanceFactor);

            Assert.AreEqual(0, root.Left.Left.Left.BalanceFactor);
            //Assert.AreEqual(0, root.Left.Left.Right.BalanceFactor);
            //Assert.AreEqual(0, root.Left.Right.Left.BalanceFactor);
            //Assert.AreEqual(800, root.Left.Right.Right.BalanceFactor);
            //Assert.AreEqual(1300, root.Right.Left.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Left.Right.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.Left.BalanceFactor);
            Assert.AreEqual(0, root.Right.Right.Right.BalanceFactor);
        }
    }
}
