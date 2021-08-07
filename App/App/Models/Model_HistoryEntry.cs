
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Models
{
	public class Model_HistoryEntry
	{
		public string RollName { get; private set; }

		public int FinalResult { get; private set; }

		public ReadOnlyCollection<KeyValuePair<string, int>> IndividualResults { get; private set; }

		public Model_HistoryEntry
		(
			string RollName,
			int FinalResult,
			ReadOnlyCollection<KeyValuePair<string, int>> IndividualResults
		)
		{
			this.RollName = RollName;
			this.FinalResult = FinalResult;
			this.IndividualResults = IndividualResults;
		}
	}
}
