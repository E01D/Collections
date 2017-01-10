namespace E01D.Collections.Models.Collections.Trees.Avl
{
    public class AvlStackNode<TNode>
    {
        public AvlStackNode<TNode> Previous { get; set; }

        public TNode Node { get; set; }
        public int ImmediateChangeInBalanceFactor { get; set; }
    }
}
