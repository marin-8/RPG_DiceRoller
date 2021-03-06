
using System;
using System.Linq;
using System.Collections.Generic;

using App.Enums;
using App.GUIDs;
using App.Logic;
using App.Models;

using Xamarin.Forms;

namespace App.Screens
{
	public partial class Screen_CustomRolls : ContentPage
	{
		private Model_HistoryEntry _LastRoll = new
		(
			"Last roll's name",
			12,
			new(new KeyValuePair<string, int>[]
			{
				new("Dice part", 7),
				new("Constant part", 5),
			})			
		);

		public Model_HistoryEntry LastRoll
		{
			get => _LastRoll;
			set
			{
				if(value == _LastRoll) return;
				_LastRoll = value;
				OnPropertyChanged(nameof(LastRoll));
			}
		}

		public Screen_CustomRolls()
		{
			InitializeComponent();
			BindingContext = this;

			lock(Global.Rolls_Lock)
				RollList.ItemsSource = Global.Rolls;
		}

		private async void NewRoll_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Screen_Rol(null));
		}

		private void RollList_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var rolTapped = (Model_Roll)e.Item;

			LastRoll = Logic_Rolling.Roll(rolTapped);
		}

		private async void RollOptions_Clicked(object sender, EventArgs e)
		{
			var ID_rolTapped = (GUID)((Button)sender).BindingContext;

			var rollOptionString =
				await DisplayActionSheet
				(
					"Roll options", "Cancel", null,
					Enum_ItemOptions.Edit.ToString(),
					Enum_ItemOptions.Delete.ToString()
				);

			if(rollOptionString == null || rollOptionString == "Cancel")
				return;

			var rollOption =
				(Enum_ItemOptions) Enum.Parse
				(
					typeof(Enum_ItemOptions),
					rollOptionString
				);

			switch(rollOption)
			{
				case Enum_ItemOptions.Edit:
				{
					Model_Roll rolTapped;

					lock(Global.Rolls_Lock)
						rolTapped =
							Global.Rolls
							.Single(r => r.ID.Equals(ID_rolTapped));

					await Navigation.PushAsync(new Screen_Rol(rolTapped));

					break;
				}

				case Enum_ItemOptions.Delete:
				{
					if(await DisplayAlert ("Confirm deletion", "Are you sure you want to delete the roll?", "Yes", "No"))
					{
						lock(Global.Rolls_Lock)
							Global.Rolls
								.Remove(
									Global.Rolls
										.Single(r => r.ID.Equals(ID_rolTapped)));
					}

					break;
				}
			}	
		}
	}
}
