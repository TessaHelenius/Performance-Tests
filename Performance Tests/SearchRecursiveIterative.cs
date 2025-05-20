using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_Tests
{

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class SearchRecursiveIterative
    {
        private BinarySearchTree bst;
        private int searchValue;

        [GlobalSetup]
        public void Setup()
        {
            bst = new BinarySearchTree();
            var values = Enumerable.Range(0, 200000).OrderBy(_ => Guid.NewGuid()).ToArray();

            foreach (var value in values)
            {
                bst.Insert(value);
            }

            searchValue = 199999;
        }

        [Benchmark(OperationsPerInvoke = 10000)]
        public bool RecursiveSearch()
        {
            bool result = false;
            for (int i = 0; i < 10000; i++)
            {
                result = bst.SearchRecursive(bst.Root, searchValue);
            }
            return result;
        }

        [Benchmark(OperationsPerInvoke = 10000)]
        public bool IterativeSearch()
        {
            bool result = false;
            for (int i = 0; i < 10000; i++)
            {
                result = bst.SearchIterative(searchValue);
            }
            return result;
        }
    }

    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value) => Value = value;
    }

    public class BinarySearchTree
    {
        public Node Root;

        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }

        private Node Insert(Node node, int value)
        {
            if (node == null) return new Node(value);
            if (value < node.Value) node.Left = Insert(node.Left, value);
            else node.Right = Insert(node.Right, value);
            return node;
        }

        public bool SearchRecursive(Node node, int value)
        {
            if (node == null) return false;
            if (node.Value == value) return true;
            return value < node.Value
                ? SearchRecursive(node.Left, value)
                : SearchRecursive(node.Right, value);
        }

        public bool SearchIterative(int value)
        {
            var current = Root;
            while (current != null)
            {
                if (current.Value == value) return true;
                current = value < current.Value ? current.Left : current.Right;
            }
            return false;
        }
    }
}
