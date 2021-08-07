
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
	public partial class Screen_ConstantPart : ContentPage
	{
		private Model_Roll Origin_Roll;
		public bool Creating { get; set; } = true;

		public Model_Roll_Part_Constant Current_ConstantPart { get; set; } = new
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
				Current_ConstantPart = Origin_ConstantPart;
			else
				Current_ConstantPart.ID = GUID.New_GUID();
			
			Creating = Origin_ConstantPart == null;
		}

		private void Switch_Toggled(object sender, ToggledEventArgs e)
		{
			Console.WriteLine(Current_ConstantPart.Sign);
		}

		private async void Add_Clicked(object sender, EventArgs e)
		{
			Origin_Roll.ConstantParts.Add(Current_ConstantPart);

			await Navigation.PopAsync();
		}
	}
}
