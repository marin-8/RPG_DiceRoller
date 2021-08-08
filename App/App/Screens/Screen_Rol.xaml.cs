
using System;
using System.Linq;

using App.Enums;
using App.GUIDs;
using App.Models;

using Xamarin.Forms;

namespace App.Screens
{
	public partial class Screen_Rol : ContentPage
	{
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

		private Model_Roll _Roll = new
		(
			new(0),
			"",
			new(),
			new()
		);
		public Model_Roll Roll
		{
			get => _Roll;
			set
			{
				if(value == _Roll) return;
				_Roll = value;
				OnPropertyChanged(nameof(Roll));
			}
		}

		public Screen_Rol(Model_Roll Origin_Roll)
		{
			InitializeComponent();
			BindingContext = this;

			if(Origin_Roll != null)
			{
				Creating = false;
				Roll = Origin_Roll;
			}
			else
			{
				Creating = true;
				Roll.ID = GUID.New_GUID();
			}
		}

		private async void NewPart_Clicked(object sender, EventArgs e)
		{
			var partTypeString =
				await DisplayActionSheet
				(
					"Add", "Cancel", null,
					Enum_RollPartTypes.Dice.ToString(),
					Enum_RollPartTypes.Constant.ToString()
				);

			if(partTypeString == null || partTypeString == "Cancel")
				return;

			var partType =
				(Enum_RollPartTypes) Enum.Parse
				(
					typeof(Enum_RollPartTypes),
					partTypeString
				);

			if(partType == Enum_RollPartTypes.Dice)
				await Navigation.PushAsync(new Screen_DicePart(Roll, null));
			else if(partType == Enum_RollPartTypes.Constant)
				await Navigation.PushAsync(new Screen_ConstantPart(Roll, null));
		}

		private async void Add_Clicked(object sender, EventArgs e)
		{
			if(Roll.DiceParts.Count > 0 || Roll.ConstantParts.Count > 0)
			{
				lock(Global.Roles_Lock)
					Global.Roles.Add(Roll);

				await Navigation.PopAsync();
			}
			else
			{
				await DisplayAlert ("Warning", "Rolls must have at least one part", "OK");
			}
		}

		private async void DicePartOptions_Clicked(object sender, EventArgs e)
		{
			var ID_dicePartTapped = (GUID)((Button)sender).BindingContext;

			var dicePartOptionString =
				await DisplayActionSheet
				(
					"Dice part options", "Cancel", null,
					Enum_ItemOptions.Edit.ToString(),
					Enum_ItemOptions.Delete.ToString()
				);

			if(dicePartOptionString == null || dicePartOptionString == "Cancel")
				return;

			var dicePartOption =
				(Enum_ItemOptions) Enum.Parse
				(
					typeof(Enum_ItemOptions),
					dicePartOptionString
				);

			switch(dicePartOption)
			{
				case Enum_ItemOptions.Edit:
				{
					Model_Roll_Part_Dice dicePartTapped =
						Roll.DiceParts
						.Single(r => r.ID.Equals(ID_dicePartTapped));

					await Navigation.PushAsync(new Screen_DicePart(Roll, dicePartTapped));

					break;
				}

				case Enum_ItemOptions.Delete:
				{
					if(await DisplayAlert ("Confirm deletion", "Are you sure you want to delete the dice part?", "Yes", "No"))
					{
						Roll.DiceParts
							.Remove(
								Roll.DiceParts
									.Single(r => r.ID.Equals(ID_dicePartTapped)));
					}

					break;
				}
			}
		}

		private async void ConstantPartOptions_Clicked(object sender, EventArgs e)
		{
			var ID_constantPartTapped = (GUID)((Button)sender).BindingContext;

			var constantPartOptionString =
				await DisplayActionSheet
				(
					"Constant part options", "Cancel", null,
					Enum_ItemOptions.Edit.ToString(),
					Enum_ItemOptions.Delete.ToString()
				);

			if(constantPartOptionString == null || constantPartOptionString == "Cancel")
				return;

			var constantPartOption =
				(Enum_ItemOptions) Enum.Parse
				(
					typeof(Enum_ItemOptions),
					constantPartOptionString
				);

			switch(constantPartOption)
			{
				case Enum_ItemOptions.Edit:
				{
					Model_Roll_Part_Constant constantPartTapped =
						Roll.ConstantParts
						.Single(r => r.ID.Equals(ID_constantPartTapped));

					await Navigation.PushAsync(new Screen_ConstantPart(Roll, constantPartTapped));

					break;
				}

				case Enum_ItemOptions.Delete:
				{
					if(await DisplayAlert ("Confirm deletion", "Are you sure you want to delete the constant part?", "Yes", "No"))
					{
						Roll.ConstantParts
							.Remove(
								Roll.ConstantParts
									.Single(r => r.ID.Equals(ID_constantPartTapped)));
					}

					break;
				}
			}
		}
	}
}
