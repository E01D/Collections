using E01D.Collections.Components.Collections.Trees;

namespace E01D.Collections.Api.Collections.Trees
{
    public interface TreeApi_I<TNode, TKey>
    {
        TreeNodeFluent<TNode, TKey> Add(TNode newNode);

        /// <summary>
        /// Adds a node use the fluent interface.
        /// </summary>
        /// <param name="existingRoot"></param>
        /// <param name="newNode"></param>
        /// <returns></returns>
        TreeNodeFluent<TNode, TKey> Add(TNode existingRoot, TNode newNode);

        TNode AddNode(TNode newNode);

        /// <summary>
        /// Should return the new root of the treee
        /// </summary>
        /// <param name="existingRoot">The existing root of the local tree.</param>
        /// <param name="newNode">The new node to insert.</param>
        /// <returns>The new root of the tree</returns>
        TNode AddNode(TNode existingRoot, TNode newNode);

        TNode Remove(TNode root, TKey key);
    }
}
