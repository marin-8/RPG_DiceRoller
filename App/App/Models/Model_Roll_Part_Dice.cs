
using App.GUIDs;

namespace App.Models
{
	public class Model_Roll_Part_Dice
	{
		public GUID ID { get; set; }
		public string Name { get; set; }
		public int NumberOfDice { get; set; }
		public int NumberOfDiceFaces { get; set; }

		public Model_Roll_Part_Dice(string Name, int NumberOfDice, int NumberOfDiceFaces)
		{
			ID = GUID.New_GUID();
			this.Name = Name;
			this.NumberOfDice = NumberOfDice;
			this.NumberOfDiceFaces = NumberOfDiceFaces;
		}

		public Model_Roll_Part_Dice(GUID ID, string Name, int NumberOfDice, int NumberOfDiceFaces)
		{
			this.ID = ID;
			this.Name = Name;
			this.NumberOfDice = NumberOfDice;
			this.NumberOfDiceFaces = NumberOfDiceFaces;
		}
	}
}
