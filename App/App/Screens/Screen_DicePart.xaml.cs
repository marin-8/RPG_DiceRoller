
using System;

using App.GUIDs;
using App.Models;

using Xamarin.Forms;

namespace App.Screens
{
	public partial class Screen_DicePart : ContentPage
	{
		#pragma warning disable IDE0044
		private Model_Roll Origin_Roll;
		#pragma warning restore IDE0044

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

		private Model_Roll_Part_Dice _DicePart = new
		(
			new(0),
			"",
			1,
			20
		);

		public Model_Roll_Part_Dice DicePart
		{
			get => _DicePart;
			set
			{
				if(value == _DicePart) return;
				_DicePart = value;
				OnPropertyChanged(nameof(DicePart));
			}
		}

		public Screen_DicePart(Model_Roll Origin_Roll, Model_Roll_Part_Dice Origin_DicePart)
		{
			InitializeComponent();
			BindingContext = this;

			this.Origin_Roll = Origin_Roll;

			if(Origin_DicePart != null)
			{
				Creating = false;
				DicePart = Origin_DicePart;
			}
			else
			{
				Creating = true;
				DicePart.ID = GUID.New_GUID();
			}
		}

		private async void Add_Clicked(object sender, EventArgs e)
		{
			Origin_Roll.DiceParts.Add(DicePart);

			await Navigation.PopAsync();
		}
	}
}
