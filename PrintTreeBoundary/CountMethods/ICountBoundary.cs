using PrintTreeBoundary.CountMethods;
using System.Collections.Generic;

namespace PrintTreeBoundary.CountMethods
{
    internal interface ICountBinaryTreeBoundary
    {
        IList<TreeNode> GetOutputSequence(TreeNode rootNode);
    }
}
