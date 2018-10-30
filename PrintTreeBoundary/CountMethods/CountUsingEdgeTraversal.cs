using System;
using System.Collections.Generic;

namespace PrintTreeBoundary.CountMethods
{
    internal class CountUsingEdgeTraversal : ICountBinaryTreeBoundary
    {
        bool isRecursive = false;

        public CountUsingEdgeTraversal(CountOptions options = CountOptions.Iterative)
        {
            if (options == CountOptions.Recursive) isRecursive = true;
        }

        public IList<TreeNode> GetOutputSequence(TreeNode rootNode)
        {
            List<TreeNode> output = new List<TreeNode>();

            output.AddRange(PrintLeft(rootNode, out bool isLinearTree));
            output.AddRange(PrintLeaf(rootNode));

            // Don't print right if we discovered that while traversing LEFT the tree is linear.
            if (!isLinearTree)
                output.AddRange(PrintRight(rootNode));
            return output;
        }

        private IList<TreeNode> PrintLeft(TreeNode t, out bool isLinear)
        {
            List<TreeNode> output = new List<TreeNode>();
            isLinear = true;

            var temp = t;
            while (temp != null)
            {
                // Only print if it's not a LEAF
                if (temp.Left != null || temp.Right != null)
                {
                    output.Add(temp);
                }

                // Walk left if a left node, otherwise walk right
                if (temp.Left != null)
                {
                    if (temp.Right != null) isLinear = false;
                    temp = temp.Left;
                }
                else if (temp.Right != null)
                {
                    temp = temp.Right;
                }
                else
                    temp = null;
            }
            return output;
        }

        private IList<TreeNode> PrintRight(TreeNode t)
        {
            var temp = t;
            List<TreeNode> output = new List<TreeNode>();
            Stack<TreeNode> reversePrint = new Stack<TreeNode>();
            while (temp != null)
            {
                if (temp.Right != null && temp.Left != null)
                {
                    reversePrint.Push(temp);
                }
                else if (temp.Right == null && temp.Left != null)
                {
                    reversePrint.Push(temp);
                    temp = temp.Left;
                    continue;
                }
                temp = temp.Right;
            }

            // We drop out at 1 instead to avoid reprinting the top
            while (reversePrint.Count > 1)
            {
                output.Add(reversePrint.Pop());
            }
            return output;
        }

        private IList<TreeNode> PrintLeaf(TreeNode rootNode)
        {
            IList<TreeNode> nodes = new List<TreeNode>();
            if (isRecursive)
                PrintLeafRecursive(rootNode, nodes);
            else
                nodes = PrintLeafIterative(rootNode);
            return nodes;
        }

        private IList<TreeNode> PrintLeafIterative(TreeNode t)
        {
            List<TreeNode> output = new List<TreeNode>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(t);
            while (q.Count > 0)
            {
                TreeNode tn = q.Dequeue();
                if (tn == null) continue;
                if (tn.Left == null && tn.Right == null)
                    output.Add(tn);

                q.Enqueue(tn.Left);
                q.Enqueue(tn.Right);
            }
            return output;
        }

        private void PrintLeafRecursive(TreeNode t, IList<TreeNode> nodes)
        {
            if (t == null) return;
            if (t.Left == null && t.Right == null)
                nodes.Add(t);
            PrintLeafRecursive(t.Left, nodes);
            PrintLeafRecursive(t.Right, nodes);
        }

        public override string ToString()
        {
            return $"{nameof(CountUsingEdgeTraversal)} isRecursive({isRecursive})";
        }
    }
}
