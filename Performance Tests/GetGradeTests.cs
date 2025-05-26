using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_Tests
{
    // Benchmarkdotnetin avulla suorituskykymittaus
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class GetGradeTests
    {
        private int[] scores;
        // Alustetaan testidata, satunnaisia arvosanoja välillä 0-100
        [GlobalSetup]
        public void Setup()
        {
            Random rand = new Random();
            scores = new int[1000000];
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = rand.Next(0, 101);
            }
        }
        // Benchmark-metodit eri arvosanan saamiseksi
        [Benchmark]
        public void IfElse()
        {
            foreach (var score in scores)
            {
                GetGradeIfElse(score);
            }
        }

        [Benchmark]
        public void SwitchCase()
        {
            foreach (var score in scores)
            {
                GetGradeSwitch(score);
            }
        }

        [Benchmark]
        public void Recursive()
        {
            foreach (var score in scores)
            {
                GetGradeRecursive(score);
            }
        }
        // Arvosanan hakeminen if-else-rakenteella
        public string GetGradeIfElse(int score)
        {
            if (score >= 90) return "A";
            else if (score >= 80) return "B";
            else if (score >= 70) return "C";
            else if (score >= 60) return "D";
            else return "F";
        }
        // Arvosanan hakeminen switch-case-rakenteella
        public string GetGradeSwitch(int score)
        {
            switch (score)
            {
                case >= 90:
                    return "A";
                case >= 80:
                    return "B";
                case >= 70:
                    return "C";
                case >= 60:
                    return "D";
                default:
                    return "F";
            }
        }
        // Arvosanan hakeminen rekursiivisesti
        public string GetGradeRecursive(int score)
        {
            return GetGradeRecursiveHelperMethod(score, 90);
        }

        // Rekursiivinen apumetodi arvosanan hakemiseen
        public string GetGradeRecursiveHelperMethod(int score, int currentLimit)
        {
            if (currentLimit < 60)
                return "F";

            if (score >= currentLimit)
            {
                if (currentLimit == 90)
                    return "A";
                else if (currentLimit == 80)
                    return "B";
                else if (currentLimit == 70)
                    return "C";
                else if (currentLimit == 60)
                    return "D";
                else
                    return "F";
            }

            return GetGradeRecursiveHelperMethod(score, currentLimit - 10);
        }
    }
}
