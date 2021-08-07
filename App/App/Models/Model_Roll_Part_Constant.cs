
using App.GUIDs;

namespace App.Models
{
	public class Model_Roll_Part_Constant
	{
		public GUID ID { get; set; }
		public string Name { get; set; }
		public bool Sign { get; set; }
		public int Value { get; set; }

		public Model_Roll_Part_Constant(string Name, bool Sign, int Value)
		{
			ID = GUID.New_GUID();
			this.Name = Name;
			this.Sign = Sign;
			this.Value = Value;
		}

		public Model_Roll_Part_Constant(GUID ID, string Name, bool Sign, int Value)
		{
			this.ID = ID;
			this.Name = Name;
			this.Sign = Sign;
			this.Value = Value;
		}
	}
}
