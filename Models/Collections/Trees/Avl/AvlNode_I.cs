namespace E01D.Collections.Models.Collections.Trees.Avl
{
    public interface AvlNode_I<TNode, TKey>
    {
        TNode Left { get; set; }

        TNode Right { get; set; }

        int BalanceFactor { get; set; }

        TKey Key { get; set; }
    }
}
