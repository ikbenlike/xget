using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;

class wClient
{
	public static void Main(string[] args)
	{
		String[] arguments = Environment.GetCommandLineArgs();
		WebClient webClient = new WebClient();

		if (arguments[1] == "-f") {
			try
			{
				string[] listLinksToDownload = System.IO.File.ReadAllLines(arguments[2]);
				foreach (string linkToDownload in listLinksToDownload)
				{
					try {
						char[] splitChars = { '/' };
						string[] fileDest = linkToDownload.Split (splitChars);
						Console.WriteLine ("File to download:\n" + linkToDownload + "\nDestination:\n" + fileDest.Last());
						webClient.DownloadFile (linkToDownload, fileDest.Last());	
					} catch (IndexOutOfRangeException) {
						Console.WriteLine ("please input a valid link");
					}
				}

			}
			catch (System.IO.FileNotFoundException){
				Console.WriteLine ("please provide a valid path");
			}
		} else {

			try {
				Console.WriteLine ("File to download:\n" + arguments [1] + "\nDestination:\n" + arguments [2]);
				webClient.DownloadFile (arguments [1], arguments [2]);	
			} catch (IndexOutOfRangeException) {
				try {
					char[] splitChars = { '/' };
					string linkToDownload = arguments [1];
					string[] fileDest = linkToDownload.Split (splitChars);
					Console.WriteLine ("File to download:\n" + arguments [1] + "\nDestination:\n" + fileDest.Last ());
					webClient.DownloadFile (arguments [1], fileDest.Last ());
				} catch (IndexOutOfRangeException) {
					Console.WriteLine ("please input a valid URL and destination");
					throw;
				}
			}
		}
	}
}