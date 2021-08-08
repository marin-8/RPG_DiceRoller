
using System;

using App.GUIDs;
using App.Models;

using Xamarin.Forms;

namespace App.Screens
{
	public partial class Screen_ConstantPart : ContentPage
	{
		private Model_Roll Origin_Roll;

		private bool _Creating = true;
		public bool Creating
		{
			get => _Creating;
			set
			{
				if(value == _Creating) return;
				_Creating = value;
				OnPropertyChanged(nameof(Creating));
			}
		}

		public Model_Roll_Part_Constant ConstantPart { get; set; } = new
		(
			"",
			true,
			2
		);

		public Screen_ConstantPart(Model_Roll Origin_Roll, Model_Roll_Part_Constant Origin_ConstantPart)
		{
			InitializeComponent();
			BindingContext = this;

			this.Origin_Roll = Origin_Roll;

			if(Origin_ConstantPart != null)
				ConstantPart = Origin_ConstantPart;
			else
				ConstantPart.ID = GUID.New_GUID();
			
			Creating = Origin_ConstantPart == null;
		}

		private async void Add_Clicked(object sender, EventArgs e)
		{
			Origin_Roll.ConstantParts.Add(ConstantPart);

			await Navigation.PopAsync();
		}
	}
}
