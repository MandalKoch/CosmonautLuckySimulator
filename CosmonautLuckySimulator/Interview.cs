using System.Collections.Generic;
using System.Linq;

namespace CosmonautLuckySimulator
{
    public class Interview
    {
        private readonly IEnumerable<Candidate> mCanditates;
        
        public Interview(IEnumerable<Candidate> canditates)
        {
            mCanditates = canditates.ToList();
        }

        public IEnumerable<Candidate> Get10BestOnes()
        {
            return mCanditates
                .OrderByDescending(c => c.Level)
                .Take(10);
        }

        public IEnumerable<Candidate> Get10BestOnePurelyOnSkill()
        {
            return mCanditates
                .OrderByDescending(c => c.Skill)
                .Take(10);
        }

        public double GetMedianLuckOf10Best()
        {
            var luck = Get10BestOnes().Sum(c => c.Level);
            return luck / 10;
        }
    }
}