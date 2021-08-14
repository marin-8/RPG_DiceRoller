
using System;

using App.GUIDs;
using App.Logic;
using App.Models;

using Xamarin.Forms;

namespace App.Screens
{
	public partial class Screen_ConstantPart : ContentPage
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

		private Model_Roll_Part_Constant _ConstantPart = new
		(
			"",
			true,
			2
		);

		public Model_Roll_Part_Constant ConstantPart
		{
			get => _ConstantPart;
			set
			{
				if(value == _ConstantPart) return;
				_ConstantPart = value;
				OnPropertyChanged(nameof(ConstantPart));
			}
		}

		public Screen_ConstantPart(Model_Roll Origin_Roll, Model_Roll_Part_Constant Origin_ConstantPart)
		{
			InitializeComponent();
			BindingContext = this;

			this.Origin_Roll = Origin_Roll;

			if(Origin_ConstantPart != null)
			{
				Creating = false;
				ConstantPart = Origin_ConstantPart;
			}
			else
			{
				Creating = true;
				ConstantPart.ID = GUID.New_GUID();
			}
		}

		protected override void OnDisappearing()
		{
			Logic_LoadSave.Save();

			base.OnDisappearing();
		}

		private async void Add_Clicked(object sender, EventArgs e)
		{
			Origin_Roll.ConstantParts.Add(ConstantPart);

			await Navigation.PopAsync();
		}
	}
}
