
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
	public partial class Screen_BasicRolls : ContentPage
	{
		public Screen_BasicRolls()
		{
			InitializeComponent();
			BindingContext = this;
		}
	}
}
