
using System.ComponentModel;

using Newtonsoft.Json;

using App.GUIDs;

namespace App.Models
{
	public class Model_Roll_Part_Dice : INotifyPropertyChanged
	{
		[JsonIgnore] public GUID ID { get; set; }

		private string _Name;
		[JsonProperty("1")] public string Name
		{
			get => _Name;
			set
			{
				if(value == _Name) return;
				_Name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		private int _NumberOfDice;
		[JsonProperty("2")] public int NumberOfDice
		{
			get => _NumberOfDice;
			set
			{
				if(value == _NumberOfDice) return;
				_NumberOfDice = value;
				OnPropertyChanged(nameof(NumberOfDice));
			}
		}

		private int _NumberOfDiceFaces;
		[JsonProperty("3")] public int NumberOfDiceFaces
		{
			get => _NumberOfDiceFaces;
			set
			{
				if(value == _NumberOfDiceFaces) return;
				_NumberOfDiceFaces = value;
				OnPropertyChanged(nameof(NumberOfDiceFaces));
			}
		}

		[JsonConstructor]
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

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName) {
			PropertyChanged?.Invoke(this, new(propertyName)); }
	}
}
