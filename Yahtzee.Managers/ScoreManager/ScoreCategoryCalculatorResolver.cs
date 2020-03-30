using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;

namespace Yahtzee.Managers.ScoreManager
{
    public class ScoreCategoryCalculatorResolver : IScoreCategoryCalculatorResolver
    {
        private readonly IEnumerable<IScoreCategoryCalculator> _calculators;

        public ScoreCategoryCalculatorResolver(IEnumerable<IScoreCategoryCalculator> calculators)
        {
            _calculators = calculators;
        }

        public IScoreCategoryCalculator Resolve(ScoreCategories scoreCategory)
        {
            var calculator = _calculators.FirstOrDefault(c => c.Type == scoreCategory);
            if (calculator == null)
            {
                throw new ArgumentException($"Score calculator not found for {Enum.GetName(typeof(ScoreCategories), scoreCategory)}");
            }
            return calculator;
        }
    }
}
