using PrintTreeBoundary.CountMethods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                TreeFactory.Tree3(),
                TreeFactory.SingleNodeTree(),
                TreeFactory.WeightedRight(),
                // Repeat same test to get an idea for average for larger trees
                TreeFactory.BalancedSizeN(20),
                TreeFactory.BalancedSizeN(20),
                TreeFactory.BalancedSizeN(20),
                TreeFactory.BalancedSizeN(20),
                TreeFactory.BalancedSizeN(20),
                TreeFactory.BalancedSizeN(20),
                TreeFactory.BalancedSizeN(20),
                TreeFactory.BalancedSizeN(20),
            };

            // Create our counting functions
            IList<ICountBinaryTreeBoundary> countFunctions = new ICountBinaryTreeBoundary[] {
                new CountUsingLevelOrder(),
                new CountUsingEdgeTraversal(CountOptions.Iterative),
                new CountUsingEdgeTraversal(CountOptions.Recursive)
            };

            // Count using each function and compare output - Fail the test where outputs are not equal
            for(int currentTree = 0; currentTree < trees.Count(); currentTree++)
            {
                var tree = trees[currentTree];
                string[] results = new string[countFunctions.Count];
                for(int current = 0; current < results.Length; current++)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    // Run 100 iterations each so we can get decent time measurements
                    for (int i = 0; i < 1; i++)
                    {
                        results[current] = countFunctions[current].GetOutputSequence(tree).ToCommaString();
                    }
                    Console.WriteLine($"Tree({currentTree}) Function({countFunctions[current]}) ExecutionTime({timer.ElapsedMilliseconds}ms): {results[current]}");
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
