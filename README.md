# Performance Tests

This repository contains the performance testing code used in the thesis titled  
*"Tietorakenteiden ja ohjelmointirakenteiden suorituskykyanalyysi C#-kielessä"*  
by Tessa Helenius (2025).

## Purpose

The purpose of this project is to compare the execution performance of commonly used data structures and programming structures in the C# language. This includes:

- Arrays, Lists, and Dictionaries
- Loops (`for`, `foreach`, `while`, `do-while`)
- Conditional statements (`if-else`, `switch-case`)
- Recursion
- LINQ operations

Tests were conducted using:
- [BenchmarkDotNet](https://benchmarkdotnet.org/)
- Visual Studio Performance Profiler

## Structure

- `Performance Tests/`: Contains all benchmark test classes categorized by structure or feature.
- `Performance Tests.sln`: Visual Studio solution file to open the project.

## Running the Benchmarks

To run the benchmarks:

1. Open Performance Tests.sln in Visual Studio.
2. In Program.cs, uncomment the #define line for the test category you want to run (e.g. #define DATASTRUCTURE_TESTS).
3. Run the project in **Release** mode.
4. Results will be printed in the console and saved as BenchmarkDotNet result files.

**Note:** Only one test group can be run at a time. The test group is selected by uncommenting its corresponding #define line at the top of Program.cs.

For accurate results:
- Close unnecessary applications.
- Ensure the system remains idle during test execution.

## License

This project is licensed under the MIT License. See `LICENSE.txt` for details.
