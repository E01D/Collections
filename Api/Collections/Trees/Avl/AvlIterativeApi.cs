using E01D.Collections.Components.Collections.Trees;
using E01D.Collections.Models.Collections.Trees.Avl;

namespace E01D.Collections.Api.Collections.Trees.Avl
{
    public abstract class AvlIterativeApi<TNode, TKey> : AvlApi_I<TNode, TKey>
    {
        public TreeNodeFluent<TNode, TKey> Add(TNode newNode)
        {
            return new TreeNodeFluent<TNode, TKey>()
            {
                Api = GetApi(),
                Root = AddNode(default(TNode), newNode)
            };
        }

        /// <summary>
        /// Adds a node use the fluent interface.
        /// </summary>
        /// <param name="existingRoot"></param>
        /// <param name="newNode"></param>
        /// <returns></returns>
        public TreeNodeFluent<TNode, TKey> Add(TNode existingRoot, TNode newNode)
        {
            return new TreeNodeFluent<TNode, TKey>()
            {
                Api = GetApi(),
                Root = AddNode(existingRoot, newNode)
            };
        }

        /// <summary>
        /// Creates a new tree.
        /// </summary>
        /// <param name="newNode"></param>
        /// <returns></returns>
        public TNode AddNode(TNode newNode)
        {
            return AddNode(NullNode(), newNode);
        }

        /// <summary>
        /// Adds a new node to the tree and returns the new root of the tree.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="newNode"></param>
        /// <param name="compareValue"></param>
        /// <note>Having the comparison value passsed in allows for the method to be more easily tested.   We can just pick various compare values and see how the tree responds.</note>
        /// <returns>The new root of the tree.</returns>
        public TNode AddNode(TNode root, TNode newNode)
        {
            if (IsNull(root))
            {
                return newNode;
            }

            if (IsNull(newNode))
            {
                return root;
            }

            var node = root;

            AvlStackNode<TNode> stack = null;

            int direction;

            TNode nextNode;

            // While there is a node to insert
            do
            {
                var comparisonValue = Compare(node, newNode);

                if (comparisonValue == 0)
                {
                    return HandleDuplicateException(root, node, newNode);
                }

                if (comparisonValue > 0 || SupportsDuplicateKeys())
                {
                    nextNode = GetLeft(node);

                    direction = 1;

                    if (IsNull(nextNode))
                    {
                        node = SetLeft(node, newNode);

                        break;
                    }
                }
                else //(comparisonValue < 0)
                {
                    nextNode = GetRight(node);

                    direction = -1;

                    if (IsNull(nextNode))
                    {
                        node = SetRight(node, newNode);

                        break;
                    }
                }

                stack = new AvlStackNode<TNode>()
                {
                    ImmediateChangeInBalanceFactor = direction,
                    Node = node,
                    Previous = stack
                };

                node = nextNode;
            }
            while (!IsNull(nextNode)); // nextNode != null

            // adjust balance factor on the current node
            var newBalanceFactor = GetBalanceFactor(node) + direction;

            node = SetBalanceFactor(node, newBalanceFactor);

            return BalanceTree(stack, node, newBalanceFactor); // If I am adding a new node to the right of the parent, the parent balance factor will increase by one.

            // Found a node that is the same
        }

        private TNode BalanceTree(AvlStackNode<TNode> stack, TNode parent, int newTheoreticalBalanceFactorForParent)
        {
            while (newTheoreticalBalanceFactorForParent != 0 && stack != null)
            {
                // STEP 1: CHECK IF EDGE NEEDS TO BE SETUP - Has to be first due to immutability
                // This needs to be first since we might need to estabalish / update a edge prior to rotations
                // since the AVL tree is immutable.  
                if (newTheoreticalBalanceFactorForParent == 1 || newTheoreticalBalanceFactorForParent == -1)
                {
                    // immutability forces this
                    var grandparent = stack.Node;

                    // no parent node forces this so we cannot just look up the data structure
                    newTheoreticalBalanceFactorForParent = stack.ImmediateChangeInBalanceFactor;

                    // no parent node forces.
                    stack = stack.Previous;

                    // This is a neccessity since we are using 

                    // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                    if (newTheoreticalBalanceFactorForParent == 1)
                    {
                        // immutability forces this - rotations fail without this being set.
                        parent = SetLeft(grandparent, parent);
                    }
                    else
                    {
                        // immutability forces this - rotations fail without this being set.
                        parent = SetRight(grandparent, parent);
                    }

                    // part of AVL algoirthm
                    newTheoreticalBalanceFactorForParent = GetBalanceFactor(parent) + newTheoreticalBalanceFactorForParent;

                    // part of AVL algoirthm
                    parent = SetBalanceFactor(parent, newTheoreticalBalanceFactorForParent);
                }

                // STEP 2: CHECK IF ROTATION NEEDS TO BE PERFORMED

                switch (newTheoreticalBalanceFactorForParent)
                {
                    case 2:
                        {
                            var singleRotate = GetBalanceFactor(GetLeft(parent)) == 1;

                            #region Notes

                            // Note: the balance factor logic is specific to the sub
                            //       case.  The logic is not setup to work correctly
                            //       if you calling rotate left and then rotate right.  
                            //       This is because the logic is optimized and the 
                            //       Rotate right does not consider this particular right 
                            //       rotation needed by this rotation sequence.

                            #endregion

                            parent = singleRotate ? RotateRight(parent) : RotateLeftRight(parent);

                            break;
                        }
                    case -2:
                        {
                            var singleRotate = GetBalanceFactor(GetRight(parent)) == -1;

                            // Note: the balance factor logic is specific to the sub
                            //       case.  The logic is not setup to work correctly
                            //       if you calling rotate right and then rotate left.  
                            //       This is because the logic is optimized and the 
                            //       Rotate Left does not consider this particular left 
                            //       rotation needed by this rotation sequence.
                            parent = singleRotate ? RotateLeft(parent) : RotateRightLeft(parent);

                            break;
                        }
                }

            }

            return FixTree(stack, parent);
        }

