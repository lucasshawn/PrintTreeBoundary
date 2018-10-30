using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTreeBoundary
{
    internal static class ListToStringExtension
    {
        public static string ToCommaString(this IList<TreeNode> nodes)
        {
            var s = string.Join(',', nodes);
            if (s.Length > 100) return s.Substring(0, 100) + "...";
            return s;
        }
    }
}
