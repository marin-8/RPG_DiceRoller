
using System.ComponentModel;
using System.Collections.ObjectModel;

using App.GUIDs;

namespace App.Models
{
	public class Model_Roll : INotifyPropertyChanged
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
		public ObservableCollection<Model_Roll_Part_Dice> DiceParts { get; set; }
		public ObservableCollection<Model_Roll_Part_Constant> ConstantParts { get; set; }

		public Model_Roll(string Name, ObservableCollection<Model_Roll_Part_Dice> DiceParts, ObservableCollection<Model_Roll_Part_Constant> ConstantParts)
		{
			ID = GUID.New_GUID();
			this.Name = Name;
			this.DiceParts = DiceParts;
			this.ConstantParts = ConstantParts;
		}

		public Model_Roll(GUID ID, string Name, ObservableCollection<Model_Roll_Part_Dice> DiceParts, ObservableCollection<Model_Roll_Part_Constant> ConstantParts)
		{
			this.ID = ID;
			this.Name = Name;
			this.DiceParts = DiceParts;
			this.ConstantParts = ConstantParts;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName) {
			PropertyChanged?.Invoke(this, new(propertyName)); }
	}
}
