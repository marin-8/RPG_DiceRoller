
using System.Collections.ObjectModel;

using App.Models;

namespace App
{
	public static class Global
	{
		public static ObservableCollection<Model_HistoryEntry> History = new();
		public static readonly object History_Lock = new();

		public static ObservableCollection<Model_Roll> Rolls = new();
		public static readonly object Rolls_Lock = new();

		public static void ClearAndFill_Roles(Model_Roll[] NewRolls)
		{
			lock(Rolls_Lock)
			{
				Rolls.Clear();

				foreach(var newRoll in NewRolls)
					Rolls.Add(newRoll);
			}
		}
	}
}
