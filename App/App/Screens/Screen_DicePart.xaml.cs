
using System;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using App.Models;
using App.GUIDs;

using Xamarin.Forms;

namespace App.Screens
{
	public partial class Screen_DicePart : ContentPage
	{
		private Model_Roll Origin_Roll;
		public bool Creating { get; set; } = true;

		public Model_Roll_Part_Dice Current_DicePart { get; set; } = new
		(
			new(0),
			"",
			1,
			20
		);

		public Screen_DicePart(Model_Roll Origin_Roll, Model_Roll_Part_Dice Origin_DicePart)
		{
			InitializeComponent();
			BindingContext = this;

			this.Origin_Roll = Origin_Roll;

			if(Origin_DicePart != null)
				Current_DicePart = Origin_DicePart;
			else
				Current_DicePart.ID = GUID.New_GUID();
			
			Creating = Origin_DicePart == null;

			Stepper_NumberOfDice.Value = Current_DicePart.NumberOfDice;
			Label_NumberOfDice.Text = Current_DicePart.NumberOfDice.ToString();

			Stepper_NumberOfDiceFaces.Value = Current_DicePart.NumberOfDiceFaces;
			Label_NumberOfDiceFaces.Text = Current_DicePart.NumberOfDiceFaces.ToString();
		}

		private void Stepper_NumberOfDice_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			Current_DicePart.NumberOfDice = (int)Stepper_NumberOfDice.Value;
			Label_NumberOfDice.Text = Current_DicePart.NumberOfDice.ToString();
		}

		private void Stepper_NumberOfDiceFaces_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			Current_DicePart.NumberOfDiceFaces = (int)Stepper_NumberOfDiceFaces.Value;
			Label_NumberOfDiceFaces.Text = Current_DicePart.NumberOfDiceFaces.ToString();
		}

		private async void Add_Clicked(object sender, EventArgs e)
		{
			Origin_Roll.DiceParts.Add(Current_DicePart);

			await Navigation.PopAsync();
		}
	}
}
