using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmonautLuckySimulator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IList<Task> tasks = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                int id = i;
                var task = new Task(() =>PrintInterviewLuckMedian(id)) ;
                task.Start();
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Finished");
        }

        private static void PrintInterviewLuckMedian(int id)
        {
            var interview = new Interview(Candidate.GenerateRandomCandidates(1000));
            Console.WriteLine($"Run number:{id}\tMedian Luck: {interview.GetMedianLuckOf10Best():F2}");
        }
    }
}