        private TNode FixTree(AvlStackNode<TNode> stack, TNode node)
        {
            // Could be null on delete possibly.
            if (IsNull(node)) return node;

            while (stack != null)
            {
                var childNode = node;

                node = stack.Node;

                // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                if (stack.ImmediateChangeInBalanceFactor == 1)
                {
                    node = SetLeft(node, childNode);
                }
                else
                {
                    node = SetRight(node, childNode);
                }

                stack = stack.Previous;
            }

            return node;
        }

        public TNode RotateLeft(TNode parent)
        {
            var pivot = GetRight(parent);

            var newParentBalanceFactor = GetBalanceFactor(pivot) + 1;

            parent = SetRight(parent, GetLeft(pivot), -newParentBalanceFactor);

            pivot = SetLeft(pivot, parent, newParentBalanceFactor);

            return pivot;
        }

        public TNode RotateRight(TNode parent)
        {
            var pivot = GetLeft(parent);

            var pivotBalanceFactor = GetBalanceFactor(pivot);

            var newParentBalanceFactor = GetBalanceFactor(pivot) - 1;

            // Notes: Balance Factor
            // If the pivot node has a right sub tree, then there would be a 
            // transfer of sub trees from the pivot node to parent node.  
            // The result would be the pivot node would 
            var parentPrime = SetLeft(parent, GetRight(pivot), -newParentBalanceFactor);

            pivot = SetRight(pivot, parentPrime, newParentBalanceFactor);

            return pivot;
        }

        public TNode RotateLeftRight(TNode x4)
        {
            //                      x4               x4
            //                     /  \             /  \
            //                   x6               x5    ?
            //                  /  \     ==>     /  \
            //                 a*   x5          x6   d
            //                     / \         /  \   
            //                    c*  d       a*   c  


            // First Operation - Rotate Right

            // c - 6
            var x6 = GetLeft(x4); // *
            // b - 5
            var x5 = GetRight(x6); // *

            var c = GetLeft(x5); // *

            var x5Bf = GetBalanceFactor(x5); // *

            //var x6Bf = GetBalanceFactor(x6);

            // d moves to left of x6
            var x6Prime = SetRight(x6, c, x5Bf == -1 ? 1 : 0); //*

            // x6 moves to right of x5 now that d moved
            var x5Prime = SetLeft(x5, x6Prime, 0);

            // x5 takes the place fo x6 under x4
            var x4Prime = SetLeft(x4, x5Prime, x5Bf == -1 || x5Bf == 0 ? 0 : -1);

            // ----------------------------

            //                      x4              x4                    x5
            //                     /  \            /  \                 /    \
            //                   x6               x5   ?               x6     x4
            //                  /  \     ==>     /  \       =>        /  \   /  \
            //                 a*   x5          x6   d               a*   c d    ?
            //                     / \         /  \   
            //                    c*  d       a*   c  

            var d = GetRight(x5);

            var x4Final = SetLeft(x4Prime, d);

            var x5Final = SetRight(x5Prime, x4Final);

            return x5Final;
        }

