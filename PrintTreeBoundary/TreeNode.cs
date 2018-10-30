namespace PrintTreeBoundary
{
    internal class TreeNode
    {
        public TreeNode Left = null;
        public TreeNode Right = null;
        public int Data = int.MinValue;

        public override string ToString()
        {
            return $"{this.Data}";
        }    
    }
}
