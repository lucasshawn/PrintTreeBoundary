using PrintTreeBoundary.CountMethods;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PrintTreeBoundary
{
    internal class CountUsingLevelOrder : ICountBinaryTreeBoundary
    {
        bool isRecursive = true;
        public CountUsingLevelOrder(CountOptions options = CountOptions.Recursive)
        {
            isRecursive = options == CountOptions.Recursive;
        }
        public IList<TreeNode> GetOutputSequence(TreeNode rootNode)
        {
            IList<TreeNode> output = new List<TreeNode>();
            var levelMap = BuildLevelMap(rootNode);
            if (levelMap.Count == 0) return output;

            Stack<TreeNode> rightSide = new Stack<TreeNode>();

            // Walk Left
            for (int i = 0; i < levelMap.Count - 1; i++)
            {
                var currentLevel = levelMap[i];
                Debug.Assert(currentLevel.Count > 0, "We should never have an empty level in the level map- something is wrong.");

                output.Add(currentLevel[0]);
                if (currentLevel.Count > 1)
                    rightSide.Push(currentLevel[currentLevel.Count - 1]);
            }

            // Walk bottom
            foreach (var entryInLastLevel in levelMap[levelMap.Count - 1])
                output.Add(entryInLastLevel);

            // Walk right
            while (rightSide.Count != 0)
                output.Add(rightSide.Pop());

            return output;
        }

        private IList<IList<TreeNode>> BuildLevelMap(TreeNode rootNode)
        {
            var levelMap = new List<IList<TreeNode>>();
                traverseRecursive(rootNode, 0, levelMap);
            
            // Cleanup empty tails
            levelMap.RemoveAll(inst => inst.Count == 0);
            return levelMap;
        }

        private void traverseRecursive(TreeNode rootNode, int level, IList<IList<TreeNode>> levelMap)
        {
            if (rootNode == null) return;
            levelMap.Add(new List<TreeNode>());
            levelMap[level].Add(rootNode);
            traverseRecursive(rootNode.Left, level + 1, levelMap);
            traverseRecursive(rootNode.Right, level + 1, levelMap);
        }
    }
}
