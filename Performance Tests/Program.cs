
//#define DATASTRUCTURE_TESTS
//#define LOOP_TESTS
//#define CONDITION_ORDER_TESTS
//#define CONDITIONAL_AND_RECURSION_TESTS



using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using Perfolizer.Horology;

namespace Performance_Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {


#if DATASTRUCTURE_TESTS
                        var config = ManualConfig.Create(DefaultConfig.Instance)
                  .AddJob(Job.Default
                  .WithMinIterationTime(TimeInterval.FromMilliseconds(200))
                  .WithInvocationCount(4096)
                  .WithWarmupCount(5)
                  .WithIterationCount(10));


                        BenchmarkRunner.Run<ArrayTests>(config);
                        BenchmarkRunner.Run<ListTests>(config);
                        BenchmarkRunner.Run<DictionaryTests>(config);


                        //TIETORAKENTEIDEN TESTIKOODIT PERFORMANCE PROFILERIA VARTEN

                        var test = new ArrayTests();
                        //var test = new DictionaryTests();
                        //var test = new ListTests();

                        test.Setup();

                        for (int i = 0; i < 10000; i++)
                        {
                            test.Search();
                            test.Add();
                            test.DeleteFromStart();
                            test.DeleteFromMiddle();
                            test.DeleteFromEnd();

                        }
          
#endif


#if LOOP_TESTS




            var config = ManualConfig.Create(DefaultConfig.Instance)
        .AddJob(Job.Default
        .WithInvocationCount(1024)
        .WithWarmupCount(5)
        .WithIterationCount(15)
        .WithUnrollFactor(1));

            BenchmarkRunner.Run<SumTests>(config);
            BenchmarkRunner.Run<MaxValueTests>(config);
            BenchmarkRunner.Run<EvenNumberTests>(config);

            //SumTests TESTIKOODI PERFORMANCE PROFILERIA VARTEN

            var test = new SumTests();

            test.Setup();

            for (int i = 0; i < 1000; i++)
            {
                test.SumWithFor();
                test.SumWithForeach();
                test.SumWithWhile();
                test.SumWithDoWhile();
                test.SumWithLinq();
            }

            //MaxValueTests TESTIKOODI PERFORMANCE PROFILERIA VARTEN

            //var test = new MaxValueTests();

            //test.Setup();

            //for (int i = 0; i < 1000; i++)
            //{
            //    test.MaxWithFor();
            //    test.MaxWithForeach();
            //    test.MaxWithWhile();
            //    test.MaxWithDoWhile();
            //    test.MaxWithLinq();

            //}

            //EvenNumberTests Performance Profiler koodi

            //var test = new EvenNumberTests();

            //test.Setup();

            //for (int i = 0; i < 1000; i++)
            //{
            //    test.CountWithFor();
            //    test.CountWithForeach();
            //    test.CountWithWhile();
            //    test.CountWithDoWhile();
            //    test.CountWithLinq();

            //}

#endif


#if CONDITION_ORDER_TESTS

            var config = ManualConfig.Create(DefaultConfig.Instance)
           .AddJob(Job.Default
           .WithRuntime(CoreRuntime.Core80)
           .WithWarmupCount(5)
           .WithIterationCount(10)
           .WithInvocationCount(2048)
           .WithUnrollFactor(1));

            //BenchmarkRunner.Run<AgeGroupTests>();
            //BenchmarkRunner.Run<BirthMonthTests>();


            //BirthMonthTests TESTIKOODI PERFORMANCE PROFILERIA VARTEN

            var test = new BirthMonthTests();

            test.Setup();

            for (int i = 0; i < 100; i++)
            {
                test.IfCommonFirst();
                test.IfCommonMiddle();
                test.IfCommonLast();

                test.SwitchCommonFirst();
                test.SwitchCommonMiddle();
                test.SwitchCommonLast();
            }

            //AgeGroupTests TESTIKOODI PERFORMANCE PROFILERIA VARTEN

            //var test = new AgeGroupTests();

            //test.Setup();

            //for (int i = 0; i < 100; i++)
            //{
            //    test.IfAdultFirst();
            //    test.IfAdultLast();

            //    test.SwitchAdultFirst();
            //    test.SwitchAdultLast();

            //}


#endif


#if CONDITIONAL_AND_RECURSION_TESTS



            var config = ManualConfig.Create(DefaultConfig.Instance)
                .AddJob(Job.Default
                    .WithMinIterationTime(TimeInterval.FromMilliseconds(200))         
                    .WithInvocationCount(2048) 
                    .WithWarmupCount(5)
                    .WithIterationCount(10)                                     
                    .WithUnrollFactor(1));



            BenchmarkRunner.Run<GetGradeTests>(config);
            BenchmarkRunner.Run<SearchRecursiveIterative>(config);



            //GetGradeTests TESTIKOODI PERFORMANCE PROFILERIA VARTEN
            //var test = new GetGradeTests();

            // test.Setup();

            // for (int i = 0; i < 1000; i++)
            // {
            //     test.IfElse();
            //     test.SwitchCase();
            //     test.Recursive();
            // }


            //SearchRecursiveIterative TESTIKOODI PERFORMANCE PROFILERIA VARTEN

            //var test = new SearchRecursiveIterative();
            //test.Setup();


            //int recursiveCount = 0;
            //for (int i = 0; i < 10000; i++)
            //{
            //    if (test.RecursiveSearch())
            //        recursiveCount++;
            //}
            


            //int iterativeCount = 0;
            //for (int i = 0; i < 10000; i++)
            //{
            //    if (test.IterativeSearch())
            //        iterativeCount++;
            //}
            
#endif              
              
              
            





        }
    }
}
