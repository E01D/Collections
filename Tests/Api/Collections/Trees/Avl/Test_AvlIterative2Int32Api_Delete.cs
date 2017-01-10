using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E01D.Collections.Api.Collections.Trees.Avl;
using E01D.Collections.Models.Collections.Trees.Avl;
using NUnit.Framework;

namespace E01D.Collections.Tests.Api.Collections.Trees.Avl
{
    [TestFixture]
    public class Test_AvlIterative2Int32Api_Delete : Test_AvlInt32Base_Delete
    {
        public override AvlApi_I<Int32AvlNode, int> CreateApi()
        {
            return new AvlIterativeInt32Api();
        }
    }
}
