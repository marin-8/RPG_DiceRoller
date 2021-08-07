
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using App.Models;

namespace App.Logic
{
	public static class Logic_Rolling
	{
		private static readonly Random RNG = new();

		public static Model_HistoryEntry Roll(Model_Roll Roll)
		{
			var rollName = Roll.Name;

			var diceRolls = Generate_DiceRolls(Roll);

			var finalResult = Calculate_FinalResult(Roll, diceRolls);
			var individualResults = Calculate_IndividualResults(Roll, diceRolls);

			return new
			(
				rollName,
				finalResult,
				individualResults
			);
		}

		private static List<int> Generate_DiceRolls(Model_Roll Roll)
		{
			var diceRolls = new List<int>();

			for(int i = 0 ; i < Roll.DiceParts.Count ; i++)
			{
				var sum = 0;

				for(int j = 0 ; j < Roll.DiceParts[i].NumberOfDice ; j++)
					sum += RNG.Next(Roll.DiceParts[i].NumberOfDiceFaces) + 1;

				diceRolls.Add(sum);
			}

			return diceRolls;
		}

		private static int Calculate_FinalResult(Model_Roll rol, List<int> diceRolls)
		{
			return
				diceRolls.Sum()
				+
				rol.ConstantParts.Sum(cp =>
				{
					return
						cp.Sign
							? cp.Value
							: -cp.Value;
				});
		}

		private static ReadOnlyCollection<KeyValuePair<string, int>> Calculate_IndividualResults(Model_Roll rol, List<int> diceRolls)
		{
			var retorno = new List<KeyValuePair<string, int>>();

			for(int i = 0 ; i < rol.DiceParts.Count ; i++)
				retorno.Add(new KeyValuePair<string, int>(rol.DiceParts[i].Name, diceRolls[i]));

			foreach(var constantPart in
				rol.ConstantParts
					.Select(cp => new KeyValuePair<string, int>
					(
						cp.Name,
						cp.Sign
							? cp.Value
							: -cp.Value
					)))
			{
				retorno.Add(constantPart);
			}

			return new(retorno);
		}
	}
}
