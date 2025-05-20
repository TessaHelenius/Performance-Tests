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
    public class DictionaryTests
    {
        private Dictionary<int, int> baseDictionary;

        [GlobalSetup]
        public void Setup()
        {
            int size = 1000000;
            baseDictionary = new Dictionary<int, int>(size);
            for (int i = 0; i < size; i++)
            {
                baseDictionary.Add(i, i);
            }
        }

        [Benchmark]
        public bool Search()
        {
            return baseDictionary.ContainsKey(baseDictionary.Count - 1);
        }

        [Benchmark]
        public Dictionary<int, int> Add()
        {
            var dict = new Dictionary<int, int>(baseDictionary);
            dict.Add(dict.Count, dict.Count);
            return dict;
        }

        [Benchmark]
        public Dictionary<int, int> DeleteFromStart()
        {
            var dict = new Dictionary<int, int>(baseDictionary);
            dict.Remove(10);
            return dict;
        }

        [Benchmark]
        public Dictionary<int, int> DeleteFromMiddle()
        {
            var dict = new Dictionary<int, int>(baseDictionary);
            dict.Remove(500000);
            return dict;
        }

        [Benchmark]
        public Dictionary<int, int> DeleteFromEnd()
        {
            var dict = new Dictionary<int, int>(baseDictionary);
            dict.Remove(999999);
            return dict;
        }

    }
}
