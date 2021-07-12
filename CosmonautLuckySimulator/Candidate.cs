using System.Collections.Generic;
using Bogus;

namespace CosmonautLuckySimulator
{
    public class Candidate
    {
        public string Name { get; set; }
        public int Skill { get;  set;}
        public int Luck { get; set;}

        public double Level
        {
            get
            {
             return  Skill * 0.95 + Luck * 0.05;
            }
        }

        public Candidate()
        {}

        public Candidate(string name, int skill, int luck)
        {
            Name = name;
            Skill = skill;
            Luck = luck;
        }

        public override string ToString()
        {
            return $"{Name} with Level: {Level:##.###}";
        }

        public static Candidate GenerateRandomCandidate()
        {
            var canFaker = new Faker<Candidate>()
                .RuleFor(u => u.Name ,(f,u) => f.Random.Word())
                .RuleFor(u => u.Luck, (f, u) => f.Random.Int(0, 100))
                .RuleFor(u => u.Skill, (f, u) => f.Random.Int(0, 100));
            return canFaker.Generate();
        }
        
        public static IEnumerable<Candidate> GenerateRandomCandidates(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                yield return GenerateRandomCandidate();
            }
        }
    }
}