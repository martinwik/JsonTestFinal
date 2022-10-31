using System;
using Newtonsoft;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Program
{
    public class Program 
    {
        static void Main(string[] args)
        {
            
            try
            {
                int[] listNummerArray = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(@"data.json"));

                Statistics.DescriptiveStatistics(listNummerArray);

                Console.WriteLine("Maximum: " + Statistics.Maximum(listNummerArray));

                Console.WriteLine("Minimum: " + Statistics.Minimum(listNummerArray));

                Console.WriteLine("Medelvärde: " + Statistics.Mean(listNummerArray));

                Console.WriteLine("Median: " + Statistics.Median(listNummerArray));

                Console.WriteLine("Typevärde: " + string.Join(", ", Statistics.Mode(listNummerArray)));

                Console.WriteLine("Variationsbredd: " + Statistics.Range(listNummerArray));

                Console.WriteLine("Standardavvikelse: " + Statistics.StandardDeviation(listNummerArray));
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("Sequence contains no elements");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.ReadLine();

        }

    }
}
