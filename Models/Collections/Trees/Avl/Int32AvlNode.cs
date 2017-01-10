using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01D.Collections.Models.Collections.Trees.Avl
{
    public class Int32AvlNode
    {
        public Int32AvlNode Left { get; set; }

        public Int32AvlNode Right { get; set; }

        public int BalanceFactor { get; set; }

        public int Key { get; set; }

        public override string ToString()
        {
            return $"K: {Key}, {Left?.Key.ToString() ?? "?"} | {Right?.Key.ToString() ?? "?"}, BF: {BalanceFactor}";
        }
    }
}
