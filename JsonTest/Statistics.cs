﻿using Newtonsoft.Json;

using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace Program
{
    public class Statistics:Program
    {

        public static dynamic DescriptiveStatistics(int[] source)
        {

            if(source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if(source.Length == 0)
            {
                Console.WriteLine("Sequence contains no elements");
                throw new InvalidOperationException(nameof(source));
            }

            return 0;
        }

        public static int Maximum(int[] source)
        {
            return source.Max();
        }

        public static int Minimum(int[] source)
        {
            return source.Min();
        }

        public static int Range(int[] source)
        {
            return Maximum(source) - Minimum(source);
        }

        public static double Mean(int[] source)
        {
            return Math.Round((double)Decimal.Divide(source.Sum(), source.Length), 1);
        }

        public static double Median(int[] source)
        {
            int[] sourceSorted = (int[])source.Clone();
            Array.Sort(sourceSorted);
            int size = sourceSorted.Length;
            int mid = size / 2;

            if(size % 2 != 0)
                return sourceSorted[mid];

            dynamic value1 = sourceSorted[mid];
            dynamic value2 = sourceSorted[mid - 1];

            return (value1 + value2) / 2;
        }

        public static double StandardDeviation(int[] source)
        {
            double sum = 0.0;
            int i;
            for(i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }
            double mean = sum / i;
            double varianceSum = 0.0;
            for(int x = 0; x < source.Length; x++)
            {
                varianceSum += Math.Pow(source[x] - mean, 2);
            }
            double variance = varianceSum / (source.Length - 1);
            double standardDev = Math.Pow(variance, 0.5);
            return Math.Round( standardDev, 1);
        }

        public static int[] Mode(int[] source)
        {
            // Check if the array has values        
            if(source == null || source.Length == 0)
                throw new ArgumentException("Array is empty.");

            // Convert the array to a Lookup
            var dictSource = source.ToLookup(x => x);

            // Find the number of modes
            var numberOfModes = dictSource.Max(x => x.Count());

            // Get only the modes
            var modes = dictSource.Where(x => x.Count() == numberOfModes).Select(x => x.Key);

            return modes.Reverse().ToArray();
        }


    }
}