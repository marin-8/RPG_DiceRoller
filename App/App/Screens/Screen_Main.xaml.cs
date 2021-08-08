
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
	public partial class Screen_Main : ContentPage
	{
		private Model_HistoryEntry _LastRoll = new
		(
			"Roll name",
			12,
			new(new KeyValuePair<string, int>[]
			{
				new("Dice roll", 7),
				new("Constant", 5),
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

		public Screen_Main()
		{
			InitializeComponent();
			BindingContext = this;

			lock(Global.Roles_Lock)
				RollList.ItemsSource = Global.Roles;
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
					Enum_RollOptions.Edit.ToString(),
					Enum_RollOptions.Delete.ToString()
				);

			if(rollOptionString == "Cancel")
				return;

			var rollOption =
				(Enum_RollOptions) Enum.Parse
				(
					typeof(Enum_RollOptions),
					rollOptionString
				);

			switch(rollOption)
			{
				case Enum_RollOptions.Edit:
				{
					Model_Roll rolTapped;

					lock(Global.Roles_Lock)
						rolTapped =
							Global.Roles
							.Where(r => r.ID.Equals(ID_rolTapped))
							.Single();

					await Navigation.PushAsync(new Screen_Rol(rolTapped));

					break;
				}

				case Enum_RollOptions.Delete:
				{
					if(await DisplayAlert ("Confirm deletion", "Are you sure you want to delete the roll?", "Yes", "No"))
					{
						lock(Global.Roles_Lock)
							Global.Roles
								.Remove(
									Global.Roles
										.Where(r => r.ID.Equals(ID_rolTapped))
										.Single());
					}

					break;
				}
			}	
		}
	}
}
