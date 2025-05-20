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
    public class ListTests
    {
        private List<int> baseList;

        [GlobalSetup]
        public void Setup()
        {
            int size = 1000000;
            baseList = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                baseList.Add(i);
            }
        }

        [Benchmark]
        public bool Search()
        {
            return baseList.Contains(baseList.Count - 1);
        }

        [Benchmark]
        public void Add()
        {
            var list = new List<int>(baseList);
            list.Add(list.Count);
        }

        [Benchmark]
        public void DeleteFromStart()
        {
            var list = new List<int>(baseList);
            list.RemoveAt(0);
        }

        [Benchmark]
        public void DeleteFromMiddle()
        {
            var list = new List<int>(baseList);
            list.RemoveAt(list.Count / 2);
        }

        [Benchmark]
        public void DeleteFromEnd()
        {
            var list = new List<int>(baseList);
            list.RemoveAt(list.Count - 1);
        }
    }
}
