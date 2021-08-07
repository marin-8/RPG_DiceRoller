
using System.Collections.ObjectModel;

using App.Models;

namespace App
{
	public static class Global
	{
		public static ObservableCollection<Model_HistoryEntry> History = new();
		public static readonly object History_Lock = new();

		public static ObservableCollection<Model_Roll> Roles = new();
		public static readonly object Roles_Lock = new();
	}
}
