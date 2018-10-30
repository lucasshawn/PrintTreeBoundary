using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTreeBoundary
{
    internal static class ListToStringExtension
    {
        public static string ToCommaString(this IList<TreeNode> nodes)
        {
            return string.Join(',', nodes);
        }
    }
}