        public TNode RotateRightLeft(TNode x4)
        {
            //                      x4               x4
            //                       \                \
            //                        x6               x5
            //                       /  \     ==>     / \
            //                      x5   a*          c   x6
            //                     / \                  / \
            //                    c*  d                d   a*


            // First Operation - Rotate Right

            // c - 6
            var x6 = GetRight(x4);
            // b - 5
            var x5 = GetLeft(x6);

            var d = GetRight(x5);

            var x5Bf = GetBalanceFactor(x5);

            //var x6Bf = GetBalanceFactor(x6);

            // d moves to left of x6
            var x6Prime = SetLeft(x6, d, x5Bf == 1 ? -1 : 0);

            // x6 moves to right of x5 now that d moved
            var x5Prime = SetRight(x5, x6Prime, 0);

            // x5 takes the place fo x6 under x4
            var x4Prime = SetRight(x4, x5Prime, x5Bf == 1 || x5Bf == 0 ? 0 : 1);

            // ----------------------------

            //                      x4               x4                   x5*
            //                       \                \                  /  \
            //                        x6               x5              x4*   x6
            //                       /  \     ==>     / \   =:>       /  \  /  \ 
            //                      x5   a*          c   x6          ?    c d   a
            //                     / \                  / \
            //                    c*  d                d   a

            var c = GetLeft(x5);

            var x4Final = SetRight(x4Prime, c);

            var x5Final = SetLeft(x5Prime, x4Final);

            return x5Final;
        }

        private TNode Find(TNode root, TKey key, out AvlStackNode<TNode> stack)
        {
            stack = null;

            var node = root;

            while (!IsNull(node))
            {
                var compareResult = CompareKeys(GetKey(node), key);

                if (compareResult == 0)
                {
                    break;
                }

                if (compareResult < 0)
                {
                    stack = new AvlStackNode<TNode>()
                    {
                        // remove something on the right side, so net change is 1, or addition to left side
                        ImmediateChangeInBalanceFactor = 1,
                        Node = node,
                        Previous = stack
                    };

                    node = GetRight(node);
                }
                else if (compareResult > 0 || SupportsDuplicateKeys())
                {
                    stack = new AvlStackNode<TNode>()
                    {
                        // remove something on the left side, so net change is -1, or addition to right side
                        ImmediateChangeInBalanceFactor = -1,
                        Node = node,
                        Previous = stack
                    };

                    node = GetLeft(node);
                }
            }

            return node;
        }

        public TNode Remove(TNode root, TKey key)
        {
            AvlStackNode<TNode> stack;

            TNode nodeToRemove = Find(root, key, out stack);

            // If no node was found, return root; nothing has changed.
            if (IsNull(nodeToRemove)) return root;

            return RemoveNode(nodeToRemove, stack);
        }

