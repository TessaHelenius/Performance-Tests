using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_Tests
{// Benchmarkdotnetin avulla suorituskykymittaus
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
   // [DisassemblyDiagnoser(printSource: true, printInstructionAddresses: true)] // 
    public class MaxValueTests
    {
        private List<int> list;
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
        // Hakee suurimman arvon listasta for-silmukalla
        [Benchmark]
        public int MaxWithFor()
        {
            int max = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > max)
                    max = list[i];
            }
            return max;
        }
        // Hakee suurimman arvon listasta foreach-silmukalla
        [Benchmark]
        public int MaxWithForeach()
        {
            int max = 0;
            foreach (var item in list)
            {
                if (item > max)
                    max = item;
            }
            return max;
        }
        // Hakee suurimman arvon listasta while-silmukalla
        [Benchmark]
        public int MaxWithWhile()
        {
            int max = 0;
            int i = 0;
            while (i < list.Count)
            {
                if (list[i] > max)
                    max = list[i];
                i++;
            }
            return max;
        }
        // Hakee suurimman arvon listasta do-while-silmukalla
        [Benchmark]
        public int MaxWithDoWhile()
        {
            int max = 0;
            int i = 0;
            if (list.Count > 0)
            {
                do
                {
                    if (list[i] > max)
                        max = list[i];
                    i++;
                } while (i < list.Count);
            }
            return max;
        }
        // Hakee suurimman arvon listasta LINQ:n avulla
        [Benchmark]
        public int MaxWithLinq()
        {
            return list.Max();
        }
    }
}
