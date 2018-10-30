using PrintTreeBoundary.CountMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrintTreeBoundary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create some sample trees
            IList<TreeNode> trees = new TreeNode[] {
                TreeFactory.Tree1(),
                TreeFactory.Tree2(),
                TreeFactory.Tree3()
            };

            // Create our counting functions
            IList<ICountBinaryTreeBoundary> countFunctions = new ICountBinaryTreeBoundary[] {
                new CountUsingLevelOrder(),
                new CountUsingEdgeTraversal(),
                
            };

            // Count using each function and compare output - Fail the test where outputs are not equal
            for(int currentTree = 0; currentTree < trees.Count(); currentTree++)
            {
                var tree = trees[currentTree];
                string[] results = new string[countFunctions.Count];
                for(int current = 0; current < results.Length; current++)
                {
                    results[current] = countFunctions[current].GetOutputSequence(tree).ToCommaString();
                    Console.WriteLine($"Tree({currentTree}) Function({countFunctions[current].GetType().Name}): {results[current]}");
                }
                bool matchingOutput = results.Distinct().Count() == 1;
                Console.WriteLine($"\tMatching Output? {matchingOutput}");
                // If anything in the array is different, it's a fail.
                Assert.True(matchingOutput);
            }

            Console.WriteLine("\r\nComplete.");
            Console.ReadLine();
        }
    }
}
