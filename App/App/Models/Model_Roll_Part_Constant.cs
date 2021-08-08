
using System.ComponentModel;

using App.GUIDs;

namespace App.Models
{
	public class Model_Roll_Part_Constant : INotifyPropertyChanged
	{
		public GUID ID { get; set; }
		
		private string _Name;
		public string Name
		{
			get => _Name;
			set
			{
				if(value == _Name) return;
				_Name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		private bool _Sign;
		public bool Sign
		{
			get => _Sign;
			set
			{
				if(value == _Sign) return;
				_Sign = value;
				OnPropertyChanged(nameof(Sign));
			}
		}

		private int _Value;
		public int Value
		{
			get => _Value;
			set
			{
				if(value == _Value) return;
				_Value = value;
				OnPropertyChanged(nameof(Value));
			}
		}

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

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName) {
			PropertyChanged?.Invoke(this, new(propertyName)); }
	}
}
