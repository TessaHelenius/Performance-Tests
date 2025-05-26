using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_Tests
{
    // Benchmarkdotnetin avulla suorituskykymittaus
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class DictionaryTests
    {
        private Dictionary<int, int> baseDictionary;
        // Alustetaan testidata
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
        // Hakee viimeisen arvon sanakirjasta
        [Benchmark]
        public bool Search()
        {
            return baseDictionary.ContainsKey(baseDictionary.Count - 1);
        }
        // Lisää uuden arvon sanakirjaan
        [Benchmark]
        public Dictionary<int, int> Add()
        {
            var dict = new Dictionary<int, int>(baseDictionary);
            dict.Add(dict.Count, dict.Count);
            return dict;
        }
        // Poistaa arvon sanakirjan alusta
        [Benchmark]
        public Dictionary<int, int> DeleteFromStart()
        {
            var dict = new Dictionary<int, int>(baseDictionary);
            dict.Remove(10);
            return dict;
        }
        // Poistaa arvon sanakirjan keskeltä
        [Benchmark]
        public Dictionary<int, int> DeleteFromMiddle()
        {
            var dict = new Dictionary<int, int>(baseDictionary);
            dict.Remove(500000);
            return dict;
        }
        // Poistaa arvon sanakirjan lopusta
        [Benchmark]
        public Dictionary<int, int> DeleteFromEnd()
        {
            var dict = new Dictionary<int, int>(baseDictionary);
            dict.Remove(999999);
            return dict;
        }

    }
}
