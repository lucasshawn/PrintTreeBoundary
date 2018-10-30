namespace PrintTreeBoundary
{
    internal static class TreeFactory
    {
        internal static TreeNode SingleNodeTree()
        {
            return new TreeNode() { Data = 1 };
        }

        internal static TreeNode WeightedRight()
        {
            TreeNode tn = new TreeNode() { Data = 1 };
            tn.Right = new TreeNode() { Data = 2 };
            tn.Right.Right = new TreeNode() { Data = 3 };
            return tn;
        }
        internal static TreeNode Tree1()
        {
            TreeNode tn = new TreeNode() { Data = 1 };
            tn.Left = new TreeNode() { Data = 2 };
            tn.Right = new TreeNode() { Data = 3 };
            tn.Left.Left = new TreeNode() { Data = 4 };
            tn.Left.Right = new TreeNode() { Data = 5 };
            tn.Right.Left = new TreeNode() { Data = 6 };
            tn.Right.Right = new TreeNode() { Data = 7 };
            return tn;
        }

        internal static TreeNode Tree2()
        {
            TreeNode tn = new TreeNode() { Data = 1 };
            tn.Left = new TreeNode() { Data = 2 };
            tn.Right = new TreeNode() { Data = 3 };
            tn.Left.Right = new TreeNode() { Data = 5 };
            tn.Right.Left = new TreeNode() { Data = 6 };
            return tn;
        }

        internal static TreeNode Tree3()
        {
            TreeNode tn = new TreeNode() { Data = 1 };
            tn.Left = new TreeNode() { Data = 2 };
            tn.Left.Left = new TreeNode() { Data = 4 };
            return tn;
        }

        internal static TreeNode BalancedSizeN(int nNodes)
        {
            if (nNodes == 0) return null;
            TreeNode tn = new TreeNode() { Data = nNodes };
            tn.Left = BalancedSizeN(nNodes - 1);
            tn.Right = BalancedSizeN(nNodes - 1);
            return tn;
        }
    }
}
