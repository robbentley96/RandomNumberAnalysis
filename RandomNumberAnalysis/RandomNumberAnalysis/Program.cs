using System;
using System.Collections.Generic;

namespace RandomNumberAnalysis
{
	class Program
	{
		static void Main(string[] args)
		{
			List<double> numList = NumberAnalysisLibrary.ReadNumbersFromCSV("Semantic Evolution SampleData.csv");
			Console.WriteLine($"Arithmetic Mean: {NumberAnalysisLibrary.CalculateMean(numList)}");
			Console.WriteLine($"Standard Deviation: {NumberAnalysisLibrary.CalculateStandardDeviation(numList)}");
			Console.WriteLine("\n\nFrequency Distribution\n");
			foreach (BinModel bin in NumberAnalysisLibrary.CalculateBinFrequencies(numList, 0, 100, 10))
			{
				Console.WriteLine($"{bin.LowerBound} - {bin.UpperBound}: {bin.Frequency}");
			}
		}
	}
}
