﻿using System.Windows.Forms;
using Microsoft.Win32;

namespace FindAndReplace.App
{
	public class RegistryData
	{
		public string Dir { get; set; }
		public string FileMask { get; set; }
		public bool IncludeSubDirectories { get; set; }
		public string FindText { get; set; }
		public string ReplaceText { get; set; }
		public bool IsCaseSensitive { get; set; }
		public bool IsRegEx { get; set; }
		public bool IsBinaryFileDetection { get; set; }
		public bool IsIncludeFilesWithoutMatches { get; set; }
		public string ExcludeFileMask { get; set; }


		public void Save()
		{
			SaveValueToRegistry("Dir", Dir);
			SaveValueToRegistry("FileMask", FileMask);
			SaveValueToRegistry("ExcludeFileMask", ExcludeFileMask);
			SaveValueToRegistry("FindText", FindText);
			SaveValueToRegistry("IncludeSubDirectories", IncludeSubDirectories.ToString());
			SaveValueToRegistry("IsCaseSensitive", IsCaseSensitive.ToString());
			SaveValueToRegistry("IsRegEx", IsRegEx.ToString());
			SaveValueToRegistry("IsBinaryFileDetection", IsBinaryFileDetection.ToString());
			SaveValueToRegistry("IsIncludeFilesWithoutMatches", IsIncludeFilesWithoutMatches.ToString());
			SaveValueToRegistry("ReplaceText", ReplaceText);
		}

		public bool IsEmpty()
		{
			//When saved even once dir will have a non null volue
			string dir = GetValueFromRegistry("Dir");
			return dir == null;
		}

		public void Load()
		{
			Dir = GetValueFromRegistry("Dir");
			FileMask = GetValueFromRegistry("Filemask");
			ExcludeFileMask = GetValueFromRegistry("ExcludeFileMask");
			FindText = GetValueFromRegistry("FindText");
			IncludeSubDirectories = GetValueFromRegistry("IncludeSubDirectories") == "True";
			IsCaseSensitive = GetValueFromRegistry("IsCaseSensitive") == "True";
			IsRegEx = GetValueFromRegistry("IsRegEx") == "True";
			IsBinaryFileDetection = GetValueFromRegistry("IsBinaryFileDetection") == "True";
			IsIncludeFilesWithoutMatches = GetValueFromRegistry("IsIncludeFilesWithoutMatches") == "True";
			ReplaceText = GetValueFromRegistry("ReplaceText");
		}


		private void SaveValueToRegistry(string name, string value)
		{
			Application.UserAppDataRegistry.SetValue(name, value, RegistryValueKind.String);
		}

		private string GetValueFromRegistry(string name)
		{
			var value = Application.UserAppDataRegistry.GetValue(name);

			if (value != null)
				return value.ToString();

			return null;
		}
	}

}