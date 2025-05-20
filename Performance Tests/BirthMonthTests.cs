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
    public class BirthMonthTests
    {
        private int[] monthData;

        [GlobalSetup]
        public void Setup()
        {
            Random rand = new Random();
            monthData = new int[10000000];

            for (int i = 0; i < monthData.Length; i++)
            {
                double selection = rand.NextDouble();

                if (selection < 0.60)
                    monthData[i] = 6;
                else
                    monthData[i] = rand.Next(1, 13);
            }
        }

        [Benchmark]
        public void IfCommonFirst()
        {
            foreach (var month in monthData)
            {
                GetMonthName_CommonFirst(month);
            }
        }

        [Benchmark]
        public void IfCommonMiddle()
        {
            foreach (var month in monthData)
            {
                GetMonthName_CommonMiddle(month);
            }
        }

        [Benchmark]
        public void IfCommonLast()
        {
            foreach (var month in monthData)
            {
                GetMonthName_CommonLast(month);
            }
        }

        [Benchmark]
        public void SwitchCommonFirst()
        {
            foreach (var month in monthData)
            {
                GetMonthName_SwitchFirst(month);
            }
        }

        [Benchmark]
        public void SwitchCommonMiddle()
        {
            foreach (var month in monthData)
            {
                GetMonthName_SwitchMiddle(month);
            }
        }

        [Benchmark]
        public void SwitchCommonLast()
        {
            foreach (var month in monthData)
            {
                GetMonthName_SwitchLast(month);
            }
        }

        private string GetMonthName_CommonFirst(int month)
        {
            if (month == 6) return "Kesäkuu";
            else if (month == 1) return "Tammikuu";
            else if (month == 2) return "Helmikuu";
            else if (month == 3) return "Maaliskuu";
            else if (month == 4) return "Huhtikuu";
            else if (month == 5) return "Toukokuu";
            else if (month == 7) return "Heinäkuu";
            else if (month == 8) return "Elokuu";
            else if (month == 9) return "Syyskuu";
            else if (month == 10) return "Lokakuu";
            else if (month == 11) return "Marraskuu";
            else if (month == 12) return "Joulukuu";
            else return "Tuntematon";
        }

        private string GetMonthName_CommonMiddle(int month)
        {
            if (month == 1) return "Tammikuu";
            else if (month == 2) return "Helmikuu";
            else if (month == 3) return "Maaliskuu";
            else if (month == 4) return "Huhtikuu";
            else if (month == 5) return "Toukokuu";
            else if (month == 6) return "Kesäkuu";
            else if (month == 7) return "Heinäkuu";
            else if (month == 8) return "Elokuu";
            else if (month == 9) return "Syyskuu";
            else if (month == 10) return "Lokakuu";
            else if (month == 11) return "Marraskuu";
            else if (month == 12) return "Joulukuu";
            else return "Tuntematon";
        }

        private string GetMonthName_CommonLast(int month)
        {
            if (month == 1) return "Tammikuu";
            else if (month == 2) return "Helmikuu";
            else if (month == 3) return "Maaliskuu";
            else if (month == 4) return "Huhtikuu";
            else if (month == 5) return "Toukokuu";
            else if (month == 7) return "Heinäkuu";
            else if (month == 8) return "Elokuu";
            else if (month == 9) return "Syyskuu";
            else if (month == 10) return "Lokakuu";
            else if (month == 11) return "Marraskuu";
            else if (month == 12) return "Joulukuu";
            else if (month == 6) return "Kesäkuu";
            else return "Tuntematon";
        }

        private string GetMonthName_SwitchFirst(int month)
        {
            switch (month)
            {
                case 6: return "Kesäkuu";
                case 1: return "Tammikuu";
                case 2: return "Helmikuu";
                case 3: return "Maaliskuu";
                case 4: return "Huhtikuu";
                case 5: return "Toukokuu";
                case 7: return "Heinäkuu";
                case 8: return "Elokuu";
                case 9: return "Syyskuu";
                case 10: return "Lokakuu";
                case 11: return "Marraskuu";
                case 12: return "Joulukuu";
                default: return "Tuntematon";
            }
        }

        private string GetMonthName_SwitchMiddle(int month)
        {
            switch (month)
            {
                case 1: return "Tammikuu";
                case 2: return "Helmikuu";
                case 3: return "Maaliskuu";
                case 4: return "Huhtikuu";
                case 5: return "Toukokuu";
                case 6: return "Kesäkuu";
                case 7: return "Heinäkuu";
                case 8: return "Elokuu";
                case 9: return "Syyskuu";
                case 10: return "Lokakuu";
                case 11: return "Marraskuu";
                case 12: return "Joulukuu";
                default: return "Tuntematon";
            }
        }

        private string GetMonthName_SwitchLast(int month)
        {
            switch (month)
            {
                case 1: return "Tammikuu";
                case 2: return "Helmikuu";
                case 3: return "Maaliskuu";
                case 4: return "Huhtikuu";
                case 5: return "Toukokuu";
                case 7: return "Heinäkuu";
                case 8: return "Elokuu";
                case 9: return "Syyskuu";
                case 10: return "Lokakuu";
                case 11: return "Marraskuu";
                case 12: return "Joulukuu";
                case 6: return "Kesäkuu";
                default: return "Tuntematon";
            }
        }
    }
}
