using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_Tests
{ // Benchmarkdotnetin avulla suorituskykymittaus
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class EvenNumberTests
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
        // Hakee parillisten lukujen määrän listasta for-silmukalla
        [Benchmark]
        public int CountWithFor()
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
        // Hakee parillisten lukujen määrän listasta foreach-silmukalla
        [Benchmark]
        public int CountWithForeach()
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
        // Hakee parillisten lukujen määrän listasta while-silmukalla
        [Benchmark]
        public int CountWithWhile()
        {
            int count = 0;
            int i = 0;
            while (i < list.Count)
            {
                if (list[i] % 2 == 0)
                {
                    count++;
                }
                i++;
            }
            return count;
        }
        // Hakee parillisten lukujen määrän listasta do-while-silmukalla
        [Benchmark]
        public int CountWithDoWhile()
        {
            int count = 0;
            int i = 0;

            do
            {
                if (list[i] % 2 == 0)
                {
                    count++;
                }
                i++;
            } while (i < list.Count);

            return count;
        }

        // Hakee parillisten lukujen määrän listasta LINQ:n avulla
        [Benchmark]
        public int CountWithLinq()
        {
            return list.Count(x => x % 2 == 0);
        }
    }
}