        private TNode RemoveNode(TNode node, AvlStackNode<TNode> stack)
        {
            // CASE 1: If has no children delete the root.  We know this is the root as there is no stack.
            if (stack == null)
            {
                // CASE 1.1 - The root node is being deleted.
                return NullNode();
            }

            var left = GetLeft(node);
            var right = GetRight(node);

            TNode newChild;

            if (!IsNull(left) && !IsNull(right))
            {
                right = RotateSmallestUp(right);

                newChild = SetLeft(right, GetLeft(node), GetBalanceFactor(right) - 1);

                return BalanceTreeAfterDeletion(stack, newChild, -1);
            }

            if (IsNull(left))
            {
                // LEFT is NULL and RIGHT is NULL
                if (IsNull(right))
                {
                    var previousStack = stack.Previous;

                    if (previousStack == null)
                    {
                        return BalanceTreeAfterDeletion(stack, right, stack.ImmediateChangeInBalanceFactor);
                    }

                    newChild = stack.Node;
                    int parentalChange;
                    TNode newChildSibling;

                    if (stack.ImmediateChangeInBalanceFactor == -1)
                    {
                        newChild = SetLeft(newChild, right, GetBalanceFactor(stack.Node) + stack.ImmediateChangeInBalanceFactor);

                        newChildSibling = GetRight(newChild);
                    }
                    else
                    {
                        newChild = SetRight(newChild, right, GetBalanceFactor(stack.Node) + stack.ImmediateChangeInBalanceFactor);

                        newChildSibling = GetLeft(newChild);
                    }

                    parentalChange = IsNull(newChildSibling) ? previousStack.ImmediateChangeInBalanceFactor : 0;

                    // could be assigned either right or left, does not matter, both are null.
                    return BalanceTreeAfterDeletion(previousStack, newChild, parentalChange);

                }

                // CASE 2a - Node with one child being deleted - left is null, right not null
                newChild = DuplicateNodeFromNode(right);

                return BalanceTreeAfterDeletion(stack, newChild, stack.ImmediateChangeInBalanceFactor);

            }

            // CASE 2b - Node with one child being deleted - left is not null, right is null
            newChild = DuplicateNodeFromNode(left);

            return BalanceTreeAfterDeletion(stack, newChild, stack.ImmediateChangeInBalanceFactor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="node"></param>
        /// <param name="parentalChange">The type of previous change determines the parantal change.</param>
        /// <returns></returns>
        private TNode BalanceTreeAfterDeletion(AvlStackNode<TNode> stack, TNode node, int parentalChange)
        {
            // Approach
            // 0) Set the new balance factor based upon the immediate change from the previous logic. 
            // 1) Set Edge which always has to be updated as the algorithm moves up the stack due to the collection nodes being immutable.
            // 2) Adjust balance factor on the node we are currently based upon rules.
            while (stack != null)
            {
                var child = node;

                node = stack.Node;

                if (stack.ImmediateChangeInBalanceFactor == -1)
                {
                    // CASE 1.2a - A leaf node is being deleted
                    node = SetLeft(node, child);
                }
                else
                {
                    // CASE 1.2b - A leaf node is being deleted
                    node = SetRight(node, child);
                }

                var newTheoreticalBalanceFactor = GetBalanceFactor(node) + parentalChange;

                switch (newTheoreticalBalanceFactor)
                {

                    case 2:
                        {
                            var singleRotate = GetBalanceFactor(GetLeft(node)) == 1;  // needs to be reverse of the insert

                            #region Notes

                            // Note: the balance factor logic is specific to the sub
                            //       case.  The logic is not setup to work correctly
                            //       if you calling rotate left and then rotate right.  
                            //       This is because the logic is optimized and the 
                            //       Rotate right does not consider this particular right 
                            //       rotation needed by this rotation sequence.

                            #endregion

                            node = singleRotate ? RotateRight(node) : RotateLeftRight(node);

                            break;
                        }
                    case -2:
                        {
                            var singleRotate = GetBalanceFactor(GetRight(node)) == -1; // needs to be reverse of the insert

                            // Note: the balance factor logic is specific to the sub
                            //       case.  The logic is not setup to work correctly
                            //       if you calling rotate right and then rotate left.  
                            //       This is because the logic is optimized and the 
                            //       Rotate Left does not consider this particular left 
                            //       rotation needed by this rotation sequence.
                            node = singleRotate ? RotateLeft(node) : RotateRightLeft(node);

                            break;
                        }
                    case 0:
                        {
                            // part of AVL algoirthm
                            node = SetBalanceFactor(node, newTheoreticalBalanceFactor);

                            break;
                        }
                    case 1:
                    case -1:
                        {
                            // Since the balance equals 1 or -1, nothing really changed, we are done.
                            break; //return FixTree(stack, node);
                        }
                }

                // This means the curent node needs to be the node in the stack;
                stack = stack.Previous;

                if (stack != null)
                {
                    parentalChange = stack.ImmediateChangeInBalanceFactor;
                }

            }

            return node;
        }

        private TNode RotateSmallestUp(TNode node)
        {
            AvlStackNode<TNode> stack = null;

            var preceding = GetLeft(node);

            while (preceding != null)
            {
                stack = new AvlStackNode<TNode>()
                {
                    Node = node,
                    Previous = stack
                };

                // since the recursive algorithm passes in preceding, we need to make the node equal to preceding.
                node = preceding;

                // update the preceding calculation for the next iteration of the while loop.
                preceding = GetLeft(node);
            }

            preceding = node;

            // reached base case of the recursive algorithm and the preceding node is now null.  

            while (stack != null)
            {
                node = stack.Node;

                node = SetLeft(node, preceding);

                preceding = RotateRight(node);

                stack = stack.Previous;
            }

            return preceding;
        }



        #region Abstract Implementation

        public abstract long CompareKeys(TKey getKey, TKey key);

        public abstract TKey GetKey(TNode node);

        public abstract bool SupportsDuplicateKeys();

        public abstract TNode HandleDuplicateException(TNode existingRoot, TNode currentRoot, TNode newNode);


        public abstract TNode CreateNode(TNode newNode, int balanceFactor);


        public abstract bool AreSame(TNode nodeA, TNode nodeB);


        public abstract TNode GetLeft(TNode existing);


        public abstract TNode GetRight(TNode existing);


        public abstract TNode SetLeft(TNode existing, TNode newLeft, int newBalanceFactor);


        public abstract TNode SetRight(TNode existing, TNode newRight, int newBalanceFactor);


        public abstract TNode SetLeft(TNode existing, TNode newLeft);


        public abstract TNode SetRight(TNode existing, TNode newRight);


        public abstract int GetBalanceFactor(TNode existing);

        public abstract TNode SetBalanceFactor(TNode existing, int newFactor);


        public abstract bool IsNull(TNode node);


        public abstract TNode NullNode();


        public abstract long Compare(TNode existing, TNode newNode);

        public abstract TNode DuplicateNode(TNode node, TNode left, TNode right);

        public abstract TNode DuplicateNodeFromNode(TNode source);


        public abstract AvlIterativeApi<TNode, TKey> GetApi();

        #endregion
    }
}
