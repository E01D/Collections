using E01D.Collections.Api.Collections.Trees;

namespace E01D.Collections.Components.Collections.Trees
{
    public class TreeNodeFluent<TNode, TKey>
    {
        public TNode Root { get; set; }

        public TreeApi_I<TNode, TKey> Api { get; set; }
    }
}
