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
    public class ArrayTests
    {

        private int[] baseArray;
        // Alustetaan testitaulukko
        [GlobalSetup]
        public void Setup()
        {
            int size = 1000000;
            baseArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                baseArray[i] = i;
            }
        }
        // Hakee viimeisen arvon taulukosta
        [Benchmark]
        public int Search()
        {
            return Array.IndexOf(baseArray, baseArray.Length - 1);
        }
        //Lisää uuden arvon taulukon loppuun
        [Benchmark]
        public int[] Add()
        {
            int[] newArray = new int[baseArray.Length + 1];
            Array.Copy(baseArray, newArray, baseArray.Length);
            newArray[baseArray.Length] = baseArray.Length;
            return newArray;
        }
        // Poistaa arvon taulukon alusta
        [Benchmark]
        public int[] DeleteFromStart()
        {
            int[] newArray = new int[baseArray.Length - 1];
            Array.Copy(baseArray, 1, newArray, 0, newArray.Length);
            return newArray;
        }
        // Poistaa arvon taulukon keskeltä
        [Benchmark]
        public int[] DeleteFromMiddle()
        {
            int deleteIndex = baseArray.Length / 2;
            int[] newArray = new int[baseArray.Length - 1];
            Array.Copy(baseArray, 0, newArray, 0, deleteIndex);
            Array.Copy(baseArray, deleteIndex + 1, newArray, deleteIndex, baseArray.Length - deleteIndex - 1);
            return newArray;
        }
        // Poistaa arvon taulukon lopusta
        [Benchmark]
        public int[] DeleteFromEnd()
        {
            int[] newArray = new int[baseArray.Length - 1];
            Array.Copy(baseArray, 0, newArray, 0, newArray.Length);
            return newArray;
        }



    }
}
