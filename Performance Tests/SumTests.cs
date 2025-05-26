using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_Tests
{//Benchmarkdotnetin avulla suorituskykymittaus
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class SumTests
    {
        private List<int> list;
        private long sumResult;
        // Alustetaan testidata
        [GlobalSetup]
        public void Setup()
        {
            int size = 3000000;
            list = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }
        }
        // Laskee listan kaikki arvot yhteen for-silmukalla
        [Benchmark]
        public long SumWithFor()
        {
            long sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }
        // Laskee listan kaikki arvot yhteen foreach-silmukalla
        [Benchmark]
        public long SumWithForeach()
        {
            long sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;
        }
        // Laskee listan kaikki arvot yhteen while-silmukalla
        [Benchmark]
        public long SumWithWhile()
        {
            long sum = 0;
            int i = 0;
            while (i < list.Count)
            {
                sum += list[i];
                i++;
            }
            return sum;
        }
        // Laskee listan kaikki arvot yhteen do-while-silmukalla
        [Benchmark]
        public long SumWithDoWhile()
        {
            long sum = 0;
            int i = 0;
            if (list.Count > 0)
            {
                do
                {
                    sum += list[i];
                    i++;
                } while (i < list.Count);
            }
            return sum;
        }
        // Laskee listan kaikki arvot yhteen LINQ:n avulla
        [Benchmark]
        public long SumWithLinq()
        {
            sumResult = list.Sum(x => (long)x);
            return sumResult;

        }
    }
}
