using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RandomNumberAnalysis
{
    public static class NumberAnalysisLibrary
    {
        public static List<double> ReadNumbersFromCSV(string csvName)
        {
			Console.WriteLine($"Processing numbers from \"{csvName}\"");
            List<double> numList = new List<double>();
            using (var reader = new StreamReader($"../../../{csvName}"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var numbers = line.Split(',');
                    foreach (string num in numbers)
                    {
                        bool isANumber = double.TryParse(num, out double numAsDouble);
                        if (isANumber)
                        {
                            numList.Add(numAsDouble);
                        }
                    }
                }
            }
            return numList;
        }

        public static double CalculateMean(List<double> numList)
        {
            if (numList.Count == 0) return 0;
            double total = 0;
            foreach (double num in numList)
            {
                total += num;
            }
            return total / numList.Count;
        }

        public static double CalculateStandardDeviation(List<double> numList)
        {
            double mean = CalculateMean(numList);
            List<double> squaredMeanDifferences = new List<double>();
            foreach (double num in numList)
            {
                squaredMeanDifferences.Add(Math.Pow((num - mean), 2));
            }
            double averageSquaredMeanDifference = CalculateMean(squaredMeanDifferences);
            return Math.Pow(averageSquaredMeanDifference, 0.5);
        }

        public static List<BinModel> CalculateBinFrequencies(List<double> numList, int minimum,int maximum, int binSize)
        {
            List<BinModel> binList = new List<BinModel>();
            for (int i = minimum; i < maximum; i += binSize)
            {
                binList.Add(new BinModel() { LowerBound = i, UpperBound = i + binSize, Frequency = 0 });
            }
            foreach (double num in numList)
            {
                BinModel selectedBin = binList.Where(x => x.UpperBound > num && x.LowerBound <= num).FirstOrDefault();
                if (selectedBin != null) { selectedBin.Frequency++; }
            }
            return binList;
        }
    }
}
