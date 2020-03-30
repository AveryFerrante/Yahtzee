using System;
using System.Collections.Generic;
using System.Linq;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;

namespace Yahtzee.Managers.ScoreManager
{
    public class ScoreCategoryValidatorResolver : IScoreCategoryValidatorResolver
    {
        private IEnumerable<IScoreCategoryValidator> _validators;

        public ScoreCategoryValidatorResolver(IEnumerable<IScoreCategoryValidator> validators)
        {
            _validators = validators;
        }

        public IScoreCategoryValidator Resolve(ScoreCategories type)
        {
            var validator = _validators.FirstOrDefault(v => v.Type == type);
            if (validator == null)
            {
                throw new ArgumentException($"No validator found for {Enum.GetName(typeof(ScoreCategories), type)}");
            }
            return validator;
        }
    }
}
