
using System.ComponentModel;

using App.GUIDs;

namespace App.Models
{
	public class Model_Roll_Part_Dice : INotifyPropertyChanged
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

		private int _NumberOfDice;
		public int NumberOfDice
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
		public int NumberOfDiceFaces
		{
			get => _NumberOfDiceFaces;
			set
			{
				if(value == _NumberOfDiceFaces) return;
				_NumberOfDiceFaces = value;
				OnPropertyChanged(nameof(NumberOfDiceFaces));
			}
		}

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
