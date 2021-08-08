
using System;

using App.GUIDs;
using App.Models;

using Xamarin.Forms;

namespace App.Screens
{
	public partial class Screen_DicePart : ContentPage
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

		public Model_Roll_Part_Dice _DicePart = new
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
				DicePart = Origin_DicePart;
			else
				DicePart.ID = GUID.New_GUID();
			
			Creating = Origin_DicePart == null;

			Stepper_NumberOfDice.Value = DicePart.NumberOfDice;
			Label_NumberOfDice.Text = DicePart.NumberOfDice.ToString();

			Stepper_NumberOfDiceFaces.Value = DicePart.NumberOfDiceFaces;
			Label_NumberOfDiceFaces.Text = DicePart.NumberOfDiceFaces.ToString();
		}

		private void Stepper_NumberOfDice_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			DicePart.NumberOfDice = (int)Stepper_NumberOfDice.Value;
			Label_NumberOfDice.Text = DicePart.NumberOfDice.ToString();
		}

		private void Stepper_NumberOfDiceFaces_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			DicePart.NumberOfDiceFaces = (int)Stepper_NumberOfDiceFaces.Value;
			Label_NumberOfDiceFaces.Text = DicePart.NumberOfDiceFaces.ToString();
		}

		private async void Add_Clicked(object sender, EventArgs e)
		{
			Origin_Roll.DiceParts.Add(DicePart);

			await Navigation.PopAsync();
		}
	}
}
