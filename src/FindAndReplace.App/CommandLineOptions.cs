﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace FindAndReplace.App
{
	public class CommandLineOptions : CommandLineOptionsBase
	{
		#region Standard Option Attribute
		[Option(null, "find", Required = true, HelpText = "Text to find.")]
		public string FindText = String.Empty;

		[Option(null, "replace", HelpText = "Replacement text.")]
		public string ReplaceText = String.Empty;

		[Option(null, "dir", Required = true, HelpText = "Directory.")]
		public string Dir = String.Empty;

		[Option(null, "fileMask", Required = true,HelpText = "File mask.")]
		public string FileMask = String.Empty;

		[Option(null, "caseSensitive", HelpText = "Is Case Sensitive.")]
		public bool IsCaseSensitive = false;

		[Option(null, "includeSubDir", HelpText = "Include SubDirectories.")]
		public bool IncludeSubDirectories = false;

		[Option(null, "cl", HelpText = "Include SubDirectories.")]
		public bool IsConsole = false; //for merge WinForms and console only

		#endregion

		#region Specialized Option Attribute

		[HelpOption("h", "help", HelpText = "Dispaly this help screen.")]
		public string GetUsage()
		{
			var help = new HelpText("Find And Replace");
			help.AdditionalNewLineAfterOption = true;
			help.Copyright = new CopyrightInfo("Entech Solutions", 2011);
			this.HandleParsingErrorsInHelp(help);
			help.AddPreOptionsLine("This is free software. You may redistribute copies of it under the terms of");
			help.AddPreOptionsLine("the MIT License <http://www.opensource.org/licenses/mit-license.php>.");
			help.AddPreOptionsLine("Usage: \n\nFindAndReplace.Console.exe --find \"Text To Find\" --replace \"Text To Replace\"  --dir \"Directory Path\" --fileMask \"*.*\"\n");
			help.AddPreOptionsLine("FindAndReplace.Console.exe --find \"Text To Find\" --dir \"Directory Path\" --fileMask \"*.*\"");
			help.AddPreOptionsLine("FindAndReplace.Console.exe --find \"Text To Find\" --dir \"Directory Path\" --fileMask \"*.*\" --caseSensitive");
			help.AddOptions(this);

			return help;
		}

		private void HandleParsingErrorsInHelp(HelpText help)
		{
			string errors = help.RenderParsingErrorsText(this);
			if (!string.IsNullOrEmpty(errors))
			{
				help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR: ", errors, Environment.NewLine));
			}
		}

		#endregion
	}
}