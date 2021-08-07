
using System;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using App.Models;
using App.GUIDs;

using Xamarin.Forms;
using App.Enums;

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
			lock(Global.Roles_Lock)
				Global.Roles.Add(Roll);

			await Navigation.PopAsync();
		}
	}
}
