using System;
using System.Collections.Generic;
using Yahtzee.Core.Entities;
using Yahtzee.Core.Enums;
using Yahtzee.Core.Interfaces;
using Yahtzee.Managers.DiceRollManager;
using Yahtzee.Managers.ScoreManager;
using Yahtzee.Managers.ScoreManager.LowerScoreManager;
using Yahtzee.Managers.ScoreManager.UpperScoreManager;
using Yahtzee.Managers.ScoreManager.UpperScoreManager.ScoreCalculators;
using System.Linq;

namespace Yahtzee.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var diceRollManager = new DiceRollManager(new DieNumberGenerator());
            var diceSet = diceRollManager.RollAll();
            while (Console.ReadLine() != "stop")
            {
                Console.WriteLine($"Current dice: { string.Join(' ', diceSet.Values.Select(v => v.ToString())) }");
                Console.WriteLine("Enter the value of dice to keep: ");
                var diceToKeep = Console.ReadLine().Split(' ').ToList().Select(s => int.Parse(s));
                diceSet = diceRollManager.RollAllButKeep(diceToKeep);
            }
        }
    }
}
