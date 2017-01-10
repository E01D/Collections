using System;
using E01D.Collections.Models.Collections.Trees.Avl;

namespace E01D.Collections.Api.Collections.Trees.Avl
{
    public class AvlIterativeInt32Api : AvlIterativeApi<Int32AvlNode, int>
    {
        public AvlIterativeInt32Api()
        {

        }




        public override int GetKey(Int32AvlNode node)
        {
            return node.Key;
        }

        public override bool SupportsDuplicateKeys()
        {
            return false;
        }

        public override Int32AvlNode HandleDuplicateException(Int32AvlNode existingRoot, Int32AvlNode currentRoot, Int32AvlNode newNode)
        {
            throw new Exception("Duplicate key");
        }

        public override Int32AvlNode CreateNode(Int32AvlNode newNode, int balanceFactor)
        {
            return new Int32AvlNode()
            {
                BalanceFactor = balanceFactor,
                Key = newNode.Key,
                Left = newNode.Left,
                Right = newNode.Right
            };
        }


        public override bool AreSame(Int32AvlNode nodeA, Int32AvlNode nodeB)
        {
            return ReferenceEquals(nodeA, nodeB);
        }


        public override Int32AvlNode GetLeft(Int32AvlNode existing)
        {
            return existing.Left;
        }


        public override Int32AvlNode GetRight(Int32AvlNode existing)
        {
            return existing.Right;
        }


        public override Int32AvlNode SetLeft(Int32AvlNode existing, Int32AvlNode newLeft, int newBalanceFactor)
        {
            return new Int32AvlNode()
            {
                BalanceFactor = newBalanceFactor,
                Key = existing.Key,
                Left = newLeft,
                Right = existing.Right
            };
        }


        public override Int32AvlNode SetRight(Int32AvlNode existing, Int32AvlNode newRight, int newBalanceFactor)
        {
            return new Int32AvlNode()
            {
                BalanceFactor = newBalanceFactor,
                Key = existing.Key,
                Left = existing.Left,
                Right = newRight
            };
        }


        public override Int32AvlNode SetLeft(Int32AvlNode existing, Int32AvlNode newLeft)
        {
            return new Int32AvlNode()
            {
                BalanceFactor = existing.BalanceFactor,
                Key = existing.Key,
                Left = newLeft,
                Right = existing.Right
            };
        }


        public override Int32AvlNode SetRight(Int32AvlNode existing, Int32AvlNode newRight)
        {
            return new Int32AvlNode()
            {
                BalanceFactor = existing.BalanceFactor,
                Key = existing.Key,
                Left = existing.Left,
                Right = newRight
            };
        }


        public override int GetBalanceFactor(Int32AvlNode existingRoot)
        {
            return existingRoot.BalanceFactor;
        }

        public override Int32AvlNode SetBalanceFactor(Int32AvlNode existing, int newFactor)
        {
            return new Int32AvlNode()
            {
                BalanceFactor = newFactor,
                Key = existing.Key,
                Left = existing.Left,
                Right = existing.Right
            };
        }


        public override bool IsNull(Int32AvlNode node)
        {
            return node == null;
        }


        public override Int32AvlNode NullNode()
        {
            return null;
        }


        public override long Compare(Int32AvlNode existingRoot, Int32AvlNode newNode)
        {
            return CompareKeys(existingRoot.Key, newNode.Key);
        }

        public override long CompareKeys(int x, int y)
        {
            //return 10 - 5 = 5;
            // Rule: If existing is greater than newNode, return greater than 0.  RULE PASSES
            return x - y;
        }

        public override Int32AvlNode DuplicateNode(Int32AvlNode node, Int32AvlNode left, Int32AvlNode right)
        {
            var newNode = new Int32AvlNode()
            {
                BalanceFactor = node.BalanceFactor,
                Key = node.Key,
                Left = left,
                Right = right,
            };

            return newNode;
        }

        public override Int32AvlNode DuplicateNodeFromNode(Int32AvlNode source)
        {
            var newNode = new Int32AvlNode()
            {
                BalanceFactor = source.BalanceFactor,
                Key = source.Key,
                Left = source.Left,
                Right = source.Right,
            };

            return newNode;
        }


        public override AvlIterativeApi<Int32AvlNode, int> GetApi()
        {
            return this;
        }
    }
}
