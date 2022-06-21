using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RandomNumberAnalysis;

namespace RandomNumberAnalysisTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(new double[] { 0, 1, 2, 3 }, 1.5)]
		[TestCase(new double[] { 100, 105 }, 102.5)]
		[TestCase(new double[] { 0, 0, 10 }, 3.33)]
		[TestCase(new double[] { 1, 2, 3 }, 2)]
		public void CalculateMeanReturnsTheMeanAverage(double[] numArray, double expected)
		{
			// Arrange
			List<double> numList = numArray.ToList();
			// Act
			double result = NumberAnalysisLibrary.CalculateMean(numList);
			// Assert
			Assert.That(Math.Round(result, 2), Is.EqualTo(Math.Round(expected, 2)));
		}

		[Test]
		public void CalculateMeanThrowsArgumentExceptionForEmptyList()
		{
			// Arrange
			List<double> numList = new List<double>();
			// Act
			// Assert
			Assert.Throws<ArgumentException>(() => NumberAnalysisLibrary.CalculateMean(numList));
		}

		[TestCase(new double[] { 0, 1, 2, 3 }, 1.12)]
		[TestCase(new double[] { 100, 105 }, 2.5)]
		[TestCase(new double[] { 0, 0, 10 }, 4.71)]
		[TestCase(new double[] { 1, 2, 3 }, 0.82)]
		public void CalculateStandardDeviationReturnsTheStandardDeviation(double[] numArray, double expected)
		{
			// Arrange
			List<double> numList = numArray.ToList();
			// Act
			double result = NumberAnalysisLibrary.CalculateStandardDeviation(numList);
			// Assert
			Assert.That(Math.Round(result, 2), Is.EqualTo(Math.Round(expected, 2)));
		}

		[Test]
		public void CalculateStandardDeviationThrowsArgumentExceptionForEmptyList()
		{
			// Arrange
			List<double> numList = new List<double>();
			// Act
			// Assert
			Assert.Throws<ArgumentException>(() => NumberAnalysisLibrary.CalculateStandardDeviation(numList));
		}

		[Test]
		public void CalculateBinFrequenciesHasAFrequencyOfOneForEachBinForEvenlyDistributedData()
		{
			// Arrange
			List<double> numList = new List<double>() { 5, 15, 25, 35, 45, 55, 65, 75, 85 ,95};
			// Act
			List<BinModel> binList = NumberAnalysisLibrary.CalculateBinFrequencies(numList, 0, 100, 10);
			// Assert
			Assert.That(binList.Where(x => x.LowerBound == 0 && x.UpperBound == 10).Select(x => x.Frequency).FirstOrDefault(),Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 10 && x.UpperBound == 20).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 20 && x.UpperBound == 30).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 30 && x.UpperBound == 40).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 40 && x.UpperBound == 50).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 50 && x.UpperBound == 60).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 60 && x.UpperBound == 70).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 70 && x.UpperBound == 80).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 80 && x.UpperBound == 90).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 90 && x.UpperBound == 100).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));

		}

		[Test]
		public void CalculateBinFrequenciesHasCorrectFrequenciesForUnevenlyDistributedData()
		{
			// Arrange
			List<double> numList = new List<double>() { 5, 25, 25, 25, 65, 65, 65, 75, 75, 95 };
			// Act
			List<BinModel> binList = NumberAnalysisLibrary.CalculateBinFrequencies(numList, 0, 100, 10);
			// Assert
			Assert.That(binList.Where(x => x.LowerBound == 0 && x.UpperBound == 10).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));
			Assert.That(binList.Where(x => x.LowerBound == 10 && x.UpperBound == 20).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(0));
			Assert.That(binList.Where(x => x.LowerBound == 20 && x.UpperBound == 30).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(3));
			Assert.That(binList.Where(x => x.LowerBound == 30 && x.UpperBound == 40).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(0));
			Assert.That(binList.Where(x => x.LowerBound == 40 && x.UpperBound == 50).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(0));
			Assert.That(binList.Where(x => x.LowerBound == 50 && x.UpperBound == 60).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(0));
			Assert.That(binList.Where(x => x.LowerBound == 60 && x.UpperBound == 70).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(3));
			Assert.That(binList.Where(x => x.LowerBound == 70 && x.UpperBound == 80).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(2));
			Assert.That(binList.Where(x => x.LowerBound == 80 && x.UpperBound == 90).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(0));
			Assert.That(binList.Where(x => x.LowerBound == 90 && x.UpperBound == 100).Select(x => x.Frequency).FirstOrDefault(), Is.EqualTo(1));

		}
	}
}