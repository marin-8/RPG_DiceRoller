
using System;
using System.IO;
using System.Threading.Tasks;

using App.Models;
using Newtonsoft.Json;

namespace App.Logic
{
	public static class Logic_LoadSave
	{
		private static readonly
			string JSON_FILE_NAME =
				Path.Combine(
					Environment.GetFolderPath(
						Environment.SpecialFolder.LocalApplicationData),
					"RollsSave.json");

		public static void Load()
		{
			if(File.Exists(JSON_FILE_NAME))
			{
				string rollsJsonString = File.ReadAllText(JSON_FILE_NAME);

				var rollsArray = JsonConvert.DeserializeObject<Model_Roll[]>(rollsJsonString);

				Global.ClearAndFill_Roles(rollsArray);
			}			
		}

		public static void Save()
		{
			Task.Run(() =>
			{
				lock(Global.Rolls_Lock)
				{
					using StreamWriter file = File.CreateText(JSON_FILE_NAME);
					new JsonSerializer().Serialize(file, Global.Rolls);
				}
			});
		}
	}
}
