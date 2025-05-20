using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_Tests
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class AgeGroupTests
    {
        private int[] ageData;

        [GlobalSetup]
        public void Setup()
        {
            Random rand = new Random();
            ageData = new int[10000000];

            for (int i = 0; i < ageData.Length; i++)
            {
                double selectionValue = rand.NextDouble();

                if (selectionValue < 0.6)
                    ageData[i] = rand.Next(20, 65);
                else if (selectionValue < 0.75)
                    ageData[i] = rand.Next(13, 20);
                else if (selectionValue < 0.9)
                    ageData[i] = rand.Next(0, 13);
                else
                    ageData[i] = rand.Next(65, 100);
            }
        }

        [Benchmark]
        public void IfAdultFirst()
        {
            foreach (var age in ageData)
            {
                AdultFirstIfElse(age);
            }
        }
        [Benchmark]
        public void IfAdultLast()
        {
            foreach (var age in ageData)
            {
                AdultLastIfElse(age);
            }
        }
        private static string AdultFirstIfElse(int age)
        {
            if (age >= 20 && age <= 64)
                return "Aikuinen";
            else if (age >= 0 && age <= 12)
                return "Lapsi";
            else if (age >= 13 && age <= 19)
                return "Nuori";
            else if (age >= 65)
                return "Seniori";
            else
                return "Tuntematon";
        }
        private static string AdultLastIfElse(int age)
        {
            if (age >= 0 && age <= 12)
                return "Lapsi";
            else if (age >= 13 && age <= 19)
                return "Nuori";
            else if (age >= 65)
                return "Seniori";
            else if (age >= 20 && age <= 64)
                return "Aikuinen";
            else
                return "Tuntematon";
        }
        [Benchmark]
        public void SwitchAdultFirst()
        {
            foreach (var age in ageData)
            {
                MostCommonFirstSwitch(age);
            }
        }

        [Benchmark]
        public void SwitchAdultLast()
        {
            foreach (var age in ageData)
            {
                MostCommonLastSwitch(age);
            }
        }

        public string MostCommonFirstSwitch(int age)
        {
            int group = GetGroup(age);

            switch (group)
            {
                case 2: return "Aikuinen";
                case 0: return "Lapsi";
                case 1: return "Nuori";
                case 3: return "Seniori";
                default: return "Tuntematon";
            }
        }

        public string MostCommonLastSwitch(int age)
        {
            int group = GetGroup(age);

            switch (group)
            {
                case 0: return "Lapsi";
                case 1: return "Nuori";
                case 3: return "Seniori";
                case 2: return "Aikuinen";
                default: return "Tuntematon";
            }
        }

        public int GetGroup(int age)
        {
            if (age >= 0 && age <= 12) return 0;
            else if (age >= 13 && age <= 19) return 1;
            else if (age >= 20 && age <= 64) return 2;
            else if (age >= 65) return 3;
            else return 4;
        }
    }
}